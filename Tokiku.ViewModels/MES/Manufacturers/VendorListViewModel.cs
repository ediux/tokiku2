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
using GalaSoft.MvvmLight.Ioc;
using System.Reflection;

namespace Tokiku.ViewModels
{
    public class VendorListViewModel : DocumentBaseViewModel, IVendorListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturersDataService;

        public VendorListViewModel(IManufacturingExecutionDataService ManufacturersDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _ManufacturersDataService = ManufacturersDataService;
            QueryCommand = new RelayCommand(Query);
            SelectedAndOpenCommand = new RelayCommand<object>(RunSelectedAndOpenCommand);

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
        public ObservableCollection<IVendorListItemViewModel> VendorList
        {
            get
            {
                if (_VendorList == null)
                {
                    QueryCommand.Execute(null);
                }

                return _VendorList;

            }
            set { _VendorList = value; RaisePropertyChanged("VendorList"); }
        }

        private ICommand _SelectedAndOpenCommand;
        public ICommand SelectedAndOpenCommand { get => _SelectedAndOpenCommand; set { _SelectedAndOpenCommand = value; RaisePropertyChanged("SelectedAndOpenCommand"); } }

        protected void Query()
        {
            _VendorList = new ObservableCollection<IVendorListItemViewModel>(
               _ManufacturersDataService.QueryAll().Select(s => new VendorListItemViewModel(s)));
        }

        protected void RunSelectedAndOpenCommand(object parameter)
        {
            if(parameter is IVendorListItemViewModel)
            {
                ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();
                IVendorListItemViewModel selecteditem = (IVendorListItemViewModel)parameter;

                if (selecteditem != null)
                {
                    tab.ViewType = Assembly.Load("TokikuNew").GetType("TokikuNew.Views.ManufacturersManageView");
                    tab.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(tab.ViewType);
                    tab.Header = string.Format("廠商:{0}-{1}", selecteditem.Code, selecteditem.ShortName);
                    tab.SelectedObject = selecteditem;
                    tab.DataModelType = typeof(IManufacturersViewModel);
                    tab.TabControlName = "Workspaces";
                    
                    var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                    Messenger.Default.Send(msg);
                }
                
            }
         
        }
    }
}
