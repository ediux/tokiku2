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
        public override void SaveModel()
        {
            try
            {
                SuppliersController controller = new SuppliersController();
                if (Items.Any())
                {
                    foreach(var item in Items)
                    {
                        SupplierTranscationItem data = new SupplierTranscationItem();
                        CopyToModel(data, item);
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
    /// 專案列表-供應商項目檢視模型
    /// </summary>
    public class SuppliersViewModel : ManufacturersBussinessItemsViewModel
    {
        #region 內部變數
        private SuppliersController controller;
        #endregion

        public SuppliersViewModel() : base()
        {

        }

        /// <summary>
        /// 專案編號
        /// </summary>
        public Guid ProjectId
        {
            get { return (Guid)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid), typeof(SuppliersViewModel), new PropertyMetadata(Guid.Empty));

        public string PlaceofReceipt
        {
            get { return (string)GetValue(PlaceofReceiptProperty); }
            set { SetValue(PlaceofReceiptProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceofReceipt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceofReceiptProperty =
            DependencyProperty.Register("PlaceofReceipt", typeof(string), typeof(SuppliersViewModel), new PropertyMetadata(string.Empty));




        public string ManufacturersName
        {
            get { return (string)GetValue(ManufacturersNameProperty); }
            set { SetValue(ManufacturersNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersNameProperty =
            DependencyProperty.Register("Manufacturers", typeof(string), typeof(SuppliersViewModel), new PropertyMetadata(string.Empty));

        public string SiteContactPerson
        {
            get { return (string)GetValue(SiteContactPersonProperty); }
            set { SetValue(SiteContactPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SiteContactPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SiteContactPersonProperty =
            DependencyProperty.Register("SiteContactPerson", typeof(string), typeof(SuppliersViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));




        public string SiteContactPersonPhone
        {
            get { return (string)GetValue(SiteContactPersonPhoneProperty); }
            set { SetValue(SiteContactPersonPhoneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SiteContactPersonPhone.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SiteContactPersonPhoneProperty =
            DependencyProperty.Register("SiteContactPersonPhone", typeof(string), typeof(SuppliersViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


        #region Model Command Functions      
        public override void Initialized()
        {
            base.Initialized();
            controller = new SuppliersController();
        }

        public override void Query()
        {
            if (ProjectId != null && ProjectId != Guid.Empty)
            {
                var executed_result = controller.Query(p => p.ProjectId == ProjectId);

                if (!executed_result.HasError)
                {
                    SupplierTranscationItem data = executed_result.Result.Single();
                    BindingFromModel(data, this);

                    if (data.ManufacturersBussinessItems != null)
                    {
                        BindingFromModel(data.ManufacturersBussinessItems, this);
                    }

                  
                }

            }

        }

        public override void SaveModel()
        {
            SupplierTranscationItem data = new SupplierTranscationItem();

            CopyToModel(data, this);

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
            if (entity is ManufacturersBussinessItemsViewModel)
            {
                ManufacturersBussinessItemsViewModel model = (ManufacturersBussinessItemsViewModel)entity;
                BindingFromModel(model, this);
                ManufacturersName = Manufacturers.Name;
            }
            else
            {
                if (entity is ManufacturersBussinessItems)
                {
                    ManufacturersBussinessItems data = (ManufacturersBussinessItems)entity;
                    BindingFromModel(data, this);
                    ManufacturersName = data.Manufacturers.Name;

                }
                else
                {
                    if(entity is SupplierTranscationItem)
                    {
                        SupplierTranscationItem data = (SupplierTranscationItem)entity;
                        BindingFromModel(data, this);
                        BindingFromModel(data.ManufacturersBussinessItems, this);
                    }
                }
            } 
        }
        #endregion

    }
}
