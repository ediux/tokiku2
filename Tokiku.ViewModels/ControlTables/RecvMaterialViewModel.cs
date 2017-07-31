using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RecvMaterialViewModelCollection : BaseViewModelCollection<RecvMaterialViewModel>
    {
        public RecvMaterialViewModelCollection()
        {
            _ControllerName = "RecvMaterial";
        }

        public RecvMaterialViewModelCollection(IEnumerable<RecvMaterialViewModel> source) : base(source)
        {
            _ControllerName = "RecvMaterial";
        }

        public static RecvMaterialViewModelCollection Query(Guid ProjectId)
        {
            try
            {
                return Query<RecvMaterialViewModelCollection, Receive>("RecvMaterial", "Query", ProjectId);
            }
            catch (Exception ex)
            {
                RecvMaterialViewModelCollection emptycollection = new RecvMaterialViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
            //RecvMaterialController ctrl = new RecvMaterialController();
            //ExecuteResultEntity<ICollection<Receive>> ere = ctrl.QuerAll();

            //if (!ere.HasError)
            //{
            //    return new RecvMaterialViewModelCollection(ere.Result.Select(s => new RecvMaterialViewModel(s)).ToList());
            //}

            //return new RecvMaterialViewModelCollection();
        }

    }

    public class RecvMaterialViewModel : BaseViewModelWithPOCOClass<Receive>
    {
        public RecvMaterialViewModel()
        {
            _SaveModelController = "RecvMaterial";
        }

        public static RecvMaterialViewModel Query(Guid Id, Guid ProjectId)
        {
            try
            {
                return QuerySingle<RecvMaterialViewModel, Receive>("RecvMaterial", "QuerySingle", ProjectId, Id);
            }
            catch (Exception ex)
            {
                RecvMaterialViewModel emptycollection = new RecvMaterialViewModel();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }


        public RecvMaterialViewModel(Receive entity) : base(entity)
        {
            _SaveModelController = "RecvMaterial";
            Details.CollectionChanged += Details_CollectionChanged;
        }

        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);

            CreateTime = DateTime.Now;
        }

        private void Details_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    ReceiptCount = Details.Sum(s => s.ReceivedQuantity);
                    ReturnWeightSubtotal = Details.Sum(s => s.ReceivedQuantity * s.UnitWeight);
                    break;
            }
        }


        /// <summary>
        /// 收料單單號
        /// </summary>
        public string ReceiptNumber
        {
            get { return CopyofPOCOInstance.ReceiptNumber; }
            set { CopyofPOCOInstance.ReceiptNumber = value; RaisePropertyChanged("ReceiptNumber"); }
        }

        /// <summary>
        /// 來料廠商系統編號
        /// </summary>
        public Guid? IncomingManufacturersId
        {
            get => CopyofPOCOInstance.IncomingManufacturersId; set
            {
                CopyofPOCOInstance.IncomingManufacturersId = value;
                RaisePropertyChanged("IncomingManufacturersId");
            }
        }


        /// <summary>
        /// 來料廠商代碼
        /// </summary>
        public string IncomingManufacturersCode
        {
            get { return CopyofPOCOInstance.IncomingManufacturers?.Code; }
            set { CopyofPOCOInstance.IncomingManufacturers.Code = value; RaisePropertyChanged("IncomingManufacturersCode"); }
        }


        /// <summary>
        /// 來料廠商
        /// </summary>
        public string IncomingManufacturersName
        {
            get { return CopyofPOCOInstance.IncomingManufacturers?.Name; }
            set { CopyofPOCOInstance.IncomingManufacturers.Name = value; RaisePropertyChanged("IncomingManufacturersName"); }
        }

        /// <summary>
        /// 來料單號
        /// </summary>
        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }

        /// <summary>
        /// 製單人員ID
        /// </summary>
        public Guid MakingUserId
        {
            get => CopyofPOCOInstance.MakingUserId; set
            {
                CopyofPOCOInstance.MakingUserId = value;
                RaisePropertyChanged("MakingUserId");
            }
        }

        /// <summary>
        /// 製單人員
        /// </summary>
        public UserViewModel MakingUser
        {
            get { return new UserViewModel(CopyofPOCOInstance.MakingUser); }
            set
            {
               
                if (value != null)
                {
                    CopyofPOCOInstance.MakingUser = value.Entity;
                    CopyofPOCOInstance.MakingUserId = value.Entity.UserId;
                }

                RaisePropertyChanged("MakingUser");
            }
        }

        /// <summary>
        /// 製單日期
        /// </summary>
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.MakingTime; }
            set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

        /// <summary>
        /// 收料支數
        /// </summary>
        public int? ReceiptCount
        {
            get
            {
                return CopyofPOCOInstance.ReceiptDetails?.Sum(s => s.ReceiptQuantity);
            }
            set { RaisePropertyChanged("ReceiptCount"); }
        }

        private int _ReturnQuantitySubtotal;
        /// <summary>
        /// 合計
        /// </summary>
        public int ReturnQuantitySubtotal { get => _ReturnQuantitySubtotal; set { _ReturnQuantitySubtotal = value; RaisePropertyChanged("ReturnQuantitySubtotal"); } }

        private decimal? _ReturnWeightSubtotal = 0;
        /// <summary>
        /// 退貨重量總計
        /// </summary>
        public decimal? ReturnWeightSubtotal { get => _ReturnWeightSubtotal; set { _ReturnWeightSubtotal = value; RaisePropertyChanged("ReturnWeightSubtotal"); } }

        public RecvMaterialDetailsViewModelCollection Details
        {
            get { return new RecvMaterialDetailsViewModelCollection(CopyofPOCOInstance.ReceiptDetails.Select(s => new RecvMaterialDetailsViewModel(s)).ToList()); }
        }
    }
}
