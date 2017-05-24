using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace TokikuNew.Controls
{
    public class ClosableTabItem : TabItem
    {
        public ClosableTabItem()
        {
            AddHandler(Button.ClickEvent, new RoutedEventHandler(Headerobj_OnPageClosing));
        }

        private void ClosableTabItem_OnPageClosing(object sender, RoutedEventArgs e)
        {
            RaiseEvent(e);
            e.Handled = true;
        }

        public bool IsPressed
        {
            get { return (bool)GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPressed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.Register("IsPressed", typeof(bool), typeof(ClosableTabItem), new PropertyMetadata(false));

        private void Headerobj_OnPageClosing(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button)
            {
                Button btn = (Button)e.OriginalSource;

                if (btn.Name == "btnTabClose")
                {
                    e.Handled = true;
                    RaiseEvent(new RoutedEventArgs(OnPageClosingEvent,e.OriginalSource));  //重新引發分頁關閉事件
                    return;
                }                            
            }                       
        }

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClosableTabItem));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }
    }
}
