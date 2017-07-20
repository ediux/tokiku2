using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    /// <summary>
    /// 客戶端商業邏輯層控制器
    /// </summary>
    public class ClientController : BaseController<Manufacturers>
    {
        private IManufacturersRepository ManufacturersRepo;

        public ClientController()
        {
            ManufacturersRepo = this.GetReoisitory<Manufacturers>() as IManufacturersRepository;
        }

        public override ExecuteResultEntity<Manufacturers> CreateNew()
        {
            try
            {
                Manufacturers model = new Manufacturers();

                var findlast = (from q in ManufacturersRepo.All()
                                where q.IsClient == true
                                orderby q.Code descending
                                select q).FirstOrDefault();

                if (findlast != null)
                {
                    if (findlast.Code.StartsWith("CM"))
                    {
                        int i = 0;

                        if (int.TryParse(findlast.Code.Substring(2), out i))
                        {
                            model.Code = string.Format("CM{0:000}", i + 1);
                            return ExecuteResultEntity<Manufacturers>.CreateResultEntity(model);
                        }
                    }
                }

                model.Id = Guid.NewGuid();
                model.Code = "CM001";

                return ExecuteResultEntity<Manufacturers>.CreateResultEntity(model);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
            }

        }

        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAll(Guid ProjectId)
        {
            try
            {
                var result = from q in ManufacturersRepo.All()
                             from p in q.ManufacturersBussinessItems
                             where q.IsClient == true && q.Void == false && p.Id == ProjectId
                             select q;


                return ExecuteResultEntity<ICollection<Manufacturers>>
                    .CreateResultEntity(new Collection<Manufacturers>(result.ToList()));

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAll()
        {
            try
            {
                var result = from q in ManufacturersRepo.All()
                             where q.IsClient == true && q.Void == false
                             orderby q.Code ascending
                             select q;

                ICollection<Manufacturers> model = new Collection<Manufacturers>(result.ToList());                
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(model);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<Manufacturers>> SearchByText(string originalSource)
        {
            if (originalSource != null && originalSource.Length > 0)
            {
                var result = (from p in ManufacturersRepo.All()
                              where p.Void == false && p.IsClient == true &&
                              (p.Code.Contains(originalSource) || p.Name.Contains(originalSource) || p.Principal.Contains(originalSource))
                              orderby p.Code ascending
                              select p);

                ExecuteResultEntity<ICollection<Manufacturers>> rtn = ExecuteResultEntity<ICollection<Manufacturers>>
                    .CreateResultEntity(new Collection<Manufacturers>(result.ToList()));

                return rtn;
            }
            else
            {
                var result = (from p in ManufacturersRepo.All()
                              where p.Void == false && p.IsClient == true
                              orderby p.Code ascending
                              select p);

                ExecuteResultEntity<ICollection<Manufacturers>> rtn = ExecuteResultEntity<ICollection<Manufacturers>>
                  .CreateResultEntity(new Collection<Manufacturers>(result.ToList()));

                return rtn;
            }
        }

        public override ExecuteResultEntity<Manufacturers> Update(Manufacturers fromModel, bool isLastRecord = true)
        {
            try
            {
                var ManufacturersRepository = this.GetReoisitory();

                var accesslog = this.GetReoisitory<AccessLog>();

                var LoginedUser = GetCurrentLoginUser();

                var dbm = (from q in ManufacturersRepository.All()
                           where q.Id == fromModel.Id
                           select q).SingleOrDefault();

                if (dbm != null)
                {
                    CheckAndUpdateValue(fromModel, dbm);



                    var toDel = dbm.Contacts.Select(s => s.Id).Except(fromModel.Contacts.Select(s => s.Id)).ToList();
                    var toAdd = fromModel.Contacts.Select(s => s.Id).Except(dbm.Contacts.Select(s => s.Id)).ToList();
                    var samerows = dbm.Contacts.Select(s => s.Id).Intersect(fromModel.Contacts.Select(s => s.Id)).ToList();

                    Stack<Contacts> RemoveStack = new Stack<Contacts>();
                    Stack<Contacts> AddStack = new Stack<Contacts>();

                    foreach (var delitem in toDel)
                    {
                        RemoveStack.Push(dbm.Contacts.Where(w => w.Id == delitem).Single());
                    }

                    foreach (var additem in toAdd)
                    {
                        AddStack.Push(fromModel.Contacts.Where(w => w.Id == additem).Single());
                    }

                    while (RemoveStack.Count > 0)
                    {
                        dbm.Contacts.Remove(RemoveStack.Pop());
                    }

                    while (AddStack.Count > 0)
                    {
                        dbm.Contacts.Add(AddStack.Pop());
                    }

                    foreach (var sameitem in samerows)
                    {
                        Contacts Source = fromModel.Contacts.Where(w => w.Id == sameitem).Single();
                        Contacts Target = dbm.Contacts.Where(w => w.Id == sameitem).Single();
                        CheckAndUpdateValue(Source, Target);
                    }

                }

                ManufacturersRepository.UnitOfWork.Commit();

                accesslog.Add(new AccessLog()
                {
                    ActionCode = (Byte)ActionCodes.Update,
                    CreateTime = DateTime.Now,
                    DataId = dbm.Id.ToString("N"),
                    Reason = "更新資料",
                    UserId = LoginedUser.Result.UserId
                });



                var rtn = Query(w => w.Id == fromModel.Id);
                return ExecuteResultEntity<Manufacturers>.CreateResultEntity(rtn.Result.SingleOrDefault());

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
            }
        }
        //private void ResultBindingToViewModelCollection(ExecuteResultEntity<ICollection<Manufacturers>> rtn, IQueryable<Manufacturers> result)
        //{
        //    if (result.Any())
        //    {
        //        foreach (var item in result)
        //        {
        //            ClientViewModel model = ResultBindingToViewModel(item);

        //            rtn.Add(model);
        //        }
        //    }
        //}

        //private Manufacturers ResultBindingToViewModel(Manufacturers item)
        //{
        //    ClientViewModel model = BindingFromModel(item);

        //    model.Contracts = new ContactsViewModelCollection();

        //    if (item.Contacts.Any())
        //    {
        //        foreach (var row in item.Contacts)
        //        {
        //            model.Contracts.Add(BindingFromModel<ContactsViewModel, Contacts>(row));
        //        }
        //    }

        //    if (item.Projects.Any())
        //    {
        //        foreach (var row in item.Projects)
        //        {
        //            model.Projects.Add(BindingFromModel<ProjectsViewModel, Projects>(row));
        //        }
        //    }

        //    if (item.ProjectContract.Any())
        //    {
        //        foreach (var row in item.ProjectContract)
        //        {
        //            model.ProjectContract.Add(BindingFromModel<ProjectContractViewModel, ProjectContract>(row));
        //        }
        //    }

        //    model.Engineerings = new EngineeringViewModelCollection();

        //    return model;
        //}

        //public override ExecuteResultEntity<ICollection<Manufacturers>> Query(Expression<Func<Manufacturers, bool>> filiter)
        //{
        //    try
        //    {
        //        var result = database.Manufacturers
        //                       .OrderBy(o => o.Code)
        //                      .SingleOrDefault(filiter);

        //        var model = ResultBindingToViewModel(result);

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientViewModel rtn = new ClientViewModel();
        //        setErrortoModel(rtn, ex);
        //        return rtn;
        //}
        //    }

        //public override ExecuteResultEntity Add(Manufacturers entity)
        //{
        //    try
        //    {
        //        using (database)
        //        {
        //            var dbm = new Manufacturers();
        //            //CopyToModel(dbm, model);

        //            if (model.Contracts.Any())
        //            {
        //                foreach (var item in model.Contracts)
        //                {
        //                    Contacts newContacts = new Contacts();
        //                    CopyToModel(newContacts, item);
        //                    dbm.Contacts.Add(newContacts);
        //                }
        //            }

        //            if (model.Materials.Any())
        //            {
        //                foreach (var item in model.Materials)
        //                {
        //                    Materials newContacts = new Materials();
        //                    CopyToModel(newContacts, item);

        //                }
        //            }

        //            database.Manufacturers.Add(dbm);
        //            database.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(model, ex);
        //    }
        //    finally
        //    {
        //        database = new TokikuEntities();
        //    }
        //}

        //public override ExecuteResultEntity<Manufacturers> Update(Manufacturers fromModel, bool isLastRecord = true)
        //{
        //    try
        //    {
        //        using (database)
        //        {
        //            StartUpWindowController uc = new StartUpWindowController();
        //            var LoginedUser = uc.GetCurrentLoginUser();
        //            var dbm = (from q in database.Manufacturers
        //                       where q.Id == model.Id && q.Void == false
        //                       select q).SingleOrDefault();

        //            if (dbm != null)
        //            {
        //                CopyToModel(dbm, model);

        //                if (model.Contracts.Any())
        //                {
        //                    foreach (var item in model.Contracts)
        //                    {
        //                        Stack<Contacts> removeStack = new Stack<Contacts>();

        //                        foreach (var rowindb in dbm.Contacts)
        //                        {
        //                            if (model.Contracts.Where(w => w.Id == rowindb.Id).Any() == false)
        //                            {
        //                                //remove(指資料真的被移除了)
        //                                removeStack.Push(rowindb);
        //                            }
        //                        }

        //                        if (removeStack.Count > 0)
        //                        {
        //                            while (removeStack.Count > 0)
        //                            {
        //                                dbm.Contacts.Remove(removeStack.Pop());
        //                            }
        //                        }

        //                        foreach (var row in model.Contracts)
        //                        {
        //                            if (dbm.Contacts.Where(w => w.Id == row.Id).Any())
        //                            {
        //                                var foundinoriginal = dbm.Contacts.Where(w => w.Id == row.Id).Single();
        //                                CopyToModel(foundinoriginal, row);
        //                                //  database.Entry(foundinoriginal).State = System.Data.Entity.EntityState.Modified;
        //                            }
        //                            else
        //                            {
        //                                Contacts newData = new Contacts();
        //                                CopyToModel(newData, row);
        //                                newData.CreateUserId = LoginedUser.UserId;
        //                                dbm.Contacts.Add(newData);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            //database.Entry(dbm).State = System.Data.Entity.EntityState.Modified;
        //            database.SaveChanges();

        //            return Query(w => w.Id == model.Id);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(model, ex);
        //        return model;
        //    }
        //    finally
        //    {
        //        database = new TokikuEntities();
        //    }
        //}
    }
}
