using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class ReturnMaterialListViewModelCollection : BaseViewModelCollection<ReturnMaterialListViewModel>
    {
        public ReturnMaterialListViewModelCollection()
        {
        }

        public ReturnMaterialListViewModelCollection(IEnumerable<ReturnMaterialListViewModel> source) : base(source)
        {
        }

        public static ReturnMaterialListViewModelCollection Query()
        {
            return Query<ReturnMaterialListViewModelCollection, Returns>("ReturnMaterialList", "QueryAll");
        }

    }

    public class ReturnMaterialListViewModel : BaseViewModelWithPOCOClass<Returns>
    {
        public ReturnMaterialListViewModel(Returns entity) : base(entity)
        {
        }

    }
}
