using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturerBusinessItemsListViewModel : BaseViewModel, IManufacturerBusinessItemsListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturingExecutionDataService;

        public ManufacturerBusinessItemsListViewModel(IManufacturingExecutionDataService ManufacturingExecutionDataService)
        {
            _ManufacturingExecutionDataService = ManufacturingExecutionDataService;

            _BussinessItemsList = new ObservableCollection<IManufacturersBussinessItemsViewModel>();

            _QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
            _SaveCommand = new RelayCommand<Manufacturers>(RunSave);
            _ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);
        }

        protected virtual void RunQuery(Manufacturers Parameter)
        {
            var queryresult = _ManufacturingExecutionDataService.GetAll(w => w.ManufacturersId == Parameter.Id)
                  .Select(s => new ManufacturersBussinessItemsViewModel(s)).ToList();

            _BussinessItemsList = new ObservableCollection<IManufacturersBussinessItemsViewModel>(queryresult);
            RaisePropertyChanged("BussinessItemsList");
        }

        protected virtual void RunSave(Manufacturers Parameter)
        {

            ModeChangedCommand.Execute(DocumentLifeCircle.Read);
        }

        protected virtual void RunModeChanged(DocumentLifeCircle Mode)
        {
            _Mode = Mode;
            RaisePropertyChanged("Mode");
        }

        private DocumentLifeCircle _Mode = DocumentLifeCircle.Read;

        public DocumentLifeCircle Mode { get => _Mode; set { _Mode = value; RaisePropertyChanged("Mode"); } }

        private ObservableCollection<IManufacturersBussinessItemsViewModel> _BussinessItemsList;
        public ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get => _BussinessItemsList;
            set {
                _BussinessItemsList = value;
                RaisePropertyChanged("BussinessItemsList");
            } }
        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set { _QueryCommand = value; RaisePropertyChanged("QueryCommand"); } }
        private ICommand _SaveCommand;
        public ICommand SaveCommand { get => _SaveCommand; set {
                _SaveCommand = value;
                RaisePropertyChanged("SaveCommand");
            } }

        private ICommand _ModeChangedCommand;

        public ICommand ModeChangedCommand { get => _ModeChangedCommand; set { _ModeChangedCommand = value; RaisePropertyChanged("ModeChangedCommand"); } }
    }
}