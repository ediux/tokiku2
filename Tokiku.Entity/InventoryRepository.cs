using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class InventoryRepository : EFRepository<Inventory>, IInventoryRepository
	{

	}

	public  partial interface IInventoryRepository : IRepositoryBase<Inventory>
	{

	}
}