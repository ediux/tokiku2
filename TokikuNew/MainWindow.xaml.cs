using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.Controllers;
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
            AddHandler(ClientListView.SelectedClientChangedEvent, new RoutedEventHandler(ClientListView_SelectedClientChanged));
            AddHandler(ProjectSelectListView.SelectedProjectChangedEvent, new RoutedEventHandler(ProjectSelectionPage_SelectedProjectChanged));
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
                string Header = "新增廠商";
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
                    using (ManufacturersManageController cc = new ManufacturersManageController())
                    {
                        addWorkarea.Header = Header;

                        var vm = new ManufacturersManageView() { Margin = new Thickness(0) };
                        ManufacturersViewModel model = new ManufacturersViewModel();

                        vm.DataContext = model;
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
                        ClientViewModel model = new ClientViewModel();

                        vm.DataContext = model;
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
                if (e.OriginalSource != null)
                {

                    ClosableTabItem addWorkarea = null;
                    string Header = string.Empty;
                    Guid SelectedProjectId = Guid.Empty;

                    if (e.OriginalSource is ProjectListViewModel)
                    {
                        ProjectListViewModel model = (ProjectListViewModel)e.OriginalSource;
                        Header = string.Format("專案:{0}-{1}", model.Code, model.ShortName);
                        SelectedProjectId = model.Id;
                    }

                    if (e.OriginalSource is ProjectsViewModel)
                    {
                        ProjectsViewModel model = (ProjectsViewModel)e.OriginalSource;
                        Header = string.Format("專案:{0}-{1}", model.Code, model.ShortName);
                        SelectedProjectId = model.Id;
                    }


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

                        ProjectsViewModel source = new ProjectsViewModel();

                        //source.Id = SelectedProjectId;
                        source.Query(SelectedProjectId);
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
                Workspaces.Items.Remove(Workspaces.SelectedItem);
            }

        }

        private void VendorSelection_SelectedVendorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();

                ManufacturersViewModel model = (ManufacturersViewModel)e.OriginalSource;

                if (model != null)
                    addWorkarea.Header = string.Format("廠商-{0}[{1}]", model.ShortName, model.Code);
                else
                    return;

                bool isExisted = false;

                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {

                    var vm = new ManufacturersManageView() { Margin = new Thickness(0) };

                    vm.DataContext = model;
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

                bool isExisted = false;

                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {

                    var vm = new ClientManageView() { Margin = new Thickness(0) };

                    vm.DataContext = model;
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

        private void MI_Main_Vendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();

                ManufacturersViewModelCollection model = ((MainViewModel)DataContext).Manufacturers;

                if (model != null)
                    addWorkarea.Header = "廠商列表";
                else
                    return;

                bool isExisted = false;

                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {

                    var vm = new VendorListView() { Margin = new Thickness(0) };

                    vm.DataContext = model;
                    vm.SelectedVendorChanged += VendorSelection_SelectedVendorChanged;

                    addWorkarea.Content = vm;

                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Main_Client_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();

                ClientViewModelCollection model = ((MainViewModel)DataContext).Clients;

                if (model != null)
                    addWorkarea.Header = "客戶列表";
                else
                    return;

                bool isExisted = false;

                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {

                    var vm = new ClientListView() { Margin = new Thickness(0) };

                    vm.DataContext = model;
                    vm.SelectedClientChanged += ClientListView_SelectedClientChanged;

                    addWorkarea.Content = vm;

                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void MI_Main_Molds_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "模具總表";


                bool isExisted = false;
                // 檢查是否重複開啟
                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }

                if (!isExisted)
                {
                    // 內容
                    var vm = new MaterialsTotalView() { Margin = new Thickness(0) };
                    addWorkarea.Content = vm;
                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void 本票管理_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "本票管理";

                bool isExisted = false;
                // 檢查是否重複開啟
                foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
                {
                    if (item.Header.Equals(addWorkarea.Header))
                    {
                        isExisted = true;
                        addWorkarea = item;
                        break;
                    }
                }
                // 內容
                if (!isExisted)
                {
                    var vm = new 本票管理UC() { Margin = new Thickness(0) };
                    addWorkarea.Content = vm;
                    Workspaces.Items.Add(addWorkarea);
                }

                Workspaces.SelectedItem = addWorkarea; // 指定當前顯示頁
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                mc = App.Resolve<ManufacturersManageController>();
                clientcontroller = App.Resolve<ClientController>();
                controller = App.Resolve<ProjectsController>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
