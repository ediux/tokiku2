using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class SuppliersViewModelCollection : BaseViewModelCollection<SuppliersViewModel>
    {
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
            set { CopyofPOCOInstance.ProjectId = value;RaisePropertyChanged("ProjectId"); }
        }

    
        public string PlaceofReceipt
        {
            get { return CopyofPOCOInstance.PlaceofReceipt; }
            set { CopyofPOCOInstance.PlaceofReceipt = value;RaisePropertyChanged("PlaceofReceipt"); }
        }



        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set {
                //var model= ManufacturersViewModel.QuerySingle<ManufacturersViewModel,Manufacturers>("", "", value);
                RaisePropertyChanged("ManufacturersName"); }
        }

    

        #region Model Command Functions      
        public override void Initialized()
        {
            base.Initialized();
            //controller = new SuppliersController();
        }

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
