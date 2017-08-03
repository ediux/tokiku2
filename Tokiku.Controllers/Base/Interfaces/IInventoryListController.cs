using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IInventoryListController : IBaseController<Inventory>
    {
        ExecuteResultEntity<ICollection<Inventory>> QueryAll();
    }
}