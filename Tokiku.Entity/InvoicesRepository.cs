using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class InvoicesRepository : EFRepository<Invoices>, IInvoicesRepository
	{

	}

	public  partial interface IInvoicesRepository : IRepositoryBase<Invoices>
	{

	}
}