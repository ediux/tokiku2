using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using Tokiku.DataServices;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesListViewModel : DocumentBaseViewModel, IMaterialCategoriesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;

        public MaterialCategoriesListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            QueryCommand = new RelayCommand<IManufacturersBussinessItemsViewModel>(RunQuery);
        }

        [PreferredConstructor]
        public MaterialCategoriesListViewModel(MaterialCategories entity, 
            IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            QueryCommand = new RelayCommand<IManufacturersBussinessItemsViewModel>(RunQuery);
            
        }

        public override void Query(object Parameter)
        {
            
        }

        private ObservableCollection<IMaterialCategoriesViewModel> _MaterialCategories;

        public ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get => _MaterialCategories; set { _MaterialCategories = value; RaisePropertyChanged("MaterialCategories"); } }

        public virtual void RunQuery(IManufacturersBussinessItemsViewModel Parameter)
        {
            
        }
    }
}