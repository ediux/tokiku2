using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InventoryListViewModelCollection : BaseViewModelCollection<InventoryListViewModel>
    {
        public InventoryListViewModelCollection()
        {
        }

        public InventoryListViewModelCollection(IEnumerable<InventoryListViewModel> source) : base(source)
        {
        }

        public static InventoryListViewModelCollection Query()
        {
            return Query<InventoryListViewModelCollection, Inventory>("InventoryList", "QueryAll");
        }

    }

    public class InventoryListViewModel : BaseViewModelWithPOCOClass<Inventory>
    {
        public InventoryListViewModel(Inventory entity) : base(entity)
        {
        }

    }
}
