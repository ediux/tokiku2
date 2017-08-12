using System.Collections.ObjectModel;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesListViewModel : IDocumentBaseViewModel<MaterialCategories>
    {
        ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get; set; }
    }
}