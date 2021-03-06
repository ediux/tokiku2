﻿using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IClientListViewModel : IDocumentBaseViewModel
    {
        ICommand SelectedAndOpenCommand { get; set; }
        ObservableCollection<IClientListItemViewModel> ClientsList { get; set; }
    }
}