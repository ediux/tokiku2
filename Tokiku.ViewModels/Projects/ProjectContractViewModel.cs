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
                        //model.SetModel(row);
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

        //public override void Query()
        //{
        //    throw new NotSupportedException();
        //}

        //public override void SaveModel()
        //{
        //    try
        //    {
        //        ProjectContractController controller = new ProjectContractController();
        //        if (Items.Any())
        //        {
        //            foreach (var item in Items)
        //            {
        //                ProjectContract data = new ProjectContract();
        //                CopyToModel(data, item);                     
        //                data.ProjectId = item.ProjectId;
        //                controller.CreateOrUpdate(data);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
    }

    /// <summary>
    /// 專案合約檢視模型
    /// </summary>
    public class ProjectContractViewModel : BaseViewModelWithPOCOClass<ProjectContract>
    {
        public ProjectContractViewModel()
        {

        }
        public ProjectContractViewModel(ProjectContract entity) : base(entity)
        {

        }



        #region ProjectId
        /// <summary>
        /// 所屬專案ID
        /// </summary>
        public Guid ProjectId
        {
            get { return CopyofPOCOInstance.ProjectId; }
            set { CopyofPOCOInstance.ProjectId = value; RaisePropertyChanged("ProjectId"); }
        }


        #endregion

        #region Name


        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }



        #endregion

        #region ContractNumber
        /// <summary>
        /// 合約編號
        /// </summary>
        public string ContractNumber
        {
            get { return CopyofPOCOInstance.ContractNumber; }
            set { CopyofPOCOInstance.ContractNumber = value; RaisePropertyChanged("ContractNumber"); }
        }

        #endregion

        #region IsAppend
        /// <summary>
        /// 此合約是追加合約
        /// </summary>
        public bool? IsAppend
        {
            get { return CopyofPOCOInstance.IsAppend; }
            set { CopyofPOCOInstance.IsAppend = value.HasValue ? value.Value : false; RaisePropertyChanged("IsAppend"); }
        }


        #endregion

        #region IsRepair
        /// <summary>
        /// 是否為修繕合約
        /// </summary>
        public bool? IsRepair
        {
            get { return CopyofPOCOInstance.IsRepair; }
            set { CopyofPOCOInstance.IsRepair = value.HasValue ? value.Value : false; RaisePropertyChanged("IsRepair"); }
        }

   
        #endregion

        

        #region Projects
        /// <summary>
        /// 所屬專案
        /// </summary>
        public Projects Projects
        {
            get { return CopyofPOCOInstance.Projects; }
        }

     
        #endregion

    
        //#region Engineerings
        ///// <summary>
        ///// 工程項目列表(清單)
        ///// </summary>
        //public EngineeringViewModelCollection Engineerings
        //{
        //    get { return (EngineeringViewModelCollection)GetValue(EngineeringsProperty); }
        //    set { SetValue(EngineeringsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Engineerings.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty EngineeringsProperty =
        //    DependencyProperty.Register("Engineerings", typeof(EngineeringViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(EngineeringViewModelCollection)));

        //#endregion

        //public ProcessingAtlasViewModelCollection ProcessingAtlas
        //{
        //    get { return (ProcessingAtlasViewModelCollection)GetValue(ProcessingAtlasProperty); }
        //    set { SetValue(ProcessingAtlasProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ProcessingAtlas.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ProcessingAtlasProperty =
        //    DependencyProperty.Register("ProcessingAtlas", typeof(ProcessingAtlasViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(ProcessingAtlasViewModelCollection)));



        //#region PromissoryNoteManagement
        ///// <summary>
        ///// 專案合約管理
        ///// </summary>
        //public PromissoryNoteManagementViewModelCollection PromissoryNoteManagement
        //{
        //    get { return (PromissoryNoteManagementViewModelCollection)GetValue(PromissoryNoteManagementProperty); }
        //    set { SetValue(PromissoryNoteManagementProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PromissoryNoteManagement.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PromissoryNoteManagementProperty =
        //    DependencyProperty.Register("PromissoryNoteManagement", typeof(PromissoryNoteManagementViewModelCollection), typeof(ProjectContractViewModel), new PropertyMetadata(default(PromissoryNoteManagementViewModelCollection)));

        //#endregion


        public DateTime SigningDate
        {
            get { return CopyofPOCOInstance.SigningDate; }
            set { CopyofPOCOInstance.SigningDate = value; RaisePropertyChanged("SigningDate"); }
        }


        //private ProjectContractController controller;

        //public override void Initialized()
        //{
        //    base.Initialized();
        //    controller = new ProjectContractController();
        //    var executeresult = controller.CreateNew(ProjectId);
        //    if (!executeresult.HasError)
        //    {
        //        ContractNumber = executeresult.Result.ContractNumber;
        //    }
        //    Engineerings = new EngineeringViewModelCollection();
        //    CreateUser = "";
        //    LastUpdateUser = "";
        //    PromissoryNoteManagement = new PromissoryNoteManagementViewModelCollection();
        //    Projects = new ProjectsViewModel(new ProjectsController());

        //    ProcessingAtlas = new ProcessingAtlasViewModelCollection();
        //}

        //public override void Query()
        //{
        //    if (controller == null)
        //        return;

        //    if (Id != Guid.Empty)
        //    {
        //        var result = controller.Query(p => p.Id == Id);

        //        if (!result.HasError)
        //        {
        //            ProjectContract data = result.Result.Single();
        //            BindingFromModel(data, this);

        //            if (data.CreateUser != null)
        //            {
        //                CreateUser = data.CreateUser.UserName;
        //            }




        //            //if (data.PromissoryNoteManagement.Any())
        //            //{
        //            //    PromissoryNoteManagement.Clear();
        //            //    foreach (var row in data.PromissoryNoteManagement)
        //            //    {
        //            //        PromissoryNoteManagementViewModel model = new PromissoryNoteManagementViewModel();
        //            //        model.DoEvents();
        //            //        model.SetModel(row);
        //            //        PromissoryNoteManagement.Add(model);
        //            //    }
        //            //}



        //            if (data.ProcessingAtlas.Any())
        //            {
        //                ProcessingAtlas.Clear();
        //                foreach (var row in data.ProcessingAtlas.OrderBy(o => o.Order).ToList())
        //                {
        //                    ProcessingAtlasViewModel model = new ProcessingAtlasViewModel();
        //                    model.DoEvents();
        //                    model.SetModel(row);
        //                    ProcessingAtlas.Add(model);
        //                }
        //            }
        //        }
        //    }
        //}

        //public override void SaveModel()
        //{
        //    ProjectContract data = new ProjectContract();
        //    CopyToModel(data, this);

        //    if(data.CreateUserId== Guid.Empty)
        //    {
        //        data.CreateUserId = controller.GetCurrentLoginUser().Result.UserId;
        //    }

        //    if (ProcessingAtlas.Any())
        //    {
        //        foreach (ProcessingAtlasViewModel model in ProcessingAtlas)
        //        {
        //            ProcessingAtlas entity = new ProcessingAtlas();
        //            CopyToModel(entity, model);
        //            entity.ProjectContractId = data.Id;
        //            data.ProcessingAtlas.Add(entity);
        //        }
        //    }

        //    var result = controller.CreateOrUpdate(data);

        //    if (result.HasError)
        //    {
        //        Errors = result.Errors;
        //        HasError = result.HasError;
        //    }

        //    Refresh();
        //}

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        ProjectContract data = (ProjectContract)entity;
        //        BindingFromModel(data, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
    }
}
