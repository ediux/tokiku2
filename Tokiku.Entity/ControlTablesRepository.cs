using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ControlTablesRepository : EFRepository<ControlTables>, IControlTablesRepository
	{

	}

	public  partial interface IControlTablesRepository : IRepositoryBase<ControlTables>
	{

	}
}