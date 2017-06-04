using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class RolesRepository : EFRepository<Roles>, IRolesRepository
	{

	}

	public  partial interface IRolesRepository : IRepositoryBase<Roles>
	{

	}
}