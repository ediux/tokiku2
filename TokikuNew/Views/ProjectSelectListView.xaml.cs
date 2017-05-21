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


    }
}
