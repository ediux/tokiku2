using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialDetailsViewModelCollection
        : BaseViewModelCollection<ShippingMaterialDetailsViewModel, PickListDetails>
    {
        public ShippingMaterialDetailsViewModelCollection()
        {

        }

        public ShippingMaterialDetailsViewModelCollection(IEnumerable<ShippingMaterialDetailsViewModel> source) : base(source)
        {

        }

        public static ShippingMaterialDetailsViewModelCollection Query(Guid ShippingMaterialMasterId)
        {
            try
            {
                return Query<ShippingMaterialDetailsViewModelCollection>(
                    "ShippingMaterialDetails", "QueryAll", ShippingMaterialMasterId);
            }
            catch (Exception ex)
            {
                ShippingMaterialDetailsViewModelCollection emptycollection
                    = new ShippingMaterialDetailsViewModelCollection();
                emptycollection.setErrortoModel(ex);
                throw;
            }

        }
    }
}
