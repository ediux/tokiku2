using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TokikuNew.Controls
{
    /// <summary>
    /// SearchBar.xaml 的互動邏輯
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(SearchEvent, tbSearchBar.Text));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        /// <summary>
        /// 引發搜尋的事件
        /// </summary>
        public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent("Search", RoutingStrategy.Bubble
          , typeof(RoutedEventHandler), typeof(SearchBar));

        /// <summary>
        /// 引發搜尋的事件
        /// </summary>
        public event RoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        /// <summary>
        /// 引發重設搜尋條件的事件
        /// </summary>
        public static readonly RoutedEvent ResetSearchEvent = EventManager.RegisterRoutedEvent("ResetSearch", RoutingStrategy.Bubble
    , typeof(RoutedEventHandler), typeof(SearchBar));

        /// <summary>
        /// 引發重設搜尋條件的事件
        /// </summary>
        public event RoutedEventHandler ResetSearch
        {
            add { AddHandler(ResetSearchEvent, value); }
            remove { RemoveHandler(ResetSearchEvent, value); }
        }

        /// <summary>
        /// 引發重新整理事件
        /// </summary>
        public static readonly RoutedEvent RefreshResultEvent = EventManager.RegisterRoutedEvent("RefreshResult", RoutingStrategy.Bubble
    , typeof(RoutedEventHandler), typeof(SearchBar));

        /// <summary>
        /// 引發重新整理事件
        /// </summary>
        public event RoutedEventHandler RefreshResult
        {
            add { AddHandler(RefreshResultEvent, value); }
            remove { RemoveHandler(RefreshResultEvent, value); }
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (e.Key == Key.Enter)
                {
                    RaiseEvent(new RoutedEventArgs(SearchEvent, tbSearchBar.Text));
                }
                else
                {
                    if (e.Key == Key.Escape)
                    {
                        RaiseEvent(new RoutedEventArgs(ResetSearchEvent, tbSearchBar));
                        tbSearchBar.Text = "";
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(RefreshResultEvent, tbSearchBar.Text));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
    }
}
