using System.Collections.ObjectModel;
using System.Windows.Input;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITranscationCategoriesListViewModel : IDocumentBaseViewModel
    {
        ICommand RefreshFromMaterialCategoriesCommand { get; set; }
        ObservableCollection<ITranscationCategoriesViewModel> TranscationCategories { get; set; }
    }
}