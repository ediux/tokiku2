using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReceiveDetailsRepository : EFRepository<ReceiveDetails>, IReceiveDetailsRepository
	{

	}

	public  partial interface IReceiveDetailsRepository : IRepositoryBase<ReceiveDetails>
	{

	}
}