using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IProjectListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<IProjectListItemViewModel> ProjectsList { get; set; }
        ICommand SelectedAndOpenCommand { get; set; }
    }
}