using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredControlTableViewModelCollection : BaseViewModelCollection<RequiredControlTableViewModel>
    {
        public RequiredControlTableViewModelCollection()
        {

        }

        public RequiredControlTableViewModelCollection(IEnumerable<RequiredControlTableViewModel> source) : base(source)
        {
            this.QueryCommand = new QueryCommand(QueryCommandHandler);
        }

        public static void QueryCommandHandler(object parameter)
        {

        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Items[e.NewStartingIndex].RowIndex = Count;
            base.OnCollectionChanged(e);
        }

        public static RequiredControlTableViewModelCollection Query(Guid ProjectId)
        {
            try
            {
                var coll = Query<RequiredControlTableViewModelCollection, View_RequiredControlTable>(
                    "ControlTable", "QueryAll", ProjectId);
                int i = 1;
                foreach (var item in coll)
                {
                    item.RowIndex = i;
                    i++;
                }
                return coll;
            }
            catch (Exception ex)
            {
                RequiredControlTableViewModelCollection collection = new RequiredControlTableViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }

        public static RequiredControlTableViewModelCollection Query()
        {
            try
            {
                var coll = Query<RequiredControlTableViewModelCollection, View_RequiredControlTable>("ControlTable", "QueryAll");
                int i = 1;
                foreach (var item in coll)
                {
                    item.RowIndex = i;
                    i++;
                }
                return coll;
            }
            catch (Exception ex)
            {
                RequiredControlTableViewModelCollection collection = new RequiredControlTableViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }

        public RequiredControlTableViewModelCollection QueryByText(string text)
        {
            try
            {
                var coll = Query<RequiredControlTableViewModelCollection, View_RequiredControlTable>("ControlTable", "SearchByText", text);
                int i = 1;
                foreach (var item in coll)
                {
                    item.RowIndex = i;
                    i++;
                }
                return coll;
            }
            catch (Exception ex)
            {
                RequiredControlTableViewModelCollection collection = new RequiredControlTableViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
            
        }
    }

    public class RequiredControlTableViewModel : BaseViewModelWithPOCOClass<View_RequiredControlTable>
    {
        public RequiredControlTableViewModel()
        {

        }

        public RequiredControlTableViewModel(View_RequiredControlTable entity) : base(entity)
        {

        }

        public bool IsSelected { get; set; }

        #region Row Index
        private int _RowIndex;

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; RaisePropertyChanged("RowIndex"); }
        }
        #endregion

        #region 東菊編號

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { RaisePropertyChanged("Code"); }
        }
        #endregion

        #region 廠商

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.ManufacturersName; }
            set { RaisePropertyChanged("ManufacturersName"); }
        }

        #endregion

        #region 廠商編號
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.FactoryNumber; ; }
            set { RaisePropertyChanged("ManufacturersCode"); }
        }
        #endregion

        #region Material Categories 材料類別

        /// <summary>
        /// 材料類別(名稱)
        /// </summary>
        [Display(Name = "材質", Order = 5)]
        public string MaterialCategories
        {
            get { return CopyofPOCOInstance.Materials; }
            set
            {
                //try
                //{
                //    Controllers.MaterialManagementController controller = new Controllers.MaterialManagementController();
                //    var executeresult = controller.FindMaterialCategoriesByName(value);

                //    if (!executeresult.HasError)
                //    {
                //        CopyofPOCOInstance.ControlTables.MaterialCategoriesId = executeresult.Result.Single().Id;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    setErrortoModel(this, ex);
                //}
                RaisePropertyChanged("MaterialCategories");
            }
        }

        #endregion

        #region 單位重量
        public decimal? UnitWeight
        {
            get { return CopyofPOCOInstance.UnitWeight; }
            set { RaisePropertyChanged("UnitWeight"); }
        }
        #endregion

        #region 訂購長度
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.OrderLength; }
            set { RaisePropertyChanged("OrderLength"); }
        }
        #endregion

        #region required quantity 需求數量-數量小計
        public int? RequiredQuantitySummary
        {
            get { return CopyofPOCOInstance.RequiredQuantitySubtotal; }
            set { CopyofPOCOInstance.RequiredQuantitySubtotal = value; RaisePropertyChanged("RequiredQuantitySummary"); }
        }
        #endregion

        #region required quantity 需求數量-重量小計
        public decimal? RequiredWeightSubtotal
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
            get { return 0; }
            set { RaisePropertyChanged("PrepareSubtotal"); }
        }
        #endregion

        #region 訂單總重量  (訂單+備品)    (單位:kg)
        public decimal? TotalWeightofOrder
        {
            get { return 0; }
            set {  RaisePropertyChanged("TotalWeightofOrder"); }
        }
        #endregion

        #region 到貨狀況 (所有倉別庫存彙總) - 數量小計(單位:支) 
        public int? ArrivalCondition_QuantitySubtotal
        {
            get { return CopyofPOCOInstance.ArrivalCondition_QuantitySubtotal; }
            set { CopyofPOCOInstance.ArrivalCondition_QuantitySubtotal = value; RaisePropertyChanged("ArrivalCondition_QuantitySubtotal"); }
        }
        #endregion

        #region 到貨狀況 (所有倉別庫存彙總)-重量小計(單位:kg)
        public double? ArrivalCondition_WeightSubtotal
        {
            get { return CopyofPOCOInstance.ArrivalCondition_WeightSubtotal;  }
            set { CopyofPOCOInstance.ArrivalCondition_WeightSubtotal = value; RaisePropertyChanged("ArrivalCondition_WeightSubtotal"); }
        }
        #endregion

        #region 缺貨數量小計
        public decimal? ArrivalCondition_OutofStock
        {
            get { return CopyofPOCOInstance.ArrivalCondition_OutofStock; }
            set { RaisePropertyChanged("ArrivalCondition_OutofStock"); }
        }
        #endregion

        #region 退貨狀況 數量小計
        public decimal? ReturnStatus_QuantitySubtotal
        {
            get { return CopyofPOCOInstance.ReturnStatus_QuantitySubtotal; }
            set { RaisePropertyChanged("ReturnStatus_QuantitySubtotal"); }
        }
        #endregion

        #region 退貨狀況 重量小計
        public double? ReturnStatus_WeightSubtotal
        {
            get { return CopyofPOCOInstance.ReturnStatus_WeightSubtotal; }
            set { RaisePropertyChanged("ReturnStatus_WeightSubtotal"); }
        }
        #endregion

        #region 退貨狀況 收穫數量小計
        public double? ReturnStatus_Receipt_QuantitySubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("ReturnStatus_Receipt_QuantitySubtotal"); }
        }
        #endregion

        #region 退貨狀況 收穫重量小計
        public double? ReturnStatus_Receipt_WeightSubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("ReturnStatus_Receipt_WeightSubtotal"); }
        }
        #endregion

        #region 退貨狀況 扣款數量小計
        public double? ReturnStatus_Charge_QuantitySubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("ReturnStatus_Charge_QuantitySubtotal"); }
        }
        #endregion

        #region 退貨狀況 扣款重量小計
        public double? ReturnStatus_Charge_WeightSubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("ReturnStatus_Charge_WeightSubtotal"); }
        }
        #endregion

        #region 庫存調整 數量小計
        public Nullable<decimal> InventoryMargin_LossAdjustment_QuantitySubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("InventoryMargin_LossAdjustment_QuantitySubtotal"); }
        }
        #endregion

        #region 庫存調整 重量小計
        public Nullable<decimal> InventoryMargin_LossAdjustment_WeightSubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("InventoryMargin_LossAdjustment_WeightSubtotal"); }
        }
        #endregion

        #region 庫存狀況 數量小計
        public Nullable<decimal> InventoryStatus_QuantitySubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("InventoryStatus_QuantitySubtotal"); }
        }
        #endregion

        #region 庫存狀況 重量小計
        public Nullable<decimal> InventoryStatus_WeightSubtotal
        {
            get { return 0; }
            set { RaisePropertyChanged("InventoryStatus_WeightSubtotal"); }
        }
        #endregion
    }
}
