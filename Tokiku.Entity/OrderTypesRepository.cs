using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class OrderTypesRepository : EFRepository<OrderTypes>, IOrderTypesRepository
	{

	}

	public  partial interface IOrderTypesRepository : IRepositoryBase<OrderTypes>
	{

	}
}