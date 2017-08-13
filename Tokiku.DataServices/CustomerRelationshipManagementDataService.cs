using System;
using System.Collections.Generic;
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
        private IClientDataService _ClientDataService;
        private IManufacturingExecutionDataService _IManufacturingExecutionDataService;
        private IManufacturersDataService _ManufacturersDataService;

        public CustomerRelationshipManagementDataService(ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService,
            IManufacturingExecutionDataService ManufacturingExecutionDataService,
            ICoreDataService CoreDataService)
        {
            _CoreDataService = CoreDataService;
            _IManufacturingExecutionDataService = ManufacturingExecutionDataService;
            _ManufacturersDataService = _IManufacturingExecutionDataService;
            _ClientDataService = CustomerRelationshipManagementDataService;
        }

        public Manufacturers Add(Manufacturers model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> AddRange(IEnumerable<Manufacturers> models)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdate(Manufacturers Model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Manufacturers GetSingle(Expression<Func<Manufacturers, bool>> filiter)
        {
            throw new NotImplementedException();
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

        public ICollection<Manufacturers> SearchByText(string filiter)
        {
            throw new NotImplementedException();
        }

        public Manufacturers Update(Manufacturers Source, Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturers> UpdateRange(IEnumerable<Manufacturers> MultiSource, Expression<Func<Manufacturers, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }
    }
}