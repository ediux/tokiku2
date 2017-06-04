using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ProjectContractRepository : EFRepository<ProjectContract>, IProjectContractRepository
	{

	}

	public  partial interface IProjectContractRepository : IRepositoryBase<ProjectContract>
	{

	}
}