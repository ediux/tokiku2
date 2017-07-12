using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class StocksRepository : EFRepository<Stocks>, IStocksRepository
	{

	}

	public  partial interface IStocksRepository : IRepositoryBase<Stocks>
	{

	}
}