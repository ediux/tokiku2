using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_ObtainMaterialRepository : EFRepository<View_ObtainMaterial>, IView_ObtainMaterialRepository
	{

	}

	public  partial interface IView_ObtainMaterialRepository : IRepositoryBase<View_ObtainMaterial>
	{

	}
}