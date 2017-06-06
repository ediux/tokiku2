using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectContractViewModelCollection : BaseViewModelCollection<ProjectContractViewModel>
    {
        public ProjectContractViewModelCollection()
        {

        }

        public ProjectContractViewModelCollection(IEnumerable<ProjectContractViewModel> source) : base(source)
        {

        }
        
        public override void StartUp_Query()
        {
            Query();
        }

        public override void Query()
        {
            
        }

        public override void Refresh()
        {
            Query();
        }
    }

    public class ProjectContractViewModel : BaseViewModel, IBaseViewModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); RaisePropertyChanged("Id"); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ProjectContractViewModel), new PropertyMetadata(Guid.NewGuid(),
                new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 所屬專案ID
        /// </summary>
        public Guid? ProjectId
        {
            get { return (Guid?)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid?), typeof(ProjectContractViewModel), new PropertyMetadata(default(Guid?),
                new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 合約編號
        /// </summary>
        public string ContractNumber
        {
            get { return (string)GetValue(ContractNumberProperty); }
            set { SetValue(ContractNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContractNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractNumberProperty =
            DependencyProperty.Register("ContractNumber", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));

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


        /// <summary>
        /// 是否為修繕合約
        /// </summary>
        public bool? IsRepair
        {
            get { return (bool?)GetValue(IsRepairProperty); }
            set { SetValue(IsRepairProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRepair.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRepairProperty =
            DependencyProperty.Register("IsRepair", typeof(bool?), typeof(ProjectContractViewModel), new PropertyMetadata(default(bool?)));

        /// <summary>
        /// 工程項目列表(清單)
        /// </summary>
        public EngineeringViewModelCollection Engineerings
        {
            get { return (EngineeringViewModelCollection)GetValue(EngineeringsProperty); }
            set { SetValue(EngineeringsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Engineerings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringsProperty =
            DependencyProperty.Register("Engineerings", typeof(EngineeringViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(EngineeringViewModelCollection)));



        /// <summary>
        /// 本票管理
        /// </summary>
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
