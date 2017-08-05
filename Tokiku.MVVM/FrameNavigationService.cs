using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tokiku.MVVM
{
    public class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        #region Fields
        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly Dictionary<string, Type> _elementByKey;
        private readonly List<string> _historic;
        private string _currentPageKey;
        #endregion

        #region Properties                                              
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                if (_currentPageKey == value)
                {
                    return;
                }

                _currentPageKey = value;
                OnPropertyChanged("CurrentPageKey");
            }
        }
        public object Parameter { get; private set; }



        #endregion
        #region Ctors and Methods
        public FrameNavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _elementByKey = new Dictionary<string, Type>();
            _historic = new List<string>();
        }
        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);
                NavigateTo(_historic.Last(), null);
            }
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
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
                    Type tIoC = typeof(SimpleIoc);

                    try
                    {
                        var methodinfo = tIoC.GetMethods().Where(w => w.Name == "GetInstance"
                    && w.GetParameters().Any(a => a.ParameterType == typeof(string))
                    && w.GetGenericArguments().Count() == 1).Single().MakeGenericMethod(_elementByKey[pageKey]);

                        var lastwin = Application.Current.MainWindow;

                        Window win = (Window)methodinfo.Invoke(SimpleIoc.Default, new object[] { pageKey });
                        
                        Application.Current.MainWindow = win;

                        lastwin.Close();
                        win.Show();
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

        public void Configure(string key, Uri pageType, Type elementtype = null)
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

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}