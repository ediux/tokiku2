using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ReturnsDetailsViewModel : BaseViewModelWithPOCOClass<ReturnDetails>
    {
        public ReturnsDetailsViewModel()
        {

        }

        public ReturnsDetailsViewModel(ReturnDetails entity) : base(entity)
        {

        }

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 訂單
        /// </summary>
        public string OrderFormNumber
        {
            get => CopyofPOCOInstance.OrderDetails.Orders.FormNumber; set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", value, BatchNumber, Code, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }

                RaisePropertyChanged("OrderFormNumber");
            }
        }

        /// <summary>
        /// 批號
        /// </summary>
        public string BatchNumber
        {
            get => CopyofPOCOInstance.OrderDetails.Orders.BatchNumber; set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, value, Code, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }

                RaisePropertyChanged("BatchNumber");
            }
        }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Code;
            set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, value, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }


                RaisePropertyChanged("Code");
            }
        }

        /// <summary>
        /// 廠商編號(大同編號)
        /// </summary>
        public string FactoryNumber
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.FactoryNumber;
            set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, Code, value, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }

                RaisePropertyChanged("FactoryNumber");
            }
        }

        /// <summary>
        /// 材質
        /// </summary>
        public string MaterialsName
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Materials.Name; set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, Code, FactoryNumber, value);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }
                RaisePropertyChanged("MaterialsName");
            }
        }

        /// <summary>
        /// 單位重量
        /// </summary>
        public decimal UnitWeight
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.UnitWeight;
            set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, Code, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }

                RaisePropertyChanged("UnitWeight");
            }
        }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public int? OrderLenth
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.OrderLength;
            set
            {
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, Code, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }
                RaisePropertyChanged("OrderLenth");
            }
        }

        /// <summary>
        /// 下單數量
        /// </summary>
        public decimal PlaceAnOrderQuantity
        {
            get { return CopyofPOCOInstance.OrderDetails.OrderQuantity; }
            set {
                
                OrderDetails result = ExecuteAction<OrderDetails>("OrderDetails", "QuerySingleDetailByReturnDetail", OrderFormNumber, BatchNumber, Code, FactoryNumber, MaterialsName);

                if (result != null)
                {
                    CopyofPOCOInstance.OrderDetails = result;
                    CopyofPOCOInstance.OrderDetailId = result.Id;
                }
                RaisePropertyChanged("PlaceAnOrderQuantity"); }
        }

        /// <summary>
        /// 出貨順序
        /// </summary>
        public int ShippingOrder { get => CopyofPOCOInstance.ShippingOrder; set { CopyofPOCOInstance.ShippingOrder = value; RaisePropertyChanged("ShippingOrder"); } }

        /// <summary>
        /// 重量
        /// </summary>
        public double Weight { get => CopyofPOCOInstance.Weight; set { CopyofPOCOInstance.Weight = value;RaisePropertyChanged("Weight"); } }

        /// <summary>
        /// 缺料
        /// </summary>
        public int LackofQuantity { get => CopyofPOCOInstance.LackQuantity; set { CopyofPOCOInstance.LackQuantity = value;RaisePropertyChanged("LackofQuantity"); } }

        /// <summary>
        /// 退貨量
        /// </summary>
        public int ReturnQuantity { get => CopyofPOCOInstance.ReturnQuantity; set { CopyofPOCOInstance.ReturnQuantity = value; RaisePropertyChanged("ReturnQuantity"); } }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get => CopyofPOCOInstance.Comment; set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); } }
    }
}
