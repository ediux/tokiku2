using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class AccessLogRepository : EFRepository<AccessLog>, IAccessLogRepository
	{

	}

	public  partial interface IAccessLogRepository : IRepositoryBase<AccessLog>
	{

	}
}