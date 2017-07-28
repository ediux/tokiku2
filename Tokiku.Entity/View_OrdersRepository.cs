using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_OrdersRepository : EFRepository<View_Orders>, IView_OrdersRepository
	{

	}

	public  partial interface IView_OrdersRepository : IRepositoryBase<View_Orders>
	{

	}
}