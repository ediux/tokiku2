using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ManufacturersFactoriesRepository : EFRepository<ManufacturersFactories>, IManufacturersFactoriesRepository
	{

	}

	public  partial interface IManufacturersFactoriesRepository : IRepositoryBase<ManufacturersFactories>
	{

	}
}