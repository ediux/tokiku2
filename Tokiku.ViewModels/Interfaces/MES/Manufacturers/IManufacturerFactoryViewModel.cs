using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturerFactoryViewModel : IEntityBaseViewModel<ManufacturersFactories>
    {
        string Address { get; set; }
        string Fax { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
    }
}