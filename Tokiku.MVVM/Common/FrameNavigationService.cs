using GalaSoft.MvvmLight.Ioc;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tokiku.MVVM
{
    public class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        //log4net
        static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields
        private static Dictionary<string, Uri> _pagesByKey;
        private static Dictionary<string, Type> _elementByKey;
        private static List<string> _historic;
        private string _currentPageKey;
        #endregion

        #region Properties                                              
        public string CurrentPageKey
        {
            get
            {
                try
                {
                    return _currentPageKey;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                    return null;
                }
            }

            private set
            {
                try
                {
                    if (_currentPageKey == value)
                    {
                        return;
                    }

                    _currentPageKey = value;
                    OnPropertyChanged("CurrentPageKey");
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);

                }
            }
        }
        public object Parameter { get; private set; }



        #endregion

        #region Ctors and Methods
        public FrameNavigationService()
        {
            try
            {
                _pagesByKey = new Dictionary<string, Uri>();
                _elementByKey = new Dictionary<string, Type>();
                _historic = new List<string>();
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);

            }

        }

        public void GoBack()
        {
            try
            {
                if (_historic.Count > 1)
                {
                    _historic.RemoveAt(_historic.Count - 1);
                    NavigateTo(_historic.Last(), null);
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);

            }

        }

        public void NavigateTo(string pageKey)
        {
            try
            {
                NavigateTo(pageKey, null);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            try
            {
                NavigateTo(pageKey, parameter, false);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        public void Configure(string key, Uri pageType, Type elementtype = null)
        {
            try
            {
                lock (_pagesByKey)
                {
                    if (_pagesByKey.ContainsKey(key))
                    {
                        _pagesByKey[key] = pageType;
                        _elementByKey[key] = elementtype;
                    }
                    else
                    {
                        _pagesByKey.Add(key, pageType);
                        _elementByKey.Add(key, elementtype);

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {

            try
            {
                //尋找子元素
                var count = VisualTreeHelper.GetChildrenCount(parent);

                if (count < 1)
                {
                    return null;
                }

                for (var i = 0; i < count; i++)
                {
                    var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;

                    if (frameworkElement != null)
                    {
                        if (frameworkElement.Name == name)
                        {
                            return frameworkElement;
                        }

                        frameworkElement = GetDescendantFromName(frameworkElement, name);
                        if (frameworkElement != null)
                        {
                            return frameworkElement;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                return null;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        public void NavigateTo(string pageKey, object parameter, bool isModal)
        {
            try
            {
                lock (_pagesByKey)
                {
                    if (!_pagesByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                    }

                    var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

                    if (frame != null)
                    {
                        frame.Source = _pagesByKey[pageKey];
                    }
                    else
                    {
                        try
                        {
                            var lastwin = Application.Current.MainWindow;

                            Window win = (Window)SimpleIoc.Default.GetInstance(_elementByKey[pageKey]);

                            Application.Current.MainWindow = win;

                            if (isModal)
                            {
                                win.ShowDialog();
                            }
                            else
                            {
                                lastwin.Close();
                                win.Show();
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                    }

                    Parameter = parameter;
                    _historic.Add(pageKey);
                    CurrentPageKey = pageKey;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        public void AutoConfigure()
        {
            try
            {
                Assembly currentasm = Assembly.GetEntryAssembly();
                _elementByKey = currentasm.GetTypes().Where(w => w.BaseType == typeof(Window) || w.BaseType == typeof(Page)).ToDictionary(x => x.Name);
                _pagesByKey = _elementByKey.ToDictionary(x => x.Key, y => new Uri(string.Format("/{0}/{1}.xaml", y.Value.Namespace.Replace(".", "/"), y.Value.Name), UriKind.Relative));
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }
        #endregion
    }
}