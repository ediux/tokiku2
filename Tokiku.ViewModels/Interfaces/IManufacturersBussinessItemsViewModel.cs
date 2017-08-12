using System;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// 材料類別
        /// </summary>
        IMaterialCategoriesListViewModel MaterialCategoriesList { get; set; }

        /// <summary>
        /// 交易類別
        /// </summary>
        ITranscationCategoriesListViewModel TranscationCategoriesList { get; set; }

        /// <summary>
        /// 票期清單
        /// </summary>
        ITicketPeriodsListViewModel TicketPeriodsList { get; set; }


        IPaymentTypesListViewModel PaymentTypesList { get; set; }
    }
}