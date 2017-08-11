﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 廠商主檔:營業項目紀錄檢視模型
    /// </summary>
    public class ManufacturersBussinessItemsViewModel : EntityBaseViewModel<ManufacturersBussinessItems>, IManufacturersBussinessItemsViewModel
    {
        [PreferredConstructor]
        public ManufacturersBussinessItemsViewModel() : base()
        {

        }

        public ManufacturersBussinessItemsViewModel(ManufacturersBussinessItems entity) : base(entity)
        {

        }

        #region MaterialCategoriesId


        public Guid? MaterialCategoriesId
        {
            get { return CopyofPOCOInstance.MaterialCategoriesId; }
            set { CopyofPOCOInstance.MaterialCategoriesId = value; RaisePropertyChanged("MaterialCategoriesId"); }
        }

        #endregion

        #region MaterialCategories
        /// <summary>
        /// 材料類別
        /// </summary>
        public string MaterialCategories
        {
            get { return CopyofPOCOInstance?.MaterialCategories?.Name; }
            set { RaisePropertyChanged("MaterialCategories"); }
        }



        #endregion

        #region Name

        /// <summary>
        /// 交易品項
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }



        #endregion

        #region PaymentTypeId


        public byte PaymentTypeId
        {
            get { return CopyofPOCOInstance.PaymentTypeId.HasValue ? CopyofPOCOInstance.PaymentTypeId.Value : (byte)0; }
            set { CopyofPOCOInstance.PaymentTypeId = value; RaisePropertyChanged("PaymentTypeId"); }
        }

        #endregion

        #region PaymentTypeName 


        public string PaymentTypeName
        {
            get { return CopyofPOCOInstance?.PaymentTypes?.PaymentTypeName; }
            set { RaisePropertyChanged("PaymentTypeName"); }
        }

        #endregion

        #region TicketPeriodId


        public int TicketPeriodId
        {
            get { return CopyofPOCOInstance.TicketPeriodId.HasValue ? CopyofPOCOInstance.TicketPeriodId.Value : 0; }
            set
            {
                //CopyofPOCOInstance.TicketPeriodId = value;
                //RaisePropertyChanged("TicketPeriodId");
                //var result = ExecuteAction<TicketPeriod>(
                //    "TicketPeriodsManagement", "QuerySingle", value);
                //if (result != null)
                //{
                //    CopyofPOCOInstance.TicketPeriod = result;
                //    RaisePropertyChanged("TicketPeriod");
                //}
            }
        }




        #endregion

        #region TicketPeriod 

        /// <summary>
        /// 票期
        /// </summary>
        public string TicketPeriod
        {
            get { return CopyofPOCOInstance?.TicketPeriod?.Name; }
            set { RaisePropertyChanged("TicketPeriod"); }
        }
        #endregion

        #region ManufacturersId

        public Guid ManufacturersId
        {
            get { return CopyofPOCOInstance.ManufacturersId; }
            set { CopyofPOCOInstance.ManufacturersId = value; RaisePropertyChanged("ManufacturersId"); }
        }



        #endregion

        #region TranscationCategoriesId

        /// <summary>
        /// 交易類別ID
        /// </summary>
        public int? TranscationCategoriesId
        {
            get { return CopyofPOCOInstance.TranscationCategoriesId; }
            set {
                CopyofPOCOInstance.TranscationCategoriesId = value;
                RaisePropertyChanged("TranscationCategoriesId");
                //var result = ExecuteAction<TranscationCategories>(
                //   "ManufacturersManage", "QuerySingleTranscationCategory", value);
                //if (result != null)
                //{
                //    CopyofPOCOInstance.TranscationCategories = result;
                //    CopyofPOCOInstance.TranscationCategoriesId = result.Id;
                //    RaisePropertyChanged("TranscationCategories");
                //}
            }
        }




        #endregion

        #region TranscationCategories 

        /// <summary>
        /// 交易類別
        /// </summary>
        public string TranscationCategories
        {
            get { return CopyofPOCOInstance?.TranscationCategories?.Name; }
            set { RaisePropertyChanged("TranscationCategories"); }
        }


        #endregion



        public Manufacturers Manufacturers
        {
            get { return CopyofPOCOInstance.Manufacturers; }
            set { Manufacturers = value; RaisePropertyChanged("Manufacturers"); }
        }




        //public override void SetModel(dynamic entity)
        //{
        //    if (!Dispatcher.CheckAccess())
        //    {
        //        Dispatcher.Invoke(DispatcherPriority.Background,
        //            new Action<dynamic>(SetModel), entity);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            if (entity is View_BussinessItemsList)
        //            {
        //                View_BussinessItemsList data = (View_BussinessItemsList)entity;
        //                if (data != null)
        //                {
        //                    BindingFromModel(data, this);
        //                }

        //            }
        //            else
        //            {
        //                if (entity is ManufacturersBussinessItems)
        //                {
        //                    ManufacturersBussinessItems data = (ManufacturersBussinessItems)entity;
        //                    BindingFromModel(data, this);
        //                    this.Manufacturers = data.Manufacturers;

        //                    if (data.Manufacturers != null)
        //                    {
        //                        MaterialCategories = data.MaterialCategories.Name;
        //                    }
        //                    if (data.PaymentTypes != null)
        //                    {
        //                        PaymentTypeName = data.PaymentTypes.PaymentTypeName;
        //                    }
        //                    if (data.TranscationCategories != null)
        //                    {
        //                        TranscationCategories = data.TranscationCategories.Name;
        //                    }
        //                    if (data.TicketPeriod != null)
        //                    {
        //                        TicketPeriod = data.TicketPeriod.Name;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            setErrortoModel(this, ex);
        //        }
        //    }
        //}
    }
}