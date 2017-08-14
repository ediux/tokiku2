using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 生產製程管理資料存取服務
    /// </summary>
    public class ManufacturingExecutionDataService : DataServiceBase, IManufacturingExecutionDataService
    {
        #region 內部宣告
        private IUnitOfWork _UnitOfWork;
        private ICoreDataService _CoreDataService;
        private IManufacturersRepository _ManufacturersRepository;
        private IManufacturersBussinessItemsRepository _ManufacturersBussinessItemsRepository;
        private ISupplierTranscationItemRepository _SupplierTranscationItemRepository;
        #endregion

        #region 建構式
        public ManufacturingExecutionDataService(IUnitOfWork UnitOfWork,
            ICoreDataService CoreDataService,
            IManufacturersRepository ManufacturersRepository,
            IManufacturersBussinessItemsRepository ManufacturersBussinessItemsRepository,
            ISupplierTranscationItemRepository SupplierTranscationItemRepository)
        {
            _UnitOfWork = UnitOfWork;

            _CoreDataService = CoreDataService;

            _ManufacturersRepository = ManufacturersRepository;
            _ManufacturersRepository.UnitOfWork = _UnitOfWork;

            _ManufacturersBussinessItemsRepository = ManufacturersBussinessItemsRepository;
            _ManufacturersBussinessItemsRepository.UnitOfWork = _UnitOfWork;

            _SupplierTranscationItemRepository = SupplierTranscationItemRepository;
            _SupplierTranscationItemRepository.UnitOfWork = _UnitOfWork;
        }
        #endregion

        #region 廠商管理
        public string GetNextProjectSerialNumber()
        {
            string Code = string.Empty;
            var repo = _ManufacturersRepository;
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

        public Manufacturers Add(Manufacturers model)
        {
            try
            {
                model.IsClient = false;
                model = _ManufacturersRepository.Add(model);
                _ManufacturersRepository.UnitOfWork.Commit();
                _ManufacturersRepository.Reload(model);

                _CoreDataService.AddAccessLog("Manufacturers", model.Id.ToString(),
                    model.CreateUserId, "Insert Data", ActionCodes.Create);

                return model;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<Manufacturers> AddRange(IEnumerable<Manufacturers> models)
        {
            try
            {

                foreach (var addrow in models)
                {
                    addrow.IsClient = false;
                    var newdata = _ManufacturersRepository.Add(addrow);

                    _CoreDataService.AddAccessLog("Manufacturers", newdata.Id.ToString(),
                   newdata.CreateUserId, "Insert Data", ActionCodes.Create, false);
                }

                _ManufacturersRepository.UnitOfWork.Commit();

                return ((IManufacturersDataService)this).GetAll(w => models.Where(a => a.Id == w.Id).Any());
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<Manufacturers> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> GetAll(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            try
            {
                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  orderby q.Code ascending
                                  select q;

                if (filiter != null)
                    return new Collection<Manufacturers>(queryresult.Where(filiter).ToList());

                return new Collection<Manufacturers>(queryresult.ToList());
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
        }

        public Manufacturers GetSingle(Expression<Func<Manufacturers, bool>> filiter)
        {

            try
            {

                var queryresult = (from q in _ManufacturersRepository.All()
                                   where q.Void == false && q.IsClient == false
                                   orderby q.Code ascending
                                   select q);

                if (filiter != null)
                    return queryresult.Where(filiter).SingleOrDefault();

                return queryresult.SingleOrDefault();

            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public Collection<Manufacturers> QueryAll()
        {
            return new Collection<Manufacturers>(((IManufacturersDataService)this).GetAll().ToList());
        }

        public Manufacturers QuerySingle(Guid ManufacturersId)
        {
            try
            {

                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  && q.Id == ManufacturersId
                                  orderby q.Code ascending
                                  select q;

                return queryresult.SingleOrDefault();
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public void Remove(Manufacturers model)
        {
            model.Void = true;
            Update(model, w => w.Id == model.Id && w.IsClient == false);
        }
        public void RemoveAll()
        {
            ((IManufacturersDataService)this).RemoveWhere();
        }

        public void RemoveWhere(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            var removefor = GetAll(filiter);

            foreach (var item in removefor)
            {
                item.Void = true;
                string updateContext = JsonConvert.SerializeObject(item);
                _CoreDataService.AddAccessLog("Manufacturers", item.Id.ToString(), _CoreDataService.GetCurrentLoginedUser().UserId,
                    "資料更新:" + updateContext,
                    ActionCodes.Update, false);
            }

            _ManufacturersRepository.UnitOfWork.Commit();
        }

        public Collection<Manufacturers> SearchByText(string filiter)
        {
            try
            {
                if (filiter != null && filiter.Length > 0)
                {

                    var queryresult = from q in _ManufacturersRepository.All()
                                      where q.Void == false && q.IsClient == false &&
                                      (q.Name.Contains(filiter) ||
                                    (q.ManufacturersBussinessItems != null && q.ManufacturersBussinessItems.Any(s => s.TradingItems.Name.Contains(filiter)))
                                      || (q.Principal != null && q.Principal.Contains(filiter)))
                                      orderby q.Code ascending
                                      select q;



                    return new Collection<Manufacturers>(queryresult.ToList());

                }
                else
                {
                    return QueryAll();
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
        }
        public Manufacturers Update(Manufacturers Source, Expression<Func<Manufacturers, bool>> filiter = null)
        {
            try
            {
                var repo = _ManufacturersRepository;

                if (repo == null)
                {
                    setErrortoModel(string.Format("Can't found data repository of {0}.", typeof(Users).Name));
                    return Source;
                }

                string updateContext = JsonConvert.SerializeObject(Source);

                if (filiter != null)
                {
                    var fromdatabase = GetSingle(filiter);

                    if (fromdatabase == null)
                        throw new NullReferenceException("此符合此條件的資料不存在於資料庫!");



                    repo.UnitOfWork.Commit();
                }
                else
                {
                    repo.UnitOfWork.Context.Entry(Source).State = EntityState.Modified;
                    repo.UnitOfWork.Commit();
                }

                //新增一筆存取紀錄
                _CoreDataService.AddAccessLog(typeof(Manufacturers).Name,
                    Source.Id.ToString(), _CoreDataService.GetCurrentLoginedUser()?.UserId,
                    "資料更新:" + updateContext, ActionCodes.Update);

                return repo.Reload(Source);
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return Source;
            }
        }
        public IEnumerable<Manufacturers> UpdateRange(IEnumerable<Manufacturers> MultiSource, Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        ICollection<Manufacturers> IDataService<Manufacturers>.SearchByText(string filiter)
        {
            ICollection<Manufacturers> rtn;
            try
            {
                if (filiter != null && filiter.Length > 0)
                {

                    var queryresult = from q in _ManufacturersRepository.All()
                                      where q.Void == false && q.IsClient == false &&
                                      (q.Name.Contains(filiter) ||
                                    (q.ManufacturersBussinessItems != null && q.ManufacturersBussinessItems.Any(s => s.TradingItems.Name.Contains(filiter)))
                                      || (q.Principal != null && q.Principal.Contains(filiter)))
                                      orderby q.Code ascending
                                      select q;

                    rtn =
                        new Collection<Manufacturers>(queryresult.ToList());

                    return rtn;

                }
                else
                {
                    return QueryAll();
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
        }

        public void CreateOrUpdate(Manufacturers Model)
        {
            try
            {
                if (_ManufacturersRepository == null)
                {
                    setErrortoModel(string.Format("Can't found data repository of {0}.", typeof(Users).Name));
                    return;
                }

                //檢查資料庫資料是否存在?
                if (_ManufacturersRepository.Where(w => w.Id == Model.Id && w.IsClient == false)?.Count() > 0)
                {
                    //repo.UnitOfWork.Context.Entry(entity).State = EntityState.Detached;

                    var update_result = ((IManufacturersDataService)this).Update(Model);

                    if (HasError)
                    {
                        setErrortoModel("更新資料時發生錯誤!");
                        return;
                    }

                    Model = _ManufacturersRepository.Reload(Model);
                }
                else
                {
                    var add_result = ((IManufacturersDataService)this).Add(Model);

                    if (HasError)
                    {
                        Errors = (new string[] { "新增資料發生錯誤!" }).Concat(Errors);
                        HasError = true;
                        return;
                    }

                    Model = _ManufacturersRepository.Reload(Model);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
            }
        }
        public void CreateOrUpdate(IEnumerable<Manufacturers> Model)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 營業項目管理
        public ManufacturersBussinessItems Add(ManufacturersBussinessItems model)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ManufacturersBussinessItems> AddRange(IEnumerable<ManufacturersBussinessItems> models)
        {
            throw new NotImplementedException();
        }
        public void CreateOrUpdate(ManufacturersBussinessItems Model)
        {
            throw new NotImplementedException();
        }
        public void CreateOrUpdate(IEnumerable<ManufacturersBussinessItems> Model)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ManufacturersBussinessItems> GetAll(Expression<Func<ManufacturersBussinessItems, bool>> filiter = null)
        {
            try
            {
                var biListRepo = _ManufacturersBussinessItemsRepository;

                var result = from q in biListRepo.All()
                             select q;

                if (filiter != null)
                {
                    return result.Where(filiter);
                }

                return result;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }
        public ManufacturersBussinessItems GetSingle(Expression<Func<ManufacturersBussinessItems, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(ManufacturersBussinessItems model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<ManufacturersBussinessItems, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public ManufacturersBussinessItems Update(ManufacturersBussinessItems Source, Expression<Func<ManufacturersBussinessItems, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufacturersBussinessItems> UpdateRange(IEnumerable<ManufacturersBussinessItems> MultiSource, Expression<Func<ManufacturersBussinessItems, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ManufacturersBussinessItems> IDataService<ManufacturersBussinessItems>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<ManufacturersBussinessItems> IDataService<ManufacturersBussinessItems>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region 供應商交易紀錄存取服務
        public SupplierTranscationItem Add(SupplierTranscationItem model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierTranscationItem> AddRange(IEnumerable<SupplierTranscationItem> models)
        {
            throw new NotImplementedException();
        }

        public SupplierTranscationItem GetSingle(Expression<Func<SupplierTranscationItem, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierTranscationItem> GetAll(Expression<Func<SupplierTranscationItem, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public SupplierTranscationItem Update(SupplierTranscationItem Source, Expression<Func<SupplierTranscationItem, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierTranscationItem> UpdateRange(IEnumerable<SupplierTranscationItem> MultiSource, Expression<Func<SupplierTranscationItem, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(SupplierTranscationItem model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<SupplierTranscationItem, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SupplierTranscationItem> IDataService<SupplierTranscationItem>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<SupplierTranscationItem> IDataService<SupplierTranscationItem>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(SupplierTranscationItem Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<SupplierTranscationItem> Model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 專案管理
        public Projects Add(Projects model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projects> AddRange(IEnumerable<Projects> models)
        {
            throw new NotImplementedException();
        }

        public Projects GetSingle(Expression<Func<Projects, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projects> GetAll(Expression<Func<Projects, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public Projects Update(Projects Source, Expression<Func<Projects, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projects> UpdateRange(IEnumerable<Projects> MultiSource, Expression<Func<Projects, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Projects model)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Projects, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Projects> IDataService<Projects>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<Projects> IDataService<Projects>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(Projects Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<Projects> Model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}