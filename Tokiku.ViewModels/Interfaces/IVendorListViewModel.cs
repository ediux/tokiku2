using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IVendorListViewModel : IBaseViewModel
    {
        ObservableCollection<IVendorListItemViewModel> VendorList { get; set; }
        ICommand QueryCommand { get; set; }
    }

    
}