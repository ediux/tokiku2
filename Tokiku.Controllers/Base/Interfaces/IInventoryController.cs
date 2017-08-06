using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IInventoryController : IViewController
    {
        IExecuteResultEntity<ICollection<Inventory>> QueryAll();
    }
}