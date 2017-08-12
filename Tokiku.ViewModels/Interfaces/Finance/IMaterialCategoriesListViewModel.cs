using System.Collections.ObjectModel;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesListViewModel : IDocumentBaseViewModel
    {
        void RunQuery(IManufacturersBussinessItemsViewModel Parameter);
        ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get; set; }
    }
}