using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public abstract class TabViewModelBase : BaseViewModel, ITabViewModel
    {
        public TabViewModelBase() : base()
        {
            _Header = string.Empty;
            _ViewType = _ContentView?.GetType();
        }
        private string _Header;
        public string Header { get => _Header; set { _Header = value; RaisePropertyChanged("Header"); } }
        private Type _ViewType;

        public Type ViewType { get => _ViewType; set { _ViewType = value; RaisePropertyChanged("ViewType"); } }

        private object _ContentView = null;

        public object ContentView { get => _ContentView; set{ _ContentView = value; RaisePropertyChanged("ContentView"); } }

        protected bool _CanClose = false;
        public virtual bool CanClose { get => _CanClose; set { _CanClose = value; RaisePropertyChanged("CanClose"); } }

        private object _SelectedObject = null;
        public object SelectedObject { get =>_SelectedObject; set { _SelectedObject = value;RaisePropertyChanged("SelectedObject"); } }

        private string _TabControlName = string.Empty;
        public string TabControlName { get => _TabControlName; set { _TabControlName = value; RaisePropertyChanged("TabControlName"); } }
    }
}