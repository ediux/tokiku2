using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_RequiredFormsRepository : EFRepository<View_RequiredForms>, IView_RequiredFormsRepository
	{

	}

	public  partial interface IView_RequiredFormsRepository : IRepositoryBase<View_RequiredForms>
	{

	}
}