using GalaSoft.MvvmLight.Ioc;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;
using Tokiku.DataServices;

namespace TokikuNew.Behaviors
{
    public class OnWindowCloseBehavior : Behavior<Window>
    {


      
        protected override void OnAttached()
        {
            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DefaultLocator.Current.CoreDataService.Logout();
            }
            catch
            {
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Closing -= AssociatedObject_Closing;
        }
    }

}