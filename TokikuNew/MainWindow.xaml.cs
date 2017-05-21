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
using Tokiku.ViewModels;

namespace TokikuNew
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 相依屬性
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(MainViewModel), typeof(MainViewModel), new PropertyMetadata(default(MainViewModel)));

        public MainViewModel Model
        {
            get { return GetValue(ModelProperty) as MainViewModel; }
            set { SetValue(ModelProperty, value); }
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            Model = new MainViewModel();
        }

        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            Workspaces.Items.Remove(Workspaces.SelectedItem);
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MI_Project_Click(object sender, RoutedEventArgs e)
        {
            //顯示選擇專案的視窗
            Frame.ProjectSelectionWindow projectSelectionWin = new Frame.ProjectSelectionWindow();
            if (projectSelectionWin.ShowDialog().HasValue && projectSelectionWin.SelectedProject != null)
            {
                MI_Project.Header = string.Format("專案:{0}-{1}", projectSelectionWin.SelectedProject.Code, projectSelectionWin.SelectedProject.ShortName);

                TabItem addWorkarea = new TabItem();


                bool isExisted = false;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(MI_Project.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {
                    addWorkarea.Header = MI_Project.Header;

                    var vm = new Views.ProjectViewer() { Margin = new Thickness(0) };
                    vm.Model = new ProjectBaseViewModel();
                    vm.Model.QueryModel(projectSelectionWin.SelectedProject.Id);
                    vm.Model.LoginedUser = Model.LoginedUser;
                    vm.DataContext = vm.Model;

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Workspaces.Items.Add(addWorkarea);
                    Workspaces.SelectedItem = addWorkarea;
                }
                else
                {

                    Workspaces.SelectedItem = addWorkarea;
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Workspaces.Items.Clear();
        }

        private void MI_CreateNew_Project_Click(object sender, RoutedEventArgs e)
        {
            TabItem addWorkarea = new TabItem();
            addWorkarea.Header = "建立專案";
            var vm = new Views.CreateProjectView() { Margin = new Thickness(0), Model = new ProjectBaseViewModel() };
            vm.Model.LoginedUser = Model.LoginedUser;
            vm.DataContext = vm.Model;
            addWorkarea.Content = vm;
            addWorkarea.Margin = new Thickness(0);

            Workspaces.Items.Add(addWorkarea);
            Workspaces.SelectedItem = addWorkarea;
        }

        private void MI_CreateNew_Factories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_CreateNew_Contracts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_CreateNew_Customers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
