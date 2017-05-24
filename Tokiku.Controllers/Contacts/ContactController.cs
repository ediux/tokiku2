using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ContactController : BaseController
    {
        private TokikuEntities database;

        public ContactController()
        {
            database = new TokikuEntities();
        }

        public void Add(ContactsViewModel model)
        {
            try
            {
                Contacts newdata = new Contacts();
                model.CreateTime = DateTime.Now;
                model.CreateUserId = model.LoginedUser.UserId;
                CopyToModel(newdata, model);
                database.Contacts.Add(newdata);
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                model.Error = ex;
            }

        }

        public ContactsViewModel QuerySingle(Guid ContactId)
        {
            ContactsViewModel model = new ContactsViewModel();

            try
            {
                var result = from p in database.Contacts
                             where p.Id == ContactId && p.Void == false
                             select p;

                if (result.Any())
                {
                    return BindingFromModel<Contacts, ContactsViewModel>(result.Single());
                }

                return null;
            }
            catch (Exception ex)
            {
                model.Error = ex;
                return model;
            }
        }

        public ObservableCollection<ContactsViewModel> QueryAll()
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Void == false
                             select p;

                return new ObservableCollection<ContactsViewModel>(result.ToList().ConvertAll(c => BindingFromModel<Contacts, ContactsViewModel>(c)));
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

        public void Update(ContactsViewModel updatedProject, Guid UserId)
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


        #region 公開方法(中介層呼叫)

        /// <summary>
        /// 儲存變更
        /// </summary>
        public void SaveModel(ContactsViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return;
                }

                if (IsExists(model.Id))
                {
                    Update(model, model.LoginedUser.UserId);
                }
                else
                {                   
                    Add(model);
                }
                model.IsEditorMode = true;
                model.IsSaved = true;
                model.IsModify = false;
            }
            catch(Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;
                    string msg = "";
                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg += errb.ErrorMessage;
                        }
                    }

                    model.Error = new Exception(msg);                    
                }
                else
                {
                    model.Error = ex;                   
                }
            }
        }


        #endregion
    }
}
