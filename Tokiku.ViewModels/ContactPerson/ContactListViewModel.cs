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
    public class ContactListViewModel : BaseViewModel, IContactListViewModel
    {
        private ICoreDataService _UserDataService;

        [PreferredConstructor]
        public ContactListViewModel(ICoreDataService UserDataService) : base()
        {
            _UserDataService = UserDataService;
            _ContractsList = new ObservableCollection<IContactsViewModel>(((IContactsDataService)_UserDataService).GetAll()
                .Select(s => new ContactsViewModel(s)));
            _QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
            _ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);
            _SaveCommand = new RelayCommand<Manufacturers>(RunSave);
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

        protected virtual void RunModeChanged(DocumentLifeCircle parameter)
        {
            _Mode = parameter;
            RaisePropertyChanged("Mode");
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

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set { _QueryCommand = value; RaisePropertyChanged("QueryCommand"); } }

        private ICommand _SaveCommand;
        public ICommand SaveCommand { get => _SaveCommand; set { _SaveCommand = value; RaisePropertyChanged("SaveCommand"); } }

        private ICommand _ModeChangedCommand;
        public ICommand ModeChangedCommand { get => _ModeChangedCommand; set { _ModeChangedCommand = value; RaisePropertyChanged("ModeChangedCommand"); } }
    }
}