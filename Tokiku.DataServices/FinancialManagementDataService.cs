using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    public class FinancialManagementDataService : DataServiceBase, IFinancialManagementDataService
    {
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

        public IEnumerable<PaymentTypes> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypes> GetAll(Expression<Func<PaymentTypes, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketPeriod> GetAll(Expression<Func<TicketPeriod, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PromissoryNoteManagement> GetAll(Expression<Func<PromissoryNoteManagement, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public PaymentTypes GetSingle(Expression<Func<PaymentTypes, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public TicketPeriod GetSingle(Expression<Func<TicketPeriod, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public PromissoryNoteManagement GetSingle(Expression<Func<PromissoryNoteManagement, bool>> filiter)
        {
            throw new NotImplementedException();
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

        IEnumerable<TicketPeriod> IDataService<TicketPeriod>.DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PromissoryNoteManagement> IDataService<PromissoryNoteManagement>.DirectExecuteSQL(string tsql, params object[] parameters)
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
    }
}