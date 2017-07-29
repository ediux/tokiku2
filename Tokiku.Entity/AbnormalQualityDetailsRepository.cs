using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class AbnormalQualityDetailsRepository : EFRepository<AbnormalQualityDetails>, IAbnormalQualityDetailsRepository
	{

	}

	public  partial interface IAbnormalQualityDetailsRepository : IRepositoryBase<AbnormalQualityDetails>
	{

	}
}