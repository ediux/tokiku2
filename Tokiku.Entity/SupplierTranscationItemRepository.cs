using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class SupplierTranscationItemRepository : EFRepository<SupplierTranscationItem>, ISupplierTranscationItemRepository
	{

	}

	public  partial interface ISupplierTranscationItemRepository : IRepositoryBase<SupplierTranscationItem>
	{

	}
}