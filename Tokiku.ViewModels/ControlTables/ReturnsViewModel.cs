using System;
using System.Collections.Generic;
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
        }

        public ReturnsViewModelCollection(IEnumerable<ReturnsViewModel> source) : base(source)
        {
        }

        public static ReturnsViewModelCollection Query()
        {
            return Query<ReturnsViewModelCollection, Returns>("Returns", "QueryAll");
        }

    }

    public class ReturnsViewModel : BaseViewModelWithPOCOClass<Returns>
    {
        public ReturnsViewModel(Returns entity) : base(entity)
        {
        }


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
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("MakingUser"); }
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

    }
}
