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
                var coll = Query<RequiredControlTableViewModelCollection, ControlTableDetails>(
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
            return Query<RequiredControlTableViewModelCollection, ControlTableDetails>("ControlTable", "QueryAll");
        }

        public RequiredControlTableViewModelCollection QueryByText(string text)
        {
            return Query<RequiredControlTableViewModelCollection, ControlTableDetails>("ControlTable", "SearchByText", text);
        }
    }

    public class RequiredControlTableViewModel : BaseViewModelWithPOCOClass<ControlTableDetails>
    {
        public RequiredControlTableViewModel(ControlTableDetails entity) : base(entity)
        {

        }


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

        #region 製單

        public string OrderNumber
        {
            get
            {
                try
                {
                    //var order = CopyofPOCOInstance;
                    //if (order != null)
                    //{
                    //    if (order.ControlTableDetails.SelectMany(s=>s.OrderDetails.Select(x=>x.Orders.FormNumber)) != null)
                    //        return order.FormDetails.FormNumber;
                    //    else
                    //        return string.Empty;
                    //}
                    //else
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

        #region 東菊編號

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.RequiredDetails?.FirstOrDefault().Code; }
            set { RaisePropertyChanged("Code"); }
        }
        #endregion

        #region 廠商

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.RequiredDetails?.FirstOrDefault().Required.Manufacturers.Name; }
            set { RaisePropertyChanged("ManufacturersName"); }
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
                return CopyofPOCOInstance.RequiredDetails?.FirstOrDefault().FactoryNumber;
            }
            set
            {
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
            get { return string.Join(",", CopyofPOCOInstance.RequiredDetails.Where(w=>w.Materials !=null).Select(s => s.Materials.Name).Distinct().ToArray()); }
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
            get { return CopyofPOCOInstance.RequiredDetails?.FirstOrDefault()?.UnitWeight; }
            set { RaisePropertyChanged("UnitWeight"); }
        }
        #endregion

        #region 訂購長度
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.RequiredDetails.FirstOrDefault().OrderLength; }
            set { RaisePropertyChanged("OrderLength"); }
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
