using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    public interface ITicketPeriodsManagementViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<ITicketPeriodsViewModel> TranscationCategories { get; set; }
    }
}