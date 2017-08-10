using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public class ManufacturerBusinessItemsListViewModel : BaseViewModel, IManufacturerBusinessItemsListViewModel
    {
        public DocumentLifeCircle Mode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}