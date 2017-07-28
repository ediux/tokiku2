using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialDetailsViewModelCollection
        : BaseViewModelCollection<ShippingMaterialDetailsViewModel>
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
                return Query<ShippingMaterialDetailsViewModelCollection, PickListDetails>
               ("ShippingMaterialDetails", "QueryAll", ShippingMaterialMasterId);
            }
            catch (Exception ex)
            {
                ShippingMaterialDetailsViewModelCollection emptycollection
                    = new ShippingMaterialDetailsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                throw;
            }

        }
    }
}
