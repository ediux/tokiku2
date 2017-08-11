using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IContactsViewModel : IEntityBaseViewModel<Contacts>
    {
        string Dep { get; set; }
        string EMail { get; set; }
        string ExtensionNumber { get; set; }
        string Fax { get; set; }
        bool IsDefault { get; set; }
        bool IsPrincipal { get; set; }
        string Mobile { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Title { get; set; }
        bool Void { get; set; }
    }
}