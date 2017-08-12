using System.Collections.ObjectModel;
using System.Windows.Input;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IPaymentTypesListViewModel : IDocumentBaseViewModel
    {
        ICommand RefreshFromPaymentTypesCommand { get; set; }
        ObservableCollection<IPaymentTypesViewModel> PaymentTypesList { get; set; }
    }
}