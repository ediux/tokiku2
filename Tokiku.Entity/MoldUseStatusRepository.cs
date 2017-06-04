using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class MoldUseStatusRepository : EFRepository<MoldUseStatus>, IMoldUseStatusRepository
	{

	}

	public  partial interface IMoldUseStatusRepository : IRepositoryBase<MoldUseStatus>
	{

	}
}