using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_PickListRepository : EFRepository<View_PickList>, IView_PickListRepository
	{

	}

	public  partial interface IView_PickListRepository : IRepositoryBase<View_PickList>
	{

	}
}