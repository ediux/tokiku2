using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IManufacturersBussinessTranscationsListViewModel : IDocumentBaseViewModel
    {
        ObservableCollection<IManufacturersBussinessTranscationsViewModel> TranscationRecords { get; set; }
    }
}