using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class InvoiceDetails_MaterialRepository : EFRepository<InvoiceDetails_Material>, IInvoiceDetails_MaterialRepository
	{

	}

	public  partial interface IInvoiceDetails_MaterialRepository : IRepositoryBase<InvoiceDetails_Material>
	{

	}
}