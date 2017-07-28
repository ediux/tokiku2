using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class InvoiceDetailsRepository : EFRepository<InvoiceDetails>, IInvoiceDetailsRepository
	{

	}

	public  partial interface IInvoiceDetailsRepository : IRepositoryBase<InvoiceDetails>
	{

	}
}