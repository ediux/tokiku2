using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessItemsViewModelColletion : BaseViewModelCollection<ManufacturersBussinessItemsViewModel>
    {

    }

    public class ManufacturersBussinessItemsViewModel : BaseViewModel
    {
        #region Id


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(Guid.NewGuid()));


        #endregion

        #region MaterialCategoriesId


        public Guid MaterialCategoriesId
        {
            get { return (Guid)GetValue(MaterialCategoriesIdProperty); }
            set { SetValue(MaterialCategoriesIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategoriesId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesIdProperty =
            DependencyProperty.Register("MaterialCategoriesId", typeof(Guid), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region MaterialCategories


        public MaterialCategoriesViewModel MaterialCategories
        {
            get { return (MaterialCategoriesViewModel)GetValue(MaterialCategoriesProperty); }
            set { SetValue(MaterialCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesProperty =
            DependencyProperty.Register("MaterialCategories", typeof(MaterialCategoriesViewModel), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(default(MaterialCategoriesViewModel)));


        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region PaymentTypeId


        public byte PaymentTypeId
        {
            get { return (byte)GetValue(PaymentTypeIdProperty); }
            set { SetValue(PaymentTypeIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypeId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeIdProperty =
            DependencyProperty.Register("PaymentTypeId", typeof(byte), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata((byte)0));


        #endregion

        #region PaymentTypes


        public PaymentTypeViewModel PaymentTypes
        {
            get { return (PaymentTypeViewModel)GetValue(PaymentTypesProperty); }
            set { SetValue(PaymentTypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypesProperty =
            DependencyProperty.Register("PaymentTypes", typeof(PaymentTypeViewModel), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(default(PaymentTypeViewModel)));


        #endregion

        #region TicketTypeId


        public byte TicketTypeId
        {
            get { return (byte)GetValue(TicketTypeIdProperty); }
            set { SetValue(TicketTypeIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketTypeId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketTypeIdProperty =
            DependencyProperty.Register("TicketTypeId", typeof(byte), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata((byte)0));


        #endregion

        #region TicketTypes


        public TicketTypesViewModel TicketTypes
        {
            get { return (TicketTypesViewModel)GetValue(TicketTypesProperty); }
            set { SetValue(TicketTypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketTypesProperty =
            DependencyProperty.Register("TicketTypes", typeof(TicketTypesViewModel), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(default(TicketTypesViewModel)));


        #endregion
        
        #region ManufacturersId

        public Guid ManufacturersId
        {
            get { return (Guid)GetValue(ManufacturersIdProperty); }
            set { SetValue(ManufacturersIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("ManufacturersId", typeof(Guid), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(Guid.Empty));

        #endregion

        #region Manufacturers


        public ManufacturersViewModel Manufacturers
        {
            get { return (ManufacturersViewModel)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ManufacturersViewModel), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(default(ManufacturersViewModel)));


        #endregion

        #region SupplierTranscationItem


        public SuppliersViewModel SupplierTranscationItem
        {
            get { return (SuppliersViewModel)GetValue(SupplierTranscationItemProperty); }
            set { SetValue(SupplierTranscationItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SupplierTranscationItemProperty =
            DependencyProperty.Register("MyProperty", typeof(SuppliersViewModel), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(default(SuppliersViewModel)));


        #endregion
    }
}
