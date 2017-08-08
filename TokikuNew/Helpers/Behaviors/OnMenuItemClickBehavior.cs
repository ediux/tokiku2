using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using Tokiku.ViewModels;

namespace TokikuNew.Helpers
{
    public class OnMenuItemClickBehavior : Behavior<MenuItem>
    {


        public ObservableCollection<ITabViewModel> PageContainer
        {
            get { return (ObservableCollection<ITabViewModel>)GetValue(PageContainerProperty); }
            set { SetValue(PageContainerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageContainer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageContainerProperty =
            DependencyProperty.Register("PageContainer", typeof(ObservableCollection<ITabViewModel>), typeof(OnMenuItemClickBehavior), new PropertyMetadata(null));



        public string TabControlName
        {
            get { return (string)GetValue(TabControlNameProperty); }
            set { SetValue(TabControlNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabControlName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabControlNameProperty =
            DependencyProperty.Register("TabControlName", typeof(string), typeof(OnMenuItemClickBehavior), new PropertyMetadata(string.Empty));




        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(OnMenuItemClickBehavior), new PropertyMetadata("未命名"));



        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext != null)
            {
                if (PageContainer != null)
                {
                    ITabViewModel tab = new FixedTabViewModel();

                    tab.Header = Header;
                    tab.ContentView = AssociatedObject.DataContext;

                    if (!PageContainer.Contains(tab))
                    {
                        PageContainer.Add(tab);
                    }
                    else
                    {
                        int i = PageContainer.IndexOf(tab);
                        tab = PageContainer[i];
                        
                        //TabControl tabctl = (TabControl)((FrameworkElement)this).FindName(TabControlName);
                    }

                }
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
