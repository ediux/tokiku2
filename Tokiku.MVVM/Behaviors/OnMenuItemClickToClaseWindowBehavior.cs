using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Tokiku.MVVM.Behaviors
{
    public class OnMenuItemClickToClaseWindowBehavior : Behavior<MenuItem>
    {


        public Window WindowInstance
        {
            get { return (Window)GetValue(WindowInstanceProperty); }
            set { SetValue(WindowInstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowInstanceProperty =
            DependencyProperty.Register("WindowInstance", typeof(Window), typeof(OnMenuItemClickToClaseWindowBehavior), new PropertyMetadata(null));



        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (WindowInstance != null)
                WindowInstance.Close();
            else
                Application.Current.Shutdown();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
    }
}
