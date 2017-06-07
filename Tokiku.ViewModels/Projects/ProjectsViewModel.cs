using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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
                foreach(var row in queryresult.Result)
                {
                    Add(BindingFromModel(row));
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
                foreach (var row in queryresult.Result)
                {
                    ProjectsViewModel model = BindingFromModel(row);
                    
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
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));

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
            DependencyProperty.Register("CompletionDate", typeof(DateTime?), typeof(ProjectContractViewModel), new PropertyMetadata(default(DateTime?)));


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
            DependencyProperty.Register("PaymentType", typeof(byte?), typeof(ProjectContractViewModel), new PropertyMetadata(default(byte?)));



        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyDate
        {
            get { return (DateTime?)GetValue(WarrantyDateProperty); }
            set { SetValue(WarrantyDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WarrantyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WarrantyDateProperty =
            DependencyProperty.Register("WarrantyDate", typeof(DateTime?), typeof(ProjectContractViewModel), new PropertyMetadata(default(DateTime?)));



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
            DependencyProperty.Register("Architect", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));



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
            DependencyProperty.Register("BuildingHeightAboveground", typeof(int?), typeof(ProjectContractViewModel), new PropertyMetadata(default(int?)));



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
            DependencyProperty.Register("BuildingHeightUnderground", typeof(int?), typeof(ProjectContractViewModel), new PropertyMetadata(default(int?)));


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
            DependencyProperty.Register("BuildingCompany", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));


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
            DependencyProperty.Register("SupervisionUnit", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));

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
            DependencyProperty.Register("Area", typeof(float?), typeof(ProjectContractViewModel), new PropertyMetadata(default(float?)));


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
            DependencyProperty.Register("Client", typeof(ClientViewModel), typeof(ProjectsViewModel), new PropertyMetadata(default(ClientViewModel)));
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
            DependencyProperty.Register("States", typeof(StatesViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(default(StatesViewModelCollection)));
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
            DependencyProperty.Register("CheckoutDay", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata((byte)1));
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
            DependencyProperty.Register("PaymentDay", typeof(byte), typeof(ProjectsViewModel), new PropertyMetadata((byte)1));
        #endregion

        #region 供應商

        /// <summary>
        /// 供應商清單        
        /// </summary>
        public ManufacturersViewModelCollection Suppliers
        {
            get { return (ManufacturersViewModelCollection)GetValue(SuppliersProperty); }
            set { SetValue(SuppliersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Suppliers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuppliersProperty =
            DependencyProperty.Register("Suppliers", typeof(ManufacturersViewModelCollection), typeof(ProjectsViewModel), new PropertyMetadata(default(ManufacturersViewModelCollection)));


        #endregion

        #region Project Contract
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

        #endregion

        #region 模型命令方法

        public override void Initialized()
        {
            base.Initialized();

            ProjectContract = new ProjectContractViewModelCollection();
            Client = new ClientViewModel();

            if (_projectcontroller == null)
                return;

            var result = _projectcontroller.CreateNew();

            if (result.HasError == false)
            {
                BindingFromModel(result.Result, this);
            }

            var result_states = _projectcontroller.GetStates();

            if (!result_states.HasError)
            {
                States = new StatesViewModelCollection();

                foreach (var states in result_states.Result)
                {
                    StatesViewModel state = new StatesViewModel();
                    BindingFromModel(states, state);
                    States.Add(state);
                }
            }


        }

        public override void SaveModel()
        {
            Entity.Projects data = new Entity.Projects();

            CopyToModel(data, this);

            if (ProjectContract != null)
            {
                foreach (ProjectContractViewModel model in ProjectContract)
                {
                    if (model != null)
                    {
                        model.ProjectId = Id;
                        model.SaveModel();
                    }
                }
            }

            if (Suppliers != null)
            {
                if (Suppliers.Any())
                {
                    foreach (ProjectContractViewModel model in ProjectContract)
                    {
                        if (model != null)
                        {
                            model.ProjectId = Id;
                            model.SaveModel();
                        }
                    }
                }
            }
            var result = _projectcontroller.CreateOrUpdate(data);

            if (result.HasError)
            {
                Errors = result.Errors;
            }

            Refresh();
        }

        public override void Query()
        {
            if (Id != Guid.Empty)
            {
                var QueryResult = _projectcontroller.Query(p => p.Id == Id && p.Void == false);

                if (!QueryResult.HasError)
                {
                    var data = QueryResult.Result.SingleOrDefault();
                    BindingFromModel(data, this);

                    var result_states = _projectcontroller.GetStates();

                    if (!result_states.HasError)
                    {
                        States = new StatesViewModelCollection();

                        foreach (var states in result_states.Result)
                        {
                            StatesViewModel state = new StatesViewModel();
                            BindingFromModel(states, state);
                            States.Add(state);
                        }
                    }
                }

                ProjectContract.ProjectId = Id;
                ProjectContract.Query();

            }

        }

        public override void Refresh()
        {
            Query();
        }
        #endregion

    }
}
