using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ReturnsViewModelCollection : BaseViewModelCollection<ReturnsViewModel>
    {
        public ReturnsViewModelCollection()
        {
            _ControllerName = "Returns";
        }

        public ReturnsViewModelCollection(IEnumerable<ReturnsViewModel> source) : base(source)
        {
            _ControllerName = "Returns";
        }

        //public static ReturnsViewModelCollection Query()
        //{
        //    return Query<ReturnsViewModelCollection, Returns>("Returns", "QueryAll");
        //}
        public static ReturnsViewModelCollection Query(Guid ProjectId)
        {
            try
            {
                ReturnsViewModelCollection collection = new ReturnsViewModelCollection();

                collection = Query<ReturnsViewModelCollection, Returns>(
                     collection.SaveModelController, "QueryAll", ProjectId);

                return collection;
            }
            catch (Exception ex)
            {
                ReturnsViewModelCollection emptycollection =
                    new ReturnsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }

    public class ReturnsViewModel : BaseViewModelWithPOCOClass<Returns>
    {
        public ReturnsViewModel()
        {
            _SaveModelController = "Returns";
        }

        public ReturnsViewModel(Returns entity) : base(entity)
        {
            _SaveModelController = "Returns";

            this.Details.CollectionChanged += Details_CollectionChanged;
        }

        private void Details_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    ReturnRecords = Details.Count;
                    ReturnQuantitySubtotal = Details.Sum(s => s.ReturnQuantity);
                    ReturnWeightSubtotal = Details.Sum(s => s.Weight);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    ReturnRecords = Details.Count;
                    ReturnQuantitySubtotal = Details.Sum(s => s.ReturnQuantity);
                    ReturnWeightSubtotal = Details.Sum(s => s.Weight);
                    break;
            }
        }

        #region 查詢單一個體的檢視資料
        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public ReturnsViewModel Query(Guid Id)
        {
            try
            {
                ReturnsViewModel viewmodel = new ReturnsViewModel();

                viewmodel = QuerySingle<ReturnsViewModel, Returns>(
                    viewmodel.SaveModelController, "QuerySingle", Id);

                return viewmodel;
            }
            catch (Exception ex)
            {
                ReturnsViewModel view = new ReturnsViewModel();
                setErrortoModel(view, ex);
                return view;
            }

        }
        #endregion

        // 退料單號
        public string ReturnNumber
        {
            get { return CopyofPOCOInstance.ReturnNumber; }
            set { CopyofPOCOInstance.ReturnNumber = value; RaisePropertyChanged("ReturnNumber"); }
        }
        // 來料廠商代碼
        public string IncomingManufacturerCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("IncomingManufacturerCode"); }
        }
        // 來料廠商
        public string IncomingManufacturerName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("IncomingManufacturerName"); }
        }
        // 來料單號
        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }

        // 收料單號
        public string ReceiptNumber
        {
            get { return CopyofPOCOInstance.ReceiptNumber; }
            set { CopyofPOCOInstance.ReceiptNumber = value; RaisePropertyChanged("ReceiptNumber"); }
        }

        // 製單人員
        public string MakingUser
        {
            get { return CopyofPOCOInstance.MakingUser.UserName; }
            set { CopyofPOCOInstance.MakingUser.UserName = value; RaisePropertyChanged("MakingUser"); }
        }
        // 製單日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("MakingTime"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

        private int _ReturnRecords = 0;
        /// <summary>
        /// 退貨筆數
        /// </summary>
        public int ReturnRecords { get => _ReturnRecords; set { _ReturnRecords = value; RaisePropertyChanged("ReturnRecords"); } }

        private int _ReturnQuantitySubtotal;
        /// <summary>
        /// 合計
        /// </summary>
        public int ReturnQuantitySubtotal { get => _ReturnQuantitySubtotal; set { _ReturnQuantitySubtotal = value; RaisePropertyChanged("ReturnQuantitySubtotal"); } }

        private double _ReturnWeightSubtotal = 0;
        public double ReturnWeightSubtotal { get => _ReturnWeightSubtotal; set { _ReturnWeightSubtotal = value; RaisePropertyChanged("ReturnWeightSubtotal"); } }
        /// <summary>
        /// 退貨單細項
        /// </summary>
        public ReturnsDetailsViewModelCollection Details
        {
            get => new ReturnsDetailsViewModelCollection(CopyofPOCOInstance.ReturnDetails.Select(s => new ReturnsDetailsViewModel(s)));
            set
            {
                CopyofPOCOInstance.ReturnDetails = new Collection<ReturnDetails>(value.Select(s => s.Entity).ToList());
                RaisePropertyChanged("Details");
            }
        }

    }


}
