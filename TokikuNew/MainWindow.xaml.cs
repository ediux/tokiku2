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
using Tokiku.Entity;
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
            this.DataContext = Model;
        }

        /// <summary>
        /// 當關閉分頁時觸發的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabItem currentworking = (TabItem)Workspaces.SelectedItem;

                if (currentworking != null)
                {
                    if (currentworking.Content is Views.ProjectManagerView)
                    {
                        Views.ProjectManagerView vm = currentworking.Content as Views.ProjectManagerView;
                        if (vm.Model.IsModify && vm.Model.IsSaved == false)
                        {
                            if (MessageBox.Show("您有變更尚未儲存，是否更新?", "關閉前確認", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                vm.Model.SaveModel();
                            }
                        }
                    }

                    if (currentworking.Content is Views.ProjectViewer)
                    {
                        Views.ProjectViewer vm = currentworking.Content as Views.ProjectViewer;
                        if (vm.Model.IsModify && vm.Model.IsSaved == false)
                        {
                            if (MessageBox.Show("您有變更尚未儲存，是否更新?", "關閉前確認", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                vm.Model.SaveModel();
                            }
                        }
                    }

                }
                Workspaces.Items.Remove(Workspaces.SelectedItem);
                Model.CurrentProject = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MI_Project_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //顯示選擇專案的視窗
                Frame.ProjectSelectionWindow projectSelectionWin = new Frame.ProjectSelectionWindow();
                if (projectSelectionWin.ShowDialog().HasValue && projectSelectionWin.SelectedProject != null)
                {
                    //MI_Project.Header = string.Format("專案:{0}-{1}", projectSelectionWin.SelectedProject.Code, projectSelectionWin.SelectedProject.ShortName);
                    string TabName = string.Format("專案:{0}-{1}", projectSelectionWin.SelectedProject.Code, projectSelectionWin.SelectedProject.ShortName);
                    Model.CurrentProject = new ProjectBaseViewModel();
                    Model.CurrentProject.QueryModel(projectSelectionWin.SelectedProject.Id);

                    TabItem addWorkarea = new TabItem();


                    bool isExisted = false;

                    foreach (TabItem item in Workspaces.Items)
                    {
                        if (item.Header.Equals(TabName))
                        {
                            isExisted = true;
                            addWorkarea = item;
                            break;
                        }
                    }

                    if (!isExisted)
                    {
                        addWorkarea.Header = TabName;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MI_CreateNew_Project_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabItem addWorkarea = new TabItem();
                addWorkarea.Header = "專案主檔";

                //if (Model.CurrentProject != null)
                //{
                //    var vm = new Views.ProjectManagerView() { Margin = new Thickness(0) };
                //    vm.Model = Model.CurrentProject;
                //    vm.Model.LoginedUser = Model.LoginedUser;
                //    vm.DataContext = vm.Model;
                //    vm.Model.IsNew = false;
                //    vm.Model.DisabledEditor();
                //    addWorkarea.Content = vm;
                //    addWorkarea.Margin = new Thickness(0);

                //    Workspaces.Items.Add(addWorkarea);
                //    Workspaces.SelectedItem = addWorkarea;
                //}
                //else
                //{
                var vm = new Views.ProjectManagerView() { Margin = new Thickness(0), Model = new ProjectBaseViewModel() };
                vm.Model.LoginedUser = Model.LoginedUser;

                if (Model.CurrentProject == null)
                {
                    vm.Model.IsNew = true;
                    vm.Model.EnableEditor();
                }
                else
                {
                    vm.Model.IsNew = false;
                    vm.Model.DisabledEditor();
                }

                vm.DataContext = vm.Model;
                addWorkarea.Content = vm;
                addWorkarea.Margin = new Thickness(0);

                Workspaces.Items.Add(addWorkarea);
                Workspaces.SelectedItem = addWorkarea;
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void MI_CreateNew_Factories_Click(object sender, RoutedEventArgs e)
        {
            string Header = "廠商主檔";
            TabItem addWorkarea = new TabItem();
            bool isExisted = false;

            foreach (TabItem item in Workspaces.Items)
            {
                if (item.Header.Equals(Header))
                {
                    isExisted = true;
                    addWorkarea = item;
                    break;
                }
            }

            if (!isExisted)
            {
                addWorkarea.Header = Header;

                var vm = new Views.ManufacturersManageView() { Margin = new Thickness(0) };       
                vm.OnPageClosing += Vm_OnPageClosing;
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

        private void MI_CreateNew_Contracts_Click(object sender, RoutedEventArgs e)
        {
            string Header = "廠商主檔-聯絡人管理";
            TabItem addWorkarea = new TabItem();
            bool isExisted = false;

            foreach (TabItem item in Workspaces.Items)
            {
                if (item.Header.Equals(Header))
                {
                    isExisted = true;
                    addWorkarea = item;
                    break;
                }
            }

            if (!isExisted)
            {
                addWorkarea.Header = Header;

                var vm = new Views.ContactPersonManageView() { Margin = new Thickness(0) };
                //vm.Model = new ContactsViewModel();
                //vm.Model.IsNew = true;                
                //vm.Model.LoginedUser = Model.LoginedUser;
                //vm.DataContext = vm.Model;             

                vm.OnPageClosing += Vm_OnPageClosing;
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

        private void Vm_OnPageClosing(object sender, RoutedEventArgs e)
        {
            btnTabClose_Click(sender, e);
        }

        private void MI_CreateNew_Customers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_SystemOption_Click(object sender, RoutedEventArgs e)
        {
            Frame.OptionWindow optwin = new Frame.OptionWindow();
            optwin.ShowDialog();
        }

        private void ProjectSelectionPage_SelectedProjectChanged(object sender, RoutedEventArgs e)
        {
            Model.CurrentProject = new ProjectBaseViewModel();
            ProjectSelectionPage.SelectedProject = e.OriginalSource as Projects;
            Model.CurrentProject.QueryModel(ProjectSelectionPage.SelectedProject.Id);

            string Header = string.Format("專案:{0}-{1}", ProjectSelectionPage.SelectedProject.Code, ProjectSelectionPage.SelectedProject.ShortName);
            Model.CurrentProject = new ProjectBaseViewModel();
            Model.CurrentProject.QueryModel(ProjectSelectionPage.SelectedProject.Id);

            TabItem addWorkarea = new TabItem();


            bool isExisted = false;

            foreach (TabItem item in Workspaces.Items)
            {
                if (item.Header.Equals(Header))
                {
                    isExisted = true;
                    addWorkarea = item;
                    break;
                }
            }

            if (!isExisted)
            {
                addWorkarea.Header = Header;

                var vm = new Views.ProjectViewer() { Margin = new Thickness(0) };
                vm.Model = new ProjectBaseViewModel();
                vm.Model.QueryModel(ProjectSelectionPage.SelectedProject.Id);
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

        private void MI_CreateNew_Customers_Contracts_Click(object sender, RoutedEventArgs e)
        {
            string Header = "客戶主檔-聯絡人管理";
            TabItem addWorkarea = new TabItem();
            bool isExisted = false;

            foreach (TabItem item in Workspaces.Items)
            {
                if (item.Header.Equals(Header))
                {
                    isExisted = true;
                    addWorkarea = item;
                    break;
                }
            }

            if (!isExisted)
            {
                addWorkarea.Header = Header;

                var vm = new Views.ContactPersonManageView() { Margin = new Thickness(0), IsClient = true };
                //vm.Model = new ContactsViewModel();
                //vm.Model.IsNew = true;                
                //vm.Model.LoginedUser = Model.LoginedUser;
                //vm.DataContext = vm.Model;             

                vm.OnPageClosing += Vm_OnPageClosing;
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
}
