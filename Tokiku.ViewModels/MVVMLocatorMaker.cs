//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.ViewModels 
{	
	public partial class ViewModelLocator
	{
		public ViewModelLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<ICloseableTabViewModel>())
				SimpleIoc.Default.Register<ICloseableTabViewModel,CloseableTabViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IFixedTabViewModel>())
				SimpleIoc.Default.Register<IFixedTabViewModel,FixedTabViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IMainViewModel>())
				SimpleIoc.Default.Register<IMainViewModel,MainViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<ILoginViewModel>())
				SimpleIoc.Default.Register<ILoginViewModel,LoginViewModel>();			

			if (!SimpleIoc.Default.IsRegistered<IUserViewModel>())
				SimpleIoc.Default.Register<IUserViewModel,UserViewModel>();			
										
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
        /// 取得IoC容器中的實作 IMainViewModel 介面的物件執行個體。
        /// </summary>
		public IMainViewModel MainViewModel
		{
			get => SimpleIoc.Default.GetInstance<IMainViewModel>();
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
	}
}
