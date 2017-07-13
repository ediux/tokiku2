using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InventoryViewModelCollection : BaseViewModelCollection<InventoryViewModel>
    {
        public InventoryViewModelCollection()
        {
            HasError = false;
        }

        public InventoryViewModelCollection(IEnumerable<InventoryViewModel> source) : base(source)
        {

        }

        public new static InventoryViewModelCollection Query()
        {
            InventoryController ctrl = new InventoryController();
            ExecuteResultEntity<ICollection<Inventory>> ere = ctrl.QuerAll();

            if (!ere.HasError)
            {
                return new InventoryViewModelCollection(ere.Result.Select(s => new InventoryViewModel(s)).ToList());
            }
            return new InventoryViewModelCollection();
        }

    }

    public class InventoryViewModel : BaseViewModelWithPOCOClass<Inventory>
    {
        public InventoryViewModel(Inventory entity) : base(entity)
        {

        }

    }
}
