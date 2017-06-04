using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ProjectsRepository : EFRepository<Projects>, IProjectsRepository
	{

	}

	public  partial interface IProjectsRepository : IRepositoryBase<Projects>
	{

	}
}