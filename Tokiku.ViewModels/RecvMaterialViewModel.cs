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

        public new static RecvMaterialViewModelCollection Query()
        {
            RecvMaterialController ctrl = new RecvMaterialController();
            ExecuteResultEntity<ICollection<Receive>> ere = ctrl.QuerAll();

            if (!ere.HasError)
            {
                return new RecvMaterialViewModelCollection(ere.Result.Select(s => new RecvMaterialViewModel(s)).ToList());
            }

            return new RecvMaterialViewModelCollection();
        }

    }

    public class RecvMaterialViewModel : BaseViewModelWithPOCOClass<Receive>
    {
        public RecvMaterialViewModel(Receive entity) : base(entity)
        {

        }

        public string ReceiptNumber
        {
            get { return CopyofPOCOInstance.ReceiptNumber; }
            set { CopyofPOCOInstance.ReceiptNumber = value; RaisePropertyChanged("ReceiptNumber"); }
        }

        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }

        public DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }

        public string CreateUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
    }
}
