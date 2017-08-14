using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Behaviors
{
    public class OnMenuItemClickBehavior : Behavior<MenuItem>
    {

        public string TabControlChannellName
        {
            get { return (string)GetValue(TabControlChannellNameProperty); }
            set { SetValue(TabControlChannellNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabControlName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabControlChannellNameProperty =
            DependencyProperty.Register("TabControlChannellName", typeof(string), typeof(OnMenuItemClickBehavior), new PropertyMetadata(string.Empty));




        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(OnMenuItemClickBehavior), new PropertyMetadata("未命名"));




        public Type ViewType
        {
            get { return (Type)GetValue(ViewTypeProperty); }
            set { SetValue(ViewTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.Register("ViewType", typeof(Type), typeof(OnMenuItemClickBehavior), new PropertyMetadata(null));



        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();

            tab.Header = Header;

            //if (AssociatedObject.DataContext != null)
            //{
            //    tab.ContentView = AssociatedObject.DataContext;
            //    tab.ViewType = AssociatedObject.DataContext?.GetType();
            //}
            //else
            //{
                tab.ContentView = SimpleIoc.Default.GetInstance(ViewType);
                tab.ViewType = ViewType;
            //}

            tab.TabControlName = TabControlChannellName;

            var msg = new NotificationMessage<ITabViewModel>(sender, tab, "OpenTab");
            Messenger.Default.Send(msg);
            //Messenger.Default.Send(tab, TabControlChannellName);

        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
