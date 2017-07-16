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
using Tokiku.Entity.ViewTables;

namespace Tokiku.Controllers
{
    public class ManufacturersManageController : BaseController<Manufacturers>
    {
        private ManufacturersBussinessItemsRepository BussinessItemsRepo;

        //private String sql;

        public ManufacturersManageController()
        {
            BussinessItemsRepo = (ManufacturersBussinessItemsRepository)this.GetReoisitory<ManufacturersBussinessItems>();
        }

        /// <summary>
        /// 取得廠商代碼流水號
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        private string GetNextProjectSerialNumber()
        {

            string Code = string.Empty;
            var repo = this.GetReoisitory();
            var lastitem = repo.All()
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
            //sql = " select distinct a.Id as Id, Code, a.Name as Name, Principal, UniformNumbers, " +
            //             " MainContactPerson, Phone, Address, Fax, FactoryPhone, FactoryAddress, " +
            //             " case when Void = 0 then '啟用' when Void = 1 then '停用' end as Void " +
            //        " from Manufacturers a " +
            //   " left join ManufacturersBussinessItems b on a.Id = b.ManufacturersId " +
            //       " where IsClient = 0 and (a.Name like '%'+@p0+'%' " +
            //                           " or b.Name like '%'+@p0+'%' " +
            //                           " or Principal like '%'+@p0+'%') " +
            //    " order by Code ";

            ExecuteResultEntity<ICollection<Manufacturers>> rtn;
            try
            {
                object[] obj = new object[] { originalSource };
                if (originalSource != null && originalSource.Length > 0)
                {
                    var ManufacturersRepository = this.GetReoisitory();
                    var queryresult = from q in ManufacturersRepository.All()
                                      where q.Void == false && q.IsClient == false &&
                                      (q.Name.Contains(originalSource) ||
                                    (q.ManufacturersBussinessItems != null && q.ManufacturersBussinessItems.Any(s => s.Name.Contains(originalSource)))
                                      || (q.Principal != null && q.Principal.Contains(originalSource)))
                                      orderby q.Code ascending
                                      select q;

                    rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                        new Collection<Manufacturers>(queryresult.ToList()));

                    return rtn;

                }
                else
                {
                    return QueryAll();
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }

        }


