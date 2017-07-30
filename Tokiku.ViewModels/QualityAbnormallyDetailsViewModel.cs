using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class QualityAbnormallyDetailsViewModel : BaseViewModelWithPOCOClass<AbnormalQualityDetails>
    {
        public QualityAbnormallyDetailsViewModel()
        {
            _SaveModelController = "AbnormalQualityDetails";
        }

        public QualityAbnormallyDetailsViewModel(AbnormalQualityDetails entity) : base(entity)
        {
            _SaveModelController = "AbnormalQualityDetails";
        }

        #region 查詢單一個體的檢視資料
        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public QualityAbnormallyDetailsViewModel Query(Guid Id)
        {
            try
            {
                QualityAbnormallyDetailsViewModel viewmodel = new QualityAbnormallyDetailsViewModel();

                viewmodel = QuerySingle<QualityAbnormallyDetailsViewModel, AbnormalQualityDetails>(
                    viewmodel.SaveModelController, "QuerySingle", Id);

                return viewmodel;
            }
            catch (Exception ex)
            {
                QualityAbnormallyDetailsViewModel view = new QualityAbnormallyDetailsViewModel();
                setErrortoModel(view, ex);
                return view;
            }

        }
        #endregion

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code { get => CopyofPOCOInstance.ReceiptDetails.OrderDetails.RequiredDetails.Code; set { RaisePropertyChanged("Code"); } }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public string FactoryNumber { get => CopyofPOCOInstance.ReceiptDetails.OrderDetails.RequiredDetails.FactoryNumber; set { RaisePropertyChanged("FactoryNumber"); } }

        /// <summary>
        /// 加工編號
        /// </summary>
        public string ProcessNumber { get => CopyofPOCOInstance.ProcessingNumber; set { CopyofPOCOInstance.ProcessingNumber = value; RaisePropertyChanged("ProcessNumber"); } }

        /// <summary>
        /// 品名/規格
        /// </summary>
        public string Specifications { get => CopyofPOCOInstance.Specifications; set { CopyofPOCOInstance.Specifications = value; RaisePropertyChanged("Specifications"); } }

        /// <summary>
        /// 長度mm
        /// </summary>
        public int? Length { get => CopyofPOCOInstance.ReceiptDetails.OrderDetails.RequiredDetails.OrderLength; set { } }

        /// <summary>
        /// 收料數量
        /// </summary>
        public int ReceiptQuantity { get => CopyofPOCOInstance.ReceiptDetails.ReceiptQuantity; set {  } }

        /// <summary>
        /// 異常數量
        /// </summary>
        public int ExceptionQuantity { get => CopyofPOCOInstance.ExceptionsQuantity; set { CopyofPOCOInstance.ExceptionsQuantity = value; RaisePropertyChanged("ExceptionQuantity"); } }

        /// <summary>
        /// 異常說明
        /// </summary>
        public string ExceptionReason { get => CopyofPOCOInstance.ExceptionsReason; set { CopyofPOCOInstance.ExceptionsReason = value; RaisePropertyChanged("ExceptionReason"); } }

        /// <summary>
        /// 原因說明
        /// </summary>
        public string Reason { get => CopyofPOCOInstance.Reason; set { CopyofPOCOInstance.Reason = value; RaisePropertyChanged("Reason"); } }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string ProcessingMethod { get => CopyofPOCOInstance.ProcessingMethod; set { CopyofPOCOInstance.ProcessingMethod = value;RaisePropertyChanged("ProcessingMethod"); } }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get => CopyofPOCOInstance.Comment; set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); } }


        /// <summary>
        /// 損失估算
        /// </summary>
        public decimal? LossCalculation { get => CopyofPOCOInstance.LossCalculation; set { CopyofPOCOInstance.LossCalculation = value; RaisePropertyChanged("LossCalculation"); } }

        /// <summary>
        /// 扣款廠商
        /// </summary>
        public string RefundsManufacturers { get => CopyofPOCOInstance.Manufacturers.Name; set {  RaisePropertyChanged("RefundsManufacturers"); } }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string OrderFormNumber { get => CopyofPOCOInstance.ReceiptDetails.OrderDetails.Orders.FormNumber; set { RaisePropertyChanged("OrderFormNumber"); } }

        /// <summary>
        /// 訂單金額
        /// </summary>
        public decimal? OrderAmount { get => CopyofPOCOInstance.OrderAmount; set { CopyofPOCOInstance.OrderAmount = value; RaisePropertyChanged("OrderAmount"); } }

        /// <summary>
        /// 主表
        /// </summary>
        public QualityAbnormallyViewModel Master { get => new QualityAbnormallyViewModel(CopyofPOCOInstance.AbnormalQuality); set { RaisePropertyChanged("Master"); } }
    }
}
