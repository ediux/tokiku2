using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProjectContractViewModelCollection : BaseViewModelCollection<ProjectContractViewModel>
    {
        private ProjectContractController _controller;
        public ProjectContractViewModelCollection()
        {

        }

        public ProjectContractViewModelCollection(IEnumerable<ProjectContractViewModel> source) : base(source)
        {

        }

        public Guid ProjectId
        {
            get; set;
        }

        public override void Initialized()
        {
            base.Initialized();
            _controller = new ProjectContractController();
        }

        public override void Query()
        {
            if (ProjectId != null && ProjectId != Guid.Empty)
            {
                var executed_result = _controller.QueryAll(ProjectId);

                if (!executed_result.HasError)
                {
                    ClearItems();
                    foreach (var row in executed_result.Result)
                    {
                        Add(BindingFromModel(row));
                    }
                }
            }

        }

        public override void SaveModel()
        {
            
        }

    }

    /// <summary>
    /// 專案合約檢視模型
    /// </summary>
    public class ProjectContractViewModel : BaseViewModel, IBaseViewModel
    {
        #region Id
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

        #endregion

        #region ProjectId
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
        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ProjectContractViewModel), new PropertyMetadata(string.Empty));

        #endregion

        #region ContractNumber
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
        #endregion

        #region IsAppend
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
        #endregion

        #region IsRepair
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
        #endregion

        #region CreateTime
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
        #endregion

        #region CreateUserId
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
        #endregion

        #region Projects
        /// <summary>
        /// 所屬專案
        /// </summary>
        public ProjectsViewModel Projects
        {
            get { return (ProjectsViewModel)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ProjectsViewModel), typeof(ProjectContractViewModel), new PropertyMetadata(default(ProjectsViewModel)));
        #endregion

        #region CreateUser
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

        #endregion

        #region LastUpdateUser
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
        #endregion

        #region Engineerings
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

        #endregion

        #region PromissoryNoteManagement
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

        #endregion

        private ProjectContractController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new ProjectContractController();
            Engineerings = new EngineeringViewModelCollection();
            CreateUser = "";
            LastUpdateUser = "";
            PromissoryNoteManagement = new PromissoryNoteManagementViewModelCollection();
            Projects = new ProjectsViewModel(new ProjectsController());
        }

        public override void Query()
        {
            if (controller == null)
                return;

            if (Id != Guid.Empty)
            {
                var result = controller.Query(p => p.Id == Id);

                if (!result.HasError)
                {
                    Entity.ProjectContract data = result.Result.Single();
                    BindingFromModel(data, this);
                    CreateUser = data.CreateUser.UserName;

                    if (data.Engineering.Any())
                    {
                        foreach (var row in data.Engineering)
                        {
                            Engineerings.Add(BindingFromModel<EngineeringViewModel, Engineering>(row));
                        }
                    }

                    if (data.PromissoryNoteManagement.Any())
                    {
                        foreach (var row in data.PromissoryNoteManagement)
                        {
                            PromissoryNoteManagement.Add(BindingFromModel<PromissoryNoteManagementViewModel, PromissoryNoteManagement>(row));
                        }
                    }
                }
            }
        }

        public override void SaveModel()
        {
            ProjectContract data = new ProjectContract();

            CopyToModel(data, this);

            if (Engineerings != null)
            {
                foreach (EngineeringViewModel model in Engineerings)
                {
                    if (model != null)
                    {
                        model.SaveModel();
                    }
                }
            }

            if (PromissoryNoteManagement.Any())
            {
                foreach (PromissoryNoteManagementViewModel model in PromissoryNoteManagement)
                {
                    if (model != null)
                    {
                        model.SaveModel();
                    }
                }
            }
          
            var result = controller.CreateOrUpdate(data);

            if (result.HasError)
            {
                Errors = result.Errors;
                HasError = result.HasError;
            }

            Refresh();
        }

    }
}
