using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace TokikuNew.Helpers
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



        public string[] Fields
        {
            get { return (string[])GetValue(FieldsProperty); }
            set { SetValue(FieldsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fields.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldsProperty =
            DependencyProperty.Register("Fields", typeof(string[]), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata(default(string[])));


        protected override void OnAttached()
        {
            AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
        }

        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ITabViewModel tab = new CloseableTabViewModel();

            if (Fields != null)
            {
                Type itemtype = AssociatedObject.SelectedItem.GetType();
                object[] values = itemtype.GetProperties().Where(s => Fields.Contains(s.Name)).Select(s => s.GetValue(AssociatedObject.SelectedItem)).ToArray();
                tab.Header = string.Format(Header, values);
            }
            else
            {
                tab.Header = Header;
            }

            tab.ContentView = SimpleIoc.Default.GetInstance(ViewType);
            tab.ViewType = ViewType;
            ((FrameworkElement)tab.ContentView).DataContext = AssociatedObject.SelectedItem;
            Messenger.Default.Send(tab, TabControlName);
            Messenger.Default.Send((IBaseViewModel)AssociatedObject.SelectedItem);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
        }
    }
}
