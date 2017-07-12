using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReceiptsRepository : EFRepository<Receipts>, IReceiptsRepository
	{

	}

	public  partial interface IReceiptsRepository : IRepositoryBase<Receipts>
	{

	}
}