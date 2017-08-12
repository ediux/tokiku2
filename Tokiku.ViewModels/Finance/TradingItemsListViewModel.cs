using System;
using Tokiku.DataServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class TradingItemsListViewModel : DocumentBaseViewModel, ITradingItemsListViewModel
    {
        public TradingItemsListViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {
        }

        private ObservableCollection<ITradingItemsViewModel> _TradingItemsList;
        public ObservableCollection<ITradingItemsViewModel> TradingItemsList { get => _TradingItemsList; set { _TradingItemsList = value; RaisePropertyChanged("TradingItemsList"); } }

        private ICommand _RefreshFromTranscationCategoriesCommand;
        public ICommand RefreshFromTranscationCategoriesCommand { get => _RefreshFromTranscationCategoriesCommand; set { _RefreshFromTranscationCategoriesCommand = value;
                RaisePropertyChanged("RefreshFromTranscationCategoriesCommand");
            } }
    }
}