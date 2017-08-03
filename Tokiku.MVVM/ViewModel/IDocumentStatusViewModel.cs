namespace Tokiku.ViewModels
{
    public interface IDocumentStatusViewModel
    {
        bool IsModify { get; set; }
        bool IsNewInstance { get; set; }
        bool IsSaved { get; set; }
    }
}