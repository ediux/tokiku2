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
using System;
using System.Linq;
using System.Reflection;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            Type tDefprovider = typeof(SimpleIoc);

            //var IsRegisteredMethod = tDefprovider.GetMethod("IsRegistered", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public,Type.DefaultBinder,Type.EmptyTypes, null);

            //RegisterMethod.Invoke("Register", Type.EmptyTypes);
            SimpleIoc.Default.Register<ILoginViewModel, LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IUserViewModel, UserViewModel>();
            //Assembly currentAsm = Assembly.GetExecutingAssembly();

            //var types = currentAsm.GetTypes().Where(w => w.IsInterface == false
            //&& w.IsClass == true
            //&& w.Name.EndsWith("ViewModel"));

            //foreach (var reg_type in types)
            //{
            //    var rtinvoker_isRegister = IsRegisteredMethod.MakeGenericMethod(reg_type.BaseType);
            //    var RegisterMethod = tDefprovider.GetMethods(BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public).Where(w=>w.GetGenericMethodDefinition().GetGenericArguments(a;
            //    var rtinvoker_Register = RegisterMethod.MakeGenericMethod(reg_type);

            //    if (!(bool)rtinvoker_isRegister.Invoke(SimpleIoc.Default, new object[] { }))
            //    {
            //        rtinvoker_Register.Invoke(SimpleIoc.Default, new object[] { });
            //    }
            //}

            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<LoginViewModel>();
            //SimpleIoc.Default.Register<UserViewModel>();
            //SimpleIoc.Default.Register<ProjectListViewModelCollection>();
            SetupNavigation();
        }

        /// <summary>
        /// 主要功能畫面檢視模型
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels

        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("mainwindow", new Uri("/MainWindow.xaml", UriKind.Relative));

            if (!SimpleIoc.Default.IsRegistered<IFrameNavigationService>())
                SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        /// <summary>
        /// Gets the 登入畫面檢視模型 property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ILoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILoginViewModel>();
            }
        }



        /// <summary>
        /// Gets the UserAccount property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public IUserViewModel UserAccount
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IUserViewModel>();
            }
        }
    }
}