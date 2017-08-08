using GalaSoft.MvvmLight.CommandWpf;
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
    public class VendorListViewModel : ViewModelBase2, IVendorListViewModel
    {
        private IManufacturersDataService _ManufacturersDataService;

        public VendorListViewModel(IManufacturersDataService ManufacturersDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            _QueryCommand = new RelayCommand(Query);
            _QueryCommand.Execute(null);
        }

        private ObservableCollection<IVendorListItemViewModel> _VendorList;
        public ObservableCollection<IVendorListItemViewModel> VendorList { get => _VendorList; set { _VendorList = value; RaisePropertyChanged("VendorList"); } }

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set  { _QueryCommand = value; RaisePropertyChanged("QueryCommand"); } }

        protected void Query()
        {
            _VendorList = new ObservableCollection<IVendorListItemViewModel>(
               _ManufacturersDataService.QueryAll().Select(s => new VendorListItemViewModel(s)));
        }
    }
}
