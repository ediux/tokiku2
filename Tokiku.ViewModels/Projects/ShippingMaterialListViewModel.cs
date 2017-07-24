using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialListViewModelCollection : BaseViewModelCollection<ShippingMaterialListViewModel>
    {
        public ShippingMaterialListViewModelCollection()
        {
        }

        public ShippingMaterialListViewModelCollection(IEnumerable<ShippingMaterialListViewModel> source) : base(source)
        {
        }

        public static ShippingMaterialListViewModelCollection Query()
        {
            return Query<ShippingMaterialListViewModelCollection, PickList>("ShippingMaterialList", "QueryAll");
        }

    }

    public class ShippingMaterialListViewModel : BaseViewModelWithPOCOClass<PickList>
    {
        public ShippingMaterialListViewModel()
        {
        }

        public ShippingMaterialListViewModel(PickList entity) : base(entity)
        {
        }
        
    }
}
