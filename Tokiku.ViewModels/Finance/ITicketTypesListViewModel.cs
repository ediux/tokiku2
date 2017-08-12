using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public interface ITicketTypesListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<ITicketTypesViewModel> TicketTypesList { get; set; }
    }
}