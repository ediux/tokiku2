using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_ShippingListRepository : EFRepository<View_ShippingList>, IView_ShippingListRepository
	{

	}

	public  partial interface IView_ShippingListRepository : IRepositoryBase<View_ShippingList>
	{

	}
}