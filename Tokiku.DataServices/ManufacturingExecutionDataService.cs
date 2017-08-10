using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #endregion

        #region 建構式
        public ManufacturingExecutionDataService(IUnitOfWork UnitOfWork,
            ICoreDataService CoreDataService,
            IManufacturersRepository ManufacturersRepository,
            IManufacturersBussinessItemsRepository ManufacturersBussinessItemsRepository)
        {
            _UnitOfWork = UnitOfWork;

            _CoreDataService = CoreDataService;

            _ManufacturersRepository = ManufacturersRepository;
            _ManufacturersRepository.UnitOfWork = _UnitOfWork;

            _ManufacturersBussinessItemsRepository = ManufacturersBussinessItemsRepository;
            _ManufacturersBussinessItemsRepository.UnitOfWork = _UnitOfWork;
        }
        #endregion

        #region 廠商管理
        public Manufacturers Add(Manufacturers model)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Manufacturers> AddRange(IEnumerable<Manufacturers> models)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Manufacturers> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Manufacturers> GetAll(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }
        public Manufacturers GetSingle(Expression<Func<Manufacturers, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public Collection<Manufacturers> QueryAll()
        {
            try
            {
                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == false
                                  orderby q.Code ascending
                                  select q;

                return new Collection<Manufacturers>(
                   queryresult.ToList());
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return new Collection<Manufacturers>();
            }
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
            throw new NotImplementedException();
        }
        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
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
                                    (q.ManufacturersBussinessItems != null && q.ManufacturersBussinessItems.Any(s => s.Name.Contains(filiter)))
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
            throw new NotImplementedException();
        }
        public IEnumerable<Manufacturers> UpdateRange(IEnumerable<Manufacturers> MultiSource, Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        ICollection<Manufacturers> IDataService<Manufacturers>.SearchByText(string filiter)
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
        public IEnumerable<ManufacturersBussinessItems> GetAll(Expression<Func<ManufacturersBussinessItems, bool>> filiter = null)
        {
            throw new NotImplementedException();
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

    }
}