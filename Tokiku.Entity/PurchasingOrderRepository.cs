using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class PurchasingOrderRepository : EFRepository<PurchasingOrder>, IPurchasingOrderRepository
	{

	}

	public  partial interface IPurchasingOrderRepository : IRepositoryBase<PurchasingOrder>
	{

	}
}