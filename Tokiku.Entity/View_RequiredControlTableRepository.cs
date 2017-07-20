using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_RequiredControlTableRepository : EFRepository<View_RequiredControlTable>, IView_RequiredControlTableRepository
	{

	}

	public  partial interface IView_RequiredControlTableRepository : IRepositoryBase<View_RequiredControlTable>
	{

	}
}