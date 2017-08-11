using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesListViewModel
    {
        ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get; set; }
    }
}