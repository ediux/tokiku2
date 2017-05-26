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
                model.CanEdit = false;
                model.IsSaved = true;
                model.IsModify = false;
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

            return new ProjectBaseViewModel()
            {
                Id = Guid.NewGuid(),
                Code = string.Format("{0:000}-{1}", DateTime.Today.Year - 1911, GetNextProjectSerialNumber((DateTime.Now.Year - 1911).ToString())),              
                IsNewInstance = true,
                CanEdit = true
            };
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
                model.CreateTime = DateTime.Now;
                model.CreateUserId = LoginedUser.UserId;
                CopyToModel(newProject, model);
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
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                if (result.Any())
                {
                    return BindingFromModel(result.Single());
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
                                 CompletionDate = p.ProjectContract.OrderByDescending(s => s.StartDate).FirstOrDefault().CompletionDate
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
                var original = QuerySingle(updatedProject.Id);
                if (original != null)
                {
                    original = updatedProject;
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
                    .OrderBy(s => s.State).OrderBy(p => p.Code)
                            .Select(p =>
                              new ProjectBaseViewModel
                              {
                                  CanEdit = true,
                                  Id = p.Id,
                                  Code = p.Code,
                                  Name = p.Name,
                                  ShortName = p.ShortName,
                                  ClientId = p.ClientId,
                                  Comment = p.Comment,
                                  ProjectSigningDate = p.ProjectSigningDate,
                                  SiteAddress = p.SiteAddress,
                                  State = p.State,
                                  Void = p.Void                                 
                              }).SingleOrDefault();

                result.CanDelete = true;
                result.CanEdit = true;
                result.IsNewInstance = false;
                result.CanSave = false;

                
                result.StateText = new ObservableCollection<StatesViewModel>(from q in database.States
                                                                             select new StatesViewModel { Id = q.Id, StateName = q.StateName });
                return result;
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

        public ObservableCollection<States> GetAllState()
        {
            return new ObservableCollection<States>(from c in database.States
                                                    select c);
        }

        public ObservableCollection<ProjectBaseViewModel> SearchByText(string text)
        {
            if (text != null && text.Length > 0)
            {
                return new ObservableCollection<ProjectBaseViewModel>(from p in database.Projects
                                                                      where p.Void == false &&
                                                                      (p.Code.Contains(text) || p.Name.Contains(text) || p.ShortName.Contains(text))
                                                                      orderby p.State ascending, p.Code ascending
                                                                      select BindingFromModel(p));
            }
            else
            {
                return new ObservableCollection<ProjectBaseViewModel>(from p in database.Projects
                                                                      where p.Void == false
                                                                      orderby p.State ascending, p.Code ascending
                                                                      select BindingFromModel(p));
            }
        }
    }
}
