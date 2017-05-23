using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectSelectListView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectSelectListView : UserControl
    {
        private ProjectsController controller = new ProjectsController();

        public ProjectSelectListView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedProjectProperty = DependencyProperty.Register("SelectedProject", typeof(ProjectBaseViewModel), typeof(ProjectSelectListView));

        public ProjectBaseViewModel SelectedProject
        {
            get { return (ProjectBaseViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        public static readonly DependencyProperty CommandClickProperty = DependencyProperty.Register("CommandClick", typeof(string), typeof(ProjectSelectListView));

        public string CommandClick
        {
            get { return (string)GetValue(CommandClickProperty); }
            set { SetValue(CommandClickProperty, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectList.ItemsSource = controller.QueryAll();            
        }

        private void ProjectList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedProject = (ProjectBaseViewModel)e.NewValue;
            RaiseEvent(new RoutedEventArgs(SelectedProjectChangedEvent, SelectedProject));
        }

        public static readonly RoutedEvent SelectedProjectChangedEvent = EventManager.RegisterRoutedEvent(
       "SelectedProjectChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ProjectSelectListView));

        public event RoutedEventHandler SelectedProjectChanged
        {
            add { AddHandler(SelectedProjectChangedEvent, value); }
            remove { RemoveHandler(SelectedProjectChangedEvent, value); }
        }

        // This method raises the Tap event
        protected void RaiseSelectProjectChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ProjectSelectListView.SelectedProjectChangedEvent);
            RaiseEvent(newEventArgs);
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                ProjectList.ItemsSource = controller.SearchByText(SearchBar.Text);
            }
            else
            {
                if(e.Key== Key.Escape)
                {
                    ProjectList.ItemsSource = controller.QueryAll();
                    SearchBar.Text = "";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //搜尋框
            ProjectList.ItemsSource = controller.SearchByText(SearchBar.Text);            
        }

        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var obj = e.AddedItems[0];
                RaiseEvent(new RoutedEventArgs(SelectedProjectChangedEvent, obj));            
            }            
        }
    }
}
