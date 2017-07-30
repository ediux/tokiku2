using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public class QualityAbnormallyViewModel : BaseViewModelWithPOCOClass<AbnormalQuality>
    {
        public QualityAbnormallyViewModel()
        {
            _SaveModelController = "AbnormalQuality";
        }

        public QualityAbnormallyViewModel(AbnormalQuality entity) : base(entity)
        {
            _SaveModelController = "AbnormalQuality";

            //CopyofPOCOInstance.UnusualNumber
        }

        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public QualityAbnormallyViewModel Query(Guid ProjectId, Guid Id)
        {
            try
            {
                QualityAbnormallyViewModel viewmodel = null;

                viewmodel = QuerySingle<QualityAbnormallyViewModel, AbnormalQuality>(
                    "AbnormalQuality", "QuerySingle", ProjectId, Id);

                return viewmodel;
            }
            catch (Exception ex)
            {
                QualityAbnormallyViewModel view = new QualityAbnormallyViewModel();
                setErrortoModel(view, ex);
                return view;
            }

        }

        /// <summary>
        /// 異常單號
        /// </summary>
        public string UnusualNumber { get => CopyofPOCOInstance.UnusualNumber; set { CopyofPOCOInstance.UnusualNumber = value; RaisePropertyChanged("UnusualNumber"); } }

        /// <summary>
        /// 製單日期
        /// </summary>
        public DateTime MakingTime { get => CopyofPOCOInstance.MakingTime; set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); } }

        /// <summary>
        /// 製單人員ID
        /// </summary>
        public Guid MakingUserId { get => CopyofPOCOInstance.MakingUserId; set { CopyofPOCOInstance.MakingUserId = value; RaisePropertyChanged("MakingUserId"); } }

        /// <summary>
        /// 製單人員
        /// </summary>
        public string MakingUser { get => CopyofPOCOInstance.MakingUser?.UserName; set { RaisePropertyChanged("MakingUser"); } }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string ProjectName { get => CopyofPOCOInstance.ProjectContract?.Projects?.Name; set { RaisePropertyChanged("ProjectName"); } }

        /// <summary>
        /// 合約系統編號
        /// </summary>
        public Guid ProjectContractId { get => CopyofPOCOInstance.ProjectContractId; set { CopyofPOCOInstance.ProjectContractId = value; RaisePropertyChanged("ProjectContractId"); } }

        /// <summary>
        /// 合約編號
        /// </summary>
        public string ProjectContractNumber { get => CopyofPOCOInstance.ProjectContract?.ContractNumber; set { RaisePropertyChanged("ProjectContractNumber"); } }

        /// <summary>
        /// 工程項目名稱
        /// </summary>
        public string EngineeringItemName { get => CopyofPOCOInstance.Engineering?.Name; set { RaisePropertyChanged("EngineeringItemName"); } }

        /// <summary>
        /// 供應商系統編號
        /// </summary>
        public Guid? ManufacturersId { get => CopyofPOCOInstance.SupplierTranscationItemId; set { CopyofPOCOInstance.SupplierTranscationItemId = value; RaisePropertyChanged("ManufacturersId"); } }

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName { get => CopyofPOCOInstance.SupplierTranscationItem?.ManufacturersBussinessItems?.Manufacturers?.Name; set { RaisePropertyChanged("ManufacturersName"); } }

        /// <summary>
        /// 交易品項
        /// </summary>
        public string ManufacturersBussinessItems { get => CopyofPOCOInstance.SupplierTranscationItem?.ManufacturersBussinessItems?.Name; set { } }

        /// <summary>
        /// 收料單號
        /// </summary>
        public string ReceiptNumber { get => CopyofPOCOInstance.Receipts?.ReceiptNumber; set { RaisePropertyChanged("ReceiptNumber"); } }

        /// <summary>
        /// 加工圖集系統編號
        /// </summary>
        public Guid? ProcessingAtlasId { get => CopyofPOCOInstance.ProcessingAtlasId; set { CopyofPOCOInstance.ProcessingAtlasId = value; RaisePropertyChanged("ProcessingAtlasId"); } }

        /// <summary>
        /// 加工圖集名稱
        /// </summary>
        public string ProcessingAtlasName { get => CopyofPOCOInstance.ProcessingAtlas?.Name; set { RaisePropertyChanged("ProcessingAtlasName"); } }
    }
}
