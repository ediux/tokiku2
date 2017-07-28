using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrderMiscellaneousRepository : EFRepository<OrderMiscellaneous>, IOrderMiscellaneousRepository
	{

	}

	public  partial interface IOrderMiscellaneousRepository : IRepositoryBase<OrderMiscellaneous>
	{

	}
}