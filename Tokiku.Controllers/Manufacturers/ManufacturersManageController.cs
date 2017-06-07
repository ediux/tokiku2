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

namespace Tokiku.Controllers
{
    public class ManufacturersManageController : BaseController<Manufacturers>
    {
        private ManufacturersRepository ManufacturersRepository;
        private ManufacturersBussinessItemsRepository BussinessItemsRepo;

        public ManufacturersManageController()
        {
            ManufacturersRepository = RepositoryHelper.GetManufacturersRepository(database);
            BussinessItemsRepo = RepositoryHelper.GetManufacturersBussinessItemsRepository(database);
        }

        /// <summary>
        /// 取得廠商代碼流水號
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        private string GetNextProjectSerialNumber()
        {
            string Code = string.Empty;
            var lastitem = ManufacturersRepository.All()
                .OrderByDescending(s => s.Code)
                .FirstOrDefault();

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

        public ExecuteResultEntity<ICollection<Manufacturers>> SearchByText(string originalSource)
        {
            if (originalSource != null && originalSource.Length > 0)
            {
                var result = (from p in ManufacturersRepository.All()
                              from b in p.ManufacturersBussinessItems
                              where p.Void == false && p.IsClient == false &&
                              (p.Name.Contains(originalSource) || p.Principal.Contains(originalSource) || b.Name.Contains(originalSource))
                              orderby p.Code ascending
                              select p);

                ExecuteResultEntity<ICollection<Manufacturers>> rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(new Collection<Manufacturers>(result.ToList()));

                return rtn;
            }
            else
            {
                var result = (from p in ManufacturersRepository.All()
                              where p.Void == false && p.IsClient == false
                              orderby p.Code ascending
                              select p);

                ExecuteResultEntity<ICollection<Manufacturers>> rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(new Collection<Manufacturers>(result.ToList()));
                return rtn;
            }
        }


        public override ExecuteResultEntity<ICollection<Manufacturers>> Query(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var result = ManufacturersRepository
                    .Where(filiter)
                    .Where(w => w.Void == false)
                    .OrderBy(p => p.Code)
                    .ToList();

                ExecuteResultEntity<ICollection<Manufacturers>> model = ExecuteResultEntity<ICollection<Manufacturers>>
                    .CreateResultEntity(new Collection<Manufacturers>(result));

                return model;
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }
        }


        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAll()
        {
            ExecuteResultEntity<ICollection<Manufacturers>> rtn;

            try
            {
                using (database)
                {
                    var result = from p in ManufacturersRepository.All()
                                 where p.Void == false && p.IsClient == false
                                 orderby p.Code ascending
                                 select p;

                    rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                        new Collection<Manufacturers>(result.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
                return rtn;
            }

        }

        //private void ResultBindingToViewModelCollection(ManufacturersViewModelCollection rtn, IQueryable<Manufacturers> result)
        //{
        //    if (result.Any())
        //    {
        //        foreach (var item in result)
        //        {
        //            ManufacturersViewModel model = ResultBindingToViewModel(item);

        //            rtn.Add(model);
        //        }
        //    }
        //    else
        //    {
        //        rtn = new ManufacturersViewModelCollection();
        //    }
        //}

        //private ManufacturersViewModel ResultBindingToViewModel(Manufacturers item)
        //{
        //    ManufacturersViewModel model = BindingFromModel(item);

        //    model.Contracts = new ContactsViewModelCollection();

        //    if (item.Contacts.Any())
        //    {
        //        foreach (var row in item.Contacts)
        //        {
        //            model.Contracts.Add(BindingFromModel<ContactsViewModel, Contacts>(row));
        //        }
        //    }

        //    if (model.Engineerings == null)
        //        model.Engineerings = new EngineeringViewModelCollection();

        //    model.PaymentTypes = new ObservableCollection<PaymentTypeViewModel>();

        //    if (database.PaymentTypes.Any())
        //    {
        //        foreach (var paytype in database.PaymentTypes.ToArray())
        //        {
        //            model.PaymentTypes.Add(new PaymentTypeViewModel { Id = paytype.Id, PaymentTypeName = paytype.PaymentTypeName });
        //        }
        //    }

        //    return model;
        //}

        public override ExecuteResultEntity<Manufacturers> CreateNew()
        {
            try
            {
                StartUpWindowController uc = new StartUpWindowController();
                var model = new Manufacturers()
                {
                    Id = Guid.NewGuid(),
                    Code = GetNextProjectSerialNumber(),
                    Contacts = new Collection<Contacts>()
                };
                return ExecuteResultEntity<Manufacturers>.CreateResultEntity(model);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
            }
        }

        public override ExecuteResultEntity Add(Manufacturers entity, bool isLastRecord = true)
        {
            try
            {

                var dbm = new Manufacturers();


                if (entity.Contacts.Any())
                {
                    foreach (var item in entity.Contacts)
                    {
                        Contacts newContacts = new Contacts();
                        //CopyToModel(newContacts, item);
                        dbm.Contacts.Add(newContacts);
                    }
                }

                //if (entity.Any())
                //{
                //    foreach (var item in model.Materials)
                //    {
                //        Materials newContacts = new Materials();
                //        //CopyToModel(newContacts, item);

                //    }
                //}
                //ManufacturersRepository.Add(dbm);
                //ManufacturersRepository.UnitOfWork.Commit();

                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        public override ExecuteResultEntity<Manufacturers> Update(Manufacturers fromModel, bool isLastRecord = true)
        {
            try
            {
                using (database)
                {

                    var LoginedUser = GetCurrentLoginUser();
                    var dbm = (from q in ManufacturersRepository.All()
                               where q.Id == fromModel.Id && q.Void == false
                               select q).SingleOrDefault();

                    if (dbm != null)
                    {


                        if (fromModel.Contacts.Any())
                        {
                            foreach (var item in fromModel.Contacts)
                            {
                                Stack<Contacts> removeStack = new Stack<Contacts>();

                                foreach (var rowindb in dbm.Contacts)
                                {
                                    if (fromModel.Contacts.Where(w => w.Id == rowindb.Id).Any() == false)
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

                                foreach (var row in fromModel.Contacts)
                                {
                                    if (dbm.Contacts.Where(w => w.Id == row.Id).Any())
                                    {
                                        var foundinoriginal = dbm.Contacts.Where(w => w.Id == row.Id).Single();
                                        //CopyToModel(foundinoriginal, row);
                                        //  database.Entry(foundinoriginal).State = System.Data.Entity.EntityState.Modified;
                                    }
                                    else
                                    {
                                        Contacts newData = new Contacts();
                                        //CopyToModel(newData, row);
                                        newData.CreateUserId = LoginedUser.Result.UserId;
                                        dbm.Contacts.Add(newData);
                                    }
                                }
                            }
                        }
                    }
                    //database.Entry(dbm).State = System.Data.Entity.EntityState.Modified;
                    ManufacturersRepository.UnitOfWork.Commit();

                    var rtn = Query(w => w.Id == fromModel.Id);
                    return ExecuteResultEntity<Manufacturers>.CreateResultEntity(rtn.Result.SingleOrDefault());
                }

            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
            }


        }

        public override ExecuteResultEntity Delete(Expression<Func<Manufacturers, bool>> condtion)
        {
            try
            {

                var result = ManufacturersRepository
                    .Where(condtion)
                    .Where(p => p.Void == false);

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;

                    return ExecuteResultEntity.CreateResultEntity();
                }

                return ExecuteResultEntity.CreateErrorResultEntity("Data not found.");
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }





        public override bool IsExists(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var result = ManufacturersRepository.Where(filiter);
                return result.Any();
            }
            catch
            {
                return false;
            }
        }


    }
}
