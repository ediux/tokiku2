using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ProjectsController : BaseController<ProjectBaseViewModel, Projects>
    {

        #region 公開方法(中介層呼叫)

        /// <summary>
        /// 儲存變更
        /// </summary>
        public override void SaveModel(ProjectBaseViewModel model)
        {
            try
            {
                if (IsExists(model.Id))
                {
                    Update(model);
                }
                else
                {
                    Add(model);

                }

                model.Status.IsSaved = true;
                model.Status.IsModify = false;
            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = CreateNew();
                }
                setErrortoModel(model, ex);
            }

        }

        #endregion

        public ProjectsController()
        {

        }

        public override ProjectBaseViewModel CreateNew()
        {
            UserController usercontroller = new UserController();

            var newmodel = new ProjectBaseViewModel()
            {
                Id = Guid.NewGuid(),
                Code = string.Format("{0:000}-{1}", DateTime.Today.Year - 1911, GetNextProjectSerialNumber((DateTime.Now.Year - 1911).ToString())),
            };

            newmodel.ProjectContract = new ProjectContractViewModelCollection();
            newmodel.StateText = GetAllState();
            ManufacturersController mc = new ManufacturersController();
            newmodel.Clients = mc.QueryAllClients();
            
            return newmodel;
        }

        public string GetNextProjectSerialNumber(string year)
        {
            var result = (from q in database.Projects
                          where q.Code.StartsWith(year.Trim())
                          orderby q.Code descending
                          select q.Code).FirstOrDefault();

            if (!string.IsNullOrEmpty(result))
            {
                string[] parts = result.Split('-');

                if (parts.Any() && parts.Length >= 1)
                {
                    int currentNumber = 0;

                    if (int.TryParse(parts[1], out currentNumber))
                    {
                        currentNumber += 1;
                        return string.Format("{0:000}", currentNumber);
                    }
                }

            }

            return "001";
        }

        public override void Add(ProjectBaseViewModel model)
        {
            try
            {
                UserController uc = new UserController();
                var LoginedUser = uc.GetCurrentLoginUser();
                Projects newProject = new Projects();
                newProject.Id = Guid.NewGuid();
                model.CreateTime = DateTime.Now;
                model.CreateUserId = LoginedUser.UserId;
                CopyToModel(newProject, model);
                if (model.ProjectContract.Any())
                {
                    foreach (var row in model.ProjectContract)
                    {
                        ProjectContract newdata = new ProjectContract();
                        newdata.ProjectId = newProject.Id;
                        newdata.SigningDate = model.ProjectSigningDate;
                        newdata.AmountDue = 0F;
                        newdata.Area = 0F;
                        CopyToModel(newdata, row);
                        newdata.State = model.StateText.Where(s => s.StateName == row.StateText).Select(s => s.Id).SingleOrDefault();
                        newProject.ProjectContract.Add(newdata);
                    }
                }
                database.Projects.Add(newProject);
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
            }

        }

        public ProjectBaseViewModel QuerySingle(Guid ProjectId)
        {
            try
            {
                ProjectContractController PCC = new ProjectContractController();
                ManufacturersController mc = new ManufacturersController();
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                if (result.Any())
                {
                    var model= BindingFromModel(result.Single());

                    model.ProjectContract = PCC.QueryAll(model.Id);
                    model.Clients = mc.QueryAllClients();
                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                ProjectBaseViewModel model = new ProjectBaseViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

        public ObservableCollection<ProjectListViewModel> QueryAll()
        {
            try
            {
                var result = from p in database.Projects
                             where p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select new ProjectListViewModel
                             {
                                 Id = p.Id,
                                 Code = p.Code,
                                 Name = p.Name,
                                 ShortName = p.ShortName,
                                 State = p.States.StateName,
                                 StartDate = (p.ProjectContract.OrderByDescending(s => s.StartDate).FirstOrDefault()).StartDate,
                                 CompletionDate = p.ProjectContract.OrderByDescending(s => s.StartDate).FirstOrDefault().CompletionDate,
                                 WarrantyDate = p.ProjectContract.OrderByDescending(s=>s.WarrantyDate).FirstOrDefault().WarrantyDate
                             };

                return new ObservableCollection<ProjectListViewModel>(result);
            }
            catch (Exception ex)
            {
                var q = new ObservableCollection<ProjectListViewModel>();
                var model = new ProjectListViewModel();
                setErrortoModel(model, ex);
                q.Add(model);
                return q;
            }
        }

        public bool IsExists(Guid ProjectId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public override ProjectBaseViewModel Update(ProjectBaseViewModel updatedProject)
        {
            try
            {
                var original = (from q in database.Projects
                                where q.Id == updatedProject.Id
                                select q).Single();

                if (original != null)
                {
                    CopyToModel(original, updatedProject);
                    if (updatedProject.ProjectContract.Any())
                    {
                        Stack<ProjectContract> removeStack = new Stack<ProjectContract>();

                        foreach (var rowindb in original.ProjectContract)
                        {
                            if (updatedProject.ProjectContract.Where(w => w.Id == rowindb.Id).Any() == false)
                            {
                                //remove(指資料真的被移除了)
                                removeStack.Push(rowindb);
                            }
                        }

                        if (removeStack.Count > 0)
                        {
                            while (removeStack.Count > 0)
                            {
                                original.ProjectContract.Remove(removeStack.Pop());
                            }
                        }

                        foreach (var row in updatedProject.ProjectContract)
                        {
                            if (original.ProjectContract.Where(w => w.Id == row.Id).Any())
                            {
                                var foundinoriginal = original.ProjectContract.Where(w => w.Id == row.Id).Single();
                                CopyToModel(foundinoriginal, row);
                                database.Entry(foundinoriginal).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                ProjectContract newData = new ProjectContract();
                                CopyToModel(newData, row);
                                newData.ProjectId = original.Id;
                                original.ProjectContract.Add(newData);
                            }
                        }
                    }
                    database.Entry(original).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();
                }
                updatedProject = Query(s => s.Id == updatedProject.Id);
                return updatedProject;
            }
            catch (Exception ex)
            {
                setErrortoModel(updatedProject, ex);
                return updatedProject;
            }

        }

        public override ProjectBaseViewModel Query(Expression<Func<Projects, bool>> filiter)
        {
            try
            {
                var result = database.Projects
                    .Where(filiter)
                    .Where(w => w.Void == false)
                    .OrderBy(s => s.State)
                    .OrderBy(p => p.Code)
                    .SingleOrDefault();

                ProjectBaseViewModel model = BindingFromModel(result);

                model.Status.IsNewInstance = false;
                model.StateText = GetAllState();

                model.ProjectContract = new ProjectContractViewModelCollection();

                if (result.ProjectContract.Any())
                {
                    foreach(var row in result.ProjectContract)
                    {
                        model.ProjectContract.Add(BindingFromModel<ProjectContractViewModel, ProjectContract>(row));
                    }
                }

                ManufacturersController mc = new ManufacturersController();

                model.Clients = mc.QueryAllClients(); 
         
                return model;
            }
            catch (Exception ex)
            {
                var model = new ProjectBaseViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }
        public void Delete(Guid ProjectId, Guid UserId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    database.AccessLog.Add(new AccessLog() { ActionCode = 3, CreateTime = DateTime.Now, DataId = ProjectId, UserId = UserId });
                    database.SaveChanges();
                }

            }
            catch (Exception)
            {

            }
        }

        public ObservableCollection<StatesViewModel> GetAllState()
        {
            return new ObservableCollection<StatesViewModel>(from c in database.States
                                                             select new StatesViewModel()
                                                             {
                                                                 Id = c.Id,
                                                                 StateName = c.StateName
                                                             });
        }

        public ObservableCollection<ProjectBaseViewModel> SearchByText(string text)
        {
            if (text != null && text.Length > 0)
            {
                var result = (from p in database.Projects
                              where p.Void == false &&
                              (p.Code.Contains(text) || p.Name.Contains(text) || p.ShortName.Contains(text))
                              orderby p.State ascending, p.Code ascending
                              select p);

                var model = new ObservableCollection<ProjectBaseViewModel>();

                if (result.Any())
                {
                    foreach(var row in result)
                    {
                        model.Add(BindingFromModel(row));
                    }
                }

                return model;
            }
            else
            {

                var result = (from p in database.Projects
                              where p.Void == false
                              orderby p.State ascending, p.Code ascending
                              select p);

                var model = new ObservableCollection<ProjectBaseViewModel>();

                if (result.Any())
                {
                    foreach (var row in result)
                    {
                        model.Add(BindingFromModel(row));
                    }
                }

                return model;
                
            }
        }
    }
}
