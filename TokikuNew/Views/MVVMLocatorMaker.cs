//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Tokiku.ViewModels"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TokikuNew.Frame;
using TokikuNew.Views;
using TokikuNew.Controls;

namespace TokikuNew 
{	
	public partial class ViewsLocator
	{
		public ViewsLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			RunOthersRegister();

			
			if (!SimpleIoc.Default.IsRegistered<ClosableTab>())
				SimpleIoc.Default.Register<ClosableTab>();
			
			if (!SimpleIoc.Default.IsRegistered<ClosableTabItem>())
				SimpleIoc.Default.Register<ClosableTabItem>();
			
			if (!SimpleIoc.Default.IsRegistered<CustomDataGrid>())
				SimpleIoc.Default.Register<CustomDataGrid>();
			
			if (!SimpleIoc.Default.IsRegistered<SearchBar>())
				SimpleIoc.Default.Register<SearchBar>();
			
			if (!SimpleIoc.Default.IsRegistered<MainWindow>())
				SimpleIoc.Default.Register<MainWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<ContactPersonManageView>())
				SimpleIoc.Default.Register<ContactPersonManageView>();
			
			if (!SimpleIoc.Default.IsRegistered<ClientListView>())
				SimpleIoc.Default.Register<ClientListView>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturersManageView>())
				SimpleIoc.Default.Register<ManufacturersManageView>();
			
			if (!SimpleIoc.Default.IsRegistered<VendorListView>())
				SimpleIoc.Default.Register<VendorListView>();
			
			if (!SimpleIoc.Default.IsRegistered<ManufacturerBussinessItemView>())
				SimpleIoc.Default.Register<ManufacturerBussinessItemView>();
			
			if (!SimpleIoc.Default.IsRegistered<OptionWindow>())
				SimpleIoc.Default.Register<OptionWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<StartUpWindow>())
				SimpleIoc.Default.Register<StartUpWindow>();
										
            if (_Current == null)
                _Current = this;

			
		}

		partial void RunOthersRegister();

		private static ViewsLocator _Current=null;
		
		/// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static ViewsLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new ViewsLocator();
                return _Current;
            }
        }

		/// <summary>
        /// 取得IoC容器中的 ClosableTab 物件執行個體。
        /// </summary>
		public ClosableTab ClosableTab
		{
			get => SimpleIoc.Default.GetInstance<ClosableTab>();
		}
		/// <summary>
        /// 取得IoC容器中的 ClosableTabItem 物件執行個體。
        /// </summary>
		public ClosableTabItem ClosableTabItem
		{
			get => SimpleIoc.Default.GetInstance<ClosableTabItem>();
		}
		/// <summary>
        /// 取得IoC容器中的 CustomDataGrid 物件執行個體。
        /// </summary>
		public CustomDataGrid CustomDataGrid
		{
			get => SimpleIoc.Default.GetInstance<CustomDataGrid>();
		}
		/// <summary>
        /// 取得IoC容器中的 SearchBar 物件執行個體。
        /// </summary>
		public SearchBar SearchBar
		{
			get => SimpleIoc.Default.GetInstance<SearchBar>();
		}
		/// <summary>
        /// 取得IoC容器中的 MainWindow 物件執行個體。
        /// </summary>
		public MainWindow MainWindow
		{
			get => SimpleIoc.Default.GetInstance<MainWindow>();
		}
		/// <summary>
        /// 取得IoC容器中的 ContactPersonManageView 物件執行個體。
        /// </summary>
		public ContactPersonManageView ContactPersonManageView
		{
			get => SimpleIoc.Default.GetInstance<ContactPersonManageView>();
		}
		/// <summary>
        /// 取得IoC容器中的 ClientListView 物件執行個體。
        /// </summary>
		public ClientListView ClientListView
		{
			get => SimpleIoc.Default.GetInstance<ClientListView>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturersManageView 物件執行個體。
        /// </summary>
		public ManufacturersManageView ManufacturersManageView
		{
			get => SimpleIoc.Default.GetInstance<ManufacturersManageView>();
		}
		/// <summary>
        /// 取得IoC容器中的 VendorListView 物件執行個體。
        /// </summary>
		public VendorListView VendorListView
		{
			get => SimpleIoc.Default.GetInstance<VendorListView>();
		}
		/// <summary>
        /// 取得IoC容器中的 ManufacturerBussinessItemView 物件執行個體。
        /// </summary>
		public ManufacturerBussinessItemView ManufacturerBussinessItemView
		{
			get => SimpleIoc.Default.GetInstance<ManufacturerBussinessItemView>();
		}
		/// <summary>
        /// 取得IoC容器中的 OptionWindow 物件執行個體。
        /// </summary>
		public OptionWindow OptionWindow
		{
			get => SimpleIoc.Default.GetInstance<OptionWindow>();
		}
		/// <summary>
        /// 取得IoC容器中的 StartUpWindow 物件執行個體。
        /// </summary>
		public StartUpWindow StartUpWindow
		{
			get => SimpleIoc.Default.GetInstance<StartUpWindow>();
		}
	}
}
