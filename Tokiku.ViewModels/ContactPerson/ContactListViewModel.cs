using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.DataServices;
using Tokiku.Entity;
using Tokiku.MVVM;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace Tokiku.ViewModels
{
    public class ContactListViewModel : DocumentBaseViewModel<Contacts>, IContactListViewModel
    {
        private ICoreDataService _UserDataService;

        [PreferredConstructor]
        public ContactListViewModel(ICoreDataService UserDataService) : base(UserDataService)
        {
            _UserDataService = UserDataService;
            _ContractsList = new ObservableCollection<IContactsViewModel>(((IContactsDataService)_UserDataService).GetAll()
                .Select(s => new ContactsViewModel(s)));
            QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
            ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);
            SaveCommand = new RelayCommand<Manufacturers>(RunSave);
            _Mode = DocumentLifeCircle.Read;
        }

        protected virtual void RunQuery(Manufacturers Parameter)
        {
            if (Parameter != null)
            {
                ContractsList =
             new ObservableCollection<IContactsViewModel>(
                 (from q in ((IContactsDataService)_UserDataService).GetAll()
                  from s in q.Manufacturers
                  where s.Id == Parameter.Id && s.IsClient == Parameter.IsClient
                  select new ContactsViewModel(q)).ToList());
            }
            else
            {
                ContractsList = new ObservableCollection<IContactsViewModel>();
            }
        }

        protected virtual void RunSave(Manufacturers Parameter)
        {

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
    }
}