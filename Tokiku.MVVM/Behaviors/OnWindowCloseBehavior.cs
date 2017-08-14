using GalaSoft.MvvmLight.Ioc;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;

namespace Tokiku.MVVM.Behaviors
{
    public class OnWindowCloseBehavior : Behavior<Window>
    {


        public static Type GetCoreDataServiceType(DependencyObject obj)
        {
            return (Type)obj.GetValue(CoreDataServiceTypeProperty);
        }

        public static void SetCoreDataServiceType(DependencyObject obj, Type value)
        {
            obj.SetValue(CoreDataServiceTypeProperty, value);
        }

        // Using a DependencyProperty as the backing store for CoreDataServiceType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoreDataServiceTypeProperty =
            DependencyProperty.RegisterAttached("CoreDataServiceType", typeof(Type), typeof(OnWindowCloseBehavior), new PropertyMetadata(null));



        protected override void OnAttached()
        {
            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Type InstanceImpType = GetCoreDataServiceType((DependencyObject)sender);
                MethodInfo logoutfunc = InstanceImpType.GetMethod("Logout", new Type[] { });

                var instance = SimpleIoc.Default.GetInstance(InstanceImpType);

                if (logoutfunc != null)
                    logoutfunc.Invoke(instance, new object[] { });

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