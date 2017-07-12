using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrdersRepository : EFRepository<Orders>, IOrdersRepository
	{

	}

	public  partial interface IOrdersRepository : IRepositoryBase<Orders>
	{

	}
}