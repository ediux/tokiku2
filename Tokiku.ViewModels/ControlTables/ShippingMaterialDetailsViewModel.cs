using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialDetailsViewModel : BaseViewModelWithPOCOClass<PickListDetails>
    {
        public ShippingMaterialDetailsViewModel()
        {

        }

        public ShippingMaterialDetailsViewModel(PickListDetails entity) : base(entity)
        {

        }

        public static ShippingMaterialDetailsViewModel Query(Guid Id)
        {
            try
            {
               return QuerySingle<ShippingMaterialDetailsViewModel, PickListDetails>(
                    "Shipping", "QuerySingle", Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
