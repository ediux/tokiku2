using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RecvMaterialDetailsViewModel : BaseViewModelWithPOCOClass<ReceiveDetails>
    {
        public RecvMaterialDetailsViewModel()
        {

        }

        public RecvMaterialDetailsViewModel(ReceiveDetails entity) : base(entity)
        {

        }

        /// <summary>
        /// 收料單細項編號
        /// </summary>
        public new Guid Id
        {
            get => CopyofPOCOInstance.Id;
            set
            {
                CopyofPOCOInstance.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        private int _RowIndex = 0;
        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex
        {
            get
            {
                if (_RowIndex == 0)
                {
                    if (CopyofPOCOInstance?.Receipts?.ReceiptDetails != null)
                        _RowIndex = CopyofPOCOInstance.Receipts.ReceiptDetails.Count + 1;
                    else
                        _RowIndex = 1;
                }

                return _RowIndex;
            }
            set
            {
                _RowIndex = value;
                RaisePropertyChanged("RowIndex");
            }
        }

        /// <summary>
        /// 訂製單號
        /// </summary>
        public string OrderNumber { get => CopyofPOCOInstance.OrderDetails.Orders.FormNumber; set { RaisePropertyChanged("OrderNumber"); } }

        /// <summary>
        /// 批號
        /// </summary>
        public string BatchNumber { get => CopyofPOCOInstance.OrderDetails.Orders.BatchNumber; set { RaisePropertyChanged("BatchNumber"); } }

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get => CopyofPOCOInstance.OrderDetails.RequiredDetails.Code; set
            {

                var found = ExecuteAction<OrderDetails>("Orders", "QuerySingleDetailByCode", value);

                if (found != null)
                {
                    CopyofPOCOInstance.OrderDetails = found;
                    CopyofPOCOInstance.OrderDetailId = found.Id;
                }
                else
                {
                    throw new Exception("找不到對應需求單項目");
                    //反查
                }

                RaisePropertyChanged("Code");
                RaisePropertyChanged("FactoryNumber");
                RaisePropertyChanged("Materials");
                RaisePropertyChanged("UnitWeight");
                RaisePropertyChanged("OrderLength");
                RaisePropertyChanged("OrderQuantity");
                RaisePropertyChanged("OrderNumber");
                RaisePropertyChanged("BatchNumber");

            }
        }

        /// <summary>
        /// 廠商編號
        /// </summary>
        public string FactoryNumber { get => CopyofPOCOInstance?.OrderDetails?.RequiredDetails?.FactoryNumber; set { RaisePropertyChanged("FactoryNumber"); } }

        /// <summary>
        /// 材質
        /// </summary>
        public string Materials { get => CopyofPOCOInstance?.OrderDetails?.RequiredDetails?.Materials?.Name; set { RaisePropertyChanged("Materials"); } }

        /// <summary>
        /// 單位重
        /// </summary>
        public decimal? UnitWeight { get => CopyofPOCOInstance?.OrderDetails?.RequiredDetails?.UnitWeight; set { RaisePropertyChanged("UnitWeight"); } }

        /// <summary>
        /// 訂購長度
        /// </summary>
        public int? OrderLength { get => CopyofPOCOInstance.OrderDetails.RequiredDetails.OrderLength; set { RaisePropertyChanged("OrderLength"); } }

        /// <summary>
        /// 下單數量
        /// </summary>
        public decimal? OrderQuantity { get => CopyofPOCOInstance.OrderDetails.OrderQuantity; set { RaisePropertyChanged("OrderQuantity"); } }

        /// <summary>
        /// 重量
        /// </summary>
        public double Weight { get => CopyofPOCOInstance.Weight; set { } }

        /// <summary>
        /// 缺料數量
        /// </summary>
        public int LackMaterialQuantity { get => CopyofPOCOInstance.LackQuantity; set { } }

        /// <summary>
        /// 收料數量
        /// </summary>
        public int ReceivedQuantity { get => CopyofPOCOInstance.ReceiptQuantity; set { } }

        /// <summary>
        /// 備註說明
        /// </summary>
        public string Comment { get => CopyofPOCOInstance.Comment; set { } }
    }
}
