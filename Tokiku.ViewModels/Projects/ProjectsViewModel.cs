using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProjectsViewModelCollection : BaseViewModelCollection<ProjectsViewModel>
    {
        private ProjectsController _projectcontroller;

        public ProjectsViewModelCollection()
        {

        }

        public ProjectsViewModelCollection(IEnumerable<ProjectsViewModel> source) : base(source)
        {

        }

        public override void Initialized()
        {
            base.Initialized();
            _projectcontroller = new ProjectsController();
        }

        public override void Query()
        {
            var queryresult = _projectcontroller.Query(a => a.Void == false);

            if (!queryresult.HasError)
            {
                ClearItems();
                foreach (var row in queryresult.Result)
                {
                    ProjectsViewModel model = new ProjectsViewModel();
                    model.SetModel(row);
                    Add(model);
                }
            }
            else
            {
                Errors = queryresult.Errors;
                HasError = queryresult.HasError;
            }
        }

        public void QueryByClient(Guid Client)
        {
            var queryresult = _projectcontroller.Query(a => a.Void == false && a.ClientId == Client);
            if (!queryresult.HasError)
            {
                ClearItems();
                foreach (var row in queryresult.Result)
                {
                    ProjectsViewModel model = new ProjectsViewModel();
                    model.SetModel(row);
                    Add(model);
                }
            }
            else
            {
                Errors = queryresult.Errors;
                HasError = queryresult.HasError;
            }
        }
    }

    public class ProjectsViewModel : BaseViewModel, IBaseViewModel
    {
        private ProjectsController _projectcontroller;

        public ProjectsViewModel()
        {
            _projectcontroller = new ProjectsController();
        }
        public ProjectsViewModel(ProjectsController projectcontroller)
        {
            _projectcontroller = projectcontroller;
        }

        #region 私有變數
        /// <summary>
        /// 專案相關控制器
        /// </summary>         
        #endregion

        #region 相依性屬性宣告

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ProjectSigningDateProperty = DependencyProperty.Register("ProjectSigningDate", typeof(DateTime), typeof(ProjectsViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty ClientIdProperty = DependencyProperty.Register("ClientId", typeof(Guid?), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty SiteAddressProperty = DependencyProperty.Register("SiteAddress", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata((byte)1, new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty VoidProperty = DependencyProperty.Register("Void", typeof(bool), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(new PropertyChangedCallback(DefaultFieldChanged)));

        #endregion

        #region 屬性
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); } }
        /// <summary>
        /// 工地地址
        /// </summary>
        public string SiteAddress { get { return (string)GetValue(SiteAddressProperty); } set { SetValue(SiteAddressProperty, value); } }
        /// <summary>
        /// 客戶
        /// </summary>
        public System.Guid? ClientId { get { return (Guid?)GetValue(ClientIdProperty); } set { SetValue(ClientIdProperty, value); } }
        /// <summary>
        /// 建立時間
        /// </summary>
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); } }
        /// <summary>
        /// 建立者(擁有者)
        /// </summary>
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); } }
        /// <summary>
        /// 工程簽約日期
        /// </summary>
        public DateTime ProjectSigningDate
        {
            get { return (DateTime)GetValue(ProjectSigningDateProperty); }
            set { SetValue(ProjectSigningDateProperty, value); }
        }
        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); } }
        /// <summary>
        /// 狀態
        /// </summary>
        public byte State { get { return (byte)GetValue(StateProperty); } set { SetValue(StateProperty, value); } }
        /// <summary>
        /// 是否停用
        /// </summary>
        /// <remarks>
        /// (0: 啟用 1:停用)
        /// </remarks>
        public bool Void { get { return (bool)GetValue(VoidProperty); } set { SetValue(VoidProperty, value); RaisePropertyChanged("Void"); } }

        /// <summary>
        /// 起造日期
        /// </summary>
        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(ProjectsViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 完工日期
        /// </summary>
        public DateTime? CompletionDate
        {
            get { return (DateTime?)GetValue(CompletionDateProperty); }
            set { SetValue(CompletionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompletionDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompletionDateProperty =
            DependencyProperty.Register("CompletionDate", typeof(DateTime?), typeof(ProjectsViewModel), new PropertyMetadata(default(DateTime?), new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 支付方式
        /// </summary>
        public byte? PaymentType
        {
            get { return (byte?)GetValue(PaymentTypeProperty); }
            set { SetValue(PaymentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeProperty =
            DependencyProperty.Register("PaymentType", typeof(byte?), typeof(ProjectsViewModel), new PropertyMetadata(default(byte?), new PropertyChangedCallback(DefaultFieldChanged)));



        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyStartDate
        {
            get { return (DateTime?)GetValue(WarrantyStartDateProperty); }
            set { SetValue(WarrantyStartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyStartDateProperty =
            DependencyProperty.Register("WarrantyStartDate", typeof(DateTime?), typeof(ProjectsViewModel), new PropertyMetadata(default(DateTime?), new PropertyChangedCallback(DefaultFieldChanged)));




        public DateTime? WarrantyDate
        {
            get { return (DateTime?)GetValue(WarrantyDateProperty); }
            set { SetValue(WarrantyDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyDateProperty =
            DependencyProperty.Register("WarrantyDate", typeof(DateTime?), typeof(ProjectsViewModel), new PropertyMetadata(default(DateTime?), new PropertyChangedCallback(DefaultFieldChanged)));




        /// <summary>
        /// 建築師
        /// </summary>
        public string Architect
        {
            get { return (string)GetValue(ArchitectProperty); }
            set { SetValue(ArchitectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Architect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArchitectProperty =
            DependencyProperty.Register("Architect", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        /// <summary>
        /// 建築高度(地上)
        /// </summary>
        public int? BuildingHeightAboveground
        {
            get { return (int?)GetValue(BuildingHeightAbovegroundProperty); }
            set { SetValue(BuildingHeightAbovegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BuildingHeightAboveground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BuildingHeightAbovegroundProperty =
            DependencyProperty.Register("BuildingHeightAboveground", typeof(int?), typeof(ProjectsViewModel), new PropertyMetadata(default(int?), new PropertyChangedCallback(DefaultFieldChanged)));



        /// <summary>
        /// 建築高度(地下)
        /// </summary>
        public int? BuildingHeightUnderground
        {
            get { return (int?)GetValue(BuildingHeightUndergroundProperty); }
            set { SetValue(BuildingHeightUndergroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BuildingHeightUnderground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BuildingHeightUndergroundProperty =
            DependencyProperty.Register("BuildingHeightUnderground", typeof(int?), typeof(ProjectsViewModel), new PropertyMetadata(default(int?), new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 營造廠
        /// </summary>
        public string BuildingCompany
        {
            get { return (string)GetValue(BuildingCompanyProperty); }
            set { SetValue(BuildingCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BuildingCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BuildingCompanyProperty =
            DependencyProperty.Register("BuildingCompany", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 監造單位
        /// </summary>
        public string SupervisionUnit
        {
            get { return (string)GetValue(SupervisionUnitProperty); }
            set { SetValue(SupervisionUnitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BuildingCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SupervisionUnitProperty =
            DependencyProperty.Register("SupervisionUnit", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 面積數
        /// </summary>
        public float? Area
        {
            get { return (float?)GetValue(AreaProperty); }
            set { SetValue(AreaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Area.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaProperty =
            DependencyProperty.Register("Area", typeof(float?), typeof(ProjectsViewModel), new PropertyMetadata(default(float?), new PropertyChangedCallback(DefaultFieldChanged)));


        #region Client
        /// <summary>
        /// 客戶列表
        /// </summary>
        public ClientViewModel Client
        {
            get { return (ClientViewModel)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clients.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Client", typeof(ClientViewModel), typeof(ProjectsViewModel), new PropertyMetadata(default(ClientViewModel), new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region States
        /// <summary>
        /// 狀態清單        
        /// </summary>
        public StatesViewModelCollection States
        {
            get { return (StatesViewModelCollection)GetValue(StatesProperty); }
            set { SetValue(StatesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for States.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatesProperty =
            DependencyProperty.Register("States", typeof(StatesViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(default(StatesViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region CheckoutDay
        /// <summary>
        /// 付款條件: 結帳日
        /// </summary>
        public byte CheckoutDay
        {
            get { return (byte)GetValue(CheckoutDayProperty); }
            set { SetValue(CheckoutDayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckoutDay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckoutDayProperty =
            DependencyProperty.Register("CheckoutDay", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata((byte)1, new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region PaymentDay
        /// <summary>
        /// 付款條件: 付款日
        /// </summary>
        public byte PaymentDay
        {
            get { return (byte)GetValue(PaymentDayProperty); }
            set { SetValue(PaymentDayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentDay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentDayProperty =
            DependencyProperty.Register("PaymentDay", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata((byte)1, new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        #region 供應商

        /// <summary>
        /// 供應商清單        
        /// </summary>
        public SuppliersViewModelCollection Suppliers
        {
            get { return (SuppliersViewModelCollection)GetValue(SuppliersProperty); }
            set { SetValue(SuppliersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Suppliers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuppliersProperty =
            DependencyProperty.Register("Suppliers", typeof(SuppliersViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(default(SuppliersViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));


        #endregion

        #region Project Contract 專案合約
        /// <summary>
        /// 專案合約清單
        /// </summary>
        public ProjectContractViewModelCollection ProjectContract
        {
            get { return (ProjectContractViewModelCollection)GetValue(ProjectContractProperty); }
            set { SetValue(ProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractProperty =
            DependencyProperty.Register("ProjectContract", typeof(ProjectContractViewModelCollection), typeof(ProjectsViewModel
                ), new PropertyMetadata(default(ProjectContractViewModelCollection), new PropertyChangedCallback(DefaultFieldChanged)));
        #endregion

        public string ArchitectConsultant
        {
            get { return (string)GetValue(ArchitectConsultantProperty); }
            set { SetValue(ArchitectConsultantProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArchitectConsultant.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArchitectConsultantProperty =
            DependencyProperty.Register("ArchitectConsultant", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        public string BuildingCompanyConsultant
        {
            get { return (string)GetValue(BuildingCompanyConsultantProperty); }
            set { SetValue(BuildingCompanyConsultantProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BuildingCompanyConsultant.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BuildingCompanyConsultantProperty =
            DependencyProperty.Register("BuildingCompanyConsultant", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));



        /// <summary>
        /// 業主顧問
        /// </summary>
        public string OwnerAdvisor
        {
            get { return (string)GetValue(OwnerAdvisorProperty); }
            set { SetValue(OwnerAdvisorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OwnerAdvisor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerAdvisorProperty =
            DependencyProperty.Register("OwnerAdvisor", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));




        public string SystemType
        {
            get { return (string)GetValue(SystemTypeProperty); }
            set { SetValue(SystemTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SystemType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SystemTypeProperty =
            DependencyProperty.Register("SystemType", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));




        public string SystemDesign
        {
            get { return (string)GetValue(SystemDesignProperty); }
            set { SetValue(SystemDesignProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SystemDesign.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SystemDesignProperty =
            DependencyProperty.Register("SystemDesign", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));




        public DateTime? LastUpdate
        {
            get { return (DateTime?)GetValue(LastUpdateProperty); }
            set { SetValue(LastUpdateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateProperty =
            DependencyProperty.Register("LastUpdate", typeof(DateTime?), typeof(ProjectsViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(DefaultFieldChanged)));




        public string LastUpdateUserName
        {
            get { return (string)GetValue(LastUpdateUserNameProperty); }
            set { SetValue(LastUpdateUserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateUserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateUserNameProperty =
            DependencyProperty.Register("LastUpdateUserName", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty));



        public string OwnerContractNumber
        {
            get { return (string)GetValue(OwnerContractNumberProperty); }
            set { SetValue(OwnerContractNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OwnerContractNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerContractNumberProperty =
            DependencyProperty.Register("OwnerContractNumber", typeof(string), typeof(ProjectsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region 模型命令方法

        public override void Initialized()
        {
            base.Initialized();

            ProjectContract = new ProjectContractViewModelCollection();
            Client = new ClientViewModel();
            Suppliers = new SuppliersViewModelCollection();

            if (_projectcontroller == null)
                return;

            var result = _projectcontroller.CreateNew();

            if (result.HasError == false)
            {
                BindingFromModel(result.Result, this);
            }

            Id = Guid.NewGuid();

            State = 1;
            CompletionDate = DateTime.Today;
            BuildingHeightAboveground = 0;
            BuildingHeightUnderground = 0;
            CheckoutDay = 1;
            PaymentDay = 1;

            ProjectContract.Add(new ProjectContractViewModel()
            {
                ContractNumber = Code,
                Name = Name,
                SigningDate = ProjectSigningDate
            });
        }

        public override void SaveModel()
        {
            Projects data = new Projects();

            if (Status.IsNewInstance)
                data.Id = Guid.NewGuid();

            CopyToModel(data, this);

            if (ProjectContract != null)
            {
                foreach (ProjectContractViewModel model in ProjectContract)
                {
                    if (model != null)
                    {
                        ProjectContract pcdata = new ProjectContract();
                   
                        CopyToModel(pcdata, model);
                        pcdata.ProjectId = data.Id;
                        data.ProjectContract.Add(pcdata);
                    }
                }
            }

            if (Suppliers != null)
            {
                if (Suppliers.Any())
                {
                    foreach (var supplier in Suppliers)
                    {
                        SupplierTranscationItem supplierdata = new SupplierTranscationItem();
                        supplierdata.PlaceofReceipt = supplier.PlaceofReceipt;
                        supplierdata.ManufacturersBussinessItemsId = supplier.Id;
                        supplierdata.ProjectId = data.Id;
                        supplierdata.SiteContactPerson = supplier.SiteContactPerson;
                        supplierdata.SiteContactPersonPhone = supplier.SiteContactPersonPhone;

                        data.SupplierTranscationItem.Add(supplierdata);

                    }
                }
            }
            var result = _projectcontroller.CreateOrUpdate(data);

            if (result.HasError)
            {
                Errors = result.Errors;
            }

            Query(data.Id);
        }

        public void Query(Guid ProjectId)
        {

            try
            {
                var QueryResult = _projectcontroller.Query(p => p.Id == ProjectId);

                if (!QueryResult.HasError)
                {
                    var data = QueryResult.Result.SingleOrDefault();
                    BindingFromModel(data, this);

                    if (data.ClientId.HasValue)
                        Client.QueryModel(data.ClientId.Value);

                    if (data.SupplierTranscationItem.Any())
                    {
                        Suppliers.Clear();
                        foreach (var row in data.SupplierTranscationItem)
                        {
                            SuppliersViewModel model = new SuppliersViewModel();
                            model.ProjectId = row.ProjectId;
                            model.PlaceofReceipt = row.PlaceofReceipt;
                            model.ManufacturersName = row.ManufacturersBussinessItems.Manufacturers.Name;
                            model.TicketPeriod = row.ManufacturersBussinessItems.TicketPeriod.Name;
                            model.MaterialCategories = row.ManufacturersBussinessItems.MaterialCategories.Name;
                            model.PaymentTypeName = row.ManufacturersBussinessItems.PaymentTypes.PaymentTypeName;
                            model.TranscationCategories = row.ManufacturersBussinessItems.TranscationCategories.Name;
                            model.SiteContactPerson = row.SiteContactPerson;
                            model.SiteContactPersonPhone = row.SiteContactPersonPhone;
                            model.SetModel(row.ManufacturersBussinessItems);

                            Suppliers.Add(model);
                        }
                    }

                    if (data.ProjectContract.Any())
                    {
                        ProjectContract.Clear();
                        foreach (var row in data.ProjectContract)
                        {
                            ProjectContractViewModel model = new ProjectContractViewModel();
                            model.SetModel(row);
                            ProjectContract.Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);

            }
        }

        public override void Query()
        {
            throw new NotSupportedException();
        }

        public override void Refresh()
        {
            Query();
        }

        public override void SetModel(dynamic entity)
        {
            Projects data = (Projects)entity;
            BindingFromModel(data, this);
            ProjectContract.Query(data.Id);
            
            if (data.SupplierTranscationItem.Any())
            {
                foreach (var row in data.SupplierTranscationItem)
                {
                    SuppliersViewModel model = new SuppliersViewModel();
                    model.ProjectId = row.ProjectId;
                    model.PlaceofReceipt = row.PlaceofReceipt;
                    model.ManufacturersName = row.ManufacturersBussinessItems.Manufacturers.Name;
                    model.TicketPeriod = row.ManufacturersBussinessItems.TicketPeriod.Name;
                    model.MaterialCategories = row.ManufacturersBussinessItems.MaterialCategories.Name;
                    model.PaymentTypeName = row.ManufacturersBussinessItems.PaymentTypes.PaymentTypeName;
                    model.TranscationCategories = row.ManufacturersBussinessItems.TranscationCategories.Name;
                    model.SetModel(row.ManufacturersBussinessItems);
                    Suppliers.Add(model);
                }
            }
        }
        #endregion

    }
}
