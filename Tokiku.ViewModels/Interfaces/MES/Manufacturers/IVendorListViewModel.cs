using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IVendorListViewModel : IDocumentBaseViewModel
    {
        ICommand SelectedAndOpenCommand { get; set; }
        ObservableCollection<IVendorListItemViewModel> VendorList { get; set; }
    }

    
}