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

            Type tDefprovider = SimpleIoc.Default.GetType();

            var IsRegisteredMethod = tDefprovider.GetMethod("IsRegistered", BindingFlags.CreateInstance | BindingFlags.Public);
            var RegisterMethod = tDefprovider.GetMethod("Register", BindingFlags.CreateInstance | BindingFlags.Public);

            Assembly currentAsm = Assembly.GetExecutingAssembly();

            var types = currentAsm.GetTypes().Where(w => w.IsInterface == false
            && w.IsClass == true
            && w.Name.EndsWith("ViewModel"));

            foreach (var reg_type in types)
            {
                var rtinvoker_isRegister = IsRegisteredMethod.MakeGenericMethod(reg_type.BaseType);
                var rtinvoker_Register = RegisterMethod.MakeGenericMethod(reg_type);

                if (!(bool)rtinvoker_isRegister.Invoke(SimpleIoc.Default, new object[] { }))
                {
                    rtinvoker_Register.Invoke(SimpleIoc.Default, new object[] { });
                }
            }

            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<LoginViewModel>();
            //SimpleIoc.Default.Register<UserViewModel>();
            //SimpleIoc.Default.Register<ProjectListViewModelCollection>();
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

        /// <summary>
        /// Gets the 登入畫面檢視模型 property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

    

        /// <summary>
        /// Gets the UserAccount property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserViewModel UserAccount
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }
    }
}