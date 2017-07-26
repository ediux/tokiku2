using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class SuppliersViewModelCollection : BaseViewModelCollection<SuppliersViewModel>
    {
        public SuppliersViewModelCollection() : base()
        {

        }

        public SuppliersViewModelCollection(IEnumerable<SuppliersViewModel> source) : base(source)
        {

        }

        public SuppliersViewModelCollection Query(Guid ProjectId)
        {
            return Query<SuppliersViewModelCollection, SupplierTranscationItem>(
                "Suppliers", "QueryByProject", ProjectId);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems.Count > 0)
                {
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        ExecuteAction<SupplierTranscationItem>("Suppliers", "Delete", ((SuppliersViewModel)e.OldItems[i]).Entity, false);
                    }
                }
            }

            base.OnCollectionChanged(e);


        }
        //public override void SaveModel()
        //{
        //    try
        //    {
        //        SuppliersController controller = new SuppliersController();
        //        if (Items.Any())
        //        {
        //            foreach(var item in Items)
        //            {
        //                SupplierTranscationItem data = new SupplierTranscationItem();
        //                CopyToModel(data, item);
        //                data.ManufacturersBussinessItemsId = item.Id;
        //                data.PlaceofReceipt = item.PlaceofReceipt;
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
    /// 專案列表-供應商項目檢視模型
    /// </summary>
    public class SuppliersViewModel : BaseViewModelWithPOCOClass<SupplierTranscationItem>
    {
        //#region 內部變數
        //private SuppliersController controller;
        //#endregion

        public SuppliersViewModel() : base()
        {

        }

        public SuppliersViewModel(SupplierTranscationItem entity) : base(entity)
        {
            _MaterialCategories = CopyofPOCOInstance?.ManufacturersBussinessItems?.MaterialCategories?.Name;
            _Name = CopyofPOCOInstance?.ManufacturersBussinessItems?.Name;
            _TicketPeriod = CopyofPOCOInstance?.ManufacturersBussinessItems?.TicketPeriod?.Name;
            _TicketPeriodId = CopyofPOCOInstance?.ManufacturersBussinessItems?.TicketPeriodId;
            _ManufacturersName = CopyofPOCOInstance?.ManufacturersBussinessItems?.Manufacturers?.Name;
            _ManufacturersId = CopyofPOCOInstance?.ManufacturersBussinessItems?.ManufacturersId;
        }

        public override void Initialized(object Parameter)
        {
            base.Initialized(Parameter);
            if (CopyofPOCOInstance == null)
                CopyofPOCOInstance = new SupplierTranscationItem();

            CopyofPOCOInstance.ManufacturersBussinessItems = new ManufacturersBussinessItems();

        }

        public string Code
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems.Manufacturers.Code;
            set { RaisePropertyChanged("Code"); }
        }
        /// <summary>
        /// 專案編號
        /// </summary>
        public Guid ProjectId
        {
            get { return CopyofPOCOInstance.ProjectId; }
            set { CopyofPOCOInstance.ProjectId = value; RaisePropertyChanged("ProjectId"); }
        }

        /// <summary>
        /// 營業項目
        /// </summary>
        public ManufacturersBussinessItems ManufacturersBussinessItems
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems;
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItems = value;

                _MaterialCategories = CopyofPOCOInstance.ManufacturersBussinessItems.MaterialCategories?.Name;
                _Name = CopyofPOCOInstance.ManufacturersBussinessItems?.Name;
                _TicketPeriod = CopyofPOCOInstance.ManufacturersBussinessItems?.TicketPeriod?.Name;
                _TicketPeriodId = CopyofPOCOInstance.ManufacturersBussinessItems?.TicketPeriodId;
                _ManufacturersName = CopyofPOCOInstance.ManufacturersBussinessItems?.Manufacturers?.Name;
                _ManufacturersId = CopyofPOCOInstance.ManufacturersBussinessItems?.ManufacturersId;
                RaisePropertyChanged("ManufacturersBussinessItems");
                RaisePropertyChanged("MaterialCategories");
                RaisePropertyChanged("Name");
                RaisePropertyChanged("TicketPeriod");
                RaisePropertyChanged("TicketPeriodId");
                RaisePropertyChanged("ManufacturersName");
            }
        }

        /// <summary>
        /// 營業項目ID
        /// </summary>
        public Guid ManufacturersBussinessItemsId
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItemsId;
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItemsId = value;
                RaisePropertyChanged("ManufacturersBussinessItemsId");
            }
        }

        private Guid? _ManufacturersId;
        public Guid? ManufacturersId
        {
            get => _ManufacturersId; set
            {
                _ManufacturersId = value;
                RaisePropertyChanged("ManufacturersId");
            }
        }


        /// <summary>
        /// 送貨地址(收貨廠商ID)
        /// </summary>
        public Guid? NextManufacturersId
        {
            get => CopyofPOCOInstance.NextManufacturersId;
            set
            {
                CopyofPOCOInstance.NextManufacturersId = value;
                RaisePropertyChanged("NextManufacturersId");
            }
        }

        /// <summary>
        /// 送貨地址(收貨廠商)
        /// </summary>
        public Manufacturers NextManufacturers
        {
            get => CopyofPOCOInstance.NextManufacturers;
            set
            {
                CopyofPOCOInstance.NextManufacturers = value;
                CopyofPOCOInstance.NextManufacturersId = CopyofPOCOInstance.NextManufacturers.Id;

                RaisePropertyChanged("NextManufacturers");
                RaisePropertyChanged("NextManufacturersId");
            }
        }

        private string _MaterialCategories;

        /// <summary>
        /// 材料類別
        /// </summary>
        public string MaterialCategories
        {
            get => _MaterialCategories;

            set
            {
                _MaterialCategories = value;
                RaisePropertyChanged("MaterialCategories");
            }
        }

        private string _Name;
        /// <summary>
        /// 交易品項
        /// </summary>
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _TicketPeriod;
        /// <summary>
        /// 票期
        /// </summary>
        public string TicketPeriod
        {
            get => _TicketPeriod;
            set
            {
                _TicketPeriod = value;
                RaisePropertyChanged("TicketPeriod");
            }
        }

        private int? _TicketPeriodId;

        /// <summary>
        /// 票期ID
        /// </summary>
        public int? TicketPeriodId
        {
            get => _TicketPeriodId;
            set
            {
                _TicketPeriodId = value;
                RaisePropertyChanged("TicketPeriodId");
            }
        }

        private string _ManufacturersName;

        /// <summary>
        /// 廠商
        /// </summary>
        public string ManufacturersName
        {
            get => _ManufacturersName;
            set
            {
                _ManufacturersName = value;
                RaisePropertyChanged("ManufacturersName");
            }
        }

        #region Model Command Functions      


        //public override void Query()
        //{
        //    if (ProjectId != null && ProjectId != Guid.Empty)
        //    {
        //        var executed_result = controller.Query(p => p.ProjectId == ProjectId);

        //        if (!executed_result.HasError)
        //        {
        //            SupplierTranscationItem data = executed_result.Result.Single();
        //            BindingFromModel(data, this);

        //            if (data.ManufacturersBussinessItems != null)
        //            {
        //                BindingFromModel(data.ManufacturersBussinessItems, this);
        //            }


        //        }

        //    }

        //}

        //public override void SaveModel()
        //{
        //    SupplierTranscationItem data = new SupplierTranscationItem();

        //    CopyToModel(data, this);

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
        //    if (entity is ManufacturersBussinessItemsViewModel)
        //    {
        //        ManufacturersBussinessItemsViewModel model = (ManufacturersBussinessItemsViewModel)entity;
        //        BindingFromModel(model, this);
        //        ManufacturersName = Manufacturers.Name;
        //    }
        //    else
        //    {
        //        if (entity is ManufacturersBussinessItems)
        //        {
        //            ManufacturersBussinessItems data = (ManufacturersBussinessItems)entity;
        //            BindingFromModel(data, this);
        //            ManufacturersName = data.Manufacturers.Name;

        //        }
        //        else
        //        {
        //            if(entity is SupplierTranscationItem)
        //            {
        //                SupplierTranscationItem data = (SupplierTranscationItem)entity;
        //                BindingFromModel(data, this);
        //                BindingFromModel(data.ManufacturersBussinessItems, this);
        //            }
        //        }
        //    } 
        //}
        #endregion

    }
}
