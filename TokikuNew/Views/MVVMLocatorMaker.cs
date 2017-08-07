//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TokikuNew.Frame;

namespace TokikuNew 
{	
	public partial class ViewsLocator
	{
		public ViewsLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			
			if (!SimpleIoc.Default.IsRegistered<OptionWindow>())
				SimpleIoc.Default.Register<OptionWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<StartUpWindow>())
				SimpleIoc.Default.Register<StartUpWindow>();
			
			if (!SimpleIoc.Default.IsRegistered<MainWindow>())
				SimpleIoc.Default.Register<MainWindow>();
										
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
		/// <summary>
        /// 取得IoC容器中的 MainWindow 物件執行個體。
        /// </summary>
		public MainWindow MainWindow
		{
			get => SimpleIoc.Default.GetInstance<MainWindow>();
		}
	}
}
