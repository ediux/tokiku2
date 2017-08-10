using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tokiku.DataServices;
using GalaSoft.MvvmLight.Messaging;

namespace Tokiku.ViewModels
{
    public class VendorListViewModel : BaseViewModel, IVendorListViewModel
    {
        private IManufacturersDataService _ManufacturersDataService;

        public VendorListViewModel(IManufacturersDataService ManufacturersDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            _QueryCommand = new RelayCommand(Query);
            _QueryCommand.Execute(null);

            Messenger.Default.Register<string>(this, "SearchBar_Query_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(_ManufacturersDataService.SearchByText(x)
                .Select(s => new VendorListItemViewModel(s)));
            });

            Messenger.Default.Register<string>(this, "SearchBar_Refresh_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(_ManufacturersDataService.SearchByText(x)
                .Select(s => new VendorListItemViewModel(s)));
            });

            Messenger.Default.Register<string>(this, "SearchBar_Reset_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(_ManufacturersDataService.QueryAll()
                .Select(s => new VendorListItemViewModel(s)));
            });
        }

        private ObservableCollection<IVendorListItemViewModel> _VendorList;
        public ObservableCollection<IVendorListItemViewModel> VendorList { get => _VendorList; set { _VendorList = value; RaisePropertyChanged("VendorList"); } }

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set { _QueryCommand = value; RaisePropertyChanged("QueryCommand"); } }

        protected void Query()
        {
            _VendorList = new ObservableCollection<IVendorListItemViewModel>(
               _ManufacturersDataService.QueryAll().Select(s => new VendorListItemViewModel(s)));
        }
    }
}
