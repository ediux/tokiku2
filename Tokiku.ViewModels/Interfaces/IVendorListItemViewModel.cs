using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IVendorListItemViewModel : IEntityBaseViewModel<Manufacturers>
    {
        string Address { get; set; }
        string Code { get; set; }
        string eMail { get; set; }
        string Fax { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Principal { get; set; }
        string ShortName { get; set; }
        string UniformNumbers { get; set; }
        bool Void { get; set; }
        string VoidStateText { get; set; }
    }
}