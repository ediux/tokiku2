using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredViewModelCollection : BaseViewModelCollection<RequiredViewModel>
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
        public new static RequiredViewModelCollection Query()
        {
            RequiredController ctrl = new RequiredController();
            ExecuteResultEntity<ICollection<Required>> ere = ctrl.QuerAll();

            if (!ere.HasError)
            {
                return new RequiredViewModelCollection(ere.Result.Select(s => new RequiredViewModel(s)).ToList());
            }
            return new RequiredViewModelCollection();
        }

    }

    public class RequiredViewModel : BaseViewModelWithPOCOClass<Required>
    {
        public RequiredViewModel(Required entity) : base(entity)
        {

        }
        
        // 專案代碼
        public string ProjectCode
        {
            get { return CopyofPOCOInstance.Projects.Code; }
            set { CopyofPOCOInstance.Projects.Code = value; RaisePropertyChanged("ProjectCode"); }
        }
        // 專案名稱
        public string ProjectName
        {
            get { return CopyofPOCOInstance.Projects.Name; }
            set { CopyofPOCOInstance.Projects.Name = value; RaisePropertyChanged("ProjectName"); }
        }
        // 合約編號
        public string ProjectContractNumber
        {
            get { return CopyofPOCOInstance.ProjectContract.ContractNumber; }
            set { CopyofPOCOInstance.ProjectContract.ContractNumber = value; RaisePropertyChanged("ProjectContractNumber"); }
        }
        // 合約名稱
        public string ProjectContractName
        {
            get { return CopyofPOCOInstance.ProjectContract.Name; }
            set { CopyofPOCOInstance.ProjectContract.Name = value; RaisePropertyChanged("ProjectContractName"); }
        }
        // 需求單單號
        public string FormNumber
        {
            get { return CopyofPOCOInstance.FormNumber; }
            set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        // 廠商編號
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("ManufacturersCode"); }
        }
        // 廠商名稱
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }
        // 物料名稱
        public string MaterialCategoriesName
        {
            get { return CopyofPOCOInstance.MaterialCategories.Name; }
            set { CopyofPOCOInstance.MaterialCategories.Name = value; RaisePropertyChanged("MaterialCategoriesName"); }
        }
        // 製單日期
        public DateTime MakingTime
        {
            get { return CopyofPOCOInstance.MakingTime; }
            set { CopyofPOCOInstance.MakingTime = value; RaisePropertyChanged("MakingTime"); }
        }
        // 製單人
        public string MakingUserName
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("MakingUserName"); }
        }
        // 需求單使用位置
        public string RequiredPostion
        {
            get { return CopyofPOCOInstance.RequiredPostion; }
            set { CopyofPOCOInstance.RequiredPostion = value; RaisePropertyChanged("RequiredPostion"); }
        }
        // 輸入日期
        public DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }
        // 輸入人員
        public string CreateUser
        {
            get { return CopyofPOCOInstance.Users.UserName; }
            set { CopyofPOCOInstance.Users.UserName = value; RaisePropertyChanged("CreateUser"); }
        }
        // 
        public System.Collections.ArrayList RequiredDetailsList
        {
            get { return (System.Collections.ArrayList)CopyofPOCOInstance.RequiredDetails; }
            //set { CopyofPOCOInstance.RequiredDetails = value; RaisePropertyChanged("RequiredDetails"); }
        }

    }
}
