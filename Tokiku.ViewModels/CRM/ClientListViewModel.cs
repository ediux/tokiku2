using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
    public class ClientListViewModel : DocumentBaseViewModel, IClientListViewModel
    {
        private IClientDataService _ClientDataService;

        public ClientListViewModel(ICustomerRelationshipManagementDataService CustomerRelationshipManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _ClientDataService = CustomerRelationshipManagementDataService;

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

        public override void Query(object Parameter)
        {
            if (Parameter == null)
            {
                _ClientsList = new ObservableCollection<IClientListItemViewModel>(
                    _ClientDataService.GetAll().Select(s => new ClientListItemViewModel(s)));
            }

        }
    }
}
