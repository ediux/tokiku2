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
using System.Windows.Shapes;
using Tokiku.Entity;

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

        public static readonly DependencyProperty SelectedProjectProperty = DependencyProperty.Register("SelectedProject", typeof(Projects), typeof(ProjectSelectionWindow));

        public Projects SelectedProject
        {
            get { return (Projects)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        private void ProjectSelectListView_SelectedProjectChanged(object sender, RoutedEventArgs e)
        {
            SelectedProject = (Projects)e.OriginalSource;
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
