using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ShippingDetailsViewModelCollection : BaseViewModelCollection<ShippingDetailsViewModel>
    {
        public ShippingDetailsViewModelCollection()
        {
        }

        public ShippingDetailsViewModelCollection(IEnumerable<ShippingDetailsViewModel> source) : base(source)
        {
        }

        public static ShippingDetailsViewModelCollection Query()
        {
            return Query<ShippingDetailsViewModelCollection, View_Shipping>("ShippingDetails", "QueryAll");
        }

    }

    public class ShippingDetailsViewModel : BaseViewModelWithPOCOClass<View_Shipping>
    {
        public ShippingDetailsViewModel(View_Shipping entity) : base(entity)
        {
        }

    }
}
