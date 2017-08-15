using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IMenuItemViewModel : IBaseViewModel
    {
        string Header { get; set; }

        string ViewName { get; set; }

        object ViewContent { get; set; }

        string TabControlName { get; set; }

        Type ViewType { get; set; }

        ObservableCollection<IMenuItemViewModel> MenuItems { get; set; }

        ICommand ClickCommand { get; set; }
    }
}