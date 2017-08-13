using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
    public class TicketPeriodsListViewModel : DocumentBaseViewModel, ITicketPeriodsListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;
        public TicketPeriodsListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;            
        }

        public override void Query(object Parameter)
        {
            _TicketTypesList = new ObservableCollection<ITicketPeriodsViewModel>(
                ((ITicketPeriodDataService)_FinancialManagementDataService).GetAll().Select(s => new TicketPeriodsViewModel(s)));            
        }

        private ObservableCollection<ITicketPeriodsViewModel> _TicketTypesList;

        public ObservableCollection<ITicketPeriodsViewModel> TicketTypesList { get => _TicketTypesList; set { _TicketTypesList = value; RaisePropertyChanged("TicketTypesList"); } }

        private ICommand _RefreshFromPaymentTypesCommand;
        public ICommand RefreshFromPaymentTypesCommand { get => _RefreshFromPaymentTypesCommand; set { _RefreshFromPaymentTypesCommand = value; RaisePropertyChanged("RefreshFromPaymentTypesCommand"); } }
    }
}
