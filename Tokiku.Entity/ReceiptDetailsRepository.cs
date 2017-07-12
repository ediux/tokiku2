using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReceiptDetailsRepository : EFRepository<ReceiptDetails>, IReceiptDetailsRepository
	{

	}

	public  partial interface IReceiptDetailsRepository : IRepositoryBase<ReceiptDetails>
	{

	}
}