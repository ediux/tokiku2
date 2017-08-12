using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface ITradingItemsListViewModel : IDocumentBaseViewModel
    {
        ICommand RefreshFromTranscationCategoriesCommand { get; set; }
        ObservableCollection<ITradingItemsViewModel> TradingItemsList { get; set; }
    }
}