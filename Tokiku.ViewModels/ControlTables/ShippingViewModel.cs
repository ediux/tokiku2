﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialViewModelCollection : BaseViewModelCollection<ShippingMaterialViewModel>
    {
        public ShippingMaterialViewModelCollection()
        {
        }

        public ShippingMaterialViewModelCollection(IEnumerable<ShippingMaterialViewModel> source) : base(source)
        {
        }

        public static ShippingMaterialViewModelCollection Query()
        {
            return Query<ShippingMaterialViewModelCollection, PickList>("ShippingMaterial", "QueryAll");
        }

    }

    public class ShippingMaterialViewModel : BaseViewModelWithPOCOClass<PickList>
    {
        public ShippingMaterialViewModel(PickList entity) : base(entity)
        {
        }

        // ID
        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }
        // 領料單單號
        public string PickListNumber
        {
            get { return CopyofPOCOInstance.PickListNumber; }
            set { CopyofPOCOInstance.PickListNumber = value; RaisePropertyChanged("PickListNumber"); }
        }
        // 來料廠商代碼
        public string IncomingManufacturersCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("IncomingManufacturersCode"); }
        }
        // 來料廠商
        public string IncomingManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("IncomingManufacturersName"); }
        }
        // 來料單號
        public string IncomingNumber
        {
            get { return CopyofPOCOInstance.IncomingNumber; }
            set { CopyofPOCOInstance.IncomingNumber = value; RaisePropertyChanged("IncomingNumber"); }
        }
         
        /// <summary>
        /// 輸入人員
        /// </summary>
        public new string CreateUser
        {
            get { return CopyofPOCOInstance.CreateUsers.UserName; }
            set { CopyofPOCOInstance.CreateUsers.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        
        /// <summary>
        /// 輸入日期
        /// </summary>
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }
        // 製單人員
        public string MakingUserName
        {
            get { return CopyofPOCOInstance.MakingUsers.UserName; }
            set { CopyofPOCOInstance.MakingUsers.UserName = value; RaisePropertyChanged("MakingUserName"); }
        }
        // 製單日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.MakingTime; }
            set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }
        // 備註
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    }
}