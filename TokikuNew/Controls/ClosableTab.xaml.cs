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
    public class ClosableTabItem : TabItem
    {
        public ClosableTabItem()
        {

            var headerobj = new ClosableTab();
            headerobj.OnPageClosing += Headerobj_OnPageClosing;
            headerobj.DataContext = this.Header;
            this.Header = headerobj;
        }

        private void Headerobj_OnPageClosing(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnPageClosingEvent));
        }

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClosableTabItem));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }
    }
    /// <summary>
    /// ClosableTab.xaml 的互動邏輯
    /// </summary>
    public partial class ClosableTab : UserControl
    {
        public ClosableTab()
        {
            InitializeComponent();
        }

        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnPageClosingEvent));
        }

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClosableTab));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

    }
}
