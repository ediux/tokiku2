//==============================================================
//=		請勿手動修改此檔案，此為T4範本自動產生。			   =
//=								By Edward Huang(2017/8/5)	   =
//==============================================================

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Tokiku.DataServices 
{	
	public partial class DefaultLocator
	{
		public DefaultLocator()
		{
			if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (!SimpleIoc.Default.IsRegistered<IAccessLogDataService>())
				SimpleIoc.Default.Register<IAccessLogDataService,AccessLogDataService>();			

			if (!SimpleIoc.Default.IsRegistered<IUserDataService>())
				SimpleIoc.Default.Register<IUserDataService,UsersDataService>();			
										
            if (_Current == null)
                _Current = this;
		}

		private static DefaultLocator _Current=null;
		
		/// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static DefaultLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new DefaultLocator();
                return _Current;
            }
        }

		/// <summary>
        /// 取得IoC容器中的實作 IAccessLogDataService 介面的物件執行個體。
        /// </summary>
		public IAccessLogDataService AccessLogDataService
		{
			get => SimpleIoc.Default.GetInstance<IAccessLogDataService>();
		}
		/// <summary>
        /// 取得IoC容器中的實作 IUserDataService 介面的物件執行個體。
        /// </summary>
		public IUserDataService UsersDataService
		{
			get => SimpleIoc.Default.GetInstance<IUserDataService>();
		}
	}
}
