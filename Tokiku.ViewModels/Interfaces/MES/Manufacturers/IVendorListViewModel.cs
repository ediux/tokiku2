using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IVendorListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<IVendorListItemViewModel> VendorList { get; set; }
    }

    
}