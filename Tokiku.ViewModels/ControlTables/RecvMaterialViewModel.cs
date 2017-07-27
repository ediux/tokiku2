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
            HasError = false;
        }

        public RecvMaterialViewModelCollection(IEnumerable<RecvMaterialViewModel> source) : base(source)
        {

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

        }
        public static RecvMaterialViewModel Query(Guid Id,Guid ProjectId)
        {
            try
            {
                return QuerySingle<RecvMaterialViewModel, Receive>("RecvMaterial", "QuerySingle",ProjectId, Id);
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

        }

        // ID
        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }
        // 收料單單號
        public string ReceiptNumber
        {
            get { return CopyofPOCOInstance.ReceiptNumber; }
            set { CopyofPOCOInstance.ReceiptNumber = value; RaisePropertyChanged("ReceiptNumber"); }
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
        // 輸入人員
        public new string CreateUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        // 輸入日期
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }
        // 製單人員
        public string MakingUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("MakingUser"); }
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
        /// 收料支數
        /// </summary>
        public int ReceiptCount
        {
            get
            {
                return CopyofPOCOInstance.ReceiptDetails.Sum(s => s.ReceiptQuantity);
            }
            set { RaisePropertyChanged("ReceiptCount"); }
        }
    }
}
