using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class RequiredRepository : EFRepository<Required>, IRequiredRepository
	{

	}

	public  partial interface IRequiredRepository : IRepositoryBase<Required>
	{

	}
}