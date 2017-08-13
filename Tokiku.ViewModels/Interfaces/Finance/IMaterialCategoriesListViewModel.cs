using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesListViewModel : IDocumentBaseViewModel
    {
        void RunQuery(ICollection<ManufacturersBussinessItems> Parameter);
        ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get; set; }
    }
}