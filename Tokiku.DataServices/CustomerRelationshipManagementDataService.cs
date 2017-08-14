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
    public class CustomerRelationshipManagementDataService : DataServiceBase, ICustomerRelationshipManagementDataService
    {
        private ICoreDataService _CoreDataService;
        private IUnitOfWork _UnitOfWork;
        private IManufacturersRepository _ManufacturersRepository;


        public CustomerRelationshipManagementDataService(IManufacturersRepository ManufacturersRepository,
            ICoreDataService CoreDataService) : base()
        {
            _CoreDataService = CoreDataService;
            _UnitOfWork = EntityLocator.Current.EFUnitOfWork;
            _ManufacturersRepository = ManufacturersRepository;
            _ManufacturersRepository.UnitOfWork = _UnitOfWork;
        }

        public Manufacturers Add(Manufacturers model)
        {
            try
            {
                model.IsClient = true;
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
                    addrow.IsClient = true;
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
                if (_ManufacturersRepository.Where(w => w.Id == Model.Id && w.IsClient == true)?.Count() > 0)
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

        public IEnumerable<Manufacturers> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> GetAll(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            try
            {
                var queryresult = from q in _ManufacturersRepository.All()
                                  where q.Void == false && q.IsClient == true
                                  orderby q.Code ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
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
                                   where q.Void == false && q.IsClient == true
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

        public void Remove(Manufacturers model)
        {

            try
            {
                model.Void = true;
                Update(model, w => w.Id == model.Id && w.IsClient == true);
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
            }

        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Manufacturers> SearchByText(string filiter)
        {
            throw new NotImplementedException();
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
    }
}