using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ReturnsRepository : EFRepository<Returns>, IReturnsRepository
	{

	}

	public  partial interface IReturnsRepository : IRepositoryBase<Returns>
	{

	}
}