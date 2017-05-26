using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WinForm = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectManagerView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectManagerView : UserControl
    {
        private ProjectsController controller = new ProjectsController();

        public ProjectManagerView()
        {
            InitializeComponent();
        }

        public ProjectBaseViewModel SelectedProject
        {
            get { return (ProjectBaseViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(ProjectBaseViewModel), typeof(ProjectManagerView), new PropertyMetadata(default(ProjectBaseViewModel)));



        //public ProjectManagerView(ProjectBaseViewModel model) : this()
        //{
        //    ObjectDataProvider _objectDataProvider = this.FindResource("UI_ProjectDataSource") as ObjectDataProvider;

        //    if (_objectDataProvider != null)
        //    {
        //        _objectDataProvider.ObjectType = controller.GetType();
        //        _objectDataProvider.MethodName = "QuerySingle";
        //        _objectDataProvider.MethodParameters.Clear();
        //        _objectDataProvider.MethodParameters.Add(model.Id);
        //        ((ProjectBaseViewModel)_objectDataProvider.Data).LoginedUser = ((MainViewModel)((ObjectDataProvider)DataContext).Data).LoginedUser;
        //    }
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.SaveModel(SelectedProject);
                SelectedProject.CanSave = false;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            SelectedProject.CanEdit = !SelectedProject.CanEdit;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            SelectedProject.CanEdit = false;
            SelectedProject.CanSave = false;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F3)
            {
                if (SelectedProject.CanSave)
                    btnSave_Click(sender, new RoutedEventArgs(e.RoutedEvent));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //註冊關閉事件處理器
            //AddHandler(DockBar.ModifyRequstEvent, new RoutedEventHandler(btnModify_Click));

            //if (SelectedProject == null)
            //{
            //    if(this.DataContext!=null && DataContext is ProjectBaseViewModel)
            //    {
            //        SelectedProject = (ProjectBaseViewModel)DataContext;
            //    }
            //}

            //dbar.DataContext = this.DataContext;
            //if (DataContext != null)
            //{
            //    ObjectDataProvider _objectDataProvider = this.FindResource("UI_ProjectDataSource") as ObjectDataProvider;
            //    //Model = (ProjectBaseViewModel)_objectDataProvider.Data;

            //    //ObjectDataProvider _objectDataProvider2 = PMV.FindResource("UI_ProjectDataSource") as ObjectDataProvider;

            //    if (_objectDataProvider != null && DataContext is ProjectBaseViewModel)
            //    {
            //        _objectDataProvider.ObjectType = typeof(ProjectBaseViewModel);
            //        _objectDataProvider.MethodName = "QuerySingle";
            //        _objectDataProvider.MethodParameters.Clear();
            //        _objectDataProvider.MethodParameters.Add(((ProjectBaseViewModel)DataContext).Id);
            //        ((ProjectBaseViewModel)_objectDataProvider.Data).LoginedUser = ((MainViewModel)((ObjectDataProvider)DataContext).Data).LoginedUser;
            //    }
            //}

            //DataContext = Model;
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SendNewPageRequestEvent, this));
        }

        public static readonly RoutedEvent SendNewPageRequestEvent = EventManager.RegisterRoutedEvent("SendNewPageRequest", RoutingStrategy.Bubble
           , typeof(RoutedEventHandler), typeof(ProjectManagerView));

        public event RoutedEventHandler SendNewPageRequest
        {
            add { AddHandler(SendNewPageRequestEvent, value); }
            remove { RemoveHandler(SendNewPageRequestEvent, value); }
        }
    }
}
