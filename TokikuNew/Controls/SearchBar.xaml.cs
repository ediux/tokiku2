using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            RaiseEvent(new RoutedEventArgs(SearchEvent, tbSearchBar.Text));
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

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
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
    }
}
