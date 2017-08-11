using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturerFactoryListViewModel : DocumentBaseViewModel<ManufacturersFactories>, IManufacturerFactoryListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturingExecutionDataService;

        public ManufacturerFactoryListViewModel(IManufacturingExecutionDataService ManufacturingExecutionDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _ManufacturingExecutionDataService = ManufacturingExecutionDataService;

            QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
        }

        public  virtual void RunQuery(Manufacturers Parameter)
        {
            FactoriesList = new ObservableCollection<IManufacturerFactoryViewModel>(
                Parameter.ManufacturersFactories.
                Select(s => new ManufacturerFactoryViewModel(s)));
        }

        private ObservableCollection<IManufacturerFactoryViewModel> _FactoriesList = new ObservableCollection<IManufacturerFactoryViewModel>();

        public ObservableCollection<IManufacturerFactoryViewModel> FactoriesList
        {
            get => _FactoriesList; set
            {
                _FactoriesList = value;
                RaisePropertyChanged("FactoriesList");
            }
        }

    }
}
