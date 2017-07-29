using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredListViewModelCollection : BaseViewModelCollection<RequiredListViewModel, Required>
    {
        public RequiredListViewModelCollection()
        {
            HasError = false;
        }

        public RequiredListViewModelCollection(IEnumerable<RequiredListViewModel> source) : base(source)
        {

        }

        public static RequiredListViewModelCollection Query()
        {
            return Query<RequiredListViewModelCollection>("Required", "Query");         
        }

    }

    public class RequiredListViewModel : BaseViewModelWithPOCOClass<Required>
    {
        public RequiredListViewModel()
        {

        }

        public RequiredListViewModel(Required entity) : base(entity)
        {
            
        }

        public string FormNumber
        {
            get
            {                 
                return CopyofPOCOInstance.FormNumber;
            }
            set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance?.Manufacturers?.Code; }
            set
            {
                RaisePropertyChanged("ManufacturersCode");
            }
        }

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance?.Manufacturers?.Name; }
            set
            {


                RaisePropertyChanged("ManufacturersName");
            }
        }

        /// <summary>
        /// 輸入日期
        /// </summary>
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }     

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is RequiredListEntity)
        //        {
        //            RequiredListEntity data = (RequiredListEntity)entity;
        //            BindingFromModel(data, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //        throw;
        //    }
        //}

    }
}
