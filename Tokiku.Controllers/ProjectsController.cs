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

                if(parts!=null && parts.Length > 1)
                {
                    int currentNumber = 0;

                    if(int.TryParse(parts[1],out currentNumber))
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
            throw new NotImplementedException();
        }
    }
}
