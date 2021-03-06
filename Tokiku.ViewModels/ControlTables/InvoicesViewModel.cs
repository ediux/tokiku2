﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InvoicesViewModelCollection : BaseViewModelCollection<InvoicesViewModel>
    {
        public InvoicesViewModelCollection()
        {
            _ControllerName = "Invoices";
        }

        public InvoicesViewModelCollection(IEnumerable<InvoicesViewModel> source) : base(source)
        {
            _ControllerName = "Invoices";
        }

        public static InvoicesViewModelCollection Query()
        {
            return Query<InvoicesViewModelCollection, Invoices>("Invoices", "QueryAll");
        }

    }

    public class InvoicesViewModel : BaseViewModelWithPOCOClass<Invoices>
    {
        public InvoicesViewModel()
        {

        }

        public InvoicesViewModel(Invoices entity) : base(entity)
        {
            _SaveModelController = "Invoices";
        }

        // ID
        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }
        // 請款單單號
        public string InvoiceNumber
        {
            get { return CopyofPOCOInstance.InvoiceNumber; }
            set { CopyofPOCOInstance.InvoiceNumber = value; RaisePropertyChanged("InvoiceNumber"); }
        }
        // 請款人
        public string InvoiceUserName
        {
            get { return CopyofPOCOInstance.InvoiceUser?.UserName; }
            set { CopyofPOCOInstance.InvoiceUser.UserName = value; RaisePropertyChanged("InvoiceUserName"); }
        }
        // 請款日期
        public DateTime InvoiceTime
        {
            get { return CopyofPOCOInstance.InvoiceTime; }
            set { CopyofPOCOInstance.InvoiceTime = value; RaisePropertyChanged("InvoiceTime"); }
        }
        // 請款廠商代碼
        public string InvoiceManufacturersCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("InvoiceManufacturersCode"); }
        }
        // 請款廠商
        public string InvoiceManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("InvoiceManufacturersName"); }
        }
        // 廠商請款單號
        public string ManufacturerInvoiceNumber
        {
            get { return CopyofPOCOInstance.ManufacturerInvoiceNumber; }
            set { CopyofPOCOInstance.ManufacturerInvoiceNumber = value; RaisePropertyChanged("ManufacturerInvoiceNumber"); }
        }
        // 預計付款日期
        public DateTime EstimatedPaymentDate
        {
            get { return CopyofPOCOInstance.EstimatedPaymentDate; }
            set { CopyofPOCOInstance.EstimatedPaymentDate = value; RaisePropertyChanged("EstimatedPaymentDate"); }
        }
        // 輸入人員
        public new string CreateUser
        {
            get { return CopyofPOCOInstance.CreateUser?.UserName; }
            set { CopyofPOCOInstance.CreateUser.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        // 輸入日期
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    }
}
