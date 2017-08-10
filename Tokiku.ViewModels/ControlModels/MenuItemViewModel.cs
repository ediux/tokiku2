using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
        public ObservableCollection<IMenuItemViewModel> SubMenus { get => _SubMenus; set { _SubMenus = value; RaisePropertyChanged("SubMenus"); } }

    }
}