using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class MenuItemViewModel : BaseViewModel, IMenuItemViewModel
    {
        public MenuItemViewModel()
        {
            _Header = string.Empty;
            _ViewName = string.Empty;
            _ContentView = null;
            _SubMenus = new ObservableCollection<IMenuItemViewModel>();
            _ClickCommand = new RelayCommand<IMenuItemViewModel>((x) => {

                ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();
            
                tab.Header = Header;
                tab.ContentView = ViewContent;
                tab.ViewType = ViewType;
                tab.TabControlName = TabControlName;

                //發出開啟新分頁的訊息
                var msg = new NotificationMessage<ITabViewModel>(this, tab, "OpenTab");
                Messenger.Default.Send(msg);
            });
        }

        private string _Header;
        public string Header { get => _Header; set { _Header = value; RaisePropertyChanged("Header"); } }
        private string _ViewName;
        public string ViewName { get => _ViewName; set { _ViewName = value; RaisePropertyChanged("ViewName"); } }
        private object _ContentView = null;
        public object ViewContent { get => _ContentView; set { _ContentView = value; RaisePropertyChanged("ContentView"); } }
        private Type _ViewType;
        public Type ViewType { get => _ViewType; set { _ViewType = value; RaisePropertyChanged("ViewType"); } }

        private ObservableCollection<IMenuItemViewModel> _SubMenus = null;
        public ObservableCollection<IMenuItemViewModel> MenuItems { get => _SubMenus; set { _SubMenus = value; RaisePropertyChanged("SubMenus"); } }

        private ICommand _ClickCommand;
        public ICommand ClickCommand { get => _ClickCommand; set { _ClickCommand = value; RaisePropertyChanged("ClickCommand"); } }

        private string _TabControlName = string.Empty;
        public string TabControlName { get => _TabControlName; set { _TabControlName = value; RaisePropertyChanged("TabControlName"); } }
    }
}