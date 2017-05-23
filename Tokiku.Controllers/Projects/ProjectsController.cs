using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ProjectsController : BaseController
    {
        private TokikuEntities database;
        #region 公開方法(中介層呼叫)



        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveModel(ProjectBaseViewModel model)
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
                model.IsEditorMode = true;
                model.IsSaved = true;
                model.IsModify = false;
            }
            catch
            {
                throw;
            }

        }

        #endregion
        public ProjectsController()
        {
            database = new TokikuEntities();
        }

        public string GetNextProjectSerialNumber(string year)
        {
            var result = (from q in database.Projects
                          where q.Code.StartsWith(year.Trim()) && q.Code.Contains("-F") == false
                          orderby q.Code descending
                          select q.Code).FirstOrDefault();

            if (!string.IsNullOrEmpty(result))
            {
                string[] parts = result.Split('-');

                if (parts != null && parts.Length > 1)
                {
                    int currentNumber = 0;

                    if (int.TryParse(parts[1], out currentNumber))
                    {
                        currentNumber += 1;
                        return currentNumber.ToString();
                    }
                }
            }

            return "001";
        }

        public void Add(ProjectBaseViewModel model)
        {
            Projects newProject = new Projects();
            model.CreateTime = DateTime.Now;
            model.CreateUserId = model.LoginedUser.UserId;
            CopyToModel(newProject, model);
            database.Projects.Add(newProject);
            database.SaveChanges();
        }

        public ProjectBaseViewModel QuerySingle(Guid ProjectId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             select p;

                if (result.Any())
                {
                    return BindingFromModel<Projects, ProjectBaseViewModel>(result.Single());
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ObservableCollection<ProjectBaseViewModel> QueryAll()
        {
            try
            {
                var result = from p in database.Projects
                             where p.Void == false
                             select p;

                return new ObservableCollection<ProjectBaseViewModel>(result.ToList().ConvertAll(c => BindingFromModel<Projects, ProjectBaseViewModel>(c)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExists(Guid ProjectId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public void Update(ProjectBaseViewModel updatedProject)
        {
            var original = QuerySingle(updatedProject.Id);
            if (original != null)
            {
                original = updatedProject;
                database.SaveChanges();
            }
        }

        public void Delete(Guid ProjectId, Guid UserId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
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

                throw;
            }
        }

        public List<States> GetAllState()
        {
            return (from c in database.States
                    select c).ToList();
        }

        public List<Projects> SearchByText(string text)
        {
            return (from p in database.Projects
                    where p.Void == false &&
                    (p.Code.Contains(text) || p.Name.Contains(text) || p.ShortName.Contains(text))
                    select p).ToList();
        }
    }
}
