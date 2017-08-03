using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class InventoryController : BaseController<IInventoryRepository,Inventory>
        , IInventoryController
    {
        public IExecuteResultEntity<ICollection<Inventory>> QueryAll()
        {
            try {
                var repo = this.GetRepository<IInventoryRepository,Inventory>();
                return ExecuteResultEntity<ICollection<Inventory>>.CreateResultEntity(
                    new Collection<Inventory>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Inventory>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
