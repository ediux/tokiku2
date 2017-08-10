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

			if (!SimpleIoc.Default.IsRegistered<IMainViewModel>())
				SimpleIoc.Default.Register<IMainViewModel,MainViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IManufacturerBusinessItemsListViewModel>())
				SimpleIoc.Default.Register<IManufacturerBusinessItemsListViewModel,ManufacturerBusinessItemsListViewModel>();			
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersBussinessItemsViewModel>())
				SimpleIoc.Default.Register<ManufacturersBussinessItemsViewModel>();

			if (!SimpleIoc.Default.IsRegistered<IManufacturersViewModel>())
				SimpleIoc.Default.Register<IManufacturersViewModel,ManufacturersViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IVendorListItemViewModel>())
				SimpleIoc.Default.Register<IVendorListItemViewModel,VendorListItemViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IVendorListViewModel>())
				SimpleIoc.Default.Register<IVendorListViewModel,VendorListViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IPaymentTypesViewModel>())
				SimpleIoc.Default.Register<IPaymentTypesViewModel,PaymentTypesViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ISearchBarViewModel>())
				SimpleIoc.Default.Register<ISearchBarViewModel,SearchBarViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IVoidViewModel>())
				SimpleIoc.Default.Register<IVoidViewModel,VoidViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ILoginViewModel>())
				SimpleIoc.Default.Register<ILoginViewModel,LoginViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IUserViewModel>())
				SimpleIoc.Default.Register<IUserViewModel,UserViewModel>();			
			
			if (!SimpleIoc.Default.IsRegistered<EmptyView>())
				SimpleIoc.Default.Register<EmptyView>();
										
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
        /// 取得IoC容器中的實作 IMainViewModel 介面的物件執行個體。
        /// </summary>
		public IMainViewModel MainViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMainViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturerBusinessItemsListViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturerBusinessItemsListViewModel ManufacturerBusinessItemsListViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturerBusinessItemsListViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersBussinessItemsViewModel 物件執行個體。
        /// </summary>
		public ManufacturersBussinessItemsViewModel ManufacturersBussinessItemsViewModel
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersBussinessItemsViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IManufacturersViewModel 介面的物件執行個體。
        /// </summary>
		public IManufacturersViewModel ManufacturersViewModel
		{
			get => SimpleIoc.Default.GetInstance<IManufacturersViewModel>();
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
        /// 取得IoC容器中的實作 IPaymentTypesViewModel 介面的物件執行個體。
        /// </summary>
		public IPaymentTypesViewModel PaymentTypesViewModel
		{
			get => SimpleIoc.Default.GetInstance<IPaymentTypesViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 ISearchBarViewModel 介面的物件執行個體。
        /// </summary>
		public ISearchBarViewModel SearchBarViewModel
		{
			get => SimpleIoc.Default.GetInstance<ISearchBarViewModel>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IVoidViewModel 介面的物件執行個體。
        /// </summary>
		public IVoidViewModel VoidViewModel
		{
			get => SimpleIoc.Default.GetInstance<IVoidViewModel>();
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
	}
}
