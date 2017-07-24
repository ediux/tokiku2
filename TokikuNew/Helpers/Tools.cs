using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TokikuNew.Helpers
{
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
