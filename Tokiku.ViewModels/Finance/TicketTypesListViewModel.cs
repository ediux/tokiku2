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
        private IFinancialManagementDataService _FinancialManagementDataService;
        public TicketTypesListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
        }
        public override void Query(object Parameter)
        {
            _TicketTypesList = new ObservableCollection<ITicketTypesViewModel>(
                );
        }

        private ObservableCollection<ITicketTypesViewModel> _TicketTypesList;
        public ObservableCollection<ITicketTypesViewModel> TicketTypesList { get => _TicketTypesList; set { _TicketTypesList = value; RaisePropertyChanged("TicketTypesList"); } }
    }
}
