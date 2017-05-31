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
    /// <summary>
    /// 聯絡人商業邏輯層控制器
    /// </summary>
    public class ContactController : BaseController<ContactsViewModel, Contacts>
    {
        public ContactController()
        {

        }

        public ContactsViewModelCollection QueryAll()
        {
            try
            {
                var result = from p in database.Contacts
                             where p.Void == false
                             orderby p.IsDefault ascending
                             select p;

                ContactsViewModelCollection rtn = new ContactsViewModelCollection();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        rtn.Add(BindingFromModel(item));
                    }
                }

                return rtn;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public ContactsViewModelCollection SearchByText(string filiter, Guid ManufactoryId, bool isClient)
        {
            if (filiter != null && filiter.Length > 0)
            {
                var result = (from p in database.Manufacturers
                              from q in p.Contacts
                              where (p.Void == false && p.Id == ManufactoryId
                              && p.IsClient == isClient) ||
                              (q.Name.Contains(filiter) || q.Phone.Contains(filiter)
                              || q.Mobile.Contains(filiter) || q.EMail.Contains(filiter))
                              orderby q.IsDefault ascending, q.Name ascending
                              select q);

                var rtn = new ContactsViewModelCollection();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        rtn.Add(BindingFromModel(item));
                    }
                }

                return rtn;
            }
            else
            {
                var result = (from p in database.Manufacturers
                              from q in p.Contacts
                              where q.Void == false && p.IsClient == isClient
                              && p.Id == ManufactoryId
                              orderby q.IsDefault ascending, q.Name ascending
                              select q);

                var rtn = new ContactsViewModelCollection();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        rtn.Add(BindingFromModel(item));
                    }
                }
                return rtn;
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
                    using (UserController usercontroller = new UserController())
                    {
                        Update(model, usercontroller.GetCurrentLoginUser().UserId);
                    }

                }
                else
                {
                    Add(model);
                }

                model.Status.IsModify = false;
                model.Status.IsNewInstance = false;
                model.Status.IsSaved = true;

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
                using (UserController usercontroller = new UserController())
                {
                    Contacts newdata = new Contacts();
                    model.CreateTime = DateTime.Now;
                    model.CreateUserId = usercontroller.GetCurrentLoginUser().UserId;
                    CopyToModel(newdata, model);
                    database.Contacts.Add(newdata);
                    database.SaveChanges();
                }

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
                    using (UserController usercontroller = new UserController())
                    {
                        CopyToModel(original, model);
                        database.AccessLog.Add(new AccessLog()
                        {
                            ActionCode = 2,
                            CreateTime = DateTime.Now,
                            DataId = original.Id,
                            UserId = usercontroller.GetCurrentLoginUser().UserId
                        });
                        database.SaveChanges();
                    }


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
                    .Where(filiter)
                    .OrderByDescending(p => p.IsDefault)
                    .OrderBy(p => p.Name);

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
