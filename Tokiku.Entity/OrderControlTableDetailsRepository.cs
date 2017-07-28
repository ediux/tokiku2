using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrderControlTableDetailsRepository : EFRepository<OrderControlTableDetails>, IOrderControlTableDetailsRepository
	{

	}

	public  partial interface IOrderControlTableDetailsRepository : IRepositoryBase<OrderControlTableDetails>
	{

	}
}