using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ProjectItemCostRepository : EFRepository<ProjectItemCost>, IProjectItemCostRepository
	{

	}

	public  partial interface IProjectItemCostRepository : IRepositoryBase<ProjectItemCost>
	{

	}
}