using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReturnDetailsRepository : EFRepository<ReturnDetails>, IReturnDetailsRepository
	{

	}

	public  partial interface IReturnDetailsRepository : IRepositoryBase<ReturnDetails>
	{

	}
}