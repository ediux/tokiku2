﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.MVVM;

namespace TokikuNew
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    { 
        static string appGuid = "{25f64493-215e-44aa-a3f3-cf3aed6bb7a0}";
        private static Mutex m;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {

                //如果要做到跨Session唯一，名稱可加入"Global\"前綴字
                //如此即使用多個帳號透過Terminal Service登入系統
                //整台機器也只能執行一份

                bool mutexIsNew = false;
                bool mutexWasCreated;

                string mutexName = "Global\\" + appGuid;

                try
                {
                    m = Mutex.OpenExisting(mutexName);
                }
                catch (WaitHandleCannotBeOpenedException)
                {                  
                    mutexIsNew = true;
                }
                catch (UnauthorizedAccessException ex)
                {                    
                    MessageBox.Show("程式已經在執行中!請關閉另一個相同程式!", "東菊金屬ERP系統", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    Shutdown();

                }


                if (mutexIsNew)
                {
                    //run
                    MutexSecurity mSec = new MutexSecurity();

                    m = new Mutex(true, mutexName, out mutexWasCreated, mSec);

                    // If the named system mutex was created, it can be

                    // used by the current instance of this program, even 

                    // though the current user is denied access. The current

                    // program owns the mutex. Otherwise, exit the program.

                    //

                    if (mutexWasCreated)
                    {
                        Console.WriteLine("Created the mutex.");
                    }
                }
                else
                {
                    //close
                    Shutdown();
                }

                StartUpLocator.StartUp();
                StartUpLocator.Current.NavigationService.AutoConfigure();
            }
            catch
            {


            }
        }

        //public static TController Resolve<TController>() where TController : class
        //{
        //    try
        //    {
        //        var result = _IoC.OfType<TController>();
        //        if (result.Any())
        //        {
        //            return result.First();
        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return default(TController);

        //    }
        //}



        //public static TWin Navigate<TWin, TView>(TView Model) where TWin : Window where TView : Tokiku.ViewModels.IBaseViewModel
        //{
        //    try
        //    {
        //        Type windowType = typeof(TWin);
        //        TWin window = default(TWin);

        //        var ctors = windowType.GetConstructors();
        //        if (ctors.Any())
        //        {
        //            foreach (var ctor in ctors.OrderByDescending(s => s.GetParameters().Length))
        //            {
        //                var parameters = ctor.GetParameters();

        //                Type[] inParamArrayTypes = parameters.Select(s => s.ParameterType).ToArray();
        //                if (inParamArrayTypes != null)
        //                {
        //                    object[] inParamArray = (object[])Array.CreateInstance(typeof(object), inParamArrayTypes.Length);


        //                    for (int i = 0; i < inParamArray.Length; i++)
        //                    {
        //                        var result = _IoC.Where(w => inParamArrayTypes[i] == w.GetType());
        //                        inParamArray[i] = result.SingleOrDefault();
        //                    }

        //                    try
        //                    {
        //                        window = (TWin)Activator.CreateInstance(windowType, inParamArray);
        //                        break;
        //                    }
        //                    catch
        //                    {
        //                        continue;
        //                    }
        //                }
        //            }
        //        }

        //        if (window == null)
        //            throw new NullReferenceException();

        //        window.DataContext = Model;
        //        window.Show();
        //        return window;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Model == null)
        //            Model = Activator.CreateInstance<TView>();

        //        Model.Errors = new string[] { ex.Message, ex.StackTrace };
        //        return default(TWin);
        //    }
        //}
    }
}
