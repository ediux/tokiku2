using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TokikuNew.Helpers
{
    public class OnSaveButtonClickBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;

        }
    }
}
