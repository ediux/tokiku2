using System;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 廠商主檔:營業項目紀錄檢視模型
    /// </summary>
    public class ManufacturersBussinessItemsViewModel : EntityBaseViewModel<ManufacturersBussinessItems>, IManufacturersBussinessItemsViewModel
    {

        public ManufacturersBussinessItemsViewModel() : base()
        {

        }

        [PreferredConstructor]
        public ManufacturersBussinessItemsViewModel(ManufacturersBussinessItems entity) : base(entity)
        {
            
        }

        #region MaterialCategoriesId 材料類別Id

        /// <summary>
        /// 材料類別Id
        /// </summary>
        public Guid? MaterialCategoriesId
        {
            get { return CopyofPOCOInstance.MaterialCategoriesId; }
            set { CopyofPOCOInstance.MaterialCategoriesId = value; RaisePropertyChanged("MaterialCategoriesId"); }
        }

        #endregion

        #region MaterialCategories 材料類別
        /// <summary>
        /// 材料類別
        /// </summary>
        public string MaterialCategories
        {
            get { return CopyofPOCOInstance?.MaterialCategories?.Name; }
            set { RaisePropertyChanged("MaterialCategories"); }
        }



        #endregion

        #region Name 交易品項

        /// <summary>
        /// 交易品項
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.TradingItems.Name; }
            set { RaisePropertyChanged("Name", CopyofPOCOInstance.TradingItems.Name, value, true); }
        }

        public Guid TradingItemsId { get => CopyofPOCOInstance.TradingItemsId; set { CopyofPOCOInstance.TradingItemsId = value;RaisePropertyChanged("TradingItemsId"); } }
        #endregion

        #region PaymentTypeId  支付方式識別碼(Id)

        /// <summary>
        /// 支付方式識別碼(Id)
        /// </summary>
        public byte PaymentTypeId
        {
            get { return CopyofPOCOInstance.PaymentTypeId.HasValue ? CopyofPOCOInstance.PaymentTypeId.Value : (byte)0; }
            set { CopyofPOCOInstance.PaymentTypeId = value; RaisePropertyChanged("PaymentTypeId"); }
        }

        #endregion

        #region PaymentTypeName 支付方式名稱

        /// <summary>
        /// 選定的支付方式顯示文字
        /// </summary>
        public string PaymentTypeName
        {
            get { return CopyofPOCOInstance?.PaymentTypes?.PaymentTypeName; }
            set { RaisePropertyChanged("PaymentTypeName", CopyofPOCOInstance?.PaymentTypes?.PaymentTypeName, value, true); }
        }

        #endregion

        #region TicketPeriodId 票期ID

        /// <summary>
        /// 票期的識別碼
        /// </summary>
        public int TicketPeriodId
        {
            get { return CopyofPOCOInstance.TicketPeriodId.HasValue ? CopyofPOCOInstance.TicketPeriodId.Value : 0; }
            set
            {
                CopyofPOCOInstance.TicketPeriodId = value;

                Tokiku.DataServices.ITicketPeriodDataService TicketPeriodDataService = Tokiku.DataServices.DefaultLocator.Current.FinancialManagementDataService;

                CopyofPOCOInstance.TicketPeriod = TicketPeriodDataService.GetSingle(w => w.Id == CopyofPOCOInstance.TicketPeriodId);

                RaisePropertyChanged("TicketPeriodId");
                //CopyofPOCOInstance.TicketPeriodId = value;
                //RaisePropertyChanged("TicketPeriodId");
                //var result = ExecuteAction<TicketPeriod>(
                //    "TicketPeriodsManagement", "QuerySingle", value);
                //if (result != null)
                //{
                //    CopyofPOCOInstance.TicketPeriod = result;
                //    RaisePropertyChanged("TicketPeriod");
                //}
            }
        }




        #endregion

        #region TicketPeriod 票期名稱

        /// <summary>
        /// 所選票期顯示的文字
        /// </summary>
        public string TicketPeriod
        {
            get { return CopyofPOCOInstance?.TicketPeriod?.Name; }
            set { RaisePropertyChanged("TicketPeriod"); }
        }
        #endregion

        #region ManufacturersId

        /// <summary>
        /// 關聯的廠商識別碼
        /// </summary>
        public Guid ManufacturersId
        {
            get { return CopyofPOCOInstance.ManufacturersId; }
            set { CopyofPOCOInstance.ManufacturersId = value; RaisePropertyChanged("ManufacturersId"); }
        }

        #endregion

        #region 關聯的廠商
        /// <summary>
        /// 關聯的廠商
        /// </summary>
        public Manufacturers Manufacturers
        {
            get { return CopyofPOCOInstance.Manufacturers; }
            set { CopyofPOCOInstance.Manufacturers = value; RaisePropertyChanged("Manufacturers"); }
        }
        #endregion

        #region TranscationCategoriesId

        /// <summary>
        /// 交易類別ID
        /// </summary>
        public int? TranscationCategoriesId
        {
            get { return CopyofPOCOInstance.TranscationCategoriesId; }
            set
            {
                CopyofPOCOInstance.TranscationCategoriesId = value;
                RaisePropertyChanged("TranscationCategoriesId");
                //var result = ExecuteAction<TranscationCategories>(
                //   "ManufacturersManage", "QuerySingleTranscationCategory", value);
                //if (result != null)
                //{
                //    CopyofPOCOInstance.TranscationCategories = result;
                //    CopyofPOCOInstance.TranscationCategoriesId = result.Id;
                //    RaisePropertyChanged("TranscationCategories");
                //}
            }
        }




        #endregion

        #region TranscationCategories 交易類別名稱

        /// <summary>
        /// 交易類別名稱
        /// </summary>
        public string TranscationCategories
        {
            get { return CopyofPOCOInstance?.TranscationCategories?.Name; }
            set { RaisePropertyChanged("TranscationCategories"); }
        }


        #endregion      
    }
}
