using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrderMaterialValuationRepository : EFRepository<OrderMaterialValuation>, IOrderMaterialValuationRepository
	{

	}

	public  partial interface IOrderMaterialValuationRepository : IRepositoryBase<OrderMaterialValuation>
	{

	}
}