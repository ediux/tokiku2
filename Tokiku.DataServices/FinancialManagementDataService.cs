using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 財務管理資料存取服務
    /// </summary>
    public class FinancialManagementDataService : DataServiceBase, IFinancialManagementDataService
    {
        private IUnitOfWork _UnitOfWork;
        private ITicketPeriodRepository _TicketPeriodRepository;
        private ITicketTypesRepository _TicketTypesRepository;
        private ITranscationCategoriesRepository _TranscationCategoriesRepository;
        private IPaymentTypesRepository _PaymentTypesRepository;
        private IPromissoryNoteManagementRepository _PromissoryNoteManagementRepository;
        private IMaterialCategoriesRepository _MaterialCategoriesRepository;

        public FinancialManagementDataService(IUnitOfWork UnitOfWork,
            ITicketPeriodRepository TicketPeriodRepository,
            ITicketTypesRepository TicketTypesRepository,
            ITranscationCategoriesRepository TranscationCategoriesRepository,
            IPaymentTypesRepository PaymentTypesRepository,
            IPromissoryNoteManagementRepository PromissoryNoteManagementRepository,
            IMaterialCategoriesRepository MaterialCategoriesRepository)
        {
            _UnitOfWork = UnitOfWork;
            _TicketPeriodRepository = TicketPeriodRepository;
            _TicketPeriodRepository.UnitOfWork = _UnitOfWork;

            _TicketTypesRepository = TicketTypesRepository;
            _TicketTypesRepository.UnitOfWork = _UnitOfWork;

            _TranscationCategoriesRepository = TranscationCategoriesRepository;
            _TranscationCategoriesRepository.UnitOfWork = _UnitOfWork;

            _PaymentTypesRepository = PaymentTypesRepository;
            _PaymentTypesRepository.UnitOfWork = _UnitOfWork;

            _PromissoryNoteManagementRepository = PromissoryNoteManagementRepository;
            _PromissoryNoteManagementRepository.UnitOfWork = _UnitOfWork;

            _MaterialCategoriesRepository = MaterialCategoriesRepository;
            _MaterialCategoriesRepository.UnitOfWork = _UnitOfWork;

        }

        public PaymentTypes Add(PaymentTypes model)
        {
            throw new NotImplementedException();
        }

        public TicketPeriod Add(TicketPeriod model)
        {
            throw new NotImplementedException();
        }

        public PromissoryNoteManagement Add(PromissoryNoteManagement model)
        {
            throw new NotImplementedException();
        }

        public MaterialCategories Add(MaterialCategories model)
        {
            throw new NotImplementedException();
        }

        public TranscationCategories Add(TranscationCategories model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypes> AddRange(IEnumerable<PaymentTypes> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketPeriod> AddRange(IEnumerable<TicketPeriod> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PromissoryNoteManagement> AddRange(IEnumerable<PromissoryNoteManagement> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaterialCategories> AddRange(IEnumerable<MaterialCategories> models)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TranscationCategories> AddRange(IEnumerable<TranscationCategories> models)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(TicketPeriod Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<TicketPeriod> Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(PaymentTypes Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<PaymentTypes> Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(PromissoryNoteManagement Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<PromissoryNoteManagement> Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(MaterialCategories Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<MaterialCategories> Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(TranscationCategories Model)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(IEnumerable<TranscationCategories> Model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypes> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypes> GetAll(Expression<Func<PaymentTypes, bool>> filiter = null)
        {
            try
            {
                var repo = _PaymentTypesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<TicketPeriod> GetAll(Expression<Func<TicketPeriod, bool>> filiter = null)
        {
            try
            {
                var repo = _TicketPeriodRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<PromissoryNoteManagement> GetAll(Expression<Func<PromissoryNoteManagement, bool>> filiter = null)
        {
            try
            {
                var repo = _PromissoryNoteManagementRepository ;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<MaterialCategories> GetAll(Expression<Func<MaterialCategories, bool>> filiter = null)
        {
            try
            {
                var repo = _MaterialCategoriesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public IEnumerable<TranscationCategories> GetAll(Expression<Func<TranscationCategories, bool>> filiter = null)
        {
            try
            {
                var repo = _TranscationCategoriesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

                if (filiter != null)
                    return queryresult.Where(filiter);

                return queryresult;
            }
            catch (Exception ex)
            {
                setErrortoModel(ex);
                return null;
            }
        }

        public PaymentTypes GetSingle(Expression<Func<PaymentTypes, bool>> filiter)
        {
            try
            {
                var repo = _PaymentTypesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

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

        public TicketPeriod GetSingle(Expression<Func<TicketPeriod, bool>> filiter)
        {
            try
            {
                var repo = _TicketPeriodRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

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

        public PromissoryNoteManagement GetSingle(Expression<Func<PromissoryNoteManagement, bool>> filiter)
        {
            try
            {
                var repo = _PromissoryNoteManagementRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

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

        public MaterialCategories GetSingle(Expression<Func<MaterialCategories, bool>> filiter)
        {
            try
            {
                var repo = _MaterialCategoriesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

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

        public TranscationCategories GetSingle(Expression<Func<TranscationCategories, bool>> filiter)
        {
            try
            {
                var repo = _TranscationCategoriesRepository;

                var queryresult = from q in repo.All()
                                  orderby q.Id ascending
                                  select q;

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

        public void Remove(PaymentTypes model)
        {
            throw new NotImplementedException();
        }

        public void Remove(TicketPeriod model)
        {
            throw new NotImplementedException();
        }

        public void Remove(PromissoryNoteManagement model)
        {
            throw new NotImplementedException();
        }

        public void Remove(MaterialCategories model)
        {
            throw new NotImplementedException();
        }

        public void Remove(TranscationCategories model)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<PaymentTypes, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<TicketPeriod, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<PromissoryNoteManagement, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<MaterialCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<TranscationCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<PaymentTypes> SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        public PaymentTypes Update(PaymentTypes Source, Expression<Func<PaymentTypes, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public TicketPeriod Update(TicketPeriod Source, Expression<Func<TicketPeriod, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public PromissoryNoteManagement Update(PromissoryNoteManagement Source, Expression<Func<PromissoryNoteManagement, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public MaterialCategories Update(MaterialCategories Source, Expression<Func<MaterialCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public TranscationCategories Update(TranscationCategories Source, Expression<Func<TranscationCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypes> UpdateRange(IEnumerable<PaymentTypes> MultiSource, Expression<Func<PaymentTypes, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketPeriod> UpdateRange(IEnumerable<TicketPeriod> MultiSource, Expression<Func<TicketPeriod, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PromissoryNoteManagement> UpdateRange(IEnumerable<PromissoryNoteManagement> MultiSource, Expression<Func<PromissoryNoteManagement, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaterialCategories> UpdateRange(IEnumerable<MaterialCategories> MultiSource, Expression<Func<MaterialCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TranscationCategories> UpdateRange(IEnumerable<TranscationCategories> MultiSource, Expression<Func<TranscationCategories, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketPeriod> IDataService<TicketPeriod>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PromissoryNoteManagement> IDataService<PromissoryNoteManagement>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MaterialCategories> IDataService<MaterialCategories>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TranscationCategories> IDataService<TranscationCategories>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ICollection<TicketPeriod> IDataService<TicketPeriod>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        ICollection<PromissoryNoteManagement> IDataService<PromissoryNoteManagement>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        ICollection<MaterialCategories> IDataService<MaterialCategories>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        ICollection<TranscationCategories> IDataService<TranscationCategories>.SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }
    }
}