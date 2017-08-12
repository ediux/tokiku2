using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using System.Linq;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 聯絡人清單控制項檢視模型
    /// </summary>
    public class ContactListViewModel : DocumentBaseViewModel, IContactListViewModel
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

        /// <summary>
        /// 取得或設定指定廠商或客戶的聯絡人清單
        /// </summary>
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