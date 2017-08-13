using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;
using GalaSoft.MvvmLight.Messaging;
using Tokiku.DataServices;
using Tokiku.MVVM;
using GalaSoft.MvvmLight.CommandWpf;

namespace Tokiku.ViewModels
{
    public class ManufacturersViewModel : DocumentBaseViewModel<Manufacturers>, IManufacturersViewModel
    {
        private IManufacturingExecutionDataService _ManufacturersDataService;
        private IFinancialManagementDataService _FinancialManagementDataService;

        #region 建構式
        public ManufacturersViewModel() : base(EntityLocator.Current.Manufacturers,DefaultLocator.Current.CoreDataService)
        {
            ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            QueryCommand = new RelayCommand<IVendorListItemViewModel>(RunQuery);
        }

        [PreferredConstructor]
        public ManufacturersViewModel(IManufacturingExecutionDataService ManufacturersDataService,
            IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            _FinancialManagementDataService = FinancialManagementDataService;
            ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            QueryCommand = new RelayCommand<IVendorListItemViewModel>(RunQuery);
            //QueryCommand.Execute(CopyofPOCOInstance);
        }

        public ManufacturersViewModel(Manufacturers entity,
            IManufacturingExecutionDataService ManufacturersDataService,
            IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(entity, CoreDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            QueryCommand = new RelayCommand<IVendorListItemViewModel>(RunQuery);
        }
        #endregion

        #region 屬性

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public new System.Guid Id { get { return CopyofPOCOInstance.Id; } set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }
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
                var result = CopyofPOCOInstance.Contacts.Where(s => s.IsDefault == true);
                if (result.Any())
                {
                    return result.Single().EMail;
                }
                return CopyofPOCOInstance.eMail;
            }
            set { CopyofPOCOInstance.eMail = value; RaisePropertyChanged("eMail"); }
        }
        public string Address { get { return CopyofPOCOInstance.Address; } set { CopyofPOCOInstance.Address = value; RaisePropertyChanged("Address"); } }
        //public string FactoryPhone { get { return CopyofPOCOInstance.FactoryPhone; } set { CopyofPOCOInstance.FactoryPhone = value; RaisePropertyChanged("FactoryPhone"); } }
        //public string FactoryFax { get { return CopyofPOCOInstance.FactoryFax; } set { CopyofPOCOInstance.FactoryFax = value; RaisePropertyChanged("FactoryFax"); } }
        //public string FactoryAddress { get { return CopyofPOCOInstance.FactoryAddress; } set { CopyofPOCOInstance.FactoryAddress = value; RaisePropertyChanged("FactoryAddress"); } }
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

        #region 聯絡人

        private IContactListViewModel _ContactsList = ViewModelLocator.Current.ContactListViewModel;
        /// <summary>
        /// 聯絡人清單
        /// </summary>
        public IContactListViewModel ContactsList { get => _ContactsList; set { _ContactsList = value; RaisePropertyChanged("ContactsList"); } }

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

        #region 控制項清單資料來源

        #region 資料啟用狀態下拉選單
        private ObservableCollection<IVoidViewModel> _VoidList = new ObservableCollection<IVoidViewModel>();

        public ObservableCollection<IVoidViewModel> VoidList { get => _VoidList; set { _VoidList = value; RaisePropertyChanged("VoidList"); } }

        #endregion

        #region 支付方式的下拉式清單資料來源
        private ObservableCollection<IPaymentTypesViewModel> _PaymentTypes = new ObservableCollection<IPaymentTypesViewModel>();
        /// <summary>
        /// 支付方式的下拉式清單資料來源
        /// </summary>
        public ObservableCollection<IPaymentTypesViewModel> PaymentTypes
        {
            get => _PaymentTypes; set
            {
                _PaymentTypes = value;
                RaisePropertyChanged("PaymentTypes");
            }
        }



        #endregion

        #region 交易紀錄

        private IManufacturersBussinessTranscationsListViewModel _TranscationRecords = ViewModelLocator.Current.ManufacturersBussinessTranscationsListViewModel;

        /// <summary>
        /// 取得廠商已交易紀錄資訊清單。
        /// </summary>
        public IManufacturersBussinessTranscationsListViewModel TranscationRecords
        {
            get => _TranscationRecords; set
            {
                _TranscationRecords = value;
                RaisePropertyChanged("TranscationRecords");
            }
        }

        #endregion

        #region ManufacturersBussinessItems 營業項目
        private IManufacturerBusinessItemsListViewModel _BusinessItemsList = ViewModelLocator.Current.ManufacturerBusinessItemsListViewModel;

        /// <summary>
        /// 營業項目
        /// </summary>
        public IManufacturerBusinessItemsListViewModel BusinessItemsList
        {
            get => _BusinessItemsList; set
            {
                _BusinessItemsList = value;
                RaisePropertyChanged("BusinessItemsList");
            }
        }
        #endregion

        #region 工廠地址清單

        private IManufacturerFactoryListViewModel _Factories;

        /// <summary>
        /// 取得或設定工廠地址清單
        /// </summary>
        public IManufacturerFactoryListViewModel Factories { get => _Factories; set { _Factories = value; RaisePropertyChanged("Factories"); } }

        #endregion
        #endregion

        #region 模型控制命令
        public override void Query(Manufacturers Parameter)
        {
            ContactsList = ViewModelLocator.Current.ContactListViewModel;
            ContactsList.QueryCommand.Execute(Parameter);

            _VoidList = new ObservableCollection<IVoidViewModel>();
            VoidList.Add(new VoidViewModel() { Value = false, Text = "啟用" });
            VoidList.Add(new VoidViewModel() { Value = true, Text = "停用" });

            _PaymentTypes = new ObservableCollection<IPaymentTypesViewModel>(
              ((IDataService<PaymentTypes>)_FinancialManagementDataService).GetAll()
                .Select(s => new PaymentTypesViewModel(s)).ToList());

            BusinessItemsList = ViewModelLocator.Current.ManufacturerBusinessItemsListViewModel;
            //BusinessItemsList.QueryCommand.Execute(Entity);
            BusinessItemsList.QueryCommand.Execute(Parameter);

            TranscationRecords = ViewModelLocator.Current.ManufacturersBussinessTranscationsListViewModel;
            TranscationRecords.QueryCommand.Execute(Parameter);
        }
        public override void SetEntity(Manufacturers entity)
        {
            base.SetEntity(entity);
            Query(entity);
        }
        public virtual void RunQuery(IVendorListItemViewModel item)
        {            
           
            CopyofPOCOInstance = item.Entity;
            Query(item.Entity);
        }

        public override void CreateNew()
        {
            try
            {
                ModeChangedCommand.Execute(DocumentLifeCircle.Create);

                Entity = new Manufacturers()
                {
                    Id = Guid.NewGuid(),
                    Code = _ManufacturersDataService.GetNextProjectSerialNumber(),
                    Contacts = new Collection<Contacts>()
                };

                ContactsList.CreateNewCommand.Execute(Entity);
                BusinessItemsList.CreateNewCommand.Execute(Entity);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public override void Save()
        {
            try
            {
                switch (Mode)
                {
                    case DocumentLifeCircle.Create:
                        //目前處於新增模式
                        _ManufacturersDataService.Add(Entity);
                        Broadcast(Mode, DocumentLifeCircle.Read, "Mode");
                        break;
                    case DocumentLifeCircle.Update:
                        //目前處於編輯模式
                        _ManufacturersDataService.CreateOrUpdate(Entity);
                        ModeChangedCommand.Execute(DocumentLifeCircle.Read);
                        break;
                }
                ModeChangedCommand.Execute(DocumentLifeCircle.Read);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }


        protected override void RunModeChanged(DocumentLifeCircle Mode)
        {            
            if (Mode == DocumentLifeCircle.None)
                Mode = DocumentLifeCircle.Read;

            base.RunModeChanged(Mode);

            BusinessItemsList.ModeChangedCommand.Execute(Mode);
            ContactsList.ModeChangedCommand.Execute(Mode);
        }
        //#region 查詢單一個體的檢視資料
        ///// <summary>
        ///// 查詢單一個體的檢視資料
        ///// </summary>
        ///// <param name="ManufacturersId"></param>
        //public static ManufacturersViewModel Query(Guid ManufacturersId)
        //{
        //    try
        //    {

        //        //return QuerySingle<ManufacturersViewModel, Manufacturers>(
        //        //    "ManufacturersManage", "QuerySingle", ManufacturersId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ManufacturersViewModel view = new ManufacturersViewModel();
        //        setErrortoModel(view, ex);
        //        return view;
        //    }

        //}
        //#endregion

        //public void Initialized(object Parameter)
        //{



        //    try
        //    {

        //        Id = Guid.NewGuid();

        //        CopyofPOCOInstance = ExecuteAction<Manufacturers>("ManufacturersManage", "CreateNew"); //controller.CreateNew();

        //        //LastUpdateTime = DateTime.Now;
        //        CreateTime = DateTime.Now;

        //        //Contracts = new ContactsViewModelCollection();
        //        //ManufacturersBussinessItems = new ManufacturersBussinessItemsViewModelColletion();
        //        //TranscationRecords = new ManufacturersBussinessTranscationsViewModelCollection();
        //    }
        //    catch (Exception ex)
        //    {

        //        setErrortoModel(this, ex);
        //    }


        //}



        //public override void SaveModel(bool isLast = true)
        //{
        //    SaveModel("ManufacturersManage", isLast);
        //}
        //public  void SaveModel()
        //{
        //    try
        //    {
        //        Manufacturers data = new Manufacturers();
        //        //data.ManufacturersBussinessItems.First().SupplierTranscationItem.First().Projects
        //        var LoginedUser = controller.GetCurrentLoginUser().Result;

        //        if (CreateUserId == Guid.Empty)
        //        {
        //            CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        //        }

        //        if (CreateTime.Year < 1754)
        //        {
        //            CreateTime = DateTime.Now;
        //        }

        //        CopyToModel(data, this);

        //        if (ManufacturersBussinessItems != null && ManufacturersBussinessItems.Count > 0)
        //        {
        //            data.ManufacturersBussinessItems = new Collection<ManufacturersBussinessItems>();

        //            foreach (var x in ManufacturersBussinessItems)
        //            {
        //                ManufacturersBussinessItems BItems = new ManufacturersBussinessItems();
        //                CopyToModel(BItems, x);
        //                BItems.ManufacturersId = Id;
        //                BItems.Id = Guid.NewGuid();
        //                data.ManufacturersBussinessItems.Add(BItems);
        //            }
        //        }

        //        if (Contracts != null)
        //        {
        //            if (Contracts.Count > 0)
        //            {
        //                data.Contacts = new Collection<Entity.Contacts>();

        //                foreach (var x in Contracts)
        //                {
        //                    if (x.Id == Guid.Empty)
        //                        x.Id = Guid.NewGuid();



        //                    if (x.CreateUserId == Guid.Empty)
        //                    {
        //                        x.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        //                    }

        //                    if (x.CreateTime.Year < 1754)
        //                    {
        //                        x.CreateTime = CreateTime;
        //                    }

        //                    Contacts contact = new Contacts();
        //                    CopyToModel(contact, x);                         
        //                    data.Contacts.Add(contact);
        //                }
        //            }
        //        }

        //        var resultsec = controller.CreateOrUpdate(data);

        //        if (resultsec.HasError)
        //        {
        //            Errors = resultsec.Errors;
        //            HasError = resultsec.HasError;
        //            return;
        //        }

        //        Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }

        //}

        //public void QueryByName(string Name)
        //{
        //    try
        //    {
        //        ManufacturersManageController controller = new ManufacturersManageController();
        //        var executeresult = controller.Query(p => p.Name == Name);

        //        if (!executeresult.HasError)
        //        {
        //            if (executeresult.Result.Any())
        //            {
        //                var data = executeresult.Result.Single();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ManufacturersEnter)
        //        {
        //            ManufacturersEnter data = (ManufacturersEnter)entity;
        //            //BindingFromModel(data, this);
        //            //DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        if (entity is Manufacturers)
        //        {
        //            Manufacturers data = (Manufacturers)entity;
        //            //BindingFromModel(data, this);
        //            //DoEvents();
        //            Status.IsNewInstance = false;
        //            Status.IsModify = false;
        //            Status.IsSaved = false;
        //        }

        //        //await Dispatcher.InvokeAsync(new Action(QueryDetails), System.Windows.Threading.DispatcherPriority.Background);                
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }

        //}
        //public void QueryDetails()
        //{
        //    //Contracts.ManufacturersId = Id;
        //    //Contracts.Query("", Id, IsClient);

        //    ManufacturersBussinessItems.QueryAsync(Id);

        //    TranscationRecords = ManufacturersBussinessTranscationsViewModelCollection.Query(Id);

        //}
        #endregion

    }
}
