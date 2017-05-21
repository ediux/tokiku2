using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProjectsController
    {
        private TokikuEntities database;

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

        public void Add(Projects model)
        {
            database.Projects.Add(model);
            database.SaveChanges();
        }

        public Projects QuerySingle(Guid ProjectId)
        {
            try
            {
                var result = from p in database.Projects
                             where p.Id == ProjectId && p.Void == false
                             select p;

                if (result.Any())
                {
                    return result.Single();
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Projects> QueryAll()
        {
            try
            {
                var result = from p in database.Projects
                             where p.Void == false
                             select p;

                return result.ToList();
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

        public void Update(Projects updatedProject)
        {
            var original = QuerySingle(updatedProject.Id);
            if (original != null)
            {
                original = updatedProject;
                database.SaveChanges();
            }
        }

        public List<States> GetAllState()
        {
            return (from c in database.States
                    select c).ToList();
        }
    }
}
