namespace Tokiku.ViewModels
{
    public interface IVoidViewModel : IBaseViewModel
    {
        string Text { get; set; }
        bool Value { get; set; }
    }
}