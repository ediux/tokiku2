using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ConstructionAtlasRepository : EFRepository<ConstructionAtlas>, IConstructionAtlasRepository
	{

	}

	public  partial interface IConstructionAtlasRepository : IRepositoryBase<ConstructionAtlas>
	{

	}
}