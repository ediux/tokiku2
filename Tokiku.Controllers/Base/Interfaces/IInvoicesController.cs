using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IInvoicesController : IBaseController<Invoices>
    {
        IExecuteResultEntity<ICollection<Invoices>> QueryAll();
    }
}