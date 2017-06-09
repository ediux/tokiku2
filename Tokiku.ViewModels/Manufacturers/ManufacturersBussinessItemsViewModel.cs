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
    public class ManufacturersBussinessItemsViewModelColletion : BaseViewModelCollection<ManufacturersBussinessItemsViewModel>
    {
        public override void Query()
        {
            //if (ManufacturersId != Guid.Empty)
            //{
            //    ManufacturersManageController controller = new ManufacturersManageController();
            //    var queryresult = controller.Query(p => p..Where(s => s.Id == ManufacturersId).Any());

            //    if (!queryresult.HasError)
            //    {
            //        var objectdataset = queryresult.Result;
            //        if (objectdataset.Any())
            //        {
            //            ClearItems();
            //            foreach (var row in objectdataset)
            //            {
            //                Add(BindingFromModel(row));
            //            }
            //        }
            //    }
            //}
        }
        public void Query(Guid ManufacturersId)
        {

        }
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
        /// <summary>
        /// 材料類別
        /// </summary>
        public string MaterialCategories
        {
            get { return (string)GetValue(MaterialCategoriesProperty); }
            set { SetValue(MaterialCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesProperty =
            DependencyProperty.Register("MaterialCategories", typeof(string), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(string.Empty));

        #endregion

        #region Name

        /// <summary>
        /// 交易品項
        /// </summary>
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

        #region PaymentTypeName 


        public string PaymentTypeName
        {
            get { return (string)GetValue(PaymentTypeNameProperty); }
            set { SetValue(PaymentTypeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeNameProperty =
            DependencyProperty.Register("PaymentTypeName ", typeof(string), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region TicketPeriodId


        public int TicketPeriodId
        {
            get { return (int)GetValue(TicketPeriodIdProperty); }
            set { SetValue(TicketPeriodIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketTypeId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPeriodIdProperty =
            DependencyProperty.Register("TicketPeriodId", typeof(int), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(1));


        #endregion

        #region TicketPeriod 

        /// <summary>
        /// 票期
        /// </summary>
        public string TicketPeriod
        {
            get { return (string)GetValue(TicketPeriodProperty); }
            set { SetValue(TicketPeriodProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPeriodProperty =
            DependencyProperty.Register("TicketPeriod", typeof(string), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(string.Empty));


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



        #region TranscationCategoriesId

        /// <summary>
        /// 交易類別ID
        /// </summary>
        public int TranscationCategoriesId
        {
            get { return (int)GetValue(TranscationCategoriesIdProperty); }
            set { SetValue(TranscationCategoriesIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranscationCategoriesIdProperty =
            DependencyProperty.Register("TranscationCategoriesId", typeof(int), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(0));


        #endregion

        #region TranscationCategories 

        /// <summary>
        /// 交易類別
        /// </summary>
        public string TranscationCategories
        {
            get { return (string)GetValue(TranscationCategoriesProperty); }
            set { SetValue(TranscationCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TranscationCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranscationCategoriesProperty =
            DependencyProperty.Register("TranscationCategories", typeof(string), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(string.Empty));


        #endregion
      
        public override void SetModel(dynamic entity)
        {
            ManufacturersBussinessItems data = (ManufacturersBussinessItems)entity;
            BindingFromModel(data, this);
            if (data.MaterialCategories != null)
            {
                MaterialCategories = data.MaterialCategories.Name;
            }
            if (data.PaymentTypes != null)
            {
                PaymentTypeName = data.PaymentTypes.PaymentTypeName;
            }
            if (data.TranscationCategories != null)
            {
                TranscationCategories = data.TranscationCategories.Name;
            }
            if (data.TicketPeriod != null)
            {
                TicketPeriod = data.TicketPeriod.Name;
            }
        }
    }
}
