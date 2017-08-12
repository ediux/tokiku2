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
        public TicketPeriodsListViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {

        }

        public ObservableCollection<ITicketPeriodsViewModel> TicketTypesList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private ICommand _RefreshFromPaymentTypesCommand;
        public ICommand RefreshFromPaymentTypesCommand { get => _RefreshFromPaymentTypesCommand; set { _RefreshFromPaymentTypesCommand = value; RaisePropertyChanged("RefreshFromPaymentTypesCommand"); } }
    }
}
