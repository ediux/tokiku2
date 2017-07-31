using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ObtainMaterialViewModelCollection : BaseViewModelCollection<ObtainMaterialViewModel>
    {
        public ObtainMaterialViewModelCollection()
        {
            _ControllerName = "ObtainMaterial";
        }

        public ObtainMaterialViewModelCollection(IEnumerable<ObtainMaterialViewModel> source) : base(source)
        {
            _ControllerName = "ObtainMaterial";
        }

        public static ObtainMaterialViewModelCollection Query()
        {
            return Query<ObtainMaterialViewModelCollection, PickListDetails>("ObtainMaterial", "QueryAll");
        }
    }

    public class ObtainMaterialViewModel : BaseViewModelWithPOCOClass<PickListDetails>
    {
        public ObtainMaterialViewModel()
        {
            _SaveModelController = "ObtainMaterial";
        }
        public ObtainMaterialViewModel(PickListDetails entity) : base(entity)
        {
            _SaveModelController = "ObtainMaterial";
        }

        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Code; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Code = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }

        // 廠商編號
        public string FactoryNumber
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.FactoryNumber; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.FactoryNumber = value; RaisePropertyChanged("FactoryNumber"); }
        }

        // 單位重
        public decimal UnitWeight
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.UnitWeight; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }

        // 訂購長度
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.OrderLength; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }

        // 領料數量
        public int ShippingQuantity
        {
            get { return CopyofPOCOInstance.ShippingQuantity; }
            set { CopyofPOCOInstance.ShippingQuantity = value; RaisePropertyChanged("ShippingQuantity"); }
        }

        // 庫存結餘數量
        public decimal? InventoryStatus_QuantitySubtotal
        {
            get { return CopyofPOCOInstance.OrderDetails.ControlTableDetails.InventoryStatus_QuantitySubtotal; }
            set { CopyofPOCOInstance.OrderDetails.ControlTableDetails.InventoryStatus_QuantitySubtotal = value; RaisePropertyChanged("InventoryStatus_QuantitySubtotal"); }
        }

        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    }
}
