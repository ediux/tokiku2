using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ControlTableViewModel : BaseViewModelWithPOCOClass<BOM>
    {
        #region Id
        /// <summary>
        /// BOM的編號
        /// </summary>
        public Guid Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }
        #endregion

        #region Row Index
        private int _RowIndex;

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; RaisePropertyChanged(""); }
        }
        #endregion

        #region 製單
        private string _OrderNumber;

        public string OrderNumber
        {
            get
            {
                try
                {
                    var order = CopyofPOCOInstance.PurchasingOrder;
                    if (order != null)
                    {
                        if (order.FormDetails != null)
                            return order.FormDetails.FormNumber;
                        else
                            return string.Empty;
                    }
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                    return "#ERROR";
                }
            }
            set
            {
                try
                {

                }
                catch (Exception ex)
                {

                    setErrortoModel(this, ex);
                }

            }
        }

        #endregion

        #region 加工編號
        private string _ProcessingNumber;
        /// <summary>
        /// 加工編號
        /// </summary>
        public string ProcessingNumber
        {
            get { return _ProcessingNumber; }
            set { _ProcessingNumber = value; RaisePropertyChanged("ProcessingNumber"); }
        }

        #endregion

        #region 東菊編號

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); }
        }
        #endregion

        #region 尺寸
        public string CutLength
        {
            get { return CopyofPOCOInstance.Size; }
            set { CopyofPOCOInstance.Size = value; RaisePropertyChanged("CutLength"); }
        }
        #endregion

        #region 廠商

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }

        #endregion

        #region 廠商編號
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturersCode
        {
            get
            {
                return CopyofPOCOInstance.FactoryNumber;
            }
            set
            {
                CopyofPOCOInstance.FactoryNumber = value;
                RaisePropertyChanged("ManufacturersCode");
            }
        }
        #endregion

        #region Material Categories 材料類別

        /// <summary>
        /// 材料類別(名稱)
        /// </summary>
        [Display(Name = "材料屬性", Order = 5)]
        public string MaterialCategories
        {
            get { return CopyofPOCOInstance.MaterialCategories.Name; }
            set
            {
                try
                {
                    Controllers.MaterialManagementController controller = new Controllers.MaterialManagementController();
                    var executeresult = controller.FindMaterialCategoriesByName(value);

                    if (!executeresult.HasError)
                    {
                        CopyofPOCOInstance.MaterialCategoriesId = executeresult.Result.Single().Id;
                    }
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        #endregion

        #region 單位重量
        public decimal? UnitWeight { get { return CopyofPOCOInstance.UnitWeight; } set { CopyofPOCOInstance.UnitWeight = value; RaisePropertyChanged("UnitWeight"); } }
        #endregion

        #region 訂購長度
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.OrderLength; }
            set { CopyofPOCOInstance.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }
        #endregion

        #region required quantity 需求數量-數量小計
        public decimal? RequiredQuantitySummary
        {
            get { return CopyofPOCOInstance.RequiredQuantitySubtotal; }
            set { CopyofPOCOInstance.RequiredQuantitySubtotal = value; RaisePropertyChanged("RequiredQuantitySummary"); }
        }
        #endregion

        #region required quantity 需求數量-重量小計
        public decimal RequiredWeightSubtotal
        {
            get { return CopyofPOCOInstance.RequiredQuantityWeightSummary; }
            set { CopyofPOCOInstance.RequiredQuantityWeightSummary = value; RaisePropertyChanged("RequiredWeightSubtotal"); }
        }
        #endregion

        #region required quantity 需求數量-未下訂單數量
        public decimal? NumberofOrdersNotPlaced
        {
            get { return CopyofPOCOInstance.NumberofOrdersNotPlaced; }
            set { CopyofPOCOInstance.NumberofOrdersNotPlaced = value; RaisePropertyChanged("NumberofOrdersNotPlaced"); }
        }
        #endregion

        #region 訂單數量-數量小計(單位:支)
        public decimal? QuantityofOrderSummary
        {
            get { return CopyofPOCOInstance.QuantityofOrderSummary; }
            set { CopyofPOCOInstance.QuantityofOrderSummary = value; RaisePropertyChanged("QuantityofOrderSummary"); }
        }
        #endregion

        #region 訂單數量-備品小計(單位:支)
        public decimal? PrepareSubtotal
        {
            get { return CopyofPOCOInstance.PrepareSubtotal; }
            set
            {
                CopyofPOCOInstance.QuantityofOrderSummary = value;
                RaisePropertyChanged("PrepareSubtotal");
            }
        }
        #endregion

        #region 訂單總重量  (訂單+備品)    (單位:kg)
        public decimal? TotalWeightofOrder
        {
            get { return CopyofPOCOInstance.TotalWeightofOrder; }
            set { CopyofPOCOInstance.TotalWeightofOrder = value; RaisePropertyChanged("TotalWeightofOrder"); }
        }
        #endregion

        #region 到貨狀況 (所有倉別庫存彙總) - 數量小計(單位:支) 
        public decimal? ArrivalCondition_QuantitySubtotal
        {
            get { return CopyofPOCOInstance.ArrivalCondition_QuantitySubtotal; }
            set { CopyofPOCOInstance.ArrivalCondition_QuantitySubtotal = value; RaisePropertyChanged("ArrivalCondition_QuantitySubtotal"); }
        }
        #endregion

        #region 到貨狀況 (所有倉別庫存彙總)-重量小計(單位:kg)
        public decimal? ArrivalCondition_WeightSubtotal
        {
            get { return CopyofPOCOInstance.ArrivalCondition_WeightSubtotal; }
            set { CopyofPOCOInstance.ArrivalCondition_WeightSubtotal = value; RaisePropertyChanged("ArrivalCondition_WeightSubtotal"); }
        }
        #endregion
    }
}
