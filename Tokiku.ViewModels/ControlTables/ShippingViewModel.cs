using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialViewModelCollection : BaseViewModelCollection<ShippingMaterialViewModel>
    {
        public ShippingMaterialViewModelCollection()
        {
           
        }

        public ShippingMaterialViewModelCollection(IEnumerable<ShippingMaterialViewModel> source) : base(source)
        {
           
        }

        public override string SaveModelController => "Shipping";

        public static ShippingMaterialViewModelCollection Query(Guid ProjectId)
        {
            return Query<ShippingMaterialViewModelCollection, PickList>
                ("Shipping", "QueryAll", ProjectId);
        }

    }

    public class ShippingMaterialViewModel : BaseViewModelWithPOCOClass<PickList>
    {
        public ShippingMaterialViewModel()
        {
 
        }

        public ShippingMaterialViewModel(PickList entity) : base(entity)
        {
            Details.CollectionChanged += Details_CollectionChanged;
           
        }

        public override void Initialized(object Parameter)
        {
            MakingTime = DateTime.Now;
        }

        private void Details_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    _ShippingCounting = Details.Count;
                    _OrderQuantitySubtotal = Details.Sum(s => s.OrderQuantity);
                    _WeightSubtotal = Details.Sum(s => s.OrderQuantity * s.UnitWeight);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    _ShippingCounting = Details.Count;
                    _OrderQuantitySubtotal = Details.Sum(s => s.OrderQuantity);
                    _WeightSubtotal = Details.Sum(s => s.OrderQuantity * s.UnitWeight);
                    break;
                       
            }
        }

        public override string SaveModelController { get => "Shipping"; set { } }


        public static ShippingMaterialViewModel Query(Guid Id, Guid ProjectId)
        {
            try
            {
                return QuerySingle<ShippingMaterialViewModel, PickList>(
                    "Shipping", "QuerySingle", Id, ProjectId);
            }
            catch (Exception ex)
            {
                ShippingMaterialViewModel emptycollection = new ShippingMaterialViewModel();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }

      
        // 領料單單號
        public string PickListNumber
        {
            get { return CopyofPOCOInstance.PickListNumber; }
            set { CopyofPOCOInstance.PickListNumber = value; RaisePropertyChanged("PickListNumber"); }
        }

        public Guid? IncomingManufacturerId
        {
            get => CopyofPOCOInstance.IncomingManufacturerId; set
            {
                CopyofPOCOInstance.IncomingManufacturerId = value;
                RaisePropertyChanged("IncomingManufacturerId");
            }
        }

        // 來料廠商代碼
        public string IncomingManufacturersCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("IncomingManufacturersCode"); }
        }
        // 來料廠商
        public string IncomingManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("IncomingManufacturersName"); }
        }
        // 來料單號
        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }

        /// <summary>
        /// 輸入人員
        /// </summary>
        public new string CreateUser
        {
            get { return CopyofPOCOInstance.CreateUsers.UserName; }
            set { CopyofPOCOInstance.CreateUsers.UserName = value; RaisePropertyChanged("CreateUser"); }
        }

        /// <summary>
        /// 輸入日期
        /// </summary>
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }

        // 製單人員
        public string MakingUserName
        {
            get { return CopyofPOCOInstance.MakingUsers.UserName; }
            set { RaisePropertyChanged("MakingUserName"); }
        }
        // 製單日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.MakingTime; }
            set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

        /// <summary>
        /// 倉別ID
        /// </summary>
        public Guid? StockId
        {
            get => CopyofPOCOInstance.StockId; set
            {
                CopyofPOCOInstance.StockId = value;
                var foundStock = ExecuteAction<Stocks>("Stock", "QuerySingle", CopyofPOCOInstance.StockId);
                if (foundStock != null)
                {
                    CopyofPOCOInstance.Stocks = foundStock;
                }
                RaisePropertyChanged("StockId");
            }
        }

        /// <summary>
        /// 倉別
        /// </summary>
        public StockViewModel Stock
        {
            get => new StockViewModel(CopyofPOCOInstance.Stocks); set
            {
                Stocks data = value.Entity;

                CopyofPOCOInstance.Stocks = data;

                if (data != null)
                {
                    CopyofPOCOInstance.StockId = data.Id;
                    RaisePropertyChanged("StockId");
                }

                RaisePropertyChanged("Stock");
            }
        }

        /// <summary>
        /// 領料單細項
        /// </summary>
        public ShippingMaterialDetailsViewModelCollection Details { get => new ShippingMaterialDetailsViewModelCollection
                (CopyofPOCOInstance.PickListDetails.Select(s => new ShippingMaterialDetailsViewModel(s)).ToList()); }

        private int _ShippingCounting = 0;

        /// <summary>
        /// 出料筆數
        /// </summary>
        public int ShippingCounting { get => _ShippingCounting; set { _ShippingCounting = value; RaisePropertyChanged("ShippingCounting"); } }

        private decimal _OrderQuantitySubtotal = 0;

        /// <summary>
        /// 數量合計
        /// </summary>
        public decimal OrderQuantitySubtotal { get => _OrderQuantitySubtotal; set { _OrderQuantitySubtotal = value;RaisePropertyChanged("OrderQuantitySubtotal"); } }

        private decimal _WeightSubtotal = 0;

        /// <summary>
        /// 重量合計
        /// </summary>
        public decimal WeightSubtotal { get => _WeightSubtotal; set { _WeightSubtotal = value; RaisePropertyChanged("WeightSubtotal"); } }
    }
}
