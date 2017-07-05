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

        public void Query(Guid ProjectId)
        {
            try
            {
                var executed_result = _controller.QueryAll(ProjectId);

                if (!executed_result.HasError)
                {
                    ClearItems();

                    foreach (var row in executed_result.Result)
                    {
                        ProjectContractViewModel model = new ProjectContractViewModel();
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

        private List<ProjectContractViewModel> BufferSwap = new List<ProjectContractViewModel>();

        public void Query(string SeatchText)
        {
            try
            {
                if (!string.IsNullOrEmpty(SeatchText))
                {
                    BufferSwap.Clear();
                    BufferSwap.AddRange(Items);

                    var result = Items.Where(w => w.ContractNumber.Contains(SeatchText)).ToList();

                    if (result.Any())
                    {
                        ClearItems();
                        foreach (var temprow in result)
                        {
                            Add(temprow);
                        }
                    }
                }
                else
                {
                    ClearItems();

                    foreach (var restore in BufferSwap)
                    {
                        Add(restore);
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

        public override void SaveModel()
        {
            try
            {
                ProjectContractController controller = new ProjectContractController();
                if (Items.Any())
                {
                    foreach (var item in Items)
                    {
                        ProjectContract data = new ProjectContract();
                        CopyToModel(data, item);                     
                        data.ProjectId = item.ProjectId;
                        controller.CreateOrUpdate(data);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
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
        public Guid ProjectId
        {
            get { return (Guid)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid), typeof(ProjectContractViewModel), new PropertyMetadata(Guid.Empty,
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


       

        public ProcessingAtlasViewModelCollection ProcessingAtlas
        {
            get { return (ProcessingAtlasViewModelCollection)GetValue(ProcessingAtlasProperty); }
            set { SetValue(ProcessingAtlasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProcessingAtlas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessingAtlasProperty =
            DependencyProperty.Register("ProcessingAtlas", typeof(ProcessingAtlasViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(ProcessingAtlasViewModelCollection)));



        #region PromissoryNoteManagement
        /// <summary>
        /// 專案合約管理
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


        public DateTime SigningDate
        {
            get { return (DateTime)GetValue(SigningDateProperty); }
            set { SetValue(SigningDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SigningDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SigningDateProperty =
            DependencyProperty.Register("SigningDate", typeof(DateTime), typeof(ProjectContractViewModel), new PropertyMetadata(DateTime.Today));


        private ProjectContractController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new ProjectContractController();
            var executeresult = controller.CreateNew(ProjectId);
            if (!executeresult.HasError)
            {
                ContractNumber = executeresult.Result.ContractNumber;
            }
            Engineerings = new EngineeringViewModelCollection();
            CreateUser = "";
            LastUpdateUser = "";
            PromissoryNoteManagement = new PromissoryNoteManagementViewModelCollection();
            Projects = new ProjectsViewModel(new ProjectsController());
          
            ProcessingAtlas = new ProcessingAtlasViewModelCollection();
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
                    ProjectContract data = result.Result.Single();
                    BindingFromModel(data, this);

                    if (data.CreateUser != null)
                    {
                        CreateUser = data.CreateUser.UserName;
                    }


                  

                    //if (data.PromissoryNoteManagement.Any())
                    //{
                    //    PromissoryNoteManagement.Clear();
                    //    foreach (var row in data.PromissoryNoteManagement)
                    //    {
                    //        PromissoryNoteManagementViewModel model = new PromissoryNoteManagementViewModel();
                    //        model.DoEvents();
                    //        model.SetModel(row);
                    //        PromissoryNoteManagement.Add(model);
                    //    }
                    //}

                   

                    if (data.ProcessingAtlas.Any())
                    {
                        ProcessingAtlas.Clear();
                        foreach (var row in data.ProcessingAtlas.OrderBy(o => o.Order).ToList())
                        {
                            ProcessingAtlasViewModel model = new ProcessingAtlasViewModel();
                            model.DoEvents();
                            model.SetModel(row);
                            ProcessingAtlas.Add(model);
                        }
                    }
                }
            }
        }

        public override void SaveModel()
        {
            ProjectContract data = new ProjectContract();
            CopyToModel(data, this);

            if(data.CreateUserId== Guid.Empty)
            {
                data.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
            }

            if (ProcessingAtlas.Any())
            {
                foreach (ProcessingAtlasViewModel model in ProcessingAtlas)
                {
                    ProcessingAtlas entity = new ProcessingAtlas();
                    CopyToModel(entity, model);
                    entity.ProjectContractId = data.Id;
                    data.ProcessingAtlas.Add(entity);
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

        public override void SetModel(dynamic entity)
        {
            try
            {
                ProjectContract data = (ProjectContract)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
