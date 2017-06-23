using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;

namespace TokikuNew
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private static Collection<object> _IoC;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                _IoC = new Collection<object>();

                _IoC.Add(new ClientController());
                _IoC.Add(new ProjectsController());
                _IoC.Add(new StartUpWindowController());
                _IoC.Add(new ManufacturersManageController());
                _IoC.Add(new SystemController());
                _IoC.Add(new MainWindowController());
                _IoC.Add(new PaymentTypesManageController());

               
            }
            catch
            {


            }
        }

        public static TController Resolve<TController>() where TController : class
        {
            try
            {
                var result = _IoC.OfType<TController>();
                if (result.Any())
                {
                    return result.First();
                }
                return null;
            }
            catch
            {
                return default(TController);

            }
        }



        public static TWin Navigate<TWin, TView>(TView Model) where TWin : Window where TView : Tokiku.ViewModels.IBaseViewModel
        {
            try
            {
                Type windowType = typeof(TWin);
                TWin window = default(TWin);

                var ctors = windowType.GetConstructors();
                if (ctors.Any())
                {
                    foreach (var ctor in ctors.OrderByDescending(s => s.GetParameters().Length))
                    {
                        var parameters = ctor.GetParameters();

                        Type[] inParamArrayTypes = parameters.Select(s => s.ParameterType).ToArray();
                        if (inParamArrayTypes != null)
                        {
                            object[] inParamArray = (object[])Array.CreateInstance(typeof(object), inParamArrayTypes.Length);


                            for (int i = 0; i < inParamArray.Length; i++)
                            {
                                var result = _IoC.Where(w => inParamArrayTypes[i] == w.GetType());
                                inParamArray[i] = result.SingleOrDefault();
                            }

                            try
                            {
                                window = (TWin)Activator.CreateInstance(windowType, inParamArray);
                                break;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }

                if (window == null)
                    throw new NullReferenceException();

                window.DataContext = Model;
                window.Show();
                return window;
            }
            catch (Exception ex)
            {
                if (Model == null)
                    Model = Activator.CreateInstance<TView>();

                Model.Errors = new string[] { ex.Message, ex.StackTrace };
                return default(TWin);
            }
        }
    }
}
