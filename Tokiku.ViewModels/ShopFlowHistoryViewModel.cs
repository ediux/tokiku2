using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public class ShopFlowHistoryViewModelCollection : BaseViewModelCollection<ShopFlowHistoryViewModel>
    {
        public ShopFlowHistoryViewModelCollection()
        {

        }
        public ShopFlowHistoryViewModelCollection(IEnumerable<ShopFlowHistoryViewModel> source) : base(source)
        {

        }
    }


    public class ShopFlowHistoryViewModel : BaseViewModel
    {

    }
}
