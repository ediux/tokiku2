using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    public interface ITicketPeriodsListViewModel : IDocumentBaseViewModel
    {
        ICommand RefreshFromPaymentTypesCommand { get; set; }
        ObservableCollection<ITicketPeriodsViewModel> TicketTypesList { get; set; }
    }
}