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
    /// <summary>
    /// 廠商主檔:營業項目設定控制項檢視模型
    /// </summary>
    public class ManufacturerBusinessItemsListViewModel : DocumentBaseViewModel<ManufacturersBussinessItems>, IManufacturerBusinessItemsListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturingExecutionDataService;

        public ManufacturerBusinessItemsListViewModel(IManufacturingExecutionDataService ManufacturingExecutionDataService
            ,ICoreDataService CoreDataService)
            :base(CoreDataService)
        {
            _ManufacturingExecutionDataService = ManufacturingExecutionDataService;

            _BussinessItemsList = new ObservableCollection<IManufacturersBussinessItemsViewModel>();

            QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
            SaveCommand = new RelayCommand<Manufacturers>(RunSave);
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

        private ObservableCollection<IManufacturersBussinessItemsViewModel> _BussinessItemsList;

        /// <summary>
        /// 取得或設定指定廠商的營業項目清單
        /// </summary>
        public ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList { get => _BussinessItemsList;
            set {
                _BussinessItemsList = value;
                RaisePropertyChanged("BussinessItemsList");
            } }
    }
}