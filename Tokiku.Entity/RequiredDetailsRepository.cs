using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class RequiredDetailsRepository : EFRepository<RequiredDetails>, IRequiredDetailsRepository
	{

	}

	public  partial interface IRequiredDetailsRepository : IRepositoryBase<RequiredDetails>
	{

	}
}