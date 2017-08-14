using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public interface IClientListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<IClientListItemViewModel> ClientsList { get; set; }
    }
}