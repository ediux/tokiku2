using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public class ShopFlowHistoryViewModelCollection : ObservableCollection<ShopFlowHistoryViewModel>, IBaseViewModel
    {
        public ShopFlowHistoryViewModelCollection()
        {

        }
        public ShopFlowHistoryViewModelCollection(IEnumerable<ShopFlowHistoryViewModel> source) : base(source)
        {

        }
        public IEnumerable<string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class ShopFlowHistoryViewModel : BaseViewModel
    {

    }
}
