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
using System.Windows.Data;
using System.Windows.Interactivity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Behaviors
{
    public class OnTabControlAddTabSwitchBehavior : Behavior<TabControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Initialized += AssociatedObject_Initialized;
        }

        private void AssociatedObject_Initialized(object sender, EventArgs e)
        {
            Messenger.Default.Register<NotificationMessage<ITabViewModel>>(AssociatedObject, ProcessRemoveTab);
            Messenger.Default.Register<NotificationMessage<ITabViewModel>>(AssociatedObject, ProcessAddTab);
        }

        protected virtual void ProcessRemoveTab(NotificationMessage<ITabViewModel> Message)
        {
            if (Message.Content.TabControlName == AssociatedObject.Name && Message.Notification == "CloseTab")
                ((ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource).Remove(Message.Content);
        }

        protected virtual void ProcessAddTab(NotificationMessage<ITabViewModel> Message)
        {
            if (Message.Notification != "OpenTab")
                return;

            if (AssociatedObject.ItemsSource is ObservableCollection<ITabViewModel>)
            {
                ObservableCollection<ITabViewModel> source = (ObservableCollection<ITabViewModel>)AssociatedObject.ItemsSource;

                if (Message.Content.TabControlName == AssociatedObject.Name)
                {
                    if (!source.Any(w => w.Header == Message.Content.Header))
                    {
                        source.Add(Message.Content);
                        AssociatedObject.SelectedItem = Message.Content;
                    }
                    else
                    {
                        var tab = source.Single(w => w.Header == Message.Content.Header);
                        AssociatedObject.SelectedItem = tab;
                    }
                }

                if (Message.Content.ContentView == null)
                {
                    if (Message.Content.ViewType != null)
                        Message.Content.ContentView = SimpleIoc.Default.GetInstanceWithoutCaching(Message.Content.ViewType);
                    else
                        return;
                }

                UserControl element = (UserControl)Message.Content.ContentView;

                if (Message.Content.SelectedObject != null)
                {
                    if (Message.Content.ContentView is UserControl)
                    {

                        Type DataModelType = Message.Content.DataModelType ??
                            ((!(element.DataContext is IFixedTabViewModel) && !(element.DataContext is ICloseableTabViewModel)) ? element.DataContext.GetType() : null);


                        element.DataContext = SimpleIoc.Default.GetInstanceWithoutCaching(Message.Content.DataModelType);

                        var DataPassMessage = new NotificationMessage<IBaseViewModel>(Message.Sender,
                            element.DataContext,
                            (IBaseViewModel)Message.Content.SelectedObject,
                              "Pass");

                        Messenger.Default.Send(DataPassMessage);

                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<NotificationMessage<ITabViewModel>>(AssociatedObject, ProcessRemoveTab);
            Messenger.Default.Unregister<NotificationMessage<ITabViewModel>>(AssociatedObject, ProcessAddTab);
            AssociatedObject.Initialized -= AssociatedObject_Initialized;
        }
    }
}
