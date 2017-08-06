using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IInventoryListController : IViewController
    {
        ExecuteResultEntity<ICollection<Inventory>> QueryAll();
    }
}