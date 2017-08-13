using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class TradingItemsRepository : EFRepository<TradingItems>, ITradingItemsRepository
	{

	}

	public  partial interface ITradingItemsRepository : IRepositoryBase<TradingItems>
	{

	}
}