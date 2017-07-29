using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ObtainMaterialViewModelCollection : BaseViewModelCollection<ObtainMaterialViewModel, PickList>
    {
        public ObtainMaterialViewModelCollection()
        {
        }

        public ObtainMaterialViewModelCollection(IEnumerable<ObtainMaterialViewModel> source) : base(source)
        {
        }

        public static ObtainMaterialViewModelCollection Query()
        {
            return Query<ObtainMaterialViewModelCollection>("ObtainMaterial", "QueryAll");
        }
    }

    public class ObtainMaterialViewModel : BaseViewModelWithPOCOClass<PickList>
    {
        public ObtainMaterialViewModel(PickList entity) : base(entity)
        {
        }
    }
}
