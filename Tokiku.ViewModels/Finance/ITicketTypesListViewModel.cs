using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITicketTypesListViewModel : IDocumentBaseViewModel<TicketTypes>
    {
        ObservableCollection<ITicketTypesViewModel> TicketTypesList { get; set; }
    }
}