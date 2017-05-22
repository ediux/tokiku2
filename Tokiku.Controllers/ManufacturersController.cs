using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ManufacturersController
    {
        private TokikuEntities database;

        public ManufacturersController()
        {
            database = new TokikuEntities();
        }

        public string GetNextProjectSerialNumber()
        {
            var result = (from q in database.Manufacturers
                          orderby q.Code descending
                          select q.Code).FirstOrDefault();

            if (!string.IsNullOrEmpty(result))
            {

            }

            return "001";
        }

        public void Add(Manufacturers model)
        {
            database.Manufacturers.Add(model);
            database.SaveChanges();
        }

        public Manufacturers QuerySingle(Guid ManufacturersId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
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

        public List<Manufacturers> QueryAll()
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Void == false
                             select p;

                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExists(Guid ManufacturersId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public void Update(Manufacturers updatedProject)
        {
            var original = QuerySingle(updatedProject.Id);
            if (original != null)
            {
                original = updatedProject;
                database.SaveChanges();
            }
        }

        public void Delete(Guid ManufacturersId, Guid UserId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ManufacturersId && p.Void == false
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    database.AccessLog.Add(new AccessLog() { ActionCode = 3, CreateTime = DateTime.Now, DataId = ManufacturersId, UserId = UserId });
                    database.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
