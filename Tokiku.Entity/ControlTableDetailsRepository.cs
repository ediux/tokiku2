using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ControlTableDetailsRepository : EFRepository<ControlTableDetails>, IControlTableDetailsRepository
	{

	}

	public  partial interface IControlTableDetailsRepository : IRepositoryBase<ControlTableDetails>
	{

	}
}