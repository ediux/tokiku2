using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public interface ITicketTypesListViewModel
    {
        ObservableCollection<ITicketTypesViewModel> TicketTypesList { get; set; }
    }
}