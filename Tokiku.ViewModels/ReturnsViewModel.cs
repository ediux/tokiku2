﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ReturnsViewModelCollection : BaseViewModelCollection<ReturnsViewModel>
    {
        public ReturnsViewModelCollection()
        {
            HasError = false;
        }

        public ReturnsViewModelCollection(IEnumerable<ReturnsViewModel> source) : base(source)
        {

        }

        public new static ReturnsViewModelCollection Query()
        {
            ReturnsController ctrl = new ReturnsController();
            ExecuteResultEntity<ICollection<Returns>> ere = ctrl.QuerAll();

            if (!ere.HasError)
            {
                return new ReturnsViewModelCollection(ere.Result.Select(s => new ReturnsViewModel(s)).ToList());
            }
            return new ReturnsViewModelCollection();
        }

    }

    public class ReturnsViewModel : BaseViewModelWithPOCOClass<Returns>
    {
        public ReturnsViewModel(Returns entity) : base(entity)
        {

        }

        // 退料單號
        public string ReturnNumber
        {
            get { return CopyofPOCOInstance.ReturnNumber; }
            set { CopyofPOCOInstance.ReturnNumber = value; RaisePropertyChanged("ReturnNumber"); }
        }
        // 來料廠商代碼
        public string IncomingManufacturerCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("IncomingManufacturerCode"); }
        }
        // 來料廠商
        public string IncomingManufacturerName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("IncomingManufacturerName"); }
        }
        // 來料單號
        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }
        // 輸入人員
        public string CreateUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        // 輸入日期
        public DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }
        // 製單人員
        public string MakingUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("MakingUser"); }
        }
        // 製單日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("MakingTime"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    }
}
