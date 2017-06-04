using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class WorkShopsRepository : EFRepository<WorkShops>, IWorkShopsRepository
	{

	}

	public  partial interface IWorkShopsRepository : IRepositoryBase<WorkShops>
	{

	}
}