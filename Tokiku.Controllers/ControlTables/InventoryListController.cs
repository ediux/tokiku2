using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.Controllers
{
    public class InventoryListController : BaseController<IInventoryRepository, Inventory>, IInventoryListController
    {
        public ExecuteResultEntity<ICollection<Inventory>> QueryAll()
        {
            try {
                var repo = SimpleIoc.Default.GetInstance<IInventoryRepository>();
                return ExecuteResultEntity<ICollection<Inventory>>.CreateResultEntity(
                    new Collection<Inventory>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Inventory>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
