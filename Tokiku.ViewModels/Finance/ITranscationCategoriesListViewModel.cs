using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITranscationCategoriesListViewModel : IDocumentBaseViewModel<TranscationCategories>
    {
        ObservableCollection<TranscationCategoriesViewModel> TranscationCategories { get; set; }
    }
}