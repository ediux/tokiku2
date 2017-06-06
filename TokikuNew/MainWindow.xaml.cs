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
using TokikuNew.Controls;
using TokikuNew.Views;

namespace TokikuNew
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ManufacturersManageController _mc, ClientController _clientcontroller, ProjectsController _controller)
        {
            InitializeComponent();

            mc = _mc;
            clientcontroller = _clientcontroller;
            controller = _controller;
        }

        ManufacturersManageController mc;
        ClientController clientcontroller;
        private ProjectsController controller;

        /// <summary>
        /// 當關閉分頁時觸發的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.Source is TabItem)
                {
                    TabItem currentworking = (TabItem)e.Source;

                    if (currentworking != null)
                    {
                        if (currentworking.Content != null)
                        {

                            Workspaces.Items.Remove(currentworking);
                            ((MainViewModel)DataContext).Refresh();

                            ((MainViewModel)DataContext).CurrentProject = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(ClosableTabItem.SendNewPageRequestEvent, new RoutedEventHandler(Window_AutoOpenNewPage));
            AddHandler(ClosableTabItem.OnPageClosingEvent, new RoutedEventHandler(btnTabClose_Click));

            ((MainViewModel)DataContext).StartUp_Query();
        }

        private void Window_AutoOpenNewPage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.Source is Views.ProjectSelectListView)
                {
                    MI_CreateNew_Project_Click(sender, e);
                }

                if (e.Source is Views.VendorListView)
                {
                    MI_CreateNew_Factories_Click(sender, e);
                }

                if (e.Source is Views.ClientListView)
                {
                    MI_CreateNew_Customers_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_CreateNew_Project_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "新增專案";

                var vm = new ProjectManagerView() { Margin = new Thickness(0) };
                vm.DataContext = new ProjectsViewModel(App.Resolve<ProjectsController>());
                ((ProjectsViewModel)vm.DataContext).Initialized();
                vm.Mode = DocumentLifeCircle.Create;

                Binding bindinglogineduser = new Binding();
                bindinglogineduser.Source = ((MainViewModel)DataContext).LoginedUser;

                vm.SetBinding(ProjectManagerView.LoginedUserProperty, bindinglogineduser);

                addWorkarea.Content = vm;
                addWorkarea.Margin = new Thickness(0);

                Workspaces.Items.Add(addWorkarea);
                Workspaces.SelectedItem = addWorkarea;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void MI_CreateNew_Factories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "新增廠商";

                bool isExisted = true;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = (ClosableTabItem)item;
                        break;
                    }
                }

                if (!isExisted)
                {
                    using (var mc = new ManufacturersManageController())
                    {
                        var vm = new ManufacturersManageView() { Margin = new Thickness(0) };
                        vm.Mode = DocumentLifeCircle.Create;
                        vm.DataContext = mc.CreateNew();

                        Binding bindinglogineduser = new Binding();
                        bindinglogineduser.Source = ((MainViewModel)DataContext).LoginedUser;

                        vm.SetBinding(ManufacturersManageView.LoginedUserProperty, bindinglogineduser);

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        Workspaces.Items.Add(addWorkarea);
                        Workspaces.SelectedItem = addWorkarea;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_CreateNew_Customers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Header = "新增客戶";
                ClosableTabItem addWorkarea = new ClosableTabItem();
                bool isExisted = false;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(Header))
                    {
                        isExisted = true;
                        addWorkarea = (ClosableTabItem)item;
                        break;
                    }
                }

                if (!isExisted)
                {
                    using (ClientController cc = new ClientController())
                    {
                        addWorkarea.Header = Header;

                        var vm = new ClientManageView() { Margin = new Thickness(0) };
                        vm.DataContext = cc.CreateNew();
                        vm.Mode = DocumentLifeCircle.Create;
                        vm.LoginedUser = ((MainViewModel)DataContext).LoginedUser;

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        Workspaces.Items.Add(addWorkarea);
                        Workspaces.SelectedItem = addWorkarea;
                    }

                }
                else
                {
                    Workspaces.SelectedItem = addWorkarea;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_SystemOption_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame.OptionWindow optwin = new Frame.OptionWindow();
                optwin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void ProjectSelectionPage_SelectedProjectChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource != null && e.OriginalSource is ProjectListViewModel)
                {
                    ProjectListViewModel model = (ProjectListViewModel)e.OriginalSource;

                    string Header = string.Format("專案:{0}-{1}", ProjectSelectionPage.SelectedProject.Code, ProjectSelectionPage.SelectedProject.ShortName);
                    ClosableTabItem addWorkarea = null;
                    bool isExisted = false;

                    foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
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
                        addWorkarea = new ClosableTabItem();
                        addWorkarea.Header = Header;
                        addWorkarea.IsSelected = true;

                        Workspaces.Items.Add(addWorkarea);
                        Workspaces.SelectedItem = addWorkarea;
                        Workspaces.SelectedIndex = Workspaces.Items.IndexOf(addWorkarea);

                        var vm = new ProjectViewer() { Margin = new Thickness(0) };

                       
                        ProjectsViewModel source = new ProjectsViewModel(App.Resolve<ProjectsController>());
                        source.Id = ProjectSelectionPage.SelectedProject.Id;
                        source.Query();
                        vm.DataContext = source;
                        vm.Mode = DocumentLifeCircle.Read;

                        Binding bindinglogineduser = new Binding();
                        bindinglogineduser.Source = ((MainViewModel)DataContext).LoginedUser;

                        vm.SetBinding(ProjectViewer.LoginedUserProperty, bindinglogineduser);

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);
                    }

                    addWorkarea.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void VendorSelection_SelectedVendorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource != null && e.OriginalSource is ManufacturersViewModel)
                {
                    ManufacturersViewModel model = (ManufacturersViewModel)e.OriginalSource;

                    string Header = string.Format("廠商-{0}[{1}]", model.ShortName, model.Code);
                    ClosableTabItem addWorkarea = null;
                    bool isExisted = false;

                    foreach (TabItem item in Workspaces.Items)
                    {
                        if (item.Header.Equals(Header))
                        {
                            isExisted = true;
                            addWorkarea = (ClosableTabItem)item;
                            break;
                        }
                    }

                    if (!isExisted)
                    {
                        addWorkarea = new ClosableTabItem();
                        addWorkarea.Header = Header;

                        var vm = new ManufacturersManageView() { Margin = new Thickness(0) };
                        vm.DataContext = model;
                        vm.LoginedUser = ((MainViewModel)DataContext).LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        Workspaces.Items.Add(addWorkarea);

                    }

                    Workspaces.SelectedItem = addWorkarea;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void MI_Reports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_Finance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_System_Members_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MI_System_Roles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientListView_SelectedClientChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();

                ClientViewModel model = (ClientViewModel)e.OriginalSource;

                if (model != null)
                    addWorkarea.Header = string.Format("客戶-{0}[{1}]", model.ShortName, model.Code);
                else
                    return;

                bool isExisted = true;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = (ClosableTabItem)item;
                        break;
                    }
                }
                if (!isExisted)
                {

                    var vm = new ClientManageView() { Margin = new Thickness(0) };

                    vm.DataContext = mc.Query(q => q.Id == model.Id);
                    vm.Mode = DocumentLifeCircle.Read;
                    vm.LoginedUser = ((MainViewModel)DataContext).LoginedUser;


                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Workspaces.Items.Add(addWorkarea);
                    Workspaces.SelectedItem = addWorkarea;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_TestView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "測試元件";

                bool isExisted = true;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = (ClosableTabItem)item;
                        break;
                    }
                }

                if (!isExisted)
                {
                    var vm = new TestView() { Margin = new Thickness(0) };
                    vm.DataContext = ((MainViewModel)DataContext).Clients;
                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Workspaces.Items.Add(addWorkarea);
                    Workspaces.SelectedItem = addWorkarea;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 票期管理功能表項目
        /// </summary>        
        private void MI_Finance_TicketManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "票期管理";

                bool isExisted = true;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = (ClosableTabItem)item;
                        break;
                    }
                }

                if (!isExisted)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