        public override ExecuteResultEntity<ICollection<Manufacturers>> Query(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {

                var ManufacturersRepository = this.GetReoisitory();
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

        public ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>> QueryViewManufacturersBussinessTranscations(Guid ManufacturersId)
        {
            ExecuteResultEntity<ICollection<View_ManufacturersBussinessTranscations>> rtn;

            try
            {
                var repo =
                    this.GetReoisitory<View_ManufacturersBussinessTranscations>();

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

        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAllForCombox()
        {
            //sql = " select Id, Code, Name, ShortName, Principal, UniformNumbers, MainContactPerson, " +
            //             " Phone, Address, Fax, FactoryPhone, FactoryAddress, " +
            //             " case when Void = 0 then '啟用' when Void = 1 then '停用' end as Void " +
            //        " from Manufacturers where IsClient = 0 order by Code ";

            ExecuteResultEntity<ICollection<Manufacturers>> rtn;

            try
            {
                var ManufacturersRepository = this.GetReoisitory();

                var queryresult = from q in ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false &&
                                  ((q.Address != null) && q.Address.Length > 0)
                                  select q;

                rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                    new Collection<Manufacturers>(queryresult.ToList()));

                return rtn;
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
                return rtn;
            }

        }
        public ExecuteResultEntity<Manufacturers> QuerySingle(Guid ManufacturersId)
        {
            ExecuteResultEntity<Manufacturers> rtn;

            try
            {
                var ManufacturersRepository = this.GetReoisitory().All();

                var queryresult = from q in ManufacturersRepository
                                  where q.Void == false && q.IsClient == false
                                  && q.Id == ManufacturersId
                                  orderby q.Code ascending
                                  select q;

                return ExecuteResultEntity<Manufacturers>.CreateResultEntity(queryresult.SingleOrDefault());

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        public ExecuteResultEntity<ICollection<Manufacturers>> QueryAll()
        {
            //sql = " select Id, Code, Name, ShortName, Principal, UniformNumbers, MainContactPerson, " +
            //             " Phone, Address, Fax, FactoryPhone, FactoryAddress, " +
            //             " case when Void = 0 then '啟用' when Void = 1 then '停用' end as Void " +
            //        " from Manufacturers where IsClient = 0 order by Code ";

            ExecuteResultEntity<ICollection<Manufacturers>> rtn;

            try
            {
                var ManufacturersRepository = this.GetReoisitory();

                var queryresult = from q in ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  orderby q.Code ascending
                                  select q;

                rtn = ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                    new Collection<Manufacturers>(queryresult.ToList()));

                return rtn;
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

        //public override ExecuteResultEntity Add(Manufacturers entity, bool isLastRecord = true)
        //{
        //    try
        //    {
        //        var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository();
        //        ManufacturersRepository.Add(entity);
        //        ManufacturersRepository.UnitOfWork.Commit();
        //        return ExecuteResultEntity.CreateResultEntity();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExecuteResultEntity.CreateErrorResultEntity(ex);
        //    }
        //}

        public ExecuteResultEntity<ManufacturersBussinessItems> CreateOrUpdateBussinessItems(ManufacturersBussinessItems entity)
        {
            try
            {

                var repo =
                    this.GetReoisitory<ManufacturersBussinessItems>();

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

        //public override ExecuteResultEntity<Manufacturers> Update(Manufacturers fromModel, bool isLastRecord = true)
        //{
        //    try
        //    {
        //        var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository();


        //        AccessLogRepository accesslog = RepositoryHelper.GetAccessLogRepository(database);

        //        //var LoginedUser = GetCurrentLoginUser();

        //        var dbm = (from q in ManufacturersRepository.All()
        //                   where q.Id == fromModel.Id
        //                   select q).SingleOrDefault();

        //        if (dbm != null)
        //        {
        //            CheckAndUpdateValue(fromModel, dbm);

        //            var toDel = dbm.Contacts.Select(s => s.Id).Except(fromModel.Contacts.Select(s => s.Id)).ToList();
        //            var toAdd = fromModel.Contacts.Select(s => s.Id).Except(dbm.Contacts.Select(s => s.Id)).ToList();
        //            var samerows = dbm.Contacts.Select(s => s.Id).Intersect(fromModel.Contacts.Select(s => s.Id)).ToList();

        //            Stack<Contacts> RemoveStack = new Stack<Contacts>();
        //            Stack<Contacts> AddStack = new Stack<Contacts>();

        //            foreach (var delitem in toDel)
        //            {
        //                RemoveStack.Push(dbm.Contacts.Where(w => w.Id == delitem).Single());
        //            }

        //            foreach (var additem in toAdd)
        //            {
        //                AddStack.Push(fromModel.Contacts.Where(w => w.Id == additem).Single());
        //            }

        //            while (RemoveStack.Count > 0)
        //            {
        //                dbm.Contacts.Remove(RemoveStack.Pop());
        //            }

        //            while (AddStack.Count > 0)
        //            {
        //                dbm.Contacts.Add(AddStack.Pop());
        //            }

        //            foreach (var sameitem in samerows)
        //            {
        //                Contacts Source = fromModel.Contacts.Where(w => w.Id == sameitem).Single();
        //                Contacts Target = dbm.Contacts.Where(w => w.Id == sameitem).Single();
        //                CheckAndUpdateValue(Source, Target);
        //            }

        //            var repo2 = RepositoryHelper.GetManufacturersBussinessItemsRepository();

        //            var toDelBI = repo2.Where(w => w.ManufacturersId == dbm.Id).Select(s => s.Id).Except(fromModel.ManufacturersBussinessItems.Select(s => s.Id)).ToList();
        //            var toAddBI = fromModel.ManufacturersBussinessItems.Select(s => s.Id).Except(repo2.Where(w => w.ManufacturersId == dbm.Id).Select(s => s.Id)).ToList();
        //            var samerowsBI = dbm.ManufacturersBussinessItems.Select(s => s.Id).Intersect(fromModel.ManufacturersBussinessItems.Select(s => s.Id)).ToList();


        //            Stack<ManufacturersBussinessItems> RemoveStackBI = new Stack<ManufacturersBussinessItems>();
        //            Stack<ManufacturersBussinessItems> AddStackBI = new Stack<ManufacturersBussinessItems>();

        //            bool isuserepo2 = false;

        //            foreach (var delitem in toDelBI)
        //            {

        //                RemoveStackBI.Push(repo2.Where(w => w.Id == delitem).Single());
        //            }

        //            foreach (var additem in toAddBI)
        //            {
        //                AddStackBI.Push(fromModel.ManufacturersBussinessItems.Where(w => w.Id == additem).ToList().Single());
        //            }

        //            while (RemoveStackBI.Count > 0)
        //            {
        //                isuserepo2 = true;
        //                repo2.Delete(RemoveStackBI.Pop());
        //                //dbm.ManufacturersBussinessItems.Remove();
        //            }

        //            while (AddStackBI.Count > 0)
        //            {
        //                isuserepo2 = true;
        //                var en = AddStackBI.Pop();
        //                repo2.Add(new ManufacturersBussinessItems()
        //                {
        //                    Id = en.Id,
        //                    ManufacturersId = en.ManufacturersId,
        //                    MaterialCategoriesId = en.MaterialCategoriesId,
        //                    PaymentTypeId = en.PaymentTypeId,
        //                    Name = en.Name,
        //                    TicketPeriodId = en.TicketPeriodId,
        //                    TranscationCategoriesId = en.TranscationCategoriesId
        //                });
        //                //dbm.ManufacturersBussinessItems.Add(AddStackBI.Pop());
        //            }

        //            if (isuserepo2)
        //                repo2.UnitOfWork.Commit();

        //            foreach (var sameitem in samerowsBI)
        //            {
        //                ManufacturersBussinessItems Source = fromModel.ManufacturersBussinessItems.Where(w => w.Id == sameitem).Single();
        //                ManufacturersBussinessItems Target = dbm.ManufacturersBussinessItems.Where(w => w.Id == sameitem).Single();
        //                Target.ManufacturersId = Source.ManufacturersId;
        //                Target.MaterialCategoriesId = Source.MaterialCategoriesId;
        //                Target.Name = Source.Name;
        //                Target.PaymentTypeId = Source.PaymentTypeId;
        //                Target.TicketPeriodId = Source.TicketPeriodId;
        //                Target.TranscationCategoriesId = Source.TranscationCategoriesId;

        //            }


        //        }

        //        ManufacturersRepository.UnitOfWork.Commit();

        //        //accesslog.Add(new AccessLog()
        //        //{
        //        //    ActionCode = (Byte)ActionCodes.Update,
        //        //    CreateTime = DateTime.Now,
        //        //    DataId = dbm.Id.ToString("N"),
        //        //    Reason = "更新資料",
        //        //    UserId = LoginedUser.Result.UserId
        //        //});

        //        var rtn = Query(w => w.Id == fromModel.Id);
        //        return ExecuteResultEntity<Manufacturers>.CreateResultEntity(rtn.Result.SingleOrDefault());


        //    }
        //    catch (Exception ex)
        //    {
        //        return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
        //    }
        //}

        public override ExecuteResultEntity<Manufacturers> Delete(Manufacturers entity, bool isDeleteRightNow = false)
        {
            try
            {
                entity.Void = true;
                var result = Update(entity, !isDeleteRightNow);
                return result;
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Manufacturers>.CreateErrorResultEntity(ex);
            }
        }

        public override bool IsExists(Expression<Func<Manufacturers, bool>> filiter)
        {
            try
            {
                var repo = this.GetReoisitory();

                var result = repo.Where(filiter);
                return result.Any();
            }
            catch
            {
                return false;
            }
        }

        public ExecuteResultEntity<TranscationCategories> QuerySingleTranscationCategory(int TranscationCategoriesId)
        {
            try
            {
                var repo = this.GetReoisitory<TranscationCategories>();

                var result = (from q in repo.All()
                              where q.Id == TranscationCategoriesId
                              select q).SingleOrDefault();

                return ExecuteResultEntity<TranscationCategories>.CreateResultEntity(
                    result);

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<TranscationCategories>
                    .CreateErrorResultEntity(ex);


            }
        }

        public ExecuteResultEntity<ICollection<TranscationCategories>> GetTranscationCategoriesList()
        {
            try
            {
                var repo = this.GetReoisitory<TranscationCategories>();

                return ExecuteResultEntity<ICollection<TranscationCategories>>.CreateResultEntity(
                    new Collection<TranscationCategories>(repo.All().ToList()));

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<TranscationCategories>>.CreateErrorResultEntity(ex);


            }
        }

        public Task<ExecuteResultEntity<ICollection<TranscationCategories>>> GetTranscationCategoriesListAsync()
        {
            try
            {
                return Task.FromResult(GetTranscationCategoriesList());
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<TranscationCategories>>.CreateErrorResultEntity(ex));
            }
        }

        public ExecuteResultEntity<ICollection<MaterialCategories>> GetMaterialCategoriesList()
        {
            try
            {
                var repo = this.GetReoisitory<MaterialCategories>();

                var result = from q in repo.All()
                             select q;

                return ExecuteResultEntity<ICollection<MaterialCategories>>.CreateResultEntity(
                    new Collection<MaterialCategories>(result.ToList()));

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<MaterialCategories>>.CreateErrorResultEntity(ex);
            }
        }

        public Task<ExecuteResultEntity<ICollection<MaterialCategories>>> GetMaterialCategoriesListAsync()
        {
            try
            {
                return Task.FromResult(GetMaterialCategoriesList());
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<MaterialCategories>>.CreateErrorResultEntity(ex));
            }
        }

        public ExecuteResultEntity<ICollection<ManufacturersBussinessItems>> QueryBussinessItemsList(Guid ManufacturersId)
        {
            try
            {
                var biListRepo = this.GetReoisitory<ManufacturersBussinessItems>();

                var result = (from q in biListRepo.All()
                              where q.ManufacturersId == ManufacturersId
                              select q).ToList();

                return ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>
                    .CreateResultEntity(
                    new Collection<ManufacturersBussinessItems>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateErrorResultEntity(ex);
            }
        }

        public Task<ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>> QueryBussinessItemsListAsync(Guid ManufacturersId)
        {
            try
            {
                var biListRepo = this.GetReoisitory<ManufacturersBussinessItems>();

                var result = (from q in biListRepo.All()
                              where q.ManufacturersId == ManufacturersId
                              select q).ToList();

                return Task.FromResult(ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateResultEntity(new Collection<ManufacturersBussinessItems>(result)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 連動下拉單查詢交易品項
        /// </summary>
        /// <param name="MaterialCategoriesId"></param>
        /// <returns></returns>
        public ExecuteResultEntity<ICollection<ManufacturersBussinessItems>> GetBussinessItemsListWithMaterialCategories(Guid MaterialCategoriesId)
        {
            //, Guid TranscationCategoriesId, Guid TicketPeriodId
            try
            {
                var repo = this.GetReoisitory<ManufacturersBussinessItems>();
                //database = repo.UnitOfWork;

                var remap = (from q in repo.All()
                             where q.MaterialCategoriesId == MaterialCategoriesId
                             select q).Distinct();

                return ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateResultEntity(
                    new Collection<ManufacturersBussinessItems>(remap.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 連動下拉單查詢交易品項
        /// </summary>
        /// <param name="MaterialCategoriesId"></param>
        /// <returns></returns>
        public Task<ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>> GetBussinessItemsListWithMaterialCategoriesAsync(Guid MaterialCategoriesId)
        {
            try
            {
                return Task.FromResult(GetBussinessItemsListWithMaterialCategories(MaterialCategoriesId));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<ManufacturersBussinessItems>>.CreateErrorResultEntity(ex));
            }
        }

        public ExecuteResultEntity<ICollection<Manufacturers>> GetManufacturersWithBusinessItem(Guid MaterialCategoriesId, string BusinessItem)
        {
            try
            {
                var repo = this.GetReoisitory();


                var matchedresult = (from q in repo.All()
                                     from s in q.ManufacturersBussinessItems
                                     where s.MaterialCategoriesId == MaterialCategoriesId
                                     && s.Name.Contains(BusinessItem)
                                     select q).Distinct().ToList();

                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateResultEntity(
                    new Collection<Manufacturers>(matchedresult));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex);
            }
        }

        public Task<ExecuteResultEntity<ICollection<Manufacturers>>> GetManufacturersWithBusinessItemAsync(Guid MaterialCategoriesId, string BusinessItem)
        {
            try
            {
                return Task.FromResult(GetManufacturersWithBusinessItem(MaterialCategoriesId, BusinessItem));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<Manufacturers>>.CreateErrorResultEntity(ex));
            }
        }
    }
}
