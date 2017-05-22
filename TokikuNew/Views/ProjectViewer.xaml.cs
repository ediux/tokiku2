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
    /// ProjectViewer.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectViewer : UserControl
    {
        private ProjectsController controller = new ProjectsController();

        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ProjectBaseViewModel), typeof(ProjectViewer), new PropertyMetadata(default(ProjectBaseViewModel)));

        public ProjectBaseViewModel Model
        {
            get { return GetValue(ModelProperty) as ProjectBaseViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion

        public ProjectViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = Model;                
        }
    }
}
