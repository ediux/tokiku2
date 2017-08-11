using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IManufacturerBusinessItemsListViewModel : IDocumentBaseViewModel<ManufacturersBussinessItems>
    {
       
        ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get; set; }
    }
}