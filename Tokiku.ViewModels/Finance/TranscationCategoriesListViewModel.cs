using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TranscationCategoriesListViewModel : DocumentBaseViewModel, ITranscationCategoriesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;

        public TranscationCategoriesListViewModel(IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;

            _RefreshFromMaterialCategoriesCommand = new RelayCommand<IList>(RunRefresh);
        }

        public override void Query(object Parameter)
        {
            _TranscationCategories = new ObservableCollection<ITranscationCategoriesViewModel>(((ITranscationCategoriesDataService)_FinancialManagementDataService).GetAll()
                .Select(s => new TranscationCategoriesViewModel(s)));
        }

        protected virtual void RunRefresh(IList Parameter)
        {
            if (Parameter is IList<IMaterialCategoriesViewModel>)
            {
                IList<IMaterialCategoriesViewModel> _source = (IList<IMaterialCategoriesViewModel>)Parameter;

                IMaterialCategoriesViewModel model = _source.First();

                _TranscationCategories = new ObservableCollection<ITranscationCategoriesViewModel>(model.Entity.ManufacturersBussinessItems
                    .Select(s => new TranscationCategoriesViewModel(s.TranscationCategories)));
            }
        }

        private ObservableCollection<ITranscationCategoriesViewModel> _TranscationCategories;
        public ObservableCollection<ITranscationCategoriesViewModel> TranscationCategories
        {
            get => _TranscationCategories; set
            {
                _TranscationCategories = value;
                RaisePropertyChanged("TranscationCategories");
            }
        }

        private ICommand _RefreshFromMaterialCategoriesCommand;
        public ICommand RefreshFromMaterialCategoriesCommand { get => _RefreshFromMaterialCategoriesCommand; set { _RefreshFromMaterialCategoriesCommand = value; RaisePropertyChanged("RefreshFromMaterialCategoriesCommand"); } }
    }
}
