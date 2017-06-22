using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class FormDetailsRepository : EFRepository<FormDetails>, IFormDetailsRepository
	{

	}

	public  partial interface IFormDetailsRepository : IRepositoryBase<FormDetails>
	{

	}
}