using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class MembershipRepository : EFRepository<Membership>, IMembershipRepository
	{

	}

	public  partial interface IMembershipRepository : IRepositoryBase<Membership>
	{

	}
}