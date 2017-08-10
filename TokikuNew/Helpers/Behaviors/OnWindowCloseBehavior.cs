using System;
using System.Windows;
using System.Windows.Interactivity;

namespace TokikuNew.Helpers
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
                Tokiku.DataServices.DefaultLocator.Current.CoreDataService.Logout();
            }
            catch (Exception ex)
            {


            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Closing -= AssociatedObject_Closing;
        }
    }

}