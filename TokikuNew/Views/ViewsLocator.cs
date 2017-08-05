using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using Tokiku.MVVM;

namespace TokikuNew.Views
{
    public partial class ViewsLocator
    {
        //public ViewsLocator()
        //{
        //    if (!ServiceLocator.IsLocationProviderSet)
        //        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        //    SetupNavigation();
        //}

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("mainwindow", new Uri("/MainWindow.xaml", UriKind.Relative),typeof(MainWindow));
            SimpleIoc.Default.Register(()=>new MainWindow(), "mainwindow");

            if (!SimpleIoc.Default.IsRegistered<IFrameNavigationService>())
                SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainWindow MainWindow
        {
            get => SimpleIoc.Default.GetInstance<MainWindow>();
        }
    }
}
