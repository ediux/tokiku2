using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Threading;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ContactsViewModelCollection : BaseViewModelCollection<ContactsViewModel>
    {
        public ContactsViewModelCollection()
        {
            _ControllerName = "ContactPersonManage";
        }

        public ContactsViewModelCollection(IEnumerable<ContactsViewModel> source) : base(source)
        {
            _ControllerName = "ContactPersonManage";
        }

        public Guid ManufacturersId
        {
            get;
            set;
        }
        public override void Initialized()
        {
            base.Initialized();
            ManufacturersId = Guid.Empty;
        }

        public ContactsViewModelCollection Query()
        {
            try
            {
                ContactsViewModelCollection collection = new ContactsViewModelCollection();

                collection = Query<ContactsViewModelCollection, Contacts>(
                     "ContactPersonManage", "QueryAll", ManufacturersId);

                return collection;
            }
            catch (Exception ex)
            {
                ContactsViewModelCollection emptycollection =
                    new ContactsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }

           
        }

        public ContactsViewModelCollection Query(string originalSource, Guid ManufurerterId, bool isClient)
        {
            try
            {
                ContactsViewModelCollection collection = new ContactsViewModelCollection();

                collection = Query<ContactsViewModelCollection, Contacts>(
                     "ContactPersonManage", "SearchByText", originalSource, ManufurerterId, isClient);

                return collection;
            }
            catch (Exception ex)
            {
                ContactsViewModelCollection emptycollection =
                    new ContactsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }

           
        }
    }

    public class ContactsViewModel : BaseViewModelWithPOCOClass<Contacts>
    {
        public ContactsViewModel()
        {
            _SaveModelController = "ContactPersonManage";
        }

        public ContactsViewModel(Contacts entity) : base(entity)
        {
            _SaveModelController = "ContactPersonManage";
        }




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





        public string EMail
        {
            get { return CopyofPOCOInstance.EMail; }
            set { CopyofPOCOInstance.EMail = value; RaisePropertyChanged("EMail"); }
        }

        public bool IsDefault
        {
            get { return CopyofPOCOInstance.IsDefault; }
            set { CopyofPOCOInstance.IsDefault = value; RaisePropertyChanged("IsDefault"); }
        }



        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);
            Id = Guid.NewGuid();
            ContactPersonManageController controller = new ContactPersonManageController();
            CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        }

    }
}
