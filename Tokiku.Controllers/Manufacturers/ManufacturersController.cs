using System;
using System.Collections;
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
    public class ManufacturersController : BaseController<ManufacturersViewModel, Manufacturers>
    {

        private UserController controller;

        public ManufacturersController()
        {
            controller = new UserController();
        }

        /// <summary>
        /// 取得廠商代碼流水號
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string GetNextProjectSerialNumber()
        {
            string Code = string.Empty;
            var lastitem = QueryAll().OrderByDescending(s => s.Code).FirstOrDefault();
            if (lastitem != null)
            {
                int numif = 0;
                if (int.TryParse(lastitem.Code, out numif))
                {
                    if (numif <= 99)
                    {
                        Code = string.Format("{0:00}", (numif + 1));
                        return Code;
                    }

                }

                Dictionary<int, string> dict = new Dictionary<int, string>();
                dict.Add(0, "0");
                dict.Add(1, "1");
                dict.Add(2, "2");
                dict.Add(3, "3");
                dict.Add(4, "4");
                dict.Add(5, "5");
                dict.Add(6, "6");
                dict.Add(7, "7");
                dict.Add(8, "8");
                dict.Add(9, "9");
                dict.Add(10, "A");
                dict.Add(11, "B");
                dict.Add(12, "C");
                dict.Add(13, "D");
                dict.Add(14, "E");
                dict.Add(15, "F");
                dict.Add(16, "G");
                dict.Add(17, "H");
                dict.Add(18, "I");
                dict.Add(19, "J");
                dict.Add(20, "K");
                dict.Add(21, "L");
                dict.Add(22, "M");
                dict.Add(23, "N");
                dict.Add(24, "O");
                dict.Add(25, "P");
                dict.Add(26, "Q");
                dict.Add(27, "R");
                dict.Add(28, "S");
                dict.Add(29, "T");
                dict.Add(30, "U");
                dict.Add(31, "V");
                dict.Add(32, "W");
                dict.Add(33, "X");
                dict.Add(34, "Y");
                dict.Add(35, "Z");

                string hignchar = lastitem.Code.Substring(0, 1);
                string lowchar = lastitem.Code.Substring(1, 1);

                int lowint = dict.Where(w => w.Value == lowchar).Select(s => s.Key).Single();
                int highint = dict.Where(w => w.Value == hignchar).Select(s => s.Key).Single();

                if (lowint == 35)
                {
                    lowint = 0;
                    highint += 1;
                }
                else
                {
                    lowint += 1;
                }

                Code = dict[highint] + dict[lowint];
            }
            else
            {
                Code = "01";
            }

            return string.Format("{0:00}", Code);
        }

       

        public IEnumerable SearchByText(string originalSource)
        {
            if (originalSource != null && originalSource.Length > 0)
            {
                var result = (from p in database.Manufacturers
                              where p.Void == false && p.IsClient == false &&
                              (p.Code.Contains(originalSource) || p.Name.Contains(originalSource) || p.ShortName.Contains(originalSource))
                              orderby p.Code ascending
                              select p);

                ManufacturersViewModelCollection rtn = new ManufacturersViewModelCollection();

                ResultBindingToViewModelCollection(rtn, result);

                return rtn;
            }
            else
            {
                var result = (from p in database.Manufacturers
                              where p.Void == false && p.IsClient == false
                              orderby p.Code ascending
                              select p);

                ManufacturersViewModelCollection rtn = new ManufacturersViewModelCollection();

                ResultBindingToViewModelCollection(rtn, result);

                return rtn;
            }
        }

      
        public override ManufacturersViewModel Query(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var result = database.Manufacturers
                    .Where(filiter)
                    .Where(w => w.Void == false)
                    .OrderBy(p => p.Code)
                    .SingleOrDefault();

                ManufacturersViewModel model = ResultBindingToViewModel(result);

                return model;
            }
            catch (Exception ex)
            {
                var model = new ManufacturersViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }
        /// <summary>
        /// 查詢單一個體的資料實體。
        /// </summary>
        /// <param name="ProjectId"></param>
        public ManufacturersViewModel QueryModel(Guid ManufacturersId)
        {
            try
            {
                return Query(q => q.Id == ManufacturersId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ManufacturersViewModelCollection QueryAll()
        {
            ManufacturersViewModelCollection rtn = new ManufacturersViewModelCollection();

            try
            {
                var result = from p in database.Manufacturers
                             where p.Void == false && p.IsClient == false
                             select p;

                ResultBindingToViewModelCollection(rtn, result);

                return rtn;
            }
            catch
            {
                return rtn;
            }
        }

        private void ResultBindingToViewModelCollection(ManufacturersViewModelCollection rtn, IQueryable<Manufacturers> result)
        {
            if (result.Any())
            {
                foreach (var item in result)
                {
                    ManufacturersViewModel model = ResultBindingToViewModel(item);

                    rtn.Add(model);
                }
            }
            else
            {
                rtn = new ManufacturersViewModelCollection();
                rtn.Add(CreateNew());
            }
        }

        private ManufacturersViewModel ResultBindingToViewModel(Manufacturers item)
        {
            ManufacturersViewModel model = BindingFromModel(item);

            model.Contracts = new ContactsViewModelCollection();

            if (item.Contacts.Any())
            {
                foreach (var row in item.Contacts)
                {
                    model.Contracts.Add(BindingFromModel<ContactsViewModel, Contacts>(row));
                }
            }

            if (model.Engineerings == null)
                model.Engineerings = new EngineeringViewModelCollection();

            model.PaymentTypes = new ObservableCollection<PaymentTypeViewModel>();

            if (database.PaymentTypes.Any())
            {
                foreach(var paytype in database.PaymentTypes.ToArray())
                {
                    model.PaymentTypes.Add(new PaymentTypeViewModel { Id = paytype.Id, PaymentTypeName = paytype.PaymentTypeName });
                }
            }
           
            return model;
        }

        public override ManufacturersViewModel CreateNew()
        {
            try
            {
                UserController uc = new UserController();
                var model = new ManufacturersViewModel()
                {
                    Id = Guid.NewGuid(),
                    Code = GetNextProjectSerialNumber(),
                    Contracts = new ContactsViewModelCollection(),
                    Engineerings = new EngineeringViewModelCollection()
                };
                return model;
            }
            catch (Exception ex)
            {
                ManufacturersViewModel m = new ManufacturersViewModel();
                m.Errors = new string[] { ex.Message, ex.StackTrace };
                return m;
            }
        }

        public override void Add(ManufacturersViewModel model)
        {
            var dbm = new Manufacturers();
            CopyToModel(dbm, model);

            if (model.Contracts.Any())
            {
                foreach (var item in model.Contracts)
                {
                    Contacts newContacts = new Contacts();
                    CopyToModel(newContacts, item);
                    dbm.Contacts.Add(newContacts);
                }
            }

            if (model.Materials.Any())
            {
                foreach (var item in model.Materials)
                {
                    Materials newContacts = new Materials();
                    CopyToModel(newContacts, item);

                }
            }

            database.Manufacturers.Add(dbm);
            database.SaveChanges();
        }

        public override ManufacturersViewModel Update(ManufacturersViewModel model)
        {
            try
            {
                UserController uc = new UserController();
                var LoginedUser = uc.GetCurrentLoginUser();
                var dbm = (from q in database.Manufacturers
                           where q.Id == model.Id && q.Void == false
                           select q).SingleOrDefault();

                if (dbm != null)
                {
                    CopyToModel(dbm, model);

                    if (model.Contracts.Any())
                    {
                        foreach (var item in model.Contracts)
                        {
                            Stack<Contacts> removeStack = new Stack<Contacts>();

                            foreach (var rowindb in dbm.Contacts)
                            {
                                if (model.Contracts.Where(w => w.Id == rowindb.Id).Any() == false)
                                {
                                    //remove(指資料真的被移除了)
                                    removeStack.Push(rowindb);
                                }
                            }

                            if (removeStack.Count > 0)
                            {
                                while (removeStack.Count > 0)
                                {
                                    dbm.Contacts.Remove(removeStack.Pop());
                                }
                            }

                            foreach (var row in model.Contracts)
                            {
                                if (dbm.Contacts.Where(w => w.Id == row.Id).Any())
                                {
                                    var foundinoriginal = dbm.Contacts.Where(w => w.Id == row.Id).Single();
                                    CopyToModel(foundinoriginal, row);
                                  //  database.Entry(foundinoriginal).State = System.Data.Entity.EntityState.Modified;
                                }
                                else
                                {
                                    Contacts newData = new Contacts();
                                    CopyToModel(newData, row);
                                    newData.CreateUserId = LoginedUser.UserId;
                                    dbm.Contacts.Add(newData);
                                }
                            }
                        }
                    }
                }
                //database.Entry(dbm).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();

                return Query(w => w.Id == model.Id);
            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
                return model;
            }

        }

        public override void Delete(ManufacturersViewModel model)
        {
            try
            {
                UserController controller = new UserController();

                var result = from p in database.Manufacturers
                             where p.Id == model.Id && p.Void == false
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    database.AccessLog.Add(new AccessLog() { ActionCode = 3, CreateTime = DateTime.Now, DataId = model.Id, UserId = controller.GetCurrentLoginUser().UserId });
                    database.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
            }
        }



        /// <summary>
        /// 儲存變更
        /// </summary>
        public override void SaveModel(ManufacturersViewModel model)
        {
            try
            {
                if (IsExists(q => q.Id == model.Id))
                {
                    Update(model);
                }
                else
                {
                    Add(model);
                    model = Query(x => x.Id == model.Id);
                }
            }
            catch(Exception ex)
            {
                setErrortoModel(model, ex);
            }
        }

        public override bool IsExists(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var result = database.Manufacturers.Where(filiter);

                return result.Any();
            }
            catch
            {

                return false;
            }
        }


    }
}
