using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class EngineeringRepository : EFRepository<Engineering>, IEngineeringRepository
	{

	}

	public  partial interface IEngineeringRepository : IRepositoryBase<Engineering>
	{

	}
}