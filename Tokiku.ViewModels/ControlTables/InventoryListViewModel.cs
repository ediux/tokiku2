using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class InventoryListViewModelCollection : BaseViewModelCollection<InventoryListViewModel, Inventory>
    {
        public InventoryListViewModelCollection()
        {
        }

        public InventoryListViewModelCollection(IEnumerable<InventoryListViewModel> source) : base(source)
        {
        }


        public static InventoryListViewModelCollection Query()
        {
            try
            {
                return Query<InventoryListViewModelCollection>("InventoryList", "QueryAll");
            }
            catch (Exception ex)
            {
                InventoryListViewModelCollection collection = new InventoryListViewModelCollection();
               collection.setErrortoModel(ex);
                return collection;
            }
        }
    }

    public class InventoryListViewModel : BaseViewModelWithPOCOClass<Inventory>
    {
        public InventoryListViewModel()
        {

        }
        public InventoryListViewModel(Inventory entity) : base(entity)
        {
        }

    }
}
