using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ContactController : BaseController<ContactsViewModel, Contacts>
    {
        public ContactController()
        {

        }

        public ObservableCollection<ContactsViewModel> QueryAll()
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Void == false
                             select p;

                return new ObservableCollection<ContactsViewModel>(result.ToList().ConvertAll(c => BindingFromModel(c)));
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
            try
            {
                Update(updatedProject);
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    updatedProject.Errors = msg.AsEnumerable();

                }

                updatedProject.Errors = new string[] { ex.Message };
            }

        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public override void SaveModel(ContactsViewModel model)
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

                model.IsModify = false;
                model.IsNewInstance = false;
                model.IsSaved = true;
                model.CanDelete = true;
                model.CanEdit = true;
                model.CanNew = true;
                model.CanSave = false;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };
            }
        }

        public override ContactsViewModel CreateNew()
        {
            try
            {
                ContactsViewModel model = new ContactsViewModel();
                return model;
            }
            catch (Exception ex)
            {
                ContactsViewModel model = new ContactsViewModel();

                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };
                return model;
            }

        }

        public override void Add(ContactsViewModel model)
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

                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();
                }

                model.Errors = new string[] { ex.Message };
            }
        }

        public override ContactsViewModel Update(ContactsViewModel model)
        {
            try
            {
                var original = (from q in database.Contacts
                                where q.Id == model.Id
                                select q).SingleOrDefault();

                if (original != null)
                {
                    CopyToModel(original, model);
                    database.AccessLog.Add(new AccessLog() { ActionCode = 2, CreateTime = DateTime.Now, DataId = original.Id, UserId = model.LoginedUser.UserId });
                    database.SaveChanges();

                    return Query(x => x.Id == model.Id);
                }

                model.Errors = new string[] { };
                model.HasError = true;

                return model;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();
                    return model;
                }

                model.Errors = new string[] { ex.Message };
                return model;

            }

        }

        public override void Delete(ContactsViewModel model)
        {
            try
            {
                model.Void = true; //設定為停用
                model = Update(model);
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();

                }

                model.Errors = new string[] { ex.Message };


            }
        }

        public override bool IsExists(Expression<Func<Contacts, bool>> filiter)
        {
            try
            {
                return database.Contacts.Where(filiter).Any();
            }
            catch
            {
                throw;
            }
        }

        public override ContactsViewModel Query(Expression<Func<Contacts, bool>> filiter)
        {
            ContactsViewModel model = new ContactsViewModel();

            try
            {
                var result = database.Contacts
                    .Where(filiter);

                if (result.Any())
                {
                    return BindingFromModel(result.Single());
                }

                return null;
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbex = (DbEntityValidationException)ex;

                    List<string> msg = new List<string>();

                    foreach (var err in dbex.EntityValidationErrors)
                    {
                        foreach (var errb in err.ValidationErrors)
                        {
                            msg.Add(errb.ErrorMessage);
                        }
                    }

                    model.Errors = msg.AsEnumerable();
                    return model;
                }

                model.Errors = new string[] { ex.Message };
                return model;
            }
        }

    }
}
