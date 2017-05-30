using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectContractViewModelCollection : ObservableCollection<ProjectContractViewModel>, IBaseViewModel
    {
        public ProjectContractViewModelCollection()
        {

        }

        public ProjectContractViewModelCollection(IEnumerable<ProjectContractViewModel> source) : base(source)
        {

        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }
        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }
    }

    public class ProjectContractViewModel : BaseViewModel, IBaseViewModel
    {
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectContractViewModel), new PropertyMetadata(Guid.NewGuid(),
                new PropertyChangedCallback(DefaultFieldChanged)));



        public Guid? ProjectId
        {
            get { return (Guid?)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid?), typeof(ProjectContractViewModel), new PropertyMetadata(default(Guid?),
                new PropertyChangedCallback(DefaultFieldChanged)));



        public Guid? ContractorId
        {
            get { return (Guid?)GetValue(ContractorIdProperty); }
            set { SetValue(ContractorIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContractorId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractorIdProperty =
            DependencyProperty.Register("ContractorId", typeof(Guid?), typeof(ProjectContractViewModel), new PropertyMetadata(default(Guid?)));



        public DateTime SigningDate
        {
            get { return (DateTime)GetValue(SigningDateProperty); }
            set { SetValue(SigningDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SigningDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SigningDateProperty =
            DependencyProperty.Register("SigningDate", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));




        public string ContractNumber
        {
            get { return (string)GetValue(ContractNumberProperty); }
            set { SetValue(ContractNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContractNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractNumberProperty =
            DependencyProperty.Register("ContractNumber", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));




        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));




        public DateTime CompletionDate
        {
            get { return (DateTime)GetValue(CompletionDateProperty); }
            set { SetValue(CompletionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompletionDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompletionDateProperty =
            DependencyProperty.Register("CompletionDate", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));




        public float? ContractAmount
        {
            get { return (float?)GetValue(ContractAmountProperty); }
            set { SetValue(ContractAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContractAmount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractAmountProperty =
            DependencyProperty.Register("ContractAmount", typeof(float?), typeof(ProjectContractViewModel), new PropertyMetadata(default(float?)));



        /// <summary>
        /// 應付金額
        /// </summary>
        public float? AmountDue
        {
            get { return (float?)GetValue(AmountDueProperty); }

            set { SetValue(AmountDueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AmountDue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountDueProperty =
            DependencyProperty.Register("AmountDue", typeof(float?), typeof(ProjectContractViewModel), new PropertyMetadata(default(float?)));




        public float? PrepaymentGuaranteeAmount
        {
            get { return (float?)GetValue(PrepaymentGuaranteeAmountProperty); }
            set { SetValue(PrepaymentGuaranteeAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrepaymentGuaranteeAmount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrepaymentGuaranteeAmountProperty =
            DependencyProperty.Register("PrepaymentGuaranteeAmount", typeof(float?), typeof(ProjectContractViewModel), new PropertyMetadata(default(float?)));





        public DateTime? OpenDate
        {
            get { return (DateTime?)GetValue(OpenDateProperty); }
            set { SetValue(OpenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenDateProperty =
            DependencyProperty.Register("OpenDate", typeof(DateTime?), typeof(ProjectContractViewModel), new PropertyMetadata(default(DateTime?)));



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

        public string PaymentTypeText
        {
            get { return (string)GetValue(PaymentTypeTextProperty); }
            set { SetValue(PaymentTypeTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypeText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeTextProperty =
            DependencyProperty.Register("PaymentTypeText", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));


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


        //public bool IsAppend { get; set; }

        /// <summary>
        /// 此合約是追加合約
        /// </summary>
        public bool? IsAppend
        {
            get { return (bool?)GetValue(IsAppendProperty); }
            set { SetValue(IsAppendProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAppend.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAppendProperty =
            DependencyProperty.Register("IsAppend", typeof(bool?), typeof(ProjectContractViewModel), new PropertyMetadata(default(bool?)));


        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));

        /// <summary>
        /// 建立人員
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProjectContractViewModel), new PropertyMetadata(Guid.Empty));

        /// <summary>
        /// 進度代碼
        /// </summary>
        public byte? State
        {
            get { return (byte?)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(byte?), typeof(ProjectContractViewModel), new PropertyMetadata(default(byte?)));


        /// <summary>
        /// 進度文字
        /// </summary>
        public string StateText
        {
            get { return (string)GetValue(StateTextProperty); }
            set { SetValue(StateTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateTextProperty =
            DependencyProperty.Register("StateText", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));



        /// <summary>
        /// 目前專案列表
        /// </summary>
        public ProjectsViewModel Projects
        {
            get { return (ProjectsViewModel)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ProjectsViewModel), typeof(ProjectContractViewModel), new PropertyMetadata(default(ProjectsViewModel)));


        /// <summary>
        /// 建立人員名稱
        /// </summary>
        public string CreateUser
        {
            get { return (string)GetValue(CreateUserProperty); }
            set { SetValue(CreateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserProperty =
            DependencyProperty.Register("CreateUser", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));


        /// <summary>
        /// 最後異動人員名稱
        /// </summary>
        public string LastUpdateUser
        {
            get { return (string)GetValue(LastUpdateUserProperty); }
            set { SetValue(LastUpdateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateUserProperty =
            DependencyProperty.Register("LastUpdateUser", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));


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
            DependencyProperty.Register("CheckoutDay", typeof(byte), typeof(ProjectContractViewModel), new PropertyMetadata((byte)0));



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
            DependencyProperty.Register("PaymentDay", typeof(byte), typeof(ProjectContractViewModel), new PropertyMetadata((byte)0));




        public bool? IsRepair
        {
            get { return (bool?)GetValue(IsRepairProperty); }
            set { SetValue(IsRepairProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRepair.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRepairProperty =
            DependencyProperty.Register("IsRepair", typeof(bool?), typeof(ProjectContractViewModel), new PropertyMetadata(default(bool?)));




        public EngineeringViewModelCollection Engineerings
        {
            get { return (EngineeringViewModelCollection)GetValue(EngineeringsProperty); }
            set { SetValue(EngineeringsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Engineerings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringsProperty =
            DependencyProperty.Register("Engineerings", typeof(EngineeringViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(EngineeringViewModelCollection)));




        public PromissoryNoteManagementViewModelCollection PromissoryNoteManagement
        {
            get { return (PromissoryNoteManagementViewModelCollection)GetValue(PromissoryNoteManagementProperty); }
            set { SetValue(PromissoryNoteManagementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PromissoryNoteManagement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromissoryNoteManagementProperty =
            DependencyProperty.Register("PromissoryNoteManagement", typeof(PromissoryNoteManagementViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(PromissoryNoteManagementViewModelCollection)));


        //public virtual ProjectBaseViewModel Projects { get; set; }
        //public virtual UserViewModel CreateUser { get; set; }

        //public virtual ICollection<PromissoryNoteManagementViewModel> PromissoryNoteManagement { get; set; }
    }
}
