using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using System.Collections.ObjectModel;
namespace Tokiku.ViewModels
{
    public interface IManufacturerBusinessItemsListViewModel : IBaseViewModel
    {
        DocumentLifeCircle Mode { get; set; }
        ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get; set; }
    }
}