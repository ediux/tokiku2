using System;
using System.Collections.Generic;
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

        }
        /// <summary>
        /// 專案編號
        /// </summary>
        public Guid ProjectId
        {
            get { return CopyofPOCOInstance.ProjectId; }
            set { CopyofPOCOInstance.ProjectId = value; RaisePropertyChanged("ProjectId"); }
        }

        public Guid ManufacturersBussinessItemsId
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItemsId;
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItemsId = value;
                RaisePropertyChanged("ManufacturersBussinessItemsId");
            }
        }
        public Guid? NextManufacturersId
        {
            get => CopyofPOCOInstance.NextManufacturersId; set
            {
                CopyofPOCOInstance.NextManufacturersId = value;
                RaisePropertyChanged("NextManufacturersId");
            }
        }

        public string MaterialCategories
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems.MaterialCategories.Name;
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItems.MaterialCategories.Name = value;
                RaisePropertyChanged("MaterialCategories");
            }
        }

        public string Name
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems.Name;
            set => RaisePropertyChanged("Name");
        }

        public string PlaceofReceipt
        {
            get { return CopyofPOCOInstance.PlaceofReceipt; }
            set { CopyofPOCOInstance.PlaceofReceipt = value; RaisePropertyChanged("PlaceofReceipt"); }
        }

        public string TicketPeriod
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems.TicketPeriod.Name;
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItems.TicketPeriod.Name = value;
                RaisePropertyChanged("TicketPeriod");
            }
        }

        public int? TicketPeriodId
        {
            get => CopyofPOCOInstance.ManufacturersBussinessItems.TicketPeriodId;
            set => RaisePropertyChanged("TicketPeriodId");
        }

        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set
            {
                CopyofPOCOInstance.ManufacturersBussinessItems.Manufacturers.Name = value;
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
