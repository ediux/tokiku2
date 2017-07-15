using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    /// <summary>
    /// 聯絡人商業邏輯層控制器
    /// </summary>
    public class ContactPersonManageController : BaseController<Contacts>
    {
        private IContactsRepository repo;
        private IAccessLogRepository accesslogrepo;

        public ContactPersonManageController()
        {
            repo = this.GetReoisitory() as IContactsRepository;
            accesslogrepo = this.GetReoisitory<AccessLog>() as IAccessLogRepository;
        }

        public ExecuteResultEntity<ICollection<Contacts>> QueryAll()
        {
            try
            {
                var result = from p in repo.All()
                             where p.Void == false
                             orderby p.IsDefault ascending
                             select p;

                ExecuteResultEntity<ICollection<Contacts>> rtn = ExecuteResultEntity<ICollection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));
                return rtn;

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Contacts>>.CreateErrorResultEntity(ex);
            }
        }


        public ExecuteResultEntity<ICollection<Contacts>> SearchByText(string filiter, Guid ManufactoryId, bool isClient)
        {
            try
            {
                if (filiter != null && filiter.Length > 0)
                {
                    var result = (from p in repo.All()
                                  from q in p.Manufacturers
                                  where (p.Void == false && q.Id == ManufactoryId
                                  && q.IsClient == isClient) ||
                                  (p.Name.Contains(filiter) || p.Phone.Contains(filiter))
                                  orderby q.Name ascending, p.IsDefault descending
                                  select p);

                    var rtn = ExecuteResultEntity<ICollection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));

                    return rtn;
                }
                else
                {
                    var result = (from p in repo.All()
                                  from q in p.Manufacturers
                                  where q.Void == false && q.IsClient == isClient
                                  && q.Id == ManufactoryId
                                  orderby p.Name ascending, p.IsDefault descending
                                  select p);

                    var rtn = ExecuteResultEntity<ICollection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));

                    return rtn;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Contacts>>.CreateErrorResultEntity(ex);
            }

        }

        public bool IsExists(Guid ContactId)
        {
            try
            {
                var result = from p in repo.All()
                             where p.Id == ContactId && p.Void == false
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public ExecuteResultEntity Update(Contacts updatedProject, Guid UserId)
        {
            try
            {
                Update(updatedProject);
                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }

        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public override ExecuteResultEntity<Contacts> CreateOrUpdate(Contacts entity, bool isLastRecord = true)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    return ExecuteResultEntity<Contacts>.CreateErrorResultEntity("Name is null or empty.");
                }

                if (IsExists(s => s.Id == entity.Id))
                {
                    ExecuteResultEntity<Contacts> result = Update(entity);

                    return result;
                }
                else
                {
                    ExecuteResultEntity result = Add(entity);

                    if (!result.HasError)
                    {
                        return ExecuteResultEntity<Contacts>.CreateResultEntity(repo.Reload(entity));
                    }

                    return new ExecuteResultEntity<Contacts>()
                    {
                        Errors = result.Errors,
                        Result = entity
                    };
                }



                //model.Status.IsModify = false;
                //model.Status.IsNewInstance = false;
                //model.Status.IsSaved = true;

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Contacts>.CreateErrorResultEntity(ex);
            }
        }

        public override ExecuteResultEntity<Contacts> CreateNew()
        {
            try
            {
                Contacts model = new Contacts();
                return ExecuteResultEntity<Contacts>.CreateResultEntity(model);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Contacts>.CreateErrorResultEntity(ex);
            }

        }

        public override ExecuteResultEntity Add(Contacts entity, bool isLastRecord = true)
        {
            try
            {
                Contacts newdata = new Contacts();
                newdata.CreateTime = DateTime.Now;
                newdata.CreateUserId = GetCurrentLoginUser().Result.UserId;
                return base.Add(entity, isLastRecord);
            }
            catch (Exception ex)
            {
                var model = ExecuteResultEntity.CreateErrorResultEntity(ex);
                return model;
            }
        }

        public override ExecuteResultEntity<Contacts> Update(Contacts fromModel, bool isLastRecord = true)
        {
            try
            {
                var loginedresult = GetCurrentLoginUser();

                var result = base.Update(fromModel, isLastRecord);

                if (!result.HasError)
                {
                    accesslogrepo.Add(new AccessLog()
                    {
                        ActionCode = 2,
                        CreateTime = DateTime.Now,
                        DataId = result.Result.Id.ToString("N"),
                        UserId = loginedresult.HasError == false ? GetCurrentLoginUser().Result.UserId : Guid.Empty
                    });
                }

                fromModel = repo.Reload(fromModel);

                return ExecuteResultEntity<Contacts>.CreateResultEntity(fromModel);

            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<Contacts>.CreateErrorResultEntity(ex);
            }


        }

        public override ExecuteResultEntity Delete(Expression<Func<Contacts, bool>> condtion)
        {
            try
            {
                var result = Query(condtion);

                if (!result.HasError)
                {
                    if (result.Result.Any())
                    {
                        int c = 0;

                        foreach (var model in result.Result)
                        {
                            model.Void = true; //設定為停用
                            Update(model, c == (result.Result.Count - 1));
                            c++;
                        }

                        return ExecuteResultEntity.CreateResultEntity();
                    }
                }

                var rtn = new ExecuteResultEntity();
                rtn.Errors = result.Errors;
                rtn.HasError = result.HasError;
                return rtn;

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        //public override ExecuteResultEntity<ICollection<Contacts>> Query(Expression<Func<Contacts, bool>> filiter)
        //{
        //    ContactsViewModel model = new ContactsViewModel();

        //    try
        //    {
        //        var result = database.Contacts
        //            .Where(filiter)
        //            .OrderByDescending(p => p.IsDefault)
        //            .OrderBy(p => p.Name);

        //        if (result.Any())
        //        {
        //            return BindingFromModel(result.Single());
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is DbEntityValidationException)
        //        {
        //            DbEntityValidationException dbex = (DbEntityValidationException)ex;

        //            List<string> msg = new List<string>();

        //            foreach (var err in dbex.EntityValidationErrors)
        //            {
        //                foreach (var errb in err.ValidationErrors)
        //                {
        //                    msg.Add(errb.ErrorMessage);
        //                }
        //            }

        //            model.Errors = msg.AsEnumerable();
        //            return model;
        //        }

        //        model.Errors = new string[] { ex.Message };
        //        return model;
        //    }
        //}

    }
}
