using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class PaymentTypesListViewModel : DocumentBaseViewModel, IPaymentTypesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;

        public PaymentTypesListViewModel(IFinancialManagementDataService FinancialManagementDataService, ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
        }

        private ObservableCollection<IPaymentTypesViewModel> _PaymentTypesList = new ObservableCollection<IPaymentTypesViewModel>();

        public ObservableCollection<IPaymentTypesViewModel> PaymentTypesList
        {
            get => _PaymentTypesList; set
            {
                _PaymentTypesList = value;
                RaisePropertyChanged("PaymentTypesList");
            }
        }

        private ICommand _RefreshFromPaymentTypesCommand;
        public ICommand RefreshFromPaymentTypesCommand { get => _RefreshFromPaymentTypesCommand; set { _RefreshFromPaymentTypesCommand = value; RaisePropertyChanged("RefreshFromPaymentTypesCommand"); } }
    }
}