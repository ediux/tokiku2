using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IInventoryController : IBaseController<Inventory>
    {
        IExecuteResultEntity<ICollection<Inventory>> QueryAll();
    }
}