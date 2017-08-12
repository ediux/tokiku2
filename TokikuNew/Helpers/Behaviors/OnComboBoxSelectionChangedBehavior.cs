using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace TokikuNew.Helpers
{
    public class OnComboBoxSelectionChangedBehavior : Behavior<ComboBox>
    {
        public static IBaseViewModel GetViewModelBinding(DependencyObject obj)
        {
            return (IBaseViewModel)obj.GetValue(ViewModelBindingProperty);
        }

        public static void SetViewModelBinding(DependencyObject obj, IBaseViewModel value)
        {
            obj.SetValue(ViewModelBindingProperty, value);
        }

        // Using a DependencyProperty as the backing store for ViewModelBinding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelBindingProperty =
            DependencyProperty.RegisterAttached("ViewModelBinding", typeof(IBaseViewModel), typeof(OnComboBoxSelectionChangedBehavior), new PropertyMetadata(default(IBaseViewModel)));


        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IBaseViewModel currentModel = GetViewModelBinding(AssociatedObject);

            Type ViewModelType = currentModel?.GetType();

            var foundRelationProperies = ViewModelType?.GetProperties().Where(w => w.Name.StartsWith("RefreshFrom") && w.Name.EndsWith("Command") && w.PropertyType == typeof(ICommand));

            if (foundRelationProperies?.Count() > 0)
            {
                foreach(var RelationProperty in foundRelationProperies)
                {
                    try
                    {
                        ICommand command = RelationProperty.GetValue(currentModel) as ICommand;
                        command?.Execute(e.AddedItems);
                    }
                    catch 
                    {
                        continue;                        
                    }                    
                }
            }

        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }
    }
}
