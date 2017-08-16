using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
    public class ClientListViewModel : DocumentBaseViewModel, IClientListViewModel
    {
        private IClientDataService _ClientDataService;

        public ClientListViewModel(ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            try
            {
                _ClientDataService = CustomerRelationshipManagementDataService;
                SelectedAndOpenCommand = new RelayCommand<object>(RunSelectedAndOpenCommand);

                Messenger.Default.Register<string>(this, "SearchBar_Query_ClientList", (x) =>
                {
                    ClientsList = new ObservableCollection<IClientListItemViewModel>(_ClientDataService.SearchByText(x)
                    .Select(s => new ClientListItemViewModel(s)));
                });

                Messenger.Default.Register<string>(this, "SearchBar_Refresh_ClientList", (x) =>
                {
                    ClientsList = new ObservableCollection<IClientListItemViewModel>(_ClientDataService.SearchByText(x)
                    .Select(s => new ClientListItemViewModel(s)));
                });

                Messenger.Default.Register<string>(this, "SearchBar_Reset_ClientList", (x) =>
                {
                    ClientsList = new ObservableCollection<IClientListItemViewModel>(_ClientDataService.GetAll()
                    .Select(s => new ClientListItemViewModel(s)));
                });
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }

        private ObservableCollection<IClientListItemViewModel> _ClientsList;

        public ObservableCollection<IClientListItemViewModel> ClientsList
        {
            get
            {
                if (_ClientsList == null)
                {
                    QueryCommand.Execute(null);
                }

                return _ClientsList;
            }
            set
            {
                _ClientsList = value;
                RaisePropertyChanged("ClientsList");
            }
        }

        private ICommand _SelectedAndOpenCommand;

        public ICommand SelectedAndOpenCommand
        {
            get => _SelectedAndOpenCommand; set
            {
                try
                {
                    _SelectedAndOpenCommand = value;
                    RaisePropertyChanged("SelectedAndOpenCommand");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }
        public override void CreateNew()
        {
            try
            {
                ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();

                tab.ViewType = Assembly.Load("TokikuNew").GetType("TokikuNew.Views.ClientManageView");
                tab.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(tab.ViewType);
                tab.Header = "新增客戶";
                tab.SelectedObject = null;
                tab.DataModelType = typeof(IClientViewModel);
                tab.TabControlName = "Workspaces";
                tab.IsNewModel = true;

                var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                Messenger.Default.Send(msg);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }

        protected void RunSelectedAndOpenCommand(object parameter)
        {
            try
            {
                if (parameter is IClientListItemViewModel)
                {
                    ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();
                    IClientListItemViewModel selecteditem = (IClientListItemViewModel)parameter;

                    if (selecteditem != null)
                    {
                        tab.ViewType = Assembly.Load("TokikuNew").GetType("TokikuNew.Views.ClientManageView");
                        tab.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(tab.ViewType);
                        tab.Header = string.Format("客戶:{0}-{1}", selecteditem.Code, selecteditem.ShortName);
                        tab.SelectedObject = selecteditem;
                        tab.DataModelType = typeof(IClientViewModel);
                        tab.TabControlName = "Workspaces";

                        var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                        Messenger.Default.Send(msg);
                    }

                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }

        public override void Query(object Parameter)
        {
            try
            {
                if (Parameter == null)
                {
                    _ClientsList = new ObservableCollection<IClientListItemViewModel>(
                        _ClientDataService.GetAll().Select(s => new ClientListItemViewModel(s)));
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }


        }
    }
}
