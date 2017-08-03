using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IInvoicesController : IBaseController<Invoices>
    {
        ExecuteResultEntity<ICollection<Invoices>> QueryAll();
    }
}