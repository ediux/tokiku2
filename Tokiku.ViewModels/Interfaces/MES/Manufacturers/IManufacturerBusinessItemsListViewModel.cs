using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IManufacturerBusinessItemsListViewModel : IDocumentBaseViewModel
    {

        ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get; set; }

        /// <summary>
        /// 材料類別下拉式清單
        /// </summary>
        IMaterialCategoriesListViewModel MaterialCategoriesDropDownList { get; set; }

        /// <summary>
        /// 交易類別下拉式清單
        /// </summary>
        ITranscationCategoriesListViewModel TranscationCategoriesDropDownList { get; set; }

        /// <summary>
        /// 交易品項下拉式清單
        /// </summary>
        ITradingItemsListViewModel TradingItemDropDownList { get; set; }

        /// <summary>
        /// 支付方式下拉式清單
        /// </summary>
        IPaymentTypesListViewModel PaymentTypesDropDownList { get; set; }

        /// <summary>
        /// 票期選擇下拉式清單
        /// </summary>
        ITicketPeriodsListViewModel TicketPeriodsDropDownList { get; set; }
    }
}