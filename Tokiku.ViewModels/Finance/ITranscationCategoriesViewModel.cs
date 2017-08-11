using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface ITranscationCategoriesViewModel : IEntityBaseViewModel<TranscationCategories>
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}