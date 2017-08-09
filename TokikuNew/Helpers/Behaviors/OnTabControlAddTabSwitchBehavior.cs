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
using Tokiku.ViewModels;

namespace TokikuNew.Helpers
{
    public class OnTabControlAddTabSwitchBehavior : Behavior<TabControl>
    {
        public string ChannelName
        {
            get { return (string)GetValue(ChannelNameProperty); }
            set { SetValue(ChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChannelNameProperty =
            DependencyProperty.Register("ChannelName", typeof(string), typeof(OnTabControlAddTabSwitchBehavior), new PropertyMetadata(string.Empty));

        protected override void OnAttached()
        {
            AssociatedObject.Initialized += AssociatedObject_Initialized;

           
        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            Messenger.Default.Register<ITabViewModel>(AssociatedObject, "TabItem_Close_View", (x) =>
            {
                ((ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource).Remove(x);
            });

            Messenger.Default.Register<ITabViewModel>(AssociatedObject, AssociatedObject.Name ?? "TabControl", (s) =>
                {
                    if (AssociatedObject.ItemsSource is ObservableCollection<ITabViewModel>)
                    {
                        ObservableCollection<ITabViewModel> source = (ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource;

                        if (!source.Any(w => w.Header == s.Header))
                        {
                            source.Add(s);
                            AssociatedObject.SelectedItem = s;                          
                        }
                        else
                        {
                            var tab = source.Single(w => w.Header == s.Header);
                            AssociatedObject.SelectedItem = tab;
                        }
                    }
                });
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<ITabViewModel>(AssociatedObject);
            AssociatedObject.Initialized -= AssociatedObject_Initialized;
        }
    }
}
