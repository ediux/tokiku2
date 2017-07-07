using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class MaterialValuationRepository : EFRepository<MaterialValuation>, IMaterialValuationRepository
	{

	}

	public  partial interface IMaterialValuationRepository : IRepositoryBase<MaterialValuation>
	{

	}
}