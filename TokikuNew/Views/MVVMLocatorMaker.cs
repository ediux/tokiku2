//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TokikuNew.Frame;
using TokikuNew.Views;
using TokikuNew.Helpers;
using TokikuNew.Controls;

namespace TokikuNew 
{	
	public partial class ViewsLocator
	{
		public ViewsLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			
			if (!SimpleIoc.Default.IsRegistered<ClosableTab>())
				SimpleIoc.Default.Register<ClosableTab>();
			
			if (!SimpleIoc.Default.IsRegistered<ClosableTabItem>())
				SimpleIoc.Default.Register<ClosableTabItem>();
			
			if (!SimpleIoc.Default.IsRegistered<CustomDataGrid>())
				SimpleIoc.Default.Register<CustomDataGrid>();
			
			if (!SimpleIoc.Default.IsRegistered<SearchBar>())
				SimpleIoc.Default.Register<SearchBar>();
			
			if (!SimpleIoc.Default.IsRegistered<OnMenuItemClickBehavior>())
				SimpleIoc.Default.Register<OnMenuItemClickBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<OnMenuItemClickToClaseWindowBehavior>())
				SimpleIoc.Default.Register<OnMenuItemClickToClaseWindowBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<OnTabControlAddTabSwitchBehavior>())
				SimpleIoc.Default.Register<OnTabControlAddTabSwitchBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<OnWindowCloseBehavior>())
				SimpleIoc.Default.Register<OnWindowCloseBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<PasswordChangedBehavior>())
				SimpleIoc.Default.Register<PasswordChangedBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<TabOnEnterBehaviorForPassword>())
				SimpleIoc.Default.Register<TabOnEnterBehaviorForPassword>();
			
			if (!SimpleIoc.Default.IsRegistered<TabOnEnterBehavior>())
				SimpleIoc.Default.Register<TabOnEnterBehavior>();
			
			if (!SimpleIoc.Default.IsRegistered<MainWindow>())
				SimpleIoc.Default.Register<MainWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<VendorListView>())
				SimpleIoc.Default.Register<VendorListView>();
			
			if (!SimpleIoc.Default.IsRegistered<OptionWindow>())
				SimpleIoc.Default.Register<OptionWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<StartUpWindow>())
				SimpleIoc.Default.Register<StartUpWindow>();
										
            if (_Current == null)
                _Current = this;
		}

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
        /// 取得IoC容器中的 OnMenuItemClickBehavior 物件執行個體。
        /// </summary>
		public OnMenuItemClickBehavior OnMenuItemClickBehavior
		{
			get => SimpleIoc.Default.GetInstance<OnMenuItemClickBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 OnMenuItemClickToClaseWindowBehavior 物件執行個體。
        /// </summary>
		public OnMenuItemClickToClaseWindowBehavior OnMenuItemClickToClaseWindowBehavior
		{
			get => SimpleIoc.Default.GetInstance<OnMenuItemClickToClaseWindowBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 OnTabControlAddTabSwitchBehavior 物件執行個體。
        /// </summary>
		public OnTabControlAddTabSwitchBehavior OnTabControlAddTabSwitchBehavior
		{
			get => SimpleIoc.Default.GetInstance<OnTabControlAddTabSwitchBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 OnWindowCloseBehavior 物件執行個體。
        /// </summary>
		public OnWindowCloseBehavior OnWindowCloseBehavior
		{
			get => SimpleIoc.Default.GetInstance<OnWindowCloseBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 PasswordChangedBehavior 物件執行個體。
        /// </summary>
		public PasswordChangedBehavior PasswordChangedBehavior
		{
			get => SimpleIoc.Default.GetInstance<PasswordChangedBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 TabOnEnterBehaviorForPassword 物件執行個體。
        /// </summary>
		public TabOnEnterBehaviorForPassword TabOnEnterBehaviorForPassword
		{
			get => SimpleIoc.Default.GetInstance<TabOnEnterBehaviorForPassword>();
		}
		/// <summary>
        /// 取得IoC容器中的 TabOnEnterBehavior 物件執行個體。
        /// </summary>
		public TabOnEnterBehavior TabOnEnterBehavior
		{
			get => SimpleIoc.Default.GetInstance<TabOnEnterBehavior>();
		}
		/// <summary>
        /// 取得IoC容器中的 MainWindow 物件執行個體。
        /// </summary>
		public MainWindow MainWindow
		{
			get => SimpleIoc.Default.GetInstance<MainWindow>();
		}
		/// <summary>
        /// 取得IoC容器中的 VendorListView 物件執行個體。
        /// </summary>
		public VendorListView VendorListView
		{
			get => SimpleIoc.Default.GetInstance<VendorListView>();
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
