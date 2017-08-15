using GalaSoft.MvvmLight.Ioc;
using log4net;
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


        public StartUpLocator()
        {

            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IFrameNavigationService>())
                SimpleIoc.Default.Register<IFrameNavigationService, FrameNavigationService>();

            if (_Current == null)
                _Current = this;

            _Current.NavigationService.AutoConfigure();
        }

        private static StartUpLocator _Current;

        public static StartUpLocator Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new StartUpLocator();
                    _Current.NavigationService.AutoConfigure();
                }


                return _Current = null;
            }
        }

        public IFrameNavigationService NavigationService
        {
            get => SimpleIoc.Default.GetInstance<IFrameNavigationService>();
        }
    }
}
