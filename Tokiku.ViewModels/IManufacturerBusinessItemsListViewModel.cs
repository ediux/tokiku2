using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IManufacturerBusinessItemsListViewModel : IBaseViewModel
    {
        ICommand QueryCommand { get; set; }
        ICommand SaveCommand { get; set; }
        ICommand ModeChangedCommand { get; set; }
        DocumentLifeCircle Mode { get; set; }
        ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get; set; }
    }
}