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
        public SuppliersViewModelCollection()
        {

        }

        public SuppliersViewModelCollection(IEnumerable<SuppliersViewModel> source) : base(source)
        {

        }

        public override void Query()
        {

        }

    }

    public class SuppliersViewModel : BaseViewModel
    {
        #region 內部變數
        private SuppliersController controller;
        #endregion

        #region 建構式
        public SuppliersViewModel() : base()
        {
            controller = new SuppliersController();
        }
        #endregion

        #region 欄位屬性 Fields(DP)

        #region ManufacturersBussinessItemsId


        public Guid ManufacturersBussinessItemsId
        {
            get { return (Guid)GetValue(ManufacturersBussinessItemsIdProperty); }
            set { SetValue(ManufacturersBussinessItemsIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersBussinessItemsIdProperty =
            DependencyProperty.Register("ManufacturersBussinessItemsId", typeof(Guid), typeof(SuppliersViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region ProjectId

        public Guid ProjectId
        {
            get { return (Guid)GetValue(ProjectIdProperty); }
            set { SetValue(ProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectIdProperty =
            DependencyProperty.Register("ProjectId", typeof(Guid), typeof(SuppliersViewModel), new PropertyMetadata(Guid.Empty));

        #endregion

        #region PlaceofReceipt

        /// <summary>
        /// 送貨地址        
        /// </summary>
        public string PlaceofReceipt
        {
            get { return (string)GetValue(PlaceofReceiptProperty); }
            set { SetValue(PlaceofReceiptProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceofReceipt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceofReceiptProperty =
            DependencyProperty.Register("PlaceofReceipt", typeof(string), typeof(SuppliersViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region 關聯

        #region ManufacturersBussinessItems
        public ManufacturersBussinessItemsViewModel ManufacturersBussinessItems
        {
            get { return (ManufacturersBussinessItemsViewModel)GetValue(ManufacturersBussinessItemsProperty); }
            set { SetValue(ManufacturersBussinessItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersBussinessItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersBussinessItemsProperty =
            DependencyProperty.Register("ManufacturersBussinessItems", typeof(ManufacturersBussinessItemsViewModel), typeof(SuppliersViewModel), new PropertyMetadata(default(ManufacturersBussinessItemsViewModel)));

        #endregion

        #region Projects


        public ProjectsViewModel Projects
        {
            get { return (ProjectsViewModel)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Projects.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(ProjectsViewModel), typeof(SuppliersViewModel), new PropertyMetadata(default(ProjectsViewModel)));

        #endregion

        #endregion

        #endregion

        #region Model Command Functions      

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
                        BindingFromModel(data.ManufacturersBussinessItems, ManufacturersBussinessItems);
                    }

                    if (data.Projects != null)
                    {
                        BindingFromModel(data.Projects, Projects);
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
        #endregion
    }
}
