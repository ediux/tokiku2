using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class PickListDetailsRepository : EFRepository<PickListDetails>, IPickListDetailsRepository
	{

	}

	public  partial interface IPickListDetailsRepository : IRepositoryBase<PickListDetails>
	{

	}
}