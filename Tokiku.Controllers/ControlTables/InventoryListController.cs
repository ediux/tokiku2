using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class InventoryListController : BaseController
    {
        public ExecuteResultEntity<ICollection<Inventory>> QueryAll()
        {
            try {
                var repo = RepositoryHelper.GetInventoryRepository();
                return ExecuteResultEntity<ICollection<Inventory>>.CreateResultEntity(
                    new Collection<Inventory>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Inventory>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
