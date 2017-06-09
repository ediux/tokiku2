using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_BussinessItemsListRepository : EFRepository<View_BussinessItemsList>, IView_BussinessItemsListRepository
	{

	}

	public  partial interface IView_BussinessItemsListRepository : IRepositoryBase<View_BussinessItemsList>
	{

	}
}