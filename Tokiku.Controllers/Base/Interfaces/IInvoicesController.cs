using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IInvoicesController : IViewController
    {
        IExecuteResultEntity<ICollection<Invoices>> QueryAll();
    }
}