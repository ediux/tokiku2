using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesViewModel : EntityBaseViewModel<MaterialCategories>, IMaterialCategoriesViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;
        private ICoreDataService _CoreDataService;
        public MaterialCategoriesViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            _CoreDataService = CoreDataService;
        }

        [PreferredConstructor]
        public MaterialCategoriesViewModel(MaterialCategories entity, IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService)
            : base(entity)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            _CoreDataService = CoreDataService;
        }

        #region Name
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

        #endregion


        public Guid Id { get => CopyofPOCOInstance.Id; set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); } }

        public DateTime CreateTime { get => CopyofPOCOInstance.CreateTime; set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); } }
        public Guid CreateUserId { get => CopyofPOCOInstance.CreateUserId; set { CopyofPOCOInstance.CreateUserId = value; RaisePropertyChanged("CreateUserId"); } }
        public IUserViewModel CreateUser { get => new UserViewModel((Users)((IUserDataService)_CoreDataService).GetSingle(s => s.UserId == CopyofPOCOInstance.CreateUserId)); set { CopyofPOCOInstance.CreateUserId = value.Entity.UserId; RaisePropertyChanged(""); } }

        public override void Query(MaterialCategories Parameter)
        {
            base.Query(Parameter);
        }

    }
}
