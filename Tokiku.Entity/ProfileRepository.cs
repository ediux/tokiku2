using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ProfileRepository : EFRepository<Profile>, IProfileRepository
	{

	}

	public  partial interface IProfileRepository : IRepositoryBase<Profile>
	{

	}
}