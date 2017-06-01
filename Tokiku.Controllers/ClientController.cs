﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    /// <summary>
    /// 客戶端商業邏輯層控制器
    /// </summary>
    public class ClientController : BaseController<ClientViewModel, Manufacturers>
    {
        public override ClientViewModel CreateNew()
        {
            ClientViewModel model = new ClientViewModel();

            var findlast = (from q in database.Manufacturers
                            where q.IsClient == true
                            orderby q.Code descending
                            select q).FirstOrDefault();

            model.Contracts = new ContactsViewModelCollection();
            model.ProjectContract = new ProjectContractViewModelCollection();
            model.Projects = new ProjectsViewModelCollection();
            model.Status.IsNewInstance = true;
            model.Status.IsSaved = false;
            model.Status.IsModify = false;

            if (findlast != null)
            {
                if (findlast.Code.StartsWith("CM"))
                {
                    int i = 0;

                    if (int.TryParse(findlast.Code.Substring(2), out i))
                    {
                        model.Code = string.Format("CM{0:000}", i + 1);
                        return model;
                    }


                }

            }

            model.Code = "CM001";


            return model;
        }

        public ClientViewModelCollection QueryAll(Guid ProjectId)
        {
            try
            {
                var result = from q in database.Manufacturers
                             from p in q.Projects
                             where q.IsClient == true && q.Void == false && p.Id == ProjectId
                             select q;

                if (result.Any())
                {
                    return new ClientViewModelCollection(result.Select(s => BindingFromModel<ClientViewModel, Manufacturers>(s))
                        .AsEnumerable());
                }

                return new ClientViewModelCollection();
            }
            catch (Exception ex)
            {
                var model = new ClientViewModelCollection();
                setErrortoModel(model, ex);
                return model;
            }
        }

        public ClientViewModelCollection QueryAll()
        {
            try
            {
                var result = from q in database.Manufacturers
                             where q.IsClient == true && q.Void == false
                             select q;

                ClientViewModelCollection model = new ClientViewModelCollection();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        ClientViewModel client = BindingFromModel(item);
                        model.Add(client);
                    }
                }

                return model;
            }
            catch (Exception ex)
            {
                var model = new ClientViewModelCollection();
                setErrortoModel(model, ex);
                return model;
            }
        }

        public IEnumerable SearchByText(string originalSource)
        {
            if (originalSource != null && originalSource.Length > 0)
            {
                var result = (from p in database.Manufacturers
                              where p.Void == false && p.IsClient == true &&
                              (p.Code.Contains(originalSource) || p.Name.Contains(originalSource) || p.ShortName.Contains(originalSource))
                              orderby p.Code ascending
                              select p);

                ClientViewModelCollection rtn = new ClientViewModelCollection();

                ResultBindingToViewModelCollection(rtn, result);

                return rtn;
            }
            else
            {
                var result = (from p in database.Manufacturers
                              where p.Void == false && p.IsClient == true
                              orderby p.Code ascending
                              select p);

                ClientViewModelCollection rtn = new ClientViewModelCollection();

                ResultBindingToViewModelCollection(rtn, result);

                return rtn;
            }
        }

        private void ResultBindingToViewModelCollection(ClientViewModelCollection rtn, IQueryable<Manufacturers> result)
        {
            if (result.Any())
            {
                foreach (var item in result)
                {
                    ClientViewModel model = ResultBindingToViewModel(item);

                    rtn.Add(model);
                }
            }
        }

        private ClientViewModel ResultBindingToViewModel(Manufacturers item)
        {
            ClientViewModel model = BindingFromModel(item);

            model.Contracts = new ContactsViewModelCollection();

            if (item.Contacts.Any())
            {
                foreach (var row in item.Contacts)
                {
                    model.Contracts.Add(BindingFromModel<ContactsViewModel, Contacts>(row));
                }
            }

            if (item.Projects.Any())
            {
                foreach (var row in item.Projects)
                {
                    model.Projects.Add(BindingFromModel<ProjectsViewModel, Projects>(row));
                }
            }

            if (item.ProjectContract.Any())
            {
                foreach (var row in item.ProjectContract)
                {
                    model.ProjectContract.Add(BindingFromModel<ProjectContractViewModel, ProjectContract>(row));
                }
            }

            model.Engineerings = new EngineeringViewModelCollection();

            return model;
        }

        public override ClientViewModel Query(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var result = database.Manufacturers
                               .OrderBy(o => o.Code)
                              .SingleOrDefault(filiter);

                var model = ResultBindingToViewModel(result);

                return model;
            }
            catch (Exception ex)
            {
                ClientViewModel rtn = new ClientViewModel();
                setErrortoModel(rtn, ex);
                return rtn;
            }
        }

        public override void Add(ClientViewModel model)
        {
            try
            {
                using (database)
                {
                    var dbm = new Manufacturers();
                    CopyToModel(dbm, model);

                    if (model.Contracts.Any())
                    {
                        foreach (var item in model.Contracts)
                        {
                            Contacts newContacts = new Contacts();
                            CopyToModel(newContacts, item);
                            dbm.Contacts.Add(newContacts);
                        }
                    }

                    if (model.Materials.Any())
                    {
                        foreach (var item in model.Materials)
                        {
                            Materials newContacts = new Materials();
                            CopyToModel(newContacts, item);

                        }
                    }

                    database.Manufacturers.Add(dbm);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public override ClientViewModel Update(ClientViewModel model)
        {
            try
            {
                using (database)
                {
                    UserController uc = new UserController();
                    var LoginedUser = uc.GetCurrentLoginUser();
                    var dbm = (from q in database.Manufacturers
                               where q.Id == model.Id && q.Void == false
                               select q).SingleOrDefault();

                    if (dbm != null)
                    {
                        CopyToModel(dbm, model);

                        if (model.Contracts.Any())
                        {
                            foreach (var item in model.Contracts)
                            {
                                Stack<Contacts> removeStack = new Stack<Contacts>();

                                foreach (var rowindb in dbm.Contacts)
                                {
                                    if (model.Contracts.Where(w => w.Id == rowindb.Id).Any() == false)
                                    {
                                        //remove(指資料真的被移除了)
                                        removeStack.Push(rowindb);
                                    }
                                }

                                if (removeStack.Count > 0)
                                {
                                    while (removeStack.Count > 0)
                                    {
                                        dbm.Contacts.Remove(removeStack.Pop());
                                    }
                                }

                                foreach (var row in model.Contracts)
                                {
                                    if (dbm.Contacts.Where(w => w.Id == row.Id).Any())
                                    {
                                        var foundinoriginal = dbm.Contacts.Where(w => w.Id == row.Id).Single();
                                        CopyToModel(foundinoriginal, row);
                                        //  database.Entry(foundinoriginal).State = System.Data.Entity.EntityState.Modified;
                                    }
                                    else
                                    {
                                        Contacts newData = new Contacts();
                                        CopyToModel(newData, row);
                                        newData.CreateUserId = LoginedUser.UserId;
                                        dbm.Contacts.Add(newData);
                                    }
                                }
                            }
                        }
                    }
                    //database.Entry(dbm).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    return Query(w => w.Id == model.Id);
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
    }
}
