using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using Tokiku.DataServices;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;
using System.Linq;
using System.Collections.Generic;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesListViewModel : DocumentBaseViewModel, IMaterialCategoriesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;

        public MaterialCategoriesListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            //QueryCommand = new RelayCommand<ICollection<ManufacturersBussinessItems>>(RunQuery);
        }

        [PreferredConstructor]
        public MaterialCategoriesListViewModel(MaterialCategories entity,
            IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
            //QueryCommand = new RelayCommand<ICollection<ManufacturersBussinessItems>>(RunQuery);

        }

        public override void Query(object Parameter)
        {
            MaterialCategories = new ObservableCollection<IMaterialCategoriesViewModel>(
                ((IMaterialCategoriesDataService)_FinancialManagementDataService).GetAll()
                .Select(s => new MaterialCategoriesViewModel(s, _FinancialManagementDataService, _CoreDataService)));
        }

        private ObservableCollection<IMaterialCategoriesViewModel> _MaterialCategories;

        public ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get => _MaterialCategories; set { _MaterialCategories = value; RaisePropertyChanged("MaterialCategories"); } }

        public virtual void RunQuery(ICollection<ManufacturersBussinessItems> Parameter)
        {
            _MaterialCategories = new ObservableCollection<IMaterialCategoriesViewModel>(
               Parameter.Select(s => new MaterialCategoriesViewModel(s.MaterialCategories, _FinancialManagementDataService, _CoreDataService)));
        }
    }
}