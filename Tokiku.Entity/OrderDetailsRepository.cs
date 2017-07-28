using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrderDetailsRepository : EFRepository<OrderDetails>, IOrderDetailsRepository
	{

	}

	public  partial interface IOrderDetailsRepository : IRepositoryBase<OrderDetails>
	{

	}
}