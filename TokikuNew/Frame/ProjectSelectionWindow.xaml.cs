using System.Windows;
using Tokiku.ViewModels;

namespace TokikuNew.Frame
{
    /// <summary>
    /// ProjectSelectionWindow.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectSelectionWindow : Window
    {
        public ProjectSelectionWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedProjectProperty = DependencyProperty.Register("SelectedProject", typeof(ProjectsViewModel), typeof(ProjectSelectionWindow));

        public ProjectsViewModel SelectedProject
        {
            get { return (ProjectsViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        private void ProjectSelectListView_SelectedProjectChanged(object sender, RoutedEventArgs e)
        {
            SelectedProject = (ProjectsViewModel)e.OriginalSource;
            DialogResult = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult != true)
            {
                DialogResult = false;
            }
        }
    }
}
