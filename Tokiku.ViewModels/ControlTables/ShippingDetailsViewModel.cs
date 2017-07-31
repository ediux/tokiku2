using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingDetailsViewModelCollection : BaseViewModelCollection<ShippingDetailsViewModel>
    {
        public ShippingDetailsViewModelCollection()
        {
        }

        public ShippingDetailsViewModelCollection(IEnumerable<ShippingDetailsViewModel> source) : base(source)
        {
        }

        public static ShippingDetailsViewModelCollection Query()
        {
            return Query<ShippingDetailsViewModelCollection, View_Shipping>("ShippingDetails", "QueryAll");
        }

    }

    public class ShippingDetailsViewModel : BaseViewModelWithPOCOClass<View_Shipping>
    {
        public ShippingDetailsViewModel(View_Shipping entity) : base(entity)
        {
        }

        // 領料單單號
        public string PickListNumber
        {
            get { return CopyofPOCOInstance.PickListNumber; }
            set { CopyofPOCOInstance.PickListNumber = value; RaisePropertyChanged("PickListNumber"); }
        }

        // 批號
        public string BatchNumber
        {
            get { return CopyofPOCOInstance.BatchNumber; }
            set { CopyofPOCOInstance.BatchNumber = value; RaisePropertyChanged("BatchNumber"); }
        }

        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.RequiredDetailsCode; }
            set { CopyofPOCOInstance.RequiredDetailsCode = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }

        // 廠商編號
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

        // 單位重(kg/m)
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

        // 下單數量
        public decimal OrderQuantity
        {
            get { return CopyofPOCOInstance.OrderQuantity; }
            set { CopyofPOCOInstance.OrderQuantity = value; RaisePropertyChanged("OrderQuantity"); }
        }

        // 出貨順序
        public int ShippingOrder
        {
            get { return CopyofPOCOInstance.ShippingOrder; }
            set { CopyofPOCOInstance.ShippingOrder = value; RaisePropertyChanged("ShippingOrder"); }
        }

        // 出貨重量
        public double Weight
        {
            get { return CopyofPOCOInstance.Weight; }
            set { CopyofPOCOInstance.Weight = value; RaisePropertyChanged("Weight"); }
        }

        // 缺貨數量
        public int LackQuantity
        {
            get { return CopyofPOCOInstance.LackQuantity; }
            set { CopyofPOCOInstance.LackQuantity = value; RaisePropertyChanged("LackQuantity"); }
        }

        // 出貨數量
        public int ShippingQuantity
        {
            get { return CopyofPOCOInstance.ShippingQuantity; }
            set { CopyofPOCOInstance.ShippingQuantity = value; RaisePropertyChanged("ShippingQuantity"); }
        }

        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    }
}
