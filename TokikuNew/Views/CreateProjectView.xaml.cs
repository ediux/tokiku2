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
    /// CreateProjectView.xaml 的互動邏輯
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ProjectBaseViewModel), typeof(CreateProjectView), new PropertyMetadata(default(ProjectBaseViewModel)));

        public ProjectBaseViewModel Model
        {
            get { return GetValue(ModelProperty) as ProjectBaseViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion

        public CreateProjectView()
        {
            InitializeComponent();

            Model = new ProjectBaseViewModel();
            this.DataContext = Model;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ProjectsController controller = new ProjectsController();
            Projects newProject = new Projects();
            newProject.ClientId = Model.ClientId;
            newProject.Code = Model.Code;
            newProject.CreateTime = Model.CreateTime = DateTime.Now;
            newProject.CreateUserId = Model.LoginedUser.UserId;
            newProject.Name = Model.Name;
            newProject.ProjectSigningDate = Model.ProjectSigningDate;
            newProject.ShortName = Model.ShortName;
            newProject.SiteAddress = Model.SiteAddress;
            newProject.Comment = Model.Comment;
            controller.Add(newProject);
            Model = new ProjectBaseViewModel();
        }
    }
}
