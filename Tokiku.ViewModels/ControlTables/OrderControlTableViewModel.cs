using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderControlTableViewModelCollection : BaseViewModelCollection<OrderControlTableViewModel, View_OrderControlTable>
    {
        public OrderControlTableViewModelCollection()
        {
        }

        public OrderControlTableViewModelCollection(IEnumerable<OrderControlTableViewModel> source) : base(source)
        {
        }

        public static OrderControlTableViewModelCollection Query()
        {
            return Query<OrderControlTableViewModelCollection>("OrderControlTable", "QueryAll");
        }

    }

    public class OrderControlTableViewModel : BaseViewModelWithPOCOClass<View_OrderControlTable>
    {
        public OrderControlTableViewModel()
        {

        }
        public OrderControlTableViewModel(View_OrderControlTable entiy):base(entiy)
        {

        }

        // 專案編號
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); }
        }
        // 專案名稱
        public string ProjectsName
        {
            get { return CopyofPOCOInstance.ProjectsName; }
            set { CopyofPOCOInstance.ProjectsName = value; RaisePropertyChanged("ProjectsName"); }
        }
        // 施工圖集
        public int? Atlas
        {
            get { return CopyofPOCOInstance.Atlas; }
            set { CopyofPOCOInstance.Atlas = value; RaisePropertyChanged("Atlas"); }
        }
        // 訂製單單號
        public string FormNumber
        {
            get { return CopyofPOCOInstance.FormNumber; }
            set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.RequiredDetailsCode; }
            set { CopyofPOCOInstance.RequiredDetailsCode = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }
        // 廠商代碼
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.ManufacturersCode; }
            set { CopyofPOCOInstance.ManufacturersCode = value; RaisePropertyChanged("ManufacturersCode"); }
        }
        // 廠商名稱
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.ManufacturersName; }
            set { CopyofPOCOInstance.ManufacturersName = value; RaisePropertyChanged("ManufacturersName"); }
        }
        // 材質
        public string MaterialsName
        {
            get { return CopyofPOCOInstance.MaterialsName; }
            set { CopyofPOCOInstance.MaterialsName = value; RaisePropertyChanged("MaterialsName"); }
        }
        // 單位重量(kg/m)
        public decimal UnitWeight
        {
            get { return CopyofPOCOInstance.UnitWeight; }
            set { CopyofPOCOInstance.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }
        // 訂購長度(mm)
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.OrderLength; }
            set { CopyofPOCOInstance.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }
        // 訂單數量(單位:支)
        public decimal? OrderQuantity
        {
            get { return CopyofPOCOInstance.OrderQuantity; }
            set { CopyofPOCOInstance.OrderQuantity = value; RaisePropertyChanged("OrderQuantity"); }
        }
        // 備品數量(單位:支)
        public decimal? SparePartsNumber
        {
            get { return CopyofPOCOInstance.SparePartsNumber; }
            set { CopyofPOCOInstance.SparePartsNumber = value; RaisePropertyChanged("SparePartsNumber"); }
        }
        // 訂單總數(備品+訂單數量)
        public decimal? OrderTotalQuantity
        {
            get { return CopyofPOCOInstance.OrderTotalQuantity; }
            set { CopyofPOCOInstance.OrderTotalQuantity = value; RaisePropertyChanged("OrderTotalQuantity"); }
        }
        // 訂單總重量(單位:kg)
        public decimal? OrderTotalWeight
        {
            get { return CopyofPOCOInstance.OrderTotalWeight; }
            set { CopyofPOCOInstance.OrderTotalWeight = value; RaisePropertyChanged("OrderTotalWeight"); }
        }
        // 預估交期
        public DateTime ExpectedDelivery
        {
            get { return CopyofPOCOInstance.ExpectedDelivery; }
            set { CopyofPOCOInstance.ExpectedDelivery = value; RaisePropertyChanged("ExpectedDelivery"); }
        }
        // 出貨順序
        public int? ShippingOrder
        {
            get { return CopyofPOCOInstance.ShippingOrder; }
            set { CopyofPOCOInstance.ShippingOrder = value; RaisePropertyChanged("ShippingOrder"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }
        // 缺料(支)
        public int LackQuantity
        {
            get { return CopyofPOCOInstance.LackQuantity; }
            set { CopyofPOCOInstance.LackQuantity = value; RaisePropertyChanged("LackQuantity"); }
        }
        // 缺料(kg)
        public decimal? LackWeight
        {
            get { return CopyofPOCOInstance.LackWeight; }
            set { CopyofPOCOInstance.LackWeight = value; RaisePropertyChanged("LackWeight"); }
        }

    }
}
