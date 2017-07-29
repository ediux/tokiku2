using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class RequiredViewModelCollection : BaseViewModelCollection<RequiredViewModel, Required>
    {
        public RequiredViewModelCollection()
        {
            HasError = false;
        }

        public RequiredViewModelCollection(IEnumerable<RequiredViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    RequiredController ctrl = new RequiredController();
        //    ExecuteResultEntity<ICollection<RequiredEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        RequiredViewModel vm = new RequiredViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}
        public static RequiredViewModelCollection Query()
        {
            //RequiredController ctrl = new RequiredController();
            //ExecuteResultEntity<ICollection<Required>> ere = ctrl.QuerAll();

            //if (!ere.HasError)
            //{
            //    return new RequiredViewModelCollection(ere.Result.Select(s => new RequiredViewModel(s)).ToList());
            //}
            return new RequiredViewModelCollection();
        }

    }

    public class RequiredViewModel : BaseViewModelWithPOCOClass<Required>
    {
        public RequiredViewModel()
        {

        }

        public RequiredViewModel(Required entity) : base(entity)
        {

        }

        //// 專案代碼
        //public string ProjectCode
        //{
        //    get { return CopyofPOCOInstance.Projects.Code; }
        //    set { CopyofPOCOInstance.Projects.Code = value; RaisePropertyChanged("ProjectCode"); }
        //}

        /// <summary>
        /// 需求單單號
        /// </summary>
        public string FormNumber
        {
            get
            {
                if (string.IsNullOrEmpty(CopyofPOCOInstance.FormNumber))
                {
                    CopyofPOCOInstance = ExecuteAction<Required>("Required", "CreateNew", CopyofPOCOInstance?.Projects?.ShortName);
                    if (!HasError)
                        return CopyofPOCOInstance.FormNumber;
                    else
                    {
                        CopyofPOCOInstance.FormNumber = "#ERROR";
                        return CopyofPOCOInstance.FormNumber;
                    }
                }

                return CopyofPOCOInstance.FormNumber;
            }
            set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }

        public ManufacturersViewModel SelectedManufacturers
        {
            get => new ManufacturersViewModel(CopyofPOCOInstance.Manufacturers);
            set
            {
                CopyofPOCOInstance.Manufacturers = value.Entity;

               
                
                RaisePropertyChanged("SelectedManufacturers");
                RaisePropertyChanged("ManufacturersCode");
                RaisePropertyChanged("ManufacturersName");
            }
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
        /// 製單日期
        /// </summary>
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.MakingTime; }
            set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }

        /// <summary>
        /// 製單人
        /// </summary>
        public string MakingUserName
        {
            get { return CopyofPOCOInstance?.MakingUser?.UserName; }
            set { CopyofPOCOInstance.MakingUser.UserName = value; RaisePropertyChanged("MakingUserName"); }
        }


        /// <summary>
        /// 需求單使用位置
        /// </summary>
        public string RequiredPostion
        {
            get { return CopyofPOCOInstance.RequiredPostion; }
            set { CopyofPOCOInstance.RequiredPostion = value; RaisePropertyChanged("RequiredPostion"); }
        }

        /// <summary>
        /// 輸入日期
        /// </summary>
        public new DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }

        // 
        /// <summary>
        /// 輸入人員
        /// </summary>
        public new string CreateUser
        {
            get { return CopyofPOCOInstance.MakingUser?.UserName; }
            set { CopyofPOCOInstance.MakingUser.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        // 
        //public System.Collections.ArrayList RequiredDetailsList
        //{
        //    get { return (System.Collections.ArrayList)CopyofPOCOInstance.RequiredDetails; }
        //    //set { CopyofPOCOInstance.RequiredDetails = value; RaisePropertyChanged("RequiredDetails"); }
        //}

        public static RequiredViewModel CreateNew(string ProjectShortName)
        {
            try
            {
                return QuerySingle<RequiredViewModel, Required>(
                    "Required", "CreateNew", ProjectShortName);
            }
            catch (Exception ex)
            {
                RequiredViewModel view = new RequiredViewModel();
                view.setErrortoModel(ex);
                return view;
            }
        }
    }
}
