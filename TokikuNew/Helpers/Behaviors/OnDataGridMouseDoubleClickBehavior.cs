using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace TokikuNew.Helpers.Behaviors
{
    public class OnDataGridMouseDoubleClickBehavior : Behavior<DataGrid>
    {
        public string TabControlName
        {
            get { return (string)GetValue(TabControlNameProperty); }
            set { SetValue(TabControlNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabControlName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabControlNameProperty =
            DependencyProperty.Register("TabControlName", typeof(string), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata(string.Empty));




        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata("未命名"));




        public Type ViewType
        {
            get { return (Type)GetValue(ViewTypeProperty); }
            set { SetValue(ViewTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.Register("ViewType", typeof(Type), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
        }

        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ITabViewModel tab = new FixedTabViewModel();

            tab.Header = Header;

            if (AssociatedObject.DataContext != null)
            {
                tab.ContentView = AssociatedObject.DataContext;
                tab.ViewType = AssociatedObject.DataContext?.GetType();
            }
            else
            {
                tab.ContentView = SimpleIoc.Default.GetInstance(ViewType);
                tab.ViewType = ViewType;
            }

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(tab, TabControlName);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
        }
    }
}
