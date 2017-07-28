using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReceiveRepository : EFRepository<Receive>, IReceiveRepository
	{

	}

	public  partial interface IReceiveRepository : IRepositoryBase<Receive>
	{

	}
}