using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IMaterialCategoriesViewModel : IEntityBaseViewModel<MaterialCategories>
    {
        string Name { get; set; }
    }
}