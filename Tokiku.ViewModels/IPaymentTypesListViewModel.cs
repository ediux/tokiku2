using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IPaymentTypesListViewModel : IDocumentBaseViewModel<PaymentTypes>
    {
        ObservableCollection<IPaymentTypesViewModel> PaymentTypesList { get; set; }
    }
}