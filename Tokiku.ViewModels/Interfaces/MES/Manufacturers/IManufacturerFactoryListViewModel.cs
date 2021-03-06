﻿using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturerFactoryListViewModel : IDocumentBaseViewModel
    {
        void RunQuery(Manufacturers Parameter);
        ObservableCollection<IManufacturerFactoryViewModel> FactoriesList { get; set; }
    }
}