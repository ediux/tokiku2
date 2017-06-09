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
                ManufacturersRepository repo = RepositoryHelper.GetManufacturersRepository(database);

                var result = (from p in repo.All()
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
                using (ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
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

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>> QueryViewManufacturersBussinessTranscations(Guid ManufacturersId)
        {
            ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>> rtn;

            try
            {
                View_ManufacturersBussinessTranscationsRepository repo = RepositoryHelper.GetView_ManufacturersBussinessTranscationsRepository(database);
                var result = repo
                    .Where(w => w.ManufacturersId == ManufacturersId)
                    .OrderBy(p => p.Code)
                    .ToList();

                ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>> model = ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>>
                    .CreateResultEntity(new Collection<View_ManufacturersBussinessTranscations>(result));

                return model;
            }
            catch (Exception ex)
            {

                rtn = ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAll()
        {
            ExecuteResultEntity<ICollection<Manufacturers>> rtn;

            try
            {
                using (ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var result = ManufacturersRepository
                                .Where(p => p.Void == false && p.IsClient == false)
                                .OrderBy(p => p.Code)
                                .ToList();

                    rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                        new Collection<Manufacturers>(result));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
                return rtn;
            }

        }



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
                ManufacturersRepository = RepositoryHelper.GetManufacturersRepository();
                ManufacturersRepository.Add(entity);
                ManufacturersRepository.UnitOfWork.Commit();
                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ManufacturersBussinessItems> CreateOrUpdateBussinessItems(ManufacturersBussinessItems entity)
        {
            try
            {
                ManufacturersBussinessItemsRepository repo = RepositoryHelper.GetManufacturersBussinessItemsRepository(database);
                var result = from q in repo.All()
                             where q.Id == entity.Id
                             select q;

                if (!result.Any())
                {
                    repo.Add(entity);
                    repo.UnitOfWork.Commit();
                }
                else
                {
                    var dbdata = result.Single();
                    Update(entity.Manufacturers, true);
                }


                repo.UnitOfWork.Commit();

                var rtn = from q in repo.All()
                          where q.Id == entity.Id
                          select q; ;

                return ExecuteResultEntity<ManufacturersBussinessItems>.CreateResultEntity(rtn.SingleOrDefault());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ManufacturersBussinessItems>.CreateErrorResultEntity(ex);

            }
        }

        public override ExecuteResultEntity<Manufacturers> Update(Manufacturers fromModel, bool isLastRecord = true)
        {
            try
            {
                using (ManufacturersRepository = RepositoryHelper.GetManufacturersRepository(database))
                {

                    var LoginedUser = GetCurrentLoginUser();
                    var dbm = (from q in ManufacturersRepository.All()
                               where q.Id == fromModel.Id && q.Void == false
                               select q).SingleOrDefault();

                    if (dbm != null)
                    {

                        var toDel = dbm.Contacts.Except(fromModel.Contacts).ToList();
                        var toAdd = fromModel.Contacts.Except(dbm.Contacts).ToList();

                        foreach (var delitem in toDel)
                        {
                            dbm.Contacts.Remove(delitem);
                        }

                        foreach (var additem in toAdd)
                        {
                            dbm.Contacts.Add(additem);
                        }

                        var toDel2 = dbm.ManufacturersBussinessItems.Except(fromModel.ManufacturersBussinessItems).ToList();
                        var toAdd2 = fromModel.ManufacturersBussinessItems.Except(dbm.ManufacturersBussinessItems).ToList();

                        foreach (var delitem in toDel2)
                        {
                            dbm.ManufacturersBussinessItems.Remove(delitem);
                        }

                        foreach (var additem in toAdd2)
                        {
                            dbm.ManufacturersBussinessItems.Add(additem);
                        }

                        //foreach (var item in fromModel.Contacts)
                        //{
                        //    Stack<Contacts> removeStack = new Stack<Contacts>();

                        //    foreach (var rowindb in dbm.Contacts)
                        //    {
                        //        if (fromModel.Contacts.Where(w => w.Id == rowindb.Id).Any() == false)
                        //        {
                        //            //remove(指資料真的被移除了)
                        //            removeStack.Push(rowindb);
                        //        }
                        //    }

                        //    if (removeStack.Count > 0)
                        //    {
                        //        while (removeStack.Count > 0)
                        //        {
                        //            dbm.Contacts.Remove(removeStack.Pop());
                        //        }
                        //    }

                        //    foreach (var row in fromModel.Contacts)
                        //    {
                        //        if (dbm.Contacts.Where(w => w.Id == row.Id).Any())
                        //        {
                        //            var foundinoriginal = dbm.Contacts.Where(w => w.Id == row.Id).Single();

                        //            foundinoriginal.Comment = row.Comment;
                        //            foundinoriginal.Dep = row.Dep;
                        //            foundinoriginal.EMail = row.EMail;
                        //            foundinoriginal.ExtensionNumber = row.ExtensionNumber;
                        //            foundinoriginal.Fax = row.Fax;
                        //            foundinoriginal.IsDefault = row.IsDefault;
                        //            foundinoriginal.IsPrincipal = row.IsPrincipal;
                        //            foundinoriginal.Manufacturers = row.Manufacturers;
                        //            foundinoriginal.Mobile = row.Mobile;
                        //            foundinoriginal.Name = row.Name;
                        //            foundinoriginal.Phone = row.Phone;
                        //            foundinoriginal.Title = row.Title;
                        //            foundinoriginal.Void = row.Void;

                        //        }
                        //        else
                        //        {

                        //            row.CreateUserId = LoginedUser.Result.UserId;
                        //            dbm.Contacts.Add(row);
                        //        }
                        //    }
                        //}

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

        public Task<ExecuteResultEntity<ICollection<TranscationCategories>>> GetTranscationCategoriesListAsync()
        {
            try
            {
                TranscationCategoriesRepository repo = RepositoryHelper.GetTranscationCategoriesRepository(database);

                return Task.FromResult(ExecuteResultEntity<ICollection<TranscationCategories>>.CreateResultEntity(
                    new Collection<TranscationCategories>(repo.All().ToList())));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<TranscationCategories>>.CreateErrorResultEntity(ex));


            }
        }

        public Task<ExecuteResultEntity<ICollection<MaterialCategories>>> GetMaterialCategoriesListAsync()
        {
            try
            {
                MaterialCategoriesRepository repo = RepositoryHelper.GetMaterialCategoriesRepository(database);

                var result = from q in repo.All()
                             select q;

                return Task.FromResult(ExecuteResultEntity<ICollection<MaterialCategories>>.CreateResultEntity(
                    new Collection<MaterialCategories>(result.ToList())));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<MaterialCategories>>.CreateErrorResultEntity(ex));


            }
        }

        public Task<ExecuteResultEntity<ICollection<View_BussinessItemsList>>> QueryBussinessItemsListAsync(Guid ManufacturersId)
        {
            try
            {
                View_BussinessItemsListRepository biListRepo = RepositoryHelper.GetView_BussinessItemsListRepository(database);

                var result = (from q in biListRepo.All()
                              select q).ToList();

                return Task.FromResult(ExecuteResultEntity<ICollection<View_BussinessItemsList>>.CreateResultEntity(new Collection<View_BussinessItemsList>(result)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<View_BussinessItemsList>>.CreateErrorResultEntity(ex));


            }
        }

    }
}
