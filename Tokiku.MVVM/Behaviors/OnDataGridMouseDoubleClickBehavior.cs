using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Behaviors
{
    public class OnDataGridMouseDoubleClickBehavior : Behavior<DataGrid>
    {
        public string TabControlChannellName
        {
            get { return (string)GetValue(TabControlChannellNameProperty); }
            set { SetValue(TabControlChannellNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabControlName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabControlChannellNameProperty =
            DependencyProperty.Register("TabControlChannellName", typeof(string), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata(string.Empty));


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



        public string DataChannelName
        {
            get { return (string)GetValue(DataChannelNameProperty); }
            set { SetValue(DataChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataChannelNameProperty =
            DependencyProperty.Register("DataChannelName", typeof(string), typeof(OnDataGridMouseDoubleClickBehavior), new PropertyMetadata(string.Empty));

        //log4net
        static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnAttached()
        {
            try
            {
                AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ITabViewModel tab = SimpleIoc.Default.GetInstanceWithoutCaching<ICloseableTabViewModel>();

            tab.ContentView = SimpleIoc.Default.GetInstance(ViewType);

            tab.ViewType = ViewType;

            if (Fields != null)
            {
                Type itemtype = AssociatedObject.SelectedItem.GetType();

                int i = 0;

                Dictionary<int, KeyValuePair<string, object>> mapping = itemtype.GetProperties().Where(s => Fields.Contains(s.Name))
                    .ToDictionary(s => i++, v => new KeyValuePair<string, object>(v.Name, v.GetValue(AssociatedObject.SelectedItem)));

                //用正規表示式檢查並替換
                tab.Header = string.Format(Header, mapping.OrderBy(o => o.Key).Select(s => s.Value.Value).ToArray());

                foreach (int FieldOrder in mapping.Keys)
                {
                    ViewType.GetProperty(mapping[FieldOrder].Key)?.SetValue(tab.ContentView, mapping[FieldOrder].Value);
                }
            }
            else
            {
                tab.Header = Header;
            }

            tab.SelectedObject = AssociatedObject.SelectedItem;
            
            tab.TabControlName = TabControlChannellName;

            var msg = new NotificationMessage<ITabViewModel>(sender, tab, "OpenTab");
            Messenger.Default.Send(msg);
            //Messenger.Default.Send((ITabViewModel)tab, (!string.IsNullOrEmpty(TabControlChannellName)) ? TabControlChannellName : "TabControl");
            //Messenger.Default.Send(AssociatedObject.SelectedItem, DataChannelName);

        }

        protected override void OnDetaching()
        {
            try
            {
                AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }
        }
    }
}
