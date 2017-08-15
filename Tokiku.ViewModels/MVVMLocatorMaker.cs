//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TokikuNew.Controls;

namespace Tokiku.ViewModels 
{	
	public partial class ViewModelLocator
	{
		public ViewModelLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<IContactListViewModel>())
				SimpleIoc.Default.Register<IContactListViewModel,ContactListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IContactsViewModel>())
				SimpleIoc.Default.Register<IContactsViewModel,ContactsViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ICloseableTabViewModel>())
				SimpleIoc.Default.Register<ICloseableTabViewModel,CloseableTabViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IFixedTabViewModel>())
				SimpleIoc.Default.Register<IFixedTabViewModel,FixedTabViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IMenuItemViewModel>())
				SimpleIoc.Default.Register<IMenuItemViewModel,MenuItemViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IClientListItemViewModel>())
				SimpleIoc.Default.Register<IClientListItemViewModel,ClientListItemViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IClientListViewModel>())
				SimpleIoc.Default.Register<IClientListViewModel,ClientListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IClientViewModel>())
				SimpleIoc.Default.Register<IClientViewModel,ClientViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IMaterialCategoriesListViewModel>())
				SimpleIoc.Default.Register<IMaterialCategoriesListViewModel,MaterialCategoriesListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IMaterialCategoriesViewModel>())
				SimpleIoc.Default.Register<IMaterialCategoriesViewModel,MaterialCategoriesViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IPaymentTypesListViewModel>())
				SimpleIoc.Default.Register<IPaymentTypesListViewModel,PaymentTypesListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IPaymentTypesViewModel>())
				SimpleIoc.Default.Register<IPaymentTypesViewModel,PaymentTypesViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketPeriodsListViewModel>())
				SimpleIoc.Default.Register<ITicketPeriodsListViewModel,TicketPeriodsListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketPeriodsViewModel>())
				SimpleIoc.Default.Register<ITicketPeriodsViewModel,TicketPeriodsViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketTypesListViewModel>())
				SimpleIoc.Default.Register<ITicketTypesListViewModel,TicketTypesListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITicketTypesViewModel>())
				SimpleIoc.Default.Register<ITicketTypesViewModel,TicketTypesViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITradingItemsListViewModel>())
				SimpleIoc.Default.Register<ITradingItemsListViewModel,TradingItemsListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITradingItemsViewModel>())
				SimpleIoc.Default.Register<ITradingItemsViewModel,TradingItemsViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITranscationCategoriesListViewModel>())
				SimpleIoc.Default.Register<ITranscationCategoriesListViewModel,TranscationCategoriesListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ITranscationCategoriesViewModel>())
				SimpleIoc.Default.Register<ITranscationCategoriesViewModel,TranscationCategoriesViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturerBusinessItemsListViewModel>())
				SimpleIoc.Default.Register<IManufacturerBusinessItemsListViewModel,ManufacturerBusinessItemsListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturerFactoryListViewModel>())
				SimpleIoc.Default.Register<IManufacturerFactoryListViewModel,ManufacturerFactoryListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturerFactoryViewModel>())
				SimpleIoc.Default.Register<IManufacturerFactoryViewModel,ManufacturerFactoryViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersBussinessItemsViewModel>())
				SimpleIoc.Default.Register<IManufacturersBussinessItemsViewModel,ManufacturersBussinessItemsViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersBussinessTranscationsListViewModel>())
				SimpleIoc.Default.Register<IManufacturersBussinessTranscationsListViewModel,ManufacturersBussinessTranscationsListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersBussinessTranscationsViewModel>())
				SimpleIoc.Default.Register<IManufacturersBussinessTranscationsViewModel,ManufacturersBussinessTranscationsViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturersViewModel>())
				SimpleIoc.Default.Register<IManufacturersViewModel,ManufacturersViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IVendorListItemViewModel>())
				SimpleIoc.Default.Register<IVendorListItemViewModel,VendorListItemViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IVendorListViewModel>())
				SimpleIoc.Default.Register<IVendorListViewModel,VendorListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IMainViewModel>())
				SimpleIoc.Default.Register<IMainViewModel,MainViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ISearchBarViewModel>())
				SimpleIoc.Default.Register<ISearchBarViewModel,SearchBarViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ILoginViewModel>())
				SimpleIoc.Default.Register<ILoginViewModel,LoginViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IUserViewModel>())
				SimpleIoc.Default.Register<IUserViewModel,UserViewModel>();			
			
			if (!SimpleIoc.Default.IsRegistered<EmptyView>())
				SimpleIoc.Default.Register<EmptyView>();

			if (!SimpleIoc.Default.IsRegistered<IVoidViewModel>())
				SimpleIoc.Default.Register<IVoidViewModel,VoidViewModel>();			
										
            if (_Current == null)
                _Current = this;
		}

		private static ViewModelLocator _Current=null;
		
		/// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static ViewModelLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new ViewModelLocator();
                return _Current;
            }
        }

		/// <summary>
        /// 取得IoC容器中的實作 IContactListViewModel 介面的物件執行個體。
        /// </summary>
		public IContactListViewModel ContactListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IContactListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IContactsViewModel 介面的物件執行個體。
        /// </summary>
		public IContactsViewModel ContactsViewModel
		{
			get => SimpleIoc.Default.GetInstance<IContactsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ICloseableTabViewModel 介面的物件執行個體。
        /// </summary>
		public ICloseableTabViewModel CloseableTabViewModel
		{
			get => SimpleIoc.Default.GetInstance<ICloseableTabViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IFixedTabViewModel 介面的物件執行個體。
        /// </summary>
		public IFixedTabViewModel FixedTabViewModel
		{
			get => SimpleIoc.Default.GetInstance<IFixedTabViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMenuItemViewModel 介面的物件執行個體。
        /// </summary>
		public IMenuItemViewModel MenuItemViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMenuItemViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IClientListItemViewModel 介面的物件執行個體。
        /// </summary>
		public IClientListItemViewModel ClientListItemViewModel
		{
			get => SimpleIoc.Default.GetInstance<IClientListItemViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IClientListViewModel 介面的物件執行個體。
        /// </summary>
		public IClientListViewModel ClientListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IClientListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IClientViewModel 介面的物件執行個體。
        /// </summary>
		public IClientViewModel ClientViewModel
		{
			get => SimpleIoc.Default.GetInstance<IClientViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMaterialCategoriesListViewModel 介面的物件執行個體。
        /// </summary>
		public IMaterialCategoriesListViewModel MaterialCategoriesListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMaterialCategoriesListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMaterialCategoriesViewModel 介面的物件執行個體。
        /// </summary>
		public IMaterialCategoriesViewModel MaterialCategoriesViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMaterialCategoriesViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPaymentTypesListViewModel 介面的物件執行個體。
        /// </summary>
		public IPaymentTypesListViewModel PaymentTypesListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IPaymentTypesListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IPaymentTypesViewModel 介面的物件執行個體。
        /// </summary>
		public IPaymentTypesViewModel PaymentTypesViewModel
		{
			get => SimpleIoc.Default.GetInstance<IPaymentTypesViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketPeriodsListViewModel 介面的物件執行個體。
        /// </summary>
		public ITicketPeriodsListViewModel TicketPeriodsListViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITicketPeriodsListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketPeriodsViewModel 介面的物件執行個體。
        /// </summary>
		public ITicketPeriodsViewModel TicketPeriodsViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITicketPeriodsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketTypesListViewModel 介面的物件執行個體。
        /// </summary>
		public ITicketTypesListViewModel TicketTypesListViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITicketTypesListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITicketTypesViewModel 介面的物件執行個體。
        /// </summary>
		public ITicketTypesViewModel TicketTypesViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITicketTypesViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITradingItemsListViewModel 介面的物件執行個體。
        /// </summary>
		public ITradingItemsListViewModel TradingItemsListViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITradingItemsListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITradingItemsViewModel 介面的物件執行個體。
        /// </summary>
		public ITradingItemsViewModel TradingItemsViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITradingItemsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITranscationCategoriesListViewModel 介面的物件執行個體。
        /// </summary>
		public ITranscationCategoriesListViewModel TranscationCategoriesListViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITranscationCategoriesListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ITranscationCategoriesViewModel 介面的物件執行個體。
        /// </summary>
		public ITranscationCategoriesViewModel TranscationCategoriesViewModel
		{
			get => SimpleIoc.Default.GetInstance<ITranscationCategoriesViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturerBusinessItemsListViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturerBusinessItemsListViewModel ManufacturerBusinessItemsListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturerBusinessItemsListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturerFactoryListViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturerFactoryListViewModel ManufacturerFactoryListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturerFactoryListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturerFactoryViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturerFactoryViewModel ManufacturerFactoryViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturerFactoryViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersBussinessItemsViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturersBussinessItemsViewModel ManufacturersBussinessItemsViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersBussinessItemsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersBussinessTranscationsListViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturersBussinessTranscationsListViewModel ManufacturersBussinessTranscationsListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersBussinessTranscationsListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersBussinessTranscationsViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturersBussinessTranscationsViewModel ManufacturersBussinessTranscationsViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersBussinessTranscationsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturersViewModel ManufacturersViewModel
		{
			get => SimpleIoc.Default.GetInstanceWithoutCaching<IManufacturersViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IVendorListItemViewModel 介面的物件執行個體。
        /// </summary>
		public IVendorListItemViewModel VendorListItemViewModel
		{
			get => SimpleIoc.Default.GetInstance<IVendorListItemViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IVendorListViewModel 介面的物件執行個體。
        /// </summary>
		public IVendorListViewModel VendorListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IVendorListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IMainViewModel 介面的物件執行個體。
        /// </summary>
		public IMainViewModel MainViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMainViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ISearchBarViewModel 介面的物件執行個體。
        /// </summary>
		public ISearchBarViewModel SearchBarViewModel
		{
			get => SimpleIoc.Default.GetInstance<ISearchBarViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ILoginViewModel 介面的物件執行個體。
        /// </summary>
		public ILoginViewModel LoginViewModel
		{
			get => SimpleIoc.Default.GetInstance<ILoginViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IUserViewModel 介面的物件執行個體。
        /// </summary>
		public IUserViewModel UserViewModel
		{
			get => SimpleIoc.Default.GetInstance<IUserViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的 EmptyView 物件執行個體。
        /// </summary>
		public EmptyView EmptyView
		{
			get => SimpleIoc.Default.GetInstance<EmptyView>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IVoidViewModel 介面的物件執行個體。
        /// </summary>
		public IVoidViewModel VoidViewModel
		{
			get => SimpleIoc.Default.GetInstance<IVoidViewModel>();
		}
	}
}
