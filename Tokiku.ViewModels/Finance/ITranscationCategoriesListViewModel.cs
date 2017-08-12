using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITranscationCategoriesListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<ITranscationCategoriesViewModel> TranscationCategories { get; set; }
    }
}