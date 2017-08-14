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
    public class VendorListViewModel : DocumentBaseViewModel, IVendorListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturersDataService;

        public VendorListViewModel(IManufacturingExecutionDataService ManufacturersDataService,
            ICoreDataService CoreDataService):base(CoreDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            QueryCommand = new RelayCommand(Query);
            

            Messenger.Default.Register<string>(this, "SearchBar_Query_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(((IManufacturersDataService)_ManufacturersDataService).SearchByText(x)
                .Select(s => new VendorListItemViewModel(s)));
            });

            Messenger.Default.Register<string>(this, "SearchBar_Refresh_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(((IManufacturersDataService)_ManufacturersDataService).SearchByText(x)
                .Select(s => new VendorListItemViewModel(s)));
            });

            Messenger.Default.Register<string>(this, "SearchBar_Reset_VendorList", (x) =>
            {
                VendorList = new ObservableCollection<IVendorListItemViewModel>(((IManufacturersDataService)_ManufacturersDataService).QueryAll()
                .Select(s => new VendorListItemViewModel(s)));
            });
        }

        private ObservableCollection<IVendorListItemViewModel> _VendorList;
        public ObservableCollection<IVendorListItemViewModel> VendorList { get {
                if (_VendorList == null)
                {
                    QueryCommand.Execute(null);
                }

                return _VendorList;

            } set { _VendorList = value; RaisePropertyChanged("VendorList"); } }

        protected void Query()
        {
            _VendorList = new ObservableCollection<IVendorListItemViewModel>(
               _ManufacturersDataService.QueryAll().Select(s => new VendorListItemViewModel(s)));
        }
    }
}
