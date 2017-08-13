using System;
using Tokiku.DataServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;

namespace Tokiku.ViewModels
{
    public class TradingItemsListViewModel : DocumentBaseViewModel, ITradingItemsListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;

        public TradingItemsListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;

            _RefreshFromTranscationCategoriesCommand = new RelayCommand<ITranscationCategoriesViewModel>(RunQuery);
        }

        public override void Query(object Parameter)
        {
            TradingItemsList = new ObservableCollection<ITradingItemsViewModel>(
                ((ITradingItemsDataService)_FinancialManagementDataService).GetAll().Select(s => new TradingItemsViewModel(s)));

        }

        protected virtual void RunQuery(ITranscationCategoriesViewModel Parameter)
        {
            Query(null);
        }

        private ObservableCollection<ITradingItemsViewModel> _TradingItemsList;
        public ObservableCollection<ITradingItemsViewModel> TradingItemsList { get => _TradingItemsList; set { _TradingItemsList = value; RaisePropertyChanged("TradingItemsList"); } }

        private ICommand _RefreshFromTranscationCategoriesCommand;
        public ICommand RefreshFromTranscationCategoriesCommand
        {
            get => _RefreshFromTranscationCategoriesCommand; set
            {
                _RefreshFromTranscationCategoriesCommand = value;
                RaisePropertyChanged("RefreshFromTranscationCategoriesCommand");
            }
        }
    }
}