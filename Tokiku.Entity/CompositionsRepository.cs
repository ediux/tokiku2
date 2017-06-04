using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class CompositionsRepository : EFRepository<Compositions>, ICompositionsRepository
	{

	}

	public  partial interface ICompositionsRepository : IRepositoryBase<Compositions>
	{

	}
}