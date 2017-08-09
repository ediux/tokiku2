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
        protected override void OnAttached()
        {
            AssociatedObject.Initialized += AssociatedObject_Initialized;
            Messenger.Default.Register<ITabViewModel>(AssociatedObject, "TabItem_Close_View", (x) =>
            {
                //var removeitem = ((ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource).Where(w => w.Header == x).Single();
                ((ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource).Remove(x);
            });
        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            Messenger.Default.Register<ITabViewModel>(AssociatedObject, AssociatedObject.Name ?? "TabControl", (s) =>
                {
                    if (AssociatedObject.ItemsSource is ObservableCollection<ITabViewModel>)
                    {
                        ObservableCollection<ITabViewModel> source = (ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource;

                        if (!source.Any(w => w.Header == s.Header))
                        {
                            source.Add(s);
                            AssociatedObject.SelectedItem = s;
                            //if (s is IFixedTabViewModel)
                            //{
                            //    TabItem fixedItem = new TabItem()
                            //    {
                            //        Header = s.Header,
                            //        Content = s.ContentView
                            //    };
                            //    AssociatedObject.Items.Add(fixedItem);
                            //    AssociatedObject.SelectedItem = fixedItem;
                            //}
                            //if(s is ICloseableTabViewModel)
                            //{
                            //    Controls.ClosableTabItem dytabliem = new Controls.ClosableTabItem() {
                            //        Header = s.Header,
                            //        Content = s.ContentView
                            //    };
                            //    AssociatedObject.Items.Add(dytabliem);
                            //    AssociatedObject.SelectedItem = dytabliem;
                            //}
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
