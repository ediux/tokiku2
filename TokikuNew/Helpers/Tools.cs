using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using Tokiku.Entity;

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
                Tokiku.DataServices.DefaultLocator.Current.UsersDataService.Logout();
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

    public class TabOnEnterBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                AssociatedObject.MoveFocus(request);
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }

    }

    public class TabOnEnterBehaviorForPassword : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                AssociatedObject.MoveFocus(request);
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
    }

    public class PasswordChangedBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            AssociatedObject.DataContext = AssociatedObject.Password;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }
    }



    public static class Tools
    {
        public static void MoveToNextUIElement(this Control target, KeyEventArgs e)
        {
            try
            {
                // Creating a FocusNavigationDirection object and setting it to a
                // local field that contains the direction selected.
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;

                // MoveFocus takes a TraveralReqest as its argument.
                TraversalRequest request = new TraversalRequest(focusDirection);

                // Gets the element with keyboard focus.
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                // Change keyboard focus.
                if (elementWithFocus != null)
                {
                    if (elementWithFocus.MoveFocus(request)) e.Handled = true;
                }
            }
            catch
            {


            }

        }
    }
}
