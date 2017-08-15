using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
      
        public App()
        {
           
            
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

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
                catch (UnauthorizedAccessException)
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

            }
            catch(Exception ex)
            {
                Log.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);

            }
        }

       
    }
}
