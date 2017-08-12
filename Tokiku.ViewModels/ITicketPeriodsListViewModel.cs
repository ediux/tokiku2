using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    public interface ITicketPeriodsListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<ITicketPeriodsViewModel> TicketTypesList { get; set; }
    }
}