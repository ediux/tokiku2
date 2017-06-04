using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class StatesRepository : EFRepository<States>, IStatesRepository
	{

	}

	public  partial interface IStatesRepository : IRepositoryBase<States>
	{

	}
}