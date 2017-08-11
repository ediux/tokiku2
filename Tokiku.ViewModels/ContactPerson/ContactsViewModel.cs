using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ContactsViewModel : EntityBaseViewModel<Contacts>, IContactsViewModel
    {
        [PreferredConstructor]
        public ContactsViewModel()
        {
        }

        public ContactsViewModel(Contacts entity) : base(entity)
        {
            MessengerInstance.Register<PropertyChangedMessageBase>(this, (m) => {
                
            });

        }


        private bool _IsSelected = false;
        /// <summary>
        /// 是否已經選定此資料列的控制旗標
        /// </summary>
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; RaisePropertyChanged("IsSelected"); } }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }


        /// <summary>
        /// 部門
        /// </summary>
        public string Dep
        {
            get { return CopyofPOCOInstance.Dep; }
            set { CopyofPOCOInstance.Dep = value; RaisePropertyChanged("Dep"); }
        }

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title
        {
            get { return CopyofPOCOInstance.Title; }
            set { CopyofPOCOInstance.Title = value; RaisePropertyChanged("Title"); }
        }

        /// <summary>
        /// 市內電話
        /// </summary>
        public string Phone
        {
            get { return CopyofPOCOInstance.Phone; }
            set { CopyofPOCOInstance.Phone = value; RaisePropertyChanged("Phone"); }
        }



        /// <summary>
        /// 分機號碼
        /// </summary>
        public string ExtensionNumber
        {
            get { return CopyofPOCOInstance.ExtensionNumber; }
            set { CopyofPOCOInstance.ExtensionNumber = value; RaisePropertyChanged("ExtensionNumber"); }
        }


        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get { return CopyofPOCOInstance.Mobile; }
            set { CopyofPOCOInstance.Mobile = value; RaisePropertyChanged("Mobile"); }
        }


        /// <summary>
        /// 傳真
        /// </summary>
        public string Fax
        {
            get { return CopyofPOCOInstance.Fax; }
            set { CopyofPOCOInstance.Fax = value; RaisePropertyChanged("Fax"); }
        }


        /// <summary>
        /// 是否為負責人
        /// </summary>
        public bool IsPrincipal
        {
            get { return CopyofPOCOInstance.IsPrincipal; }
            set { CopyofPOCOInstance.IsPrincipal = value; RaisePropertyChanged("IsPrincipal"); }
        }

        /// <summary>
        /// 是否停用(刪除)
        /// </summary>
        public bool Void
        {
            get { return CopyofPOCOInstance.Void; }
            set { CopyofPOCOInstance.Void = value; RaisePropertyChanged("Void"); }
        }

        /// <summary>
        /// 電子郵件
        /// </summary>
        public string EMail
        {
            get { return CopyofPOCOInstance.EMail; }
            set { CopyofPOCOInstance.EMail = value; RaisePropertyChanged("EMail"); }
        }

        /// <summary>
        /// 預設聯絡人
        /// </summary>
        public bool IsDefault
        {
            get { return CopyofPOCOInstance.IsDefault; }
            set { CopyofPOCOInstance.IsDefault = value; RaisePropertyChanged<bool>("IsDefault",broadcast:true); }
        }
    }
}
