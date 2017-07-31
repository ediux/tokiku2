using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialDetailsViewModel : BaseViewModelWithPOCOClass<PickListDetails>
    {
        public ShippingMaterialDetailsViewModel()
        {

        }

        public ShippingMaterialDetailsViewModel(PickListDetails entity) : base(entity)
        {

        }

        public static ShippingMaterialDetailsViewModel Query(Guid Id)
        {
            try
            {
               return QuerySingle<ShippingMaterialDetailsViewModel, PickListDetails>(
                    "Shipping", "QuerySingle", Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int _RowIndex = 0;

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex { get => _RowIndex; set { _RowIndex = value; } }

        /// <summary>
        /// 單號
        /// </summary>
        public string PickListNumber { get => CopyofPOCOInstance.OrderDetails.Orders.FormNumber; set {

            } }

        /// <summary>
        /// 批號
        /// </summary>
        public string BatchNumber { get => CopyofPOCOInstance.OrderDetails.Orders.BatchNumber; set { RaisePropertyChanged("BatchNumber"); } }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string RequiredDetailsCode { get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Code; set { RaisePropertyChanged("RequiredDetailsCode"); } }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturersCode { get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Code; set { RaisePropertyChanged("ManufacturersCode"); } }

        /// <summary>
        /// 廠商
        /// </summary>
        public string ManufacturersName { get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Required.Manufacturers.Name; set { RaisePropertyChanged("ManufacturersName");  } }

        /// <summary>
        /// 材質
        /// </summary>
        public string MaterialsName { get; set; }

        /// <summary>
        /// 單位重
        /// </summary>
        public decimal UnitWeight { get => CopyofPOCOInstance.OrderDetails.RequiredDetails.UnitWeight; set { } }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public int? OrderLength { get => CopyofPOCOInstance.OrderDetails?.RequiredDetails?.OrderLength; set { } }

        /// <summary>
        /// 訂購數量
        /// </summary>
        public decimal OrderQuantity { get => CopyofPOCOInstance.OrderDetails.OrderQuantity; set { } }

        /// <summary>
        /// 出貨順序
        /// </summary>
        public int ShippingOrder { get => CopyofPOCOInstance.ShippingOrder; set { CopyofPOCOInstance.ShippingOrder = value; RaisePropertyChanged("ShippingOrder"); } }

        /// <summary>
        /// 出貨重量
        /// </summary>
        public double Weight { get => CopyofPOCOInstance.Weight; set { CopyofPOCOInstance.Weight = value; RaisePropertyChanged("Weight"); } }

        /// <summary>
        /// 缺貨數量
        /// </summary>
        public int LackQuantity { get => CopyofPOCOInstance.LackQuantity; set { CopyofPOCOInstance.LackQuantity = value; RaisePropertyChanged("LackQuantity"); } }

        /// <summary>
        /// 出貨數量
        /// </summary>
        public int ShippingQuantity { get => CopyofPOCOInstance.ShippingQuantity; set { CopyofPOCOInstance.ShippingQuantity = value; RaisePropertyChanged("ShippingQuantity"); } }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get => CopyofPOCOInstance.Comment; set { CopyofPOCOInstance.Comment = value;RaisePropertyChanged("Comment"); } }
    }
}
