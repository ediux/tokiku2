using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_OrderMaterialValuationRepository : EFRepository<View_OrderMaterialValuation>, IView_OrderMaterialValuationRepository
	{

	}

	public  partial interface IView_OrderMaterialValuationRepository : IRepositoryBase<View_OrderMaterialValuation>
	{

	}
}