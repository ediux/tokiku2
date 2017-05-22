using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ContactController
    {
        private TokikuEntities database;

        public ContactController()
        {
            database = new TokikuEntities();
        }

        public void Add(Contacts model)
        {
            database.Contacts.Add(model);
            database.SaveChanges();
        }

        public Contacts QuerySingle(Guid ContactId)
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Id == ContactId && p.Void == false
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

        public List<Contacts> QueryAll()
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Void == false
                             select p;

                return result.ToList();
            }
            catch (Exception)
            {

                throw;
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
            var original = QuerySingle(updatedProject.Id);
            if (original != null)
            {
                original = updatedProject;
                database.AccessLog.Add(new AccessLog() { ActionCode = 2, CreateTime = DateTime.Now, DataId = updatedProject.Id, UserId = UserId });
                database.SaveChanges();
            }
        }

        public void Delete(Guid ContactsId, Guid UserId)
        {
            try
            {
                var result = from p in database.Manufacturers
                             where p.Id == ContactsId && p.Void == false
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    database.AccessLog.Add(new AccessLog() { ActionCode = 3, CreateTime = DateTime.Now, DataId = ContactsId, UserId = UserId });
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
