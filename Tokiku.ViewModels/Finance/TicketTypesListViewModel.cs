using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TicketTypesListViewModel : DocumentBaseViewModel, ITicketTypesListViewModel
    {
        public TicketTypesListViewModel(ICoreDataService CoreDataService):base(CoreDataService)
        {
            
        }

       public ObservableCollection<ITicketTypesViewModel> TicketTypesList { get; set; }
    }
}
