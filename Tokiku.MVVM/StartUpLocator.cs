using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.MVVM
{
    public class StartUpLocator
    {
        public static void StartUp()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IFrameNavigationService>())
                SimpleIoc.Default.Register<IFrameNavigationService, FrameNavigationService>();

            if (_Current == null)
                _Current = new StartUpLocator();
        }

        private static StartUpLocator _Current = null;

        /// <summary>
        /// 取得預設的容器解析物件。
        /// </summary>
        public static StartUpLocator Current
        {
            get
            {
                if (_Current == null)
                    _Current = new StartUpLocator();

                return _Current;
            }
        }

        public IFrameNavigationService NavigationService
        {
            get => SimpleIoc.Default.GetInstance<IFrameNavigationService>();
        }
    }
}
