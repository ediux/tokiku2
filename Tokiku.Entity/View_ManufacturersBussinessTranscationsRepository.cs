using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class View_ManufacturersBussinessTranscationsRepository : EFRepository<View_ManufacturersBussinessTranscations>, IView_ManufacturersBussinessTranscationsRepository
	{

	}

	public  partial interface IView_ManufacturersBussinessTranscationsRepository : IRepositoryBase<View_ManufacturersBussinessTranscations>
	{

	}
}