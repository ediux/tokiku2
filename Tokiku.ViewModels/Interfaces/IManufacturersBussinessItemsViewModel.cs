using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturersBussinessItemsViewModel : IEntityBaseViewModel<ManufacturersBussinessItems>
    {
        Manufacturers Manufacturers { get; set; }
        Guid ManufacturersId { get; set; }
        string MaterialCategories { get; set; }
        Guid? MaterialCategoriesId { get; set; }
        string Name { get; set; }
        byte PaymentTypeId { get; set; }
        string PaymentTypeName { get; set; }
        string TicketPeriod { get; set; }
        int TicketPeriodId { get; set; }
        string TranscationCategories { get; set; }
        int? TranscationCategoriesId { get; set; }
    }
}