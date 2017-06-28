using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    public class ManufacturersViewModelCollection : BaseViewModelCollection<ManufacturersViewModel>
    {
        #region 內部變數
        /// <summary>
        /// 廠商管理對應的控制器
        /// </summary>
        private ManufacturersManageController _controller;
        #endregion

        #region 建構式
        /// <summary>
        /// 預設的建構式
        /// </summary>
        public ManufacturersViewModelCollection()
        {

        }

        /// <summary>
        /// 給IoC容器使用的建構式。
        /// </summary>
        /// <param name="Controller">廠商管理商業邏輯層控制器</param>
        public ManufacturersViewModelCollection(ManufacturersManageController Controller)
        {
            _controller = Controller;
        }

        public ManufacturersViewModelCollection(IEnumerable<ManufacturersViewModel> source) : base(source)
        {

        }
        #endregion

        #region 模型命令方法
        public override void Initialized()
        {
            try
            {
                base.Initialized();

                _controller = new ManufacturersManageController();
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public override void Query()
        {
            try
            {
                if (!System.Windows.Threading.Dispatcher.CurrentDispatcher.CheckAccess())
                {
                    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(new Action(Query), System.Windows.Threading.DispatcherPriority.Background);
                }
                else
                {
                    if (_controller == null)
                        return;

                    var queryresult = _controller.QueryAll();

                    if (!queryresult.HasError)
                    {
                        ClearItems();

                        foreach (var row in queryresult.Result)
                        {
                            ManufacturersViewModel model = new ManufacturersViewModel();
                            model.DoEvents();
                            model.SetModel(row);
                            Add(model);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public void QueryByText(string originalSource)
        {
            try
            {
                var executeresult = _controller.SearchByText(originalSource);

                if (!executeresult.HasError)
                {
                    var objectdataset = executeresult.Result;
                    ClearItems();
                    foreach (var row in objectdataset)
                    {
                        ManufacturersViewModel model = new ManufacturersViewModel();
                        model.DoEvents();
                        model.SetModel(row);
                        Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public async void QueryByBusinessItem(Guid MaterialCategoriesId, string BusinessItem)
        {
            try
            {
                ManufacturersManageController controller = new ManufacturersManageController();
                var queryresult = await controller.GetManufacturersWithBusinessItemAsync(MaterialCategoriesId, BusinessItem);
                if (!queryresult.HasError)
                {
                    var objectdataset = queryresult.Result;
                    foreach (var row in objectdataset)
                    {
                        ManufacturersViewModel model = new ManufacturersViewModel();
                        model.DoEvents();
                        model.SetModel(row);
                        Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
        #endregion

    }

    public class ManufacturersViewModel : BaseViewModel
    {
        #region 內部變數
        private ManufacturersManageController controller;
        #endregion

        #region 建構式
        public ManufacturersViewModel() : base()
        {

        }

        public ManufacturersViewModel(ManufacturersManageController Controller) : base()
        {
            controller = Controller;
        }
        #endregion

        #region 屬性




        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PrincipalProperty = DependencyProperty.Register("Principal",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty UniformNumbersProperty = DependencyProperty.Register("UniformNumbers",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FaxProperty = DependencyProperty.Register("Fax",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty eMailProperty = DependencyProperty.Register("eMail",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryPhoneProperty = DependencyProperty.Register("FactoryPhone", typeof(string),
            typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryFaxProperty = DependencyProperty.Register("FactoryFax", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty FactoryAddressProperty = DependencyProperty.Register("FactoryAddress", typeof(string),
         typeof(ManufacturersViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));



        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment",
            typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void",
            typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty IsClientProperty = DependencyProperty.Register("IsClient",
         typeof(bool), typeof(ManufacturersViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime",
         typeof(DateTime), typeof(ManufacturersViewModel), new PropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId",
         typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserProperty = DependencyProperty.Register("CreateUser",
    typeof(UserViewModel), typeof(ManufacturersViewModel), new PropertyMetadata(default(UserViewModel)));

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public System.Guid Id { get { return (Guid)GetValue(IdProperty); } set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); } }
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id",
           typeof(Guid), typeof(ManufacturersViewModel), new PropertyMetadata(Guid.NewGuid(), new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion


        public string Code { get { return (string)GetValue(CodeProperty); } set { SetValue(CodeProperty, value); RaisePropertyChanged("Code"); } }
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); RaisePropertyChanged("Name"); } }
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); RaisePropertyChanged("ShortName"); } }
        public string Principal { get { return (string)GetValue(PrincipalProperty); } set { SetValue(PrincipalProperty, value); RaisePropertyChanged("Principal"); } }
        public string UniformNumbers { get { return (string)GetValue(UniformNumbersProperty); } set { SetValue(UniformNumbersProperty, value); RaisePropertyChanged("UniformNumbers"); } }
        public string Phone { get { return (string)GetValue(PhoneProperty); } set { SetValue(PhoneProperty, value); RaisePropertyChanged("Phone"); } }
        public string Fax { get { return (string)GetValue(FaxProperty); } set { SetValue(FaxProperty, value); RaisePropertyChanged("Fax"); } }
        public string eMail { get { return (string)GetValue(eMailProperty); } set { SetValue(eMailProperty, value); RaisePropertyChanged("eMail"); } }
        public string Address { get { return (string)GetValue(AddressProperty); } set { SetValue(AddressProperty, value); RaisePropertyChanged("Address"); } }
        public string FactoryPhone { get { return (string)GetValue(FactoryPhoneProperty); } set { SetValue(FactoryPhoneProperty, value); RaisePropertyChanged("FactoryPhone"); } }
        public string FactoryFax { get { return (string)GetValue(FactoryFaxProperty); } set { SetValue(FactoryFaxProperty, value); RaisePropertyChanged("FactoryFax"); } }
        public string FactoryAddress { get { return (string)GetValue(FactoryAddressProperty); } set { SetValue(FactoryAddressProperty, value); RaisePropertyChanged("FactoryAddress"); } }

        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); RaisePropertyChanged("Comment"); } }
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); RaisePropertyChanged("Void"); } }
        public bool IsClient { get { return (bool)GetValue(IsClientProperty); } set { SetValue(IsClientProperty, value); RaisePropertyChanged("IsClient"); } }
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); RaisePropertyChanged("CreateTime"); } }
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); RaisePropertyChanged("CreateUserId"); } }
        public virtual UserViewModel CreateUser { get { return (UserViewModel)GetValue(CreateUserProperty); } set { SetValue(CreateUserProperty, value); RaisePropertyChanged("CreateUser"); } }

        #region MainContactPerson

        /// <summary>
        /// 主要聯絡人
        /// </summary>
        public string MainContactPerson
        {
            get { return (string)GetValue(MainContactPersonProperty); }
            set { SetValue(MainContactPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainContactPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainContactPersonProperty =
            DependencyProperty.Register("MainContactPerson", typeof(string),
                typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty,
                    new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region AccountingCode
        /// <summary>
        /// 會計代碼
        /// </summary>
        public string AccountingCode
        {
            get { return (string)GetValue(AccountingCodeProperty); }
            set { SetValue(AccountingCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountingCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountingCodeProperty =
            DependencyProperty.Register("AccountingCode", typeof(string),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region BankName
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string BankName
        {
            get { return (string)GetValue(BankNameProperty); }
            set { SetValue(BankNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankNameProperty =
            DependencyProperty.Register("BankName", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region BankAccount
        /// <summary>
        /// 銀行帳號
        /// </summary>
        public string BankAccount
        {
            get { return (string)GetValue(BankAccountProperty); }
            set { SetValue(BankAccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountProperty =
            DependencyProperty.Register("BankAccount", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region BankAccountName
        /// <summary>
        /// 銀行帳號名稱
        /// </summary>
        public string BankAccountName
        {
            get { return (string)GetValue(BankAccountNameProperty); }
            set { SetValue(BankAccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BankAccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BankAccountNameProperty =
            DependencyProperty.Register("BankAccountName", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region PaymentType
        /// <summary>
        /// 支付方式
        /// </summary>
        public byte PaymentType
        {
            get { return (byte)GetValue(PaymentTypeProperty); }
            set { SetValue(PaymentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeProperty =
            DependencyProperty.Register("PaymentType", typeof(byte), typeof(ManufacturersViewModel),
                new PropertyMetadata((byte)0, new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region 聯絡人清單 Contracts
        /// <summary>
        /// 聯絡人清單
        /// </summary>
        public ContactsViewModelCollection Contracts
        {
            get
            {
                var source = (ContactsViewModelCollection)GetValue(ContractsProperty);
                if (source.Count == 0)
                {
                    source.Query();
                }
                return source;
            }
            set { SetValue(ContractsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contracts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractsProperty =
            DependencyProperty.Register("Contracts", typeof(ContactsViewModelCollection),
                typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ObservableCollection<ContactsViewModel>),
                    new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region 選擇的聯絡人
        /// <summary>
        /// 選擇的聯絡人
        /// </summary>
        public ContactsViewModel SelectedContract
        {
            get { return (ContactsViewModel)GetValue(SelectedContractProperty); }
            set { SetValue(SelectedContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for  SelectedContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedContractProperty =
            DependencyProperty.Register(" SelectedContract",
                typeof(ContactsViewModel), typeof(ManufacturersViewModel),
                new PropertyMetadata(default(ContactsViewModel),
                    new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region ManufacturersBussinessItems 營業項目

        /// <summary>
        /// 營業項目
        /// </summary>
        public ManufacturersBussinessItemsViewModelColletion ManufacturersBussinessItems
        {
            get
            {
                var model = (ManufacturersBussinessItemsViewModelColletion)GetValue(ManufacturersBussinessItemsProperty);
                if (model.Count == 0)
                {
                    model.Query();
                }
                return model;
            }
            set { SetValue(ManufacturersBussinessItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersBussinessItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersBussinessItemsProperty =
            DependencyProperty.Register("ManufacturersBussinessItems", typeof(ManufacturersBussinessItemsViewModelColletion), typeof(ManufacturersViewModel), new PropertyMetadata(default(ManufacturersBussinessItemsViewModelColletion)));

        #endregion

        #region 行動電話

        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile
        {
            get { return (string)GetValue(MobileProperty); }
            set { SetValue(MobileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mobile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MobileProperty =
            DependencyProperty.Register("Mobile", typeof(string), typeof(ManufacturersViewModel),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        #endregion

        #region 分機

        /// <summary>
        /// 主要聯絡人分機
        /// </summary>
        public string Extension
        {
            get { return (string)GetValue(ExtensionProperty); }
            set { SetValue(ExtensionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Extension.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtensionProperty =
            DependencyProperty.Register("Extension", typeof(string), typeof(ClientViewModel),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        #endregion

        #region LastUpdateTime
        /// <summary>
        /// 異動時間
        /// </summary>
        public DateTime LastUpdateTime
        {
            get { return (DateTime)GetValue(LastUpdateTimeProperty); }
            set { SetValue(LastUpdateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateTimeProperty =
            DependencyProperty.Register("LastUpdateTime", typeof(DateTime), typeof(ManufacturersViewModel), new PropertyMetadata(DateTime.Now
                , new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region TicketPeriodId

        /// <summary>
        /// 票期Id
        /// </summary>
        public int TicketPeriodId
        {
            get { return (int)GetValue(TicketPeriodIdProperty); }
            set { SetValue(TicketPeriodIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketPeriodId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPeriodIdProperty =
            DependencyProperty.Register("TicketPeriodId", typeof(int), typeof(ManufacturersViewModel), new PropertyMetadata(1));


        #endregion

        #region 發票地址


        public string InvoiceAddress
        {
            get { return (string)GetValue(InvoiceAddressProperty); }
            set { SetValue(InvoiceAddressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InvoiceAddress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InvoiceAddressProperty =
            DependencyProperty.Register("InvoiceAddress", typeof(string), typeof(ManufacturersViewModel), new PropertyMetadata(string.Empty));


        #endregion
        #region 交易紀錄


        public ManufacturersBussinessTranscationsViewModelCollection TranscationRecords
        {
            get
            {
                var model = (ManufacturersBussinessTranscationsViewModelCollection)GetValue(TranscationRecordsProperty);
                if (model.Count == 0)
                {
                    model.Query();
                }
                return model;
            }
            set { SetValue(TranscationRecordsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TranscationRecords.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranscationRecordsProperty =
            DependencyProperty.Register("TranscationRecords", typeof(ManufacturersBussinessTranscationsViewModelCollection), typeof(ManufacturersViewModel), new PropertyMetadata(default(ManufacturersBussinessTranscationsViewModelCollection)));


        #endregion

        #endregion

        #region 模型命令

        #region 查詢單一個體的檢視資料
        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public void QueryModel(Guid ManufacturersId)
        {
            try
            {
                var exeecuteresult = controller.Query(s => s.Id == ManufacturersId);
                if (!exeecuteresult.HasError)
                {
                    var data = exeecuteresult.Result.Single();
                    BindingFromModel(data, this);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        public override void Initialized()
        {
#if DEBUG
            Debug.WriteLine("ManufacturersViewModel initialized.");
#endif
            base.Initialized();

            try
            {
                if (controller == null)
                    controller = new ManufacturersManageController();

                Id = Guid.NewGuid();

                var createnewresult = controller.CreateNew();

                if (!createnewresult.HasError)
                {
                    var data = createnewresult.Result;
                    BindingFromModel(data, this);
                }

                LastUpdateTime = DateTime.Now;
                CreateTime = DateTime.Now;

                Contracts = new ContactsViewModelCollection();
                ManufacturersBussinessItems = new ManufacturersBussinessItemsViewModelColletion();
                TranscationRecords = new ManufacturersBussinessTranscationsViewModelCollection();
            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);
            }


        }

        public override void SaveModel()
        {
            try
            {
                Manufacturers data = new Manufacturers();
                //data.ManufacturersBussinessItems.First().SupplierTranscationItem.First().Projects
                var LoginedUser = controller.GetCurrentLoginUser().Result;

                if (CreateUserId == Guid.Empty)
                {
                    CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
                }

                if (CreateTime.Year < 1754)
                {
                    CreateTime = DateTime.Now;
                }

                CopyToModel(data, this);

                if (ManufacturersBussinessItems != null && ManufacturersBussinessItems.Count > 0)
                {
                    data.ManufacturersBussinessItems = new Collection<ManufacturersBussinessItems>();

                    foreach (var x in ManufacturersBussinessItems)
                    {
                        ManufacturersBussinessItems BItems = new ManufacturersBussinessItems();
                        CopyToModel(BItems, x);
                        BItems.ManufacturersId = Id;
                        BItems.Id = Guid.NewGuid();
                        data.ManufacturersBussinessItems.Add(BItems);
                    }
                }

                if (Contracts != null)
                {
                    if (Contracts.Count > 0)
                    {
                        data.Contacts = new Collection<Entity.Contacts>();

                        foreach (var x in Contracts)
                        {
                            if (x.Id == Guid.Empty)
                                x.Id = Guid.NewGuid();

                            if (x.CreateUserId == Guid.Empty)
                            {
                                x.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
                            }

                            if (x.CreateTime.Year < 1754)
                            {
                                x.CreateTime = CreateTime;
                            }

                            Contacts contact = new Contacts();
                            CopyToModel(contact, x);
                            //contact.Manufacturers.Add(data);
                            data.Contacts.Add(contact);
                        }
                    }
                }

                var resultsec = controller.CreateOrUpdate(data);

                if (resultsec.HasError)
                {
                    Errors = resultsec.Errors;
                    HasError = resultsec.HasError;
                    return;
                }

                Refresh();
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        public void QueryByName(string Name)
        {
            try
            {
                ManufacturersManageController controller = new ManufacturersManageController();
                var executeresult = controller.Query(p => p.Name == Name);

                if (!executeresult.HasError)
                {
                    if (executeresult.Result.Any())
                    {
                        var data = executeresult.Result.Single();
                        BindingFromModel(data, this);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is ManufacturersEnter)
                {
                    ManufacturersEnter data = (ManufacturersEnter)entity;
                    BindingFromModel(data, this);
                    DoEvents();
                    Status.IsNewInstance = false;
                    Status.IsModify = false;
                    Status.IsSaved = false;
                }

                if (entity is Manufacturers)
                {
                    Manufacturers data = (Manufacturers)entity;
                    BindingFromModel(data, this);
                    DoEvents();
                    Status.IsNewInstance = false;
                    Status.IsModify = false;
                    Status.IsSaved = false;
                }

                //await Dispatcher.InvokeAsync(new Action(QueryDetails), System.Windows.Threading.DispatcherPriority.Background);                
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }
        public void QueryDetails()
        {
            Contracts.ManufacturersId = Id;
            Contracts.Query("", Id, IsClient);

            ManufacturersBussinessItems.QueryAsync(Id);

            TranscationRecords.Query(Id);

        }
        #endregion

    }
}
