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
    public class ContactController : BaseController<Contacts>
    {
        private ContactsRepository repo;

        public ContactController()
        {
            repo = RepositoryHelper.GetContactsRepository(database);
        }

        public ExecuteResultEntity<Collection<Contacts>> QueryAll()
        {
            try
            {
                var result = from p in repo.All()
                             where p.Void == false
                             orderby p.IsDefault ascending
                             select p;

                ExecuteResultEntity<Collection<Contacts>> rtn = ExecuteResultEntity<Collection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));
                return rtn;

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Collection<Contacts>>.CreateErrorResultEntity(ex);
            }
        }


        public ExecuteResultEntity<Collection<Contacts>> SearchByText(string filiter, Guid ManufactoryId, bool isClient)
        {
            try
            {
                if (filiter != null && filiter.Length > 0)
                {
                    var result = (from p in repo.All()
                                  from q in p.Manufacturers
                                  where (p.Void == false && p.Id == ManufactoryId
                                  && q.IsClient == isClient) ||
                                  (p.Name.Contains(filiter) || p.Phone.Contains(filiter)
                           )
                                  orderby p.IsDefault ascending, q.Name ascending
                                  select p);

                    var rtn = ExecuteResultEntity<Collection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));

                    return rtn;
                }
                else
                {
                    var result = (from p in repo.All()
                                  from q in p.Manufacturers
                                  where q.Void == false && q.IsClient == isClient
                                  && p.Id == ManufactoryId
                                  orderby p.IsDefault ascending, p.Name ascending
                                  select p);

                    var rtn = ExecuteResultEntity<Collection<Contacts>>.CreateResultEntity(new Collection<Contacts>(result.ToList()));

                    return rtn;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Collection<Contacts>>.CreateErrorResultEntity(ex);
            }

        }

        public bool IsExists(Guid ContactId)
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Id == ContactId && p.Void == false
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public void Update(Contacts updatedProject, Guid UserId)
        {
            try
            {
                Update(updatedProject);
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    updatedProject.Errors = msg.AsEnumerable();

                }

                updatedProject.Errors = new string[] { ex.Message };
            }

        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public override ExecuteResultEntity<ICollection<Contacts>> CreateOrUpdate(ICollection<Contacts> ObjectDataSet)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return;
                }

                if (IsExists(model.Id))
                {
                    using (StartUpWindowController usercontroller = new StartUpWindowController())
                    {
                        Update(model, usercontroller.GetCurrentLoginUser().UserId);
                    }

                }
                else
                {
                    Add(model);
                }

                model.Status.IsModify = false;
                model.Status.IsNewInstance = false;
                model.Status.IsSaved = true;

            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };
            }
        }

        public override ExecuteResultEntity<Contacts> CreateNew()
        {
            try
            {
                ContactsViewModel model = new ContactsViewModel();
                return model;
            }
            catch (Exception ex)
            {
                ContactsViewModel model = new ContactsViewModel();

                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };
                return model;
            }

        }

        public override ExecuteResultEntity Add(Contacts entity)
        {
            try
            {
                using (database)
                {
                    using (StartUpWindowController usercontroller = new StartUpWindowController())
                    {
                        Contacts newdata = new Contacts();
                        model.CreateTime = DateTime.Now;
                        model.CreateUserId = usercontroller.GetCurrentLoginUser().UserId;
                        CopyToModel(newdata, model);
                        database.Contacts.Add(newdata);
                        database.SaveChanges();
                    }
                }

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
                using (database)
                {
                    var original = (from q in database.Contacts
                                    where q.Id == model.Id
                                    select q).SingleOrDefault();

                    if (original != null)
                    {
                        using (StartUpWindowController usercontroller = new StartUpWindowController())
                        {
                            CopyToModel(original, model);
                            database.AccessLog.Add(new AccessLog()
                            {
                                ActionCode = 2,
                                CreateTime = DateTime.Now,
                                DataId = original.Id,
                                UserId = usercontroller.GetCurrentLoginUser().UserId
                            });
                            database.SaveChanges();
                        }


                        return Query(x => x.Id == model.Id);
                    }

                    model.Errors = new string[] { };
                    model.HasError = true;

                    return model;
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
                return model;
            }
            finally
            {
                database = new TokikuEntities();
            }

        }

        public override ExecuteResultEntity Delete(Expression<Func<Contacts, bool>> condtion)
        {
            try
            {
                model.Void = true; //設定為停用
                model = Update(model);
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };


            }
        }

        public override ExecuteResultEntity<ICollection<Contacts>> Query(Expression<Func<Contacts, bool>> filiter)
        {
            ContactsViewModel model = new ContactsViewModel();

            try
            {
                var result = database.Contacts
                    .Where(filiter)
                    .OrderByDescending(p => p.IsDefault)
                    .OrderBy(p => p.Name);

                if (result.Any())
                {
                    return BindingFromModel(result.Single());
                }

                return null;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();
                    return model;
                }

                model.Errors = new string[] { ex.Message };
                return model;
            }
        }

    }
}
