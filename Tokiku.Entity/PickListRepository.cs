using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class PickListRepository : EFRepository<PickList>, IPickListRepository
	{

	}

	public  partial interface IPickListRepository : IRepositoryBase<PickList>
	{

	}
}