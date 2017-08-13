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
    public class ManufacturerBusinessItemsListViewModel : DocumentBaseViewModel, IManufacturerBusinessItemsListViewModel
    {
        private IManufacturingExecutionDataService _ManufacturingExecutionDataService;

        public ManufacturerBusinessItemsListViewModel(IManufacturingExecutionDataService ManufacturingExecutionDataService
            , ICoreDataService CoreDataService)
            : base(CoreDataService)
        {
            _ManufacturingExecutionDataService = ManufacturingExecutionDataService;
            _BussinessItemsList = new ObservableCollection<IManufacturersBussinessItemsViewModel>();

            QueryCommand = new RelayCommand<Manufacturers>(RunQuery);
            SaveCommand = new RelayCommand<Manufacturers>(RunSave);
        }

        public override void Query(object Parameter)
        {
            _MaterialCategoriesDropDownList = ViewModelLocator.Current.MaterialCategoriesListViewModel;
            _MaterialCategoriesDropDownList.QueryCommand.Execute(((Manufacturers)Parameter).ManufacturersBussinessItems);
            _TradingItemDropDownList = ViewModelLocator.Current.TradingItemsListViewModel;
            _TradingItemDropDownList.QueryCommand.Execute(((Manufacturers)Parameter).ManufacturersBussinessItems);
            _TranscationCategoriesDropDownList = ViewModelLocator.Current.TranscationCategoriesListViewModel;
            _TranscationCategoriesDropDownList.QueryCommand.Execute(((Manufacturers)Parameter).ManufacturersBussinessItems);
            _PaymentTypesDropDownList = ViewModelLocator.Current.PaymentTypesListViewModel;
            _PaymentTypesDropDownList.QueryCommand.Execute(((Manufacturers)Parameter).ManufacturersBussinessItems);
            _TicketPeriodsDropDownList = ViewModelLocator.Current.TicketPeriodsListViewModel;
            _TicketPeriodsDropDownList.QueryCommand.Execute(((Manufacturers)Parameter).ManufacturersBussinessItems);
        }

        protected virtual void RunQuery(Manufacturers Parameter)
        {
            var queryresult = Parameter.ManufacturersBussinessItems
                  .Select(s => new ManufacturersBussinessItemsViewModel(s)).ToList();

            _BussinessItemsList = new ObservableCollection<IManufacturersBussinessItemsViewModel>(queryresult);

            RaisePropertyChanged("BussinessItemsList");

            Query(Parameter);
        }

        protected virtual void RunSave(Manufacturers Parameter)
        {
            ModeChangedCommand.Execute(DocumentLifeCircle.Read);
        }

        private ObservableCollection<IManufacturersBussinessItemsViewModel> _BussinessItemsList;

        /// <summary>
        /// 取得或設定指定廠商的營業項目清單
        /// </summary>
        public ObservableCollection<IManufacturersBussinessItemsViewModel> BussinessItemsList
        {
            get => _BussinessItemsList;
            set
            {
                _BussinessItemsList = value;
                RaisePropertyChanged("BussinessItemsList");
            }
        }

        private IMaterialCategoriesListViewModel _MaterialCategoriesDropDownList;
        /// <summary>
        /// 材料類別選擇清單
        /// </summary>
        public IMaterialCategoriesListViewModel MaterialCategoriesDropDownList
        {
            get => _MaterialCategoriesDropDownList; set
            {
                _MaterialCategoriesDropDownList = value;
                RaisePropertyChanged("MaterialCategoriesDropDownList");
            }
        }

        private ITranscationCategoriesListViewModel _TranscationCategoriesDropDownList;
        /// <summary>
        /// 交易類別選擇清單        
        /// </summary>
        public ITranscationCategoriesListViewModel TranscationCategoriesDropDownList
        {
            get => _TranscationCategoriesDropDownList; set
            {
                _TranscationCategoriesDropDownList = value;
                RaisePropertyChanged("TranscationCategoriesDropDownList");
            }
        }
        private IPaymentTypesListViewModel _PaymentTypesDropDownList;
        /// <summary>
        /// 支付方式下拉選單
        /// </summary>
        public IPaymentTypesListViewModel PaymentTypesDropDownList { get => _PaymentTypesDropDownList; set { _PaymentTypesDropDownList = value; RaisePropertyChanged("PaymentTypesDropDownList"); } }

        private ITicketPeriodsListViewModel _TicketPeriodsDropDownList;
        /// <summary>
        /// 票期下拉式選單
        /// </summary>
        public ITicketPeriodsListViewModel TicketPeriodsDropDownList { get => _TicketPeriodsDropDownList; set { _TicketPeriodsDropDownList = value; RaisePropertyChanged("TicketPeriodsDropDownList"); } }

        private ITradingItemsListViewModel _TradingItemDropDownList;
        /// <summary>
        /// 交易品項下拉式選單
        /// </summary>
        public ITradingItemsListViewModel TradingItemDropDownList { get => _TradingItemDropDownList; set { _TradingItemDropDownList = value; RaisePropertyChanged("TradingItemDropDownList"); } }

    }
}