using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class InvoiceDetails_MiscellaneousRepository : EFRepository<InvoiceDetails_Miscellaneous>, IInvoiceDetails_MiscellaneousRepository
	{

	}

	public  partial interface IInvoiceDetails_MiscellaneousRepository : IRepositoryBase<InvoiceDetails_Miscellaneous>
	{

	}
}