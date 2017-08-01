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

        public static ObtainMaterialViewModelCollection QueryHeader()
        {
            return Query<ObtainMaterialViewModelCollection, PickListDetails>("ObtainMaterial", "QueryHeader");
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

        #region 領料單明細

        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Code; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Code = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }

        // 廠商編號
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Code; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Code = value; RaisePropertyChanged("ManufacturersCode"); }
        }

        // 廠商名稱
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Name; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }

        // 材質
        public string MaterialsName
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Materials.Name; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Materials.Name = value; RaisePropertyChanged("MaterialsName"); }
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

        #endregion

        #region 領料單檔頭

        // 專案合約編號
        public string ContractNumber
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.ProjectContract.ContractNumber; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.ProjectContract.ContractNumber = value; RaisePropertyChanged("ContractNumber"); }
        }

        // 專案名稱
        public string ProjectsName
        {
            get { return CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.ProjectContract.Projects.Name; }
            set { CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.ProjectContract.Projects.Name = value; RaisePropertyChanged("ProjectsName"); }
        }

        // 領料單號
        public string PickListNumber
        {
            get { return CopyofPOCOInstance.PickList.PickListNumber; }
            set { CopyofPOCOInstance.PickList.PickListNumber = value; RaisePropertyChanged("PickListNumber"); }
        }

        // 領料倉別
        public string StocksName
        {
            get { return CopyofPOCOInstance.PickList.Stocks.Name; }
            set { CopyofPOCOInstance.PickList.Stocks.Name = value; RaisePropertyChanged("StocksName"); }
        }

        // 申請日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.PickList.MakingTime; }
            set { CopyofPOCOInstance.PickList.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }

        // 製單人
        public string MakingUser
        {
            get { return CopyofPOCOInstance.PickList.MakingUsers.UserName; }
            set { CopyofPOCOInstance.PickList.MakingUsers.UserName = value; RaisePropertyChanged("MakingUser"); }
        }

        // 加工廠商
        public string IncomingManufacturersName
        {
            get { return CopyofPOCOInstance.PickList.Manufacturers.Name; }
            set { CopyofPOCOInstance.PickList.Manufacturers.Name = value; RaisePropertyChanged("IncomingManufacturersName"); }
        }

        // 輸入日期
        public override DateTime CreateTime
        {
            get { return CopyofPOCOInstance.PickList.CreateTime; }
            set { CopyofPOCOInstance.PickList.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }

        // 輸入人員
        public string CreateUserName
        {
            get { return CopyofPOCOInstance.PickList.CreateUsers.UserName; }
            set { CopyofPOCOInstance.PickList.MakingUsers.UserName = value; RaisePropertyChanged("CreateUserName"); }
        }

        #endregion
    }
}
