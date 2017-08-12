using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturersBussinessTranscationsViewModel : IEntityBaseViewModel<SupplierTranscationItem>
    {
        string Code { get; set; }
        string Name { get; set; }
    }
}