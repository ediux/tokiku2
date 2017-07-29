using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class AbnormalQualityRepository : EFRepository<AbnormalQuality>, IAbnormalQualityRepository
	{

	}

	public  partial interface IAbnormalQualityRepository : IRepositoryBase<AbnormalQuality>
	{

	}
}