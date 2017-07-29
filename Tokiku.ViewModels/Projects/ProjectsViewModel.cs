using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProjectsViewModelCollection : BaseViewModelCollection<ProjectsViewModel, Projects>
    {
        private ProjectsController _projectcontroller;

        public ProjectsViewModelCollection()
        {

        }

        public ProjectsViewModelCollection(IEnumerable<ProjectsViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    var queryresult = _projectcontroller.Query(a => a.Void == false);

        //    if (!queryresult.HasError)
        //    {
        //        ClearItems();
        //        foreach (var row in queryresult.Result)
        //        {
        //            ProjectsViewModel model = new ProjectsViewModel();
        //            //model.SetModel(row);
        //            Add(model);
        //        }
        //    }
        //    else
        //    {
        //        Errors = queryresult.Errors;
        //        HasError = queryresult.HasError;
        //    }
        //}

        public void QueryByClient(Guid Client)
        {
            var queryresult = _projectcontroller.Query(a => a.Void == false && a.ClientId == Client);
            if (!queryresult.HasError)
            {
                ClearItems();
                foreach (var row in queryresult.Result)
                {
                    ProjectsViewModel model = new ProjectsViewModel();
                    //model.SetModel(row);
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

    public class ProjectsViewModel : BaseViewModelWithPOCOClass<Projects>
    {
        private ProjectsController _projectcontroller;

        public ProjectsViewModel()
        {
            _projectcontroller = new ProjectsController();
        }

        public ProjectsViewModel(Projects entity) : base(entity)
        {

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



        #region 屬性


        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Code; }
            set { CopyofPOCOInstance.Code = value; RaisePropertyChanged("Code"); }
        }

        /// <summary>
        /// 專案名稱
        /// </summary>
        public string Name { get { return CopyofPOCOInstance.Name; } set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
        /// <summary>
        /// 專案名稱(簡稱)
        /// </summary>
        public string ShortName { get { return CopyofPOCOInstance.ShortName; } set { CopyofPOCOInstance.ShortName = value; RaisePropertyChanged("ShortName"); } }
        /// <summary>
        /// 工地地址
        /// </summary>
        public string SiteAddress { get { return CopyofPOCOInstance.SiteAddress; } set { CopyofPOCOInstance.SiteAddress = value; RaisePropertyChanged("SiteAddress"); } }
        /// <summary>
        /// 客戶
        /// </summary>
        public System.Guid? ClientId
        {
            get { return CopyofPOCOInstance.ClientId; }
            set
            {
                CopyofPOCOInstance.ClientId = value;
                RaisePropertyChanged("ClientId");
            }
        }

        /// <summary>
        /// 工程簽約日期
        /// </summary>
        public DateTime ProjectSigningDate
        {
            get { return CopyofPOCOInstance.ProjectSigningDate; }
            set { CopyofPOCOInstance.ProjectSigningDate = value; RaisePropertyChanged("ProjectSigningDate"); }
        }
        /// <summary>
        /// 備註
        /// </summary>
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }
        /// <summary>
        /// 狀態
        /// </summary>
        public byte State
        {
            get { return CopyofPOCOInstance.State; }
            set { CopyofPOCOInstance.State = value; RaisePropertyChanged("State"); }
        }
        /// <summary>
        /// 是否停用
        /// </summary>
        /// <remarks>
        /// (0: 啟用 1:停用)
        /// </remarks>
        public bool Void
        {
            get { return CopyofPOCOInstance.Void; }
            set { CopyofPOCOInstance.Void = value; RaisePropertyChanged("Void"); }
        }

        /// <summary>
        /// 起造日期
        /// </summary>
        public DateTime StartDate
        {
            get { return CopyofPOCOInstance.StartDate; }
            set { CopyofPOCOInstance.StartDate = value; RaisePropertyChanged("StartDate"); }
        }


        /// <summary>
        /// 完工日期
        /// </summary>
        public DateTime? CompletionDate
        {
            get
            {
                if (CopyofPOCOInstance.PromissoryNoteManagement.Any())
                {

                }

                return null;
            }

        }


        /// <summary>
        /// 保固日期
        /// </summary>
        public DateTime? WarrantyStartDate
        {
            get { return null; }

        }




        public DateTime? WarrantyDate
        {
            get { return null; }

        }





        /// <summary>
        /// 建築師
        /// </summary>
        public string Architect
        {
            get { return CopyofPOCOInstance.Architect; }
            set { CopyofPOCOInstance.Architect = value; RaisePropertyChanged("Architect"); }
        }



        /// <summary>
        /// 建築高度(地上)
        /// </summary>
        public int BuildingHeightAboveground
        {
            get { return CopyofPOCOInstance.BuildingHeightAboveground; }
            set { CopyofPOCOInstance.BuildingHeightAboveground = value; RaisePropertyChanged("BuildingHeightAboveground"); }
        }



        /// <summary>
        /// 建築高度(地下)
        /// </summary>
        public int BuildingHeightUnderground
        {
            get { return CopyofPOCOInstance.BuildingHeightUnderground; }
            set { CopyofPOCOInstance.BuildingHeightUnderground = value; RaisePropertyChanged("BuildingHeightUnderground"); }
        }



        /// <summary>
        /// 營造廠
        /// </summary>
        public string BuildingCompany
        {
            get { return CopyofPOCOInstance.BuildingCompany; }
            set { CopyofPOCOInstance.BuildingCompany = value; RaisePropertyChanged("BuildingCompany"); }
        }



        /// <summary>
        /// 監造單位
        /// </summary>
        public string SupervisionUnit
        {
            get { return CopyofPOCOInstance.SupervisionUnit; }
            set { CopyofPOCOInstance.SupervisionUnit = value; RaisePropertyChanged("SupervisionUnit"); }
        }


        /// <summary>
        /// 面積數
        /// </summary>
        public float Area
        {
            get { return CopyofPOCOInstance.Area; }
            set { CopyofPOCOInstance.Area = value; RaisePropertyChanged("Area"); }
        }


        #region Client
        /// <summary>
        /// 客戶
        /// </summary>
        public ClientViewModel Client
        {
            get { return null; }

        }

        #endregion


        #region CheckoutDay
        /// <summary>
        /// 付款條件: 結帳日
        /// </summary>
        public byte CheckoutDay
        {
            get { return CopyofPOCOInstance.CheckoutDay.HasValue ? CopyofPOCOInstance.CheckoutDay.Value : (byte)0; }
            set { CopyofPOCOInstance.CheckoutDay = value; RaisePropertyChanged("CheckoutDay"); }
        }

        #endregion

        #region PaymentDay
        /// <summary>
        /// 付款條件: 付款日
        /// </summary>
        public byte PaymentDay
        {
            get { return CopyofPOCOInstance.PaymentDay.HasValue ? CopyofPOCOInstance.PaymentDay.Value : (byte)0; }
            set { CopyofPOCOInstance.PaymentDay = value; RaisePropertyChanged("PaymentDay"); }
        }


        #endregion

        public string ArchitectConsultant
        {
            get { return CopyofPOCOInstance.ArchitectConsultant; }
            set { CopyofPOCOInstance.ArchitectConsultant = value; RaisePropertyChanged("ArchitectConsultant"); }
        }




        public string BuildingCompanyConsultant
        {
            get { return CopyofPOCOInstance.BuildingCompanyConsultant; }
            set { CopyofPOCOInstance.BuildingCompanyConsultant = value; RaisePropertyChanged("BuildingCompanyConsultant"); }
        }




        /// <summary>
        /// 業主顧問
        /// </summary>
        public string OwnerAdvisor
        {
            get { return CopyofPOCOInstance.OwnerAdvisor; }
            set { CopyofPOCOInstance.OwnerAdvisor = value; RaisePropertyChanged("OwnerAdvisor"); }
        }




        public string SystemType
        {
            get { return CopyofPOCOInstance.SystemType; }
            set { CopyofPOCOInstance.SystemType = value; RaisePropertyChanged("SystemType"); }
        }





        public string SystemDesign
        {
            get { return CopyofPOCOInstance.SystemDesign; }
            set { CopyofPOCOInstance.SystemDesign = value; RaisePropertyChanged("SystemDesign"); }
        }





        public string OwnerContractNumber
        {
            get { return CopyofPOCOInstance.OwnerContractNumber; }
            set { CopyofPOCOInstance.OwnerContractNumber = value; RaisePropertyChanged("OwnerContractNumber"); }
        }


        public string SiteContactPerson
        {
            get { return CopyofPOCOInstance.SiteContactPerson; }
            set { CopyofPOCOInstance.SiteContactPerson = value; RaisePropertyChanged("SiteContactPerson"); }
        }


        public string SiteContactPersonPhone
        {
            get { return CopyofPOCOInstance.SiteContactPersonPhone; }
            set { CopyofPOCOInstance.SiteContactPersonPhone = value; RaisePropertyChanged("SiteContactPersonPhone"); }
        }




        public string SitePhone
        {
            get { return CopyofPOCOInstance.SitePhone; }
            set { CopyofPOCOInstance.SitePhone = value; RaisePropertyChanged("SitePhone"); }
        }


        #endregion

        #region 模型命令方法

        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);

            //ProjectContract = new ProjectContractViewModelCollection();
            //Client = new ClientViewModel();
            //Suppliers = new SuppliersViewModelCollection();
            //ConstructionAtlas = new ConstructionAtlasViewModelCollection();

            if (_projectcontroller == null)
                return;

            var result = _projectcontroller.CreateNew();

            if (result.HasError == false)
            {
                //BindingFromModel(result.Result, this);
            }

            Id = Guid.NewGuid();

            State = 1;
            //CompletionDate = DateTime.Today;
            BuildingHeightAboveground = 0;
            BuildingHeightUnderground = 0;
            CheckoutDay = 1;
            PaymentDay = 1;

            //ProjectContract.Add(new ProjectContractViewModel()
            //{
            //    ContractNumber = Code,
            //    Name = Name,
            //    SigningDate = ProjectSigningDate
            //});
        }

        //public override void SaveModel()
        //{
        //    Projects data = new Projects();

        //    if (Status.IsNewInstance)
        //        data.Id = Guid.NewGuid();

        //    CopyToModel(data, this);

        //    if (ProjectContract != null)
        //    {
        //        foreach (ProjectContractViewModel model in ProjectContract)
        //        {
        //            if (model != null)
        //            {
        //                ProjectContract pcdata = new ProjectContract();

        //                CopyToModel(pcdata, model);
        //                pcdata.ProjectId = data.Id;
        //                data.ProjectContract.Add(pcdata);
        //            }
        //        }
        //    }

        //    if (ConstructionAtlas.Any())
        //    {
        //        foreach (ConstructionAtlasViewModel model in ConstructionAtlas)
        //        {
        //            ConstructionAtlas entity = new ConstructionAtlas();
        //            CopyToModel(entity, model);
        //            entity.ProjectContractId = data.Id;
        //            data.ConstructionAtlas.Add(entity);
        //        }
        //    }

        //    if (Suppliers != null)
        //    {
        //        if (Suppliers.Any())
        //        {
        //            foreach (var supplier in Suppliers)
        //            {
        //                SupplierTranscationItem supplierdata = new SupplierTranscationItem();
        //                supplierdata.PlaceofReceipt = supplier.PlaceofReceipt;
        //                supplierdata.ManufacturersBussinessItemsId = supplier.Id;
        //                supplierdata.ProjectId = data.Id;

        //                data.SupplierTranscationItem.Add(supplierdata);

        //            }
        //        }
        //    }
        //    var result = _projectcontroller.CreateOrUpdate(data);

        //    if (result.HasError)
        //    {
        //        Errors = result.Errors;
        //    }

        //    Query(data.Id);
        //}

        //public void Query(Guid ProjectId)
        //{

        //    try
        //    {
        //        var QueryResult = _projectcontroller.Query(p => p.Id == ProjectId);

        //        if (!QueryResult.HasError)
        //        {
        //            var data = QueryResult.Result.SingleOrDefault();

        //            //BindingFromModel(data, this);
        //            //CompletionDate = data.PromissoryNoteManagement.Where(w => w.TicketTypeId == 3 || w.TicketTypeId == 4).OrderBy(o => o.OpenDate).FirstOrDefault()?.OpenDate;
        //            //WarrantyStartDate = data.PromissoryNoteManagement.Where(w => w.TicketTypeId == 3 || w.TicketTypeId == 4).OrderByDescending(o => o.OpenDate).FirstOrDefault()?.OpenDate;
        //            //WarrantyDate = data.PromissoryNoteManagement.Where(w => w.TicketTypeId == 3 || w.TicketTypeId == 4).OrderByDescending(o => o.RecoveryDate).FirstOrDefault()?.RecoveryDate;

        //            if (data.ClientId.HasValue)
        //                Client.QueryModel(data.ClientId.Value);

        //            if (data.SupplierTranscationItem.Any())
        //            {
        //                //Suppliers.Clear();
        //                foreach (var row in data.SupplierTranscationItem)
        //                {
        //                    SuppliersViewModel model = new SuppliersViewModel();
        //                    try
        //                    {

        //                        model.ProjectId = row.ProjectId;
        //                        model.PlaceofReceipt = row.PlaceofReceipt;
        //                        model.ManufacturersName = row.ManufacturersBussinessItems.Manufacturers.Name;
        //                        //model.TicketPeriod = row.ManufacturersBussinessItems.TicketPeriod.Name;
        //                        model.MaterialCategories = row.ManufacturersBussinessItems.MaterialCategories.Name;
        //                        //model.PaymentTypeName = row.ManufacturersBussinessItems.PaymentTypes.PaymentTypeName;
        //                        //model.TranscationCategories = row.ManufacturersBussinessItems.TranscationCategories.Name;
        //                        model.SetModel(row.ManufacturersBussinessItems);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        //setErrortoModel(model, ex);
        //                    }

        //                    //if (!model.HasError)
        //                    //    Suppliers.Add(model);
        //                }
        //            }

        //            if (data.ProjectContract.Any())
        //            {
        //                //ProjectContract.Clear();
        //                foreach (var row in data.ProjectContract)
        //                {
        //                    ProjectContractViewModel model = new ProjectContractViewModel();
        //                    //model.SetModel(row);
        //                    //ProjectContract.Add(model);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        setErrortoModel(this, ex);

        //    }
        //}

        //public override void ReplyFrom(object source)
        //{
        //    if (source != null && source is ProjectListViewModel)
        //    {
        //        CopyofPOCOInstance = Query(((ProjectListViewModel)source).Id).Entity;
        //    }

        //    if (source != null && source is RoutedViewResult)
        //    {
        //        //CopyofPOCOInstance = Query(((ProjectsViewModel)((RoutedViewResult)source).RoutedValues["TargetViewModelInstance"]).Id).Entity;
        //        var provider = ((ObjectDataProvider)((RoutedViewResult)source).RoutedValues["TargetViewModelProvider"]);

        //        provider.MethodName = "Query";
        //        provider.MethodParameters[0] = ((ProjectsViewModel)((RoutedViewResult)source).RoutedValues["TargetViewModelInstance"]).Id;
                     
        //    }
        //}

        public ProjectsViewModel Query(Guid ProjectId)
        {
            return QuerySingle<ProjectsViewModel, Projects>("ProjectManagerView", "QueryById", ProjectId);
        }

        public ProjectsViewModel Refresh()
        {
            return Query(Id);
        }

        //public override void SetModel(dynamic entity)
        //{
        //    Projects data = (Projects)entity;
        //    /*B*/indingFromModel(data, this);
        //    //ProjectContract.Query(data.Id);

        //    //if (data.SupplierTranscationItem.Any())
        //    //{
        //    //    foreach (var row in data.SupplierTranscationItem)
        //    //    {
        //    //        SuppliersViewModel model = new SuppliersViewModel();
        //    //        model.ProjectId = row.ProjectId;
        //    //        model.PlaceofReceipt = row.PlaceofReceipt;

        //    //        if (row.ManufacturersBussinessItems != null)
        //    //        {
        //    //            model.ManufacturersName = row.ManufacturersBussinessItems.Manufacturers.Name;
        //    //            model.TicketPeriod = row.ManufacturersBussinessItems.TicketPeriod.Name;
        //    //            model.MaterialCategories = row.ManufacturersBussinessItems.MaterialCategories.Name;
        //    //            model.PaymentTypeName = row.ManufacturersBussinessItems.PaymentTypes.PaymentTypeName;
        //    //            model.TranscationCategories = row.ManufacturersBussinessItems.TranscationCategories.Name;
        //    //        }

        //    //        model.SetModel(row.ManufacturersBussinessItems);
        //    //        Suppliers.Add(model);
        //    //    }
        //    //}
        //}
        #endregion

    }
}
