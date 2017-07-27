using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_OrderControlTableRepository : EFRepository<View_OrderControlTable>, IView_OrderControlTableRepository
	{

	}

	public  partial interface IView_OrderControlTableRepository : IRepositoryBase<View_OrderControlTable>
	{

	}
}