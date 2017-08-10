using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.DataServices;
using Tokiku.Entity;
using Tokiku.MVVM;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    public class ContactListViewModel : BaseViewModel, IContactListViewModel
    {
        private IUserDataService _UserDataService;

        [PreferredConstructor]
        public ContactListViewModel(IUserDataService UserDataService) : base()
        {
            _UserDataService = UserDataService;
            _ContractsList = new ObservableCollection<IContactsViewModel>(((IDataService<Contacts>)_UserDataService).GetAll()
                .Select(s => new ContactsViewModel(s)));
        }

        public ContactListViewModel(IManufacturersViewModel model, IUserDataService UserDataService) : this(UserDataService)
        {
            ContractsList =
                new ObservableCollection<IContactsViewModel>(
                    (from q in _ContractsList
                    from s in q.Entity.Manufacturers
                    where s.Id == model.Id && s.IsClient == model.IsClient
                    select q).ToList());

            _Mode = model.Mode;
        }

        private ObservableCollection<IContactsViewModel> _ContractsList;
        public ObservableCollection<IContactsViewModel> ContractsList
        {
            get => _ContractsList; set
            {
                _ContractsList = value;
                RaisePropertyChanged("ContractsList");
            }
        }

        private DocumentLifeCircle _Mode;
        public DocumentLifeCircle Mode { get => _Mode; set { _Mode = value; RaisePropertyChanged("Mode"); } }
    }
}