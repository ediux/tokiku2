using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ObtainMaterialListViewModelCollection : BaseViewModelCollection<ObtainMaterialListViewModel>
    {
        public ObtainMaterialListViewModelCollection()
        {
        }

        public ObtainMaterialListViewModelCollection(IEnumerable<ObtainMaterialListViewModel> source) : base(source)
        {
        }

        public static ObtainMaterialListViewModelCollection Query()
        {
            return Query<ObtainMaterialListViewModelCollection, PickList>("ObtainMaterialList", "QueryAll");
        }
    }

    public class ObtainMaterialListViewModel : BaseViewModelWithPOCOClass<PickList>
    {
        public ObtainMaterialListViewModel(PickList entity) : base(entity)
        {
        }

    }
}
