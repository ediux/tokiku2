using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class UsersRepository : EFRepository<Users>, IUsersRepository
	{

	}

	public  partial interface IUsersRepository : IRepositoryBase<Users>
	{

	}
}