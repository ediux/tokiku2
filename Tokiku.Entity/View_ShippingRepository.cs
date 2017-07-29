using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_ShippingRepository : EFRepository<View_Shipping>, IView_ShippingRepository
	{

	}

	public  partial interface IView_ShippingRepository : IRepositoryBase<View_Shipping>
	{

	}
}