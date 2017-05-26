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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(ProjectSelectListView.SendNewPageRequestEvent, new RoutedEventHandler(MI_CreateNew_Project_Click));
            AddHandler(VendorListView.SendNewPageRequestEvent, new RoutedEventHandler(MI_CreateNew_Factories_Click));
            AddHandler(ClosableTabItem.OnPageClosingEvent, new RoutedEventHandler(btnTabClose_Click));
        }

        private void MI_CreateNew_Project_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClosableTabItem addWorkarea = new ClosableTabItem();
                addWorkarea.Header = "專案主檔";

                var vm = new Views.ProjectManagerView() { Margin = new Thickness(0)};
                vm.DataContext = controller.CreateNew();
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
                addWorkarea.Header = "廠商主檔";

                var vm = new ManufacturersManageView() { Margin = new Thickness(0) };

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

        private void MI_CreateNew_Contracts_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void MI_CreateNew_Customers_Click(object sender, RoutedEventArgs e)
        {

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
                ProjectSelectionPage.SelectedProject = e.OriginalSource as ProjectBaseViewModel;

                string Header = string.Format("專案:{0}-{1}", ProjectSelectionPage.SelectedProject.Code, ProjectSelectionPage.SelectedProject.ShortName);
                //((MainViewModel)DataContext).CurrentProject = controller.QuerySingle(ProjectSelectionPage.SelectedProject.Id);

                ClosableTabItem addWorkarea = new ClosableTabItem();
                //addWorkarea.OnPageClosing += btnTabClose_Click;

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

                    var vm = new Views.ProjectViewer() { Margin = new Thickness(0) };

                    vm.DataContext = ProjectSelectionPage.SelectedProject;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void MI_CreateNew_Customers_Contracts_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void VendorSelection_SelectedVendorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                string Header = "廠商主檔";
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
                    addWorkarea.Header = Header;

                    var vm = new Views.ManufacturersManageView() { Margin = new Thickness(0) };
                    vm.DataContext = e.OriginalSource;
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
    }
}
