using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.DataServices;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 客戶資料管理介面檢視模型
    /// </summary>
    public class ClientViewModel : DocumentBaseViewModel<Manufacturers>, IClientViewModel
    {
        private IClientDataService _ClientDataService;

        public ClientViewModel(ICoreDataService CoreDataService,
             ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService) : base(CoreDataService)
        {
            try
            {
                _ClientDataService = CustomerRelationshipManagementDataService;
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        [PreferredConstructor]
        public ClientViewModel(Manufacturers entity,
            ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService,
            ICoreDataService CoreDataService) : base(entity, CoreDataService)
        {
            try
            {
                _ClientDataService = CustomerRelationshipManagementDataService;
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        #region 屬性

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public new Guid Id { get { return CopyofPOCOInstance.Id; } set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }
        #endregion

        public string Code { get { return CopyofPOCOInstance.Code; } set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); } }
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }
        public string Principal { get { return CopyofPOCOInstance.Principal; } set { CopyofPOCOInstance.Principal = value; RaisePropertyChanged("Principal"); } }
        public string UniformNumbers { get { return CopyofPOCOInstance.UniformNumbers; } set { CopyofPOCOInstance.UniformNumbers = value; RaisePropertyChanged("UniformNumbers"); } }
        public string Phone { get { return CopyofPOCOInstance.Phone; } set { CopyofPOCOInstance.Phone = value; RaisePropertyChanged("Phone"); } }
        public string Fax { get { return CopyofPOCOInstance.Fax; } set { CopyofPOCOInstance.Fax = value; RaisePropertyChanged("Fax"); } }
        public string eMail
        {
            get
            {
                try
                {
                    var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                    if (result.Any())
                    {
                        return result.Single().EMail;
                    }
                    return CopyofPOCOInstance.eMail;
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                    return null;
                }

            }
            set
            {
                try
                {
                    CopyofPOCOInstance.eMail = value;
                    RaisePropertyChanged("eMail");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }
        public string Address { get { return CopyofPOCOInstance.Address; } set { CopyofPOCOInstance.Address = value; RaisePropertyChanged("Address"); } }
        public string Comment { get { return CopyofPOCOInstance.Comment; } set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); } }
        public bool Void { get { return CopyofPOCOInstance.Void; } set { CopyofPOCOInstance.Void = value; RaisePropertyChanged("Void"); } }
        public bool IsClient { get { return CopyofPOCOInstance.IsClient; } set { CopyofPOCOInstance.IsClient = value; RaisePropertyChanged("IsClient"); } }

        #region MainContactPerson

        /// <summary>
        /// 主要聯絡人
        /// </summary>
        public string MainContactPerson
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().Name;
                }
                return string.Empty;
            }
            set
            {
                RaisePropertyChanged("MainContactPerson");
            }
        }


        #endregion

        #region BankName
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string BankName
        {
            get { return CopyofPOCOInstance.BankName; }
            set { CopyofPOCOInstance.BankName = value; RaisePropertyChanged("BankName"); }
        }


        #endregion

        #region BankAccount
        /// <summary>
        /// 銀行帳號
        /// </summary>
        public string BankAccount
        {
            get { return CopyofPOCOInstance.BankAccount; }
            set { CopyofPOCOInstance.BankAccount = value; RaisePropertyChanged("BankAccount"); }
        }


        #endregion

        #region BankAccountName
        /// <summary>
        /// 銀行帳號名稱
        /// </summary>
        public string BankAccountName
        {
            get { return CopyofPOCOInstance.BankAccountName; }
            set { BankAccountName = value; RaisePropertyChanged("BankAccountName"); }
        }


        #endregion

        #region PaymentType
        /// <summary>
        /// 支付方式
        /// </summary>
        public byte PaymentType
        {
            get { return CopyofPOCOInstance.PaymentType; }
            set { CopyofPOCOInstance.PaymentType = value; RaisePropertyChanged("PaymentType"); }
        }


        #endregion

        #region 行動電話

        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().Mobile;
                }
                return string.Empty;
            }
            set { RaisePropertyChanged("Mobile"); }
        }



        #endregion

        #region 分機

        /// <summary>
        /// 主要聯絡人分機
        /// </summary>
        public string Extension
        {
            get
            {
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().ExtensionNumber;
                }
                return string.Empty;
            }
            set { RaisePropertyChanged("Extension"); }
        }




        #endregion

        #region TicketPeriodId

        /// <summary>
        /// 票期Id
        /// </summary>
        public int? TicketPeriodId
        {
            get { return CopyofPOCOInstance.TicketPeriodId; }
            set { CopyofPOCOInstance.TicketPeriodId = value; RaisePropertyChanged("TicketPeriodId"); }
        }

        #endregion

        #region 發票地址

        /// <summary>
        /// 發票地址
        /// </summary>
        public string InvoiceAddress
        {
            get { return CopyofPOCOInstance.InvoiceAddress; }
            set { CopyofPOCOInstance.InvoiceAddress = value; RaisePropertyChanged("InvoiceAddress"); }
        }

        private bool _IsSameForAddress = false;
        /// <summary>
        /// 同公司地址控制旗標
        /// </summary>
        public bool IsSameForAddress { get => _IsSameForAddress; set { RaisePropertyChanged("IsSameForAddress"); } }

        #endregion

        #endregion

        #region 聯絡人

        private IContactListViewModel _Contracts = ViewModelLocator.Current.ContactListViewModel;
        /// <summary>
        /// 聯絡人清單
        /// </summary>
        public IContactListViewModel Contracts
        {
            get
            {
                try
                {
                    if (_Contracts == null)
                    {
                        _Contracts = SimpleIoc.Default.GetInstance<IContactListViewModel>();
                    }

                    return _Contracts;
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                    return _Contracts;
                }

            }
            set { _Contracts = value; RaisePropertyChanged("Contracts"); }
        }

        #endregion

        protected override void CreateNew()
        {
            try
            {

                ModeChangedCommand.Execute(DocumentLifeCircle.Create);

                Manufacturers createnewresult = _ClientDataService.CreateNew();

                Status.IsNewInstance = true;
                Status.IsSaved = false;

                Contracts.QueryCommand.Execute(createnewresult);

                if (!_ClientDataService.HasError)
                {
                    CopyofPOCOInstance = createnewresult;
                    CopyofPOCOInstance.IsClient = true;
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        protected override void RunModeChanged(DocumentLifeCircle Mode)
        {
            base.RunModeChanged(Mode);
            Contracts.ModeChangedCommand.Execute(Mode);
        }

        protected override void Save()
        {
            try
            {
                if (Status.IsNewInstance)
                {
                    Id = Guid.NewGuid();
                    CreateTime = DateTime.Now;
                }

                var LoginedUser = _CoreDataService.GetCurrentLoginedUser();

                if (CreateUserId == Guid.Empty)
                {
                    CreateUserId = LoginedUser.UserId;
                }

                IsClient = true;

                if (Contracts != null)
                {
                    Contracts.SaveCommand.Execute(CopyofPOCOInstance);
                }

                _ClientDataService.CreateOrUpdate(CopyofPOCOInstance);

                if (_ClientDataService.HasError)
                {
                    setErrortoModel(this, "儲存聯絡人時發生錯誤!");
                    return;
                }

                ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        protected override void Query(object Parameter)
        {
            try
            {
                if (Parameter is Manufacturers)
                {
                    CopyofPOCOInstance = (Manufacturers)Parameter;
                }

                if (Parameter is ClientListItemViewModel)
                {
                    CopyofPOCOInstance = ((ClientListItemViewModel)Parameter).Entity;
                }

                Status.IsNewInstance = false;
                Status.IsSaved = false;

                Contracts.QueryCommand.Execute(CopyofPOCOInstance);
                ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
