using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsListViewModel : DocumentBaseViewModel<SupplierTranscationItem>, IManufacturersBussinessTranscationsListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturingExecutionDataService;
        public ManufacturersBussinessTranscationsListViewModel(IManufacturingExecutionDataService ManufacturingExecutionDataService
            , ICoreDataService CoreDataService)
            : base(CoreDataService)
        {
            _ManufacturingExecutionDataService = ManufacturingExecutionDataService;
            _TranscationRecords = new ObservableCollection<IManufacturersBussinessTranscationsViewModel>();
            QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
        }

        private void RunQuery(Manufacturers parameter)
        {
            try
            {
                _TranscationRecords = new ObservableCollection<IManufacturersBussinessTranscationsViewModel>(
                           parameter.SupplierTranscationItem
                           .Select(s => new ManufacturersBussinessTranscationsViewModel(s)));
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        private ObservableCollection<IManufacturersBussinessTranscationsViewModel> _TranscationRecords;

        public ObservableCollection<IManufacturersBussinessTranscationsViewModel> TranscationRecords { get => _TranscationRecords; set {
                _TranscationRecords = value;
                RaisePropertyChanged("TranscationRecords");
            } }
    }
}