using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ITabViewModel>(AssociatedObject, AssociatedObject.Name ?? "TabControl", (s) =>
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
            AssociatedObject.Initialized -= AssociatedObject_Initialized;
        }
    }
}
