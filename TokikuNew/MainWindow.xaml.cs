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
        public MainWindow()
        {
            InitializeComponent();
        }

        ManufacturersController mc = new ManufacturersController();
        ClientController clientcontroller = new ClientController();
        private Tokiku.Controllers.ProjectsController controller = new Tokiku.Controllers.ProjectsController();
       
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
                            ((MainViewModel)DataContext).Projects = controller.QueryAll();
                            ((MainViewModel)DataContext).Manufacturers = mc.QueryAll();
                            ((MainViewModel)DataContext).Clients = clientcontroller.QueryAll();
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
            //AddHandler(VendorListView.SendNewPageRequestEvent, new RoutedEventHandler(MI_CreateNew_Factories_Click));
            //AddHandler(ClientListView.SendNewPageRequestEvent, new RoutedEventHandler(MI_CreateNew_Customers_Click));
          


        }

        private void Window_AutoOpenNewPage(object sender, RoutedEventArgs e)
        {
            try
            {
                if(e.Source is Views.ProjectSelectListView)
                {
                    MI_CreateNew_Project_Click(sender, e);
                }

                if(e.Source is Views.VendorListView)
                {
                    MI_CreateNew_Factories_Click(sender, e);
                }

                if(e.Source is Views.ClientListView)
                {
                    MI_CreateNew_Customers_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void MI_CreateNew_Project_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "新增專案";

                var vm = new ProjectManagerView() { Margin = new Thickness(0) };
                vm.DataContext = controller.CreateNew();
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


                using (var mc = new ManufacturersController())
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
                ProjectSelectionPage.SelectedProject = e.OriginalSource as ProjectListViewModel;

                string Header = string.Format("專案:{0}-{1}", ProjectSelectionPage.SelectedProject.Code, ProjectSelectionPage.SelectedProject.ShortName);


                ClosableTabItem addWorkarea = new ClosableTabItem();

                bool isExisted = false;

                foreach (TabItem item in Workspaces.Items)
                {
                    if (item is ClosableTabItem)
                    {
                        if (item.Header.Equals(Header))
                        {
                            isExisted = true;
                            addWorkarea = (ClosableTabItem)item;
                            break;
                        }
                    }

                }

                if (!isExisted)
                {
                    addWorkarea.Header = Header;

                    var vm = new ProjectViewer() { Margin = new Thickness(0) };

                    vm.DataContext = controller.Query(w => w.Id == ProjectSelectionPage.SelectedProject.Id);
                    vm.Mode = DocumentLifeCircle.Read;

                    Binding bindinglogineduser = new Binding();
                    bindinglogineduser.Source = ((MainViewModel)DataContext).LoginedUser;

                    vm.SetBinding(ProjectViewer.LoginedUserProperty, bindinglogineduser);

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea;
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

                using (var mc = new ClientController())
                {

                    var vm = new ClientManageView() { Margin = new Thickness(0) };

                    vm.DataContext = mc.Query(q => q.Id == model.Id);
                    vm.Mode = DocumentLifeCircle.Read;
                    vm.LoginedUser = ((MainViewModel)DataContext).LoginedUser;


                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
