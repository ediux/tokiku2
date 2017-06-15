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
using TokikuNew.Controls;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{

    /// <summary>
    /// ProjectViewer.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectViewer : UserControl
    {
        private ProjectsController controller = new ProjectsController();
        private ProjectContractController projectcontractcontroller = new ProjectContractController();


        #region Document Mode

        /// <summary>
        /// 目前載入的文件所處的模式
        /// </summary>
        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProjectViewer), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region 登入的使用者
        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ProjectViewer), new PropertyMetadata(default(UserViewModel)));

        /// <summary>
        /// 登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }
        #endregion


        public ProjectViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //註冊一個處理分頁關閉的事件處理器
                AddHandler(ClosableTabItem.OnPageClosingEvent, new RoutedEventHandler(ProjectViewer_OnPageClosing));
                AddHandler(ClosableTabItem.SendNewPageRequestEvent, new RoutedEventHandler(ProjectViewer_OpenNewTab));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void ProjectViewer_OnPageClosing(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            try
            {
                if (e.OriginalSource is TabItem)
                {
                    TabItem currentworking = (TabItem)e.OriginalSource;

                    if (currentworking != null)
                    {
                        if (currentworking.Content != null)
                        {
                            UserControl contextObject = (UserControl)currentworking.Content;

                            if (contextObject.DataContext != null)
                            {
                                BaseViewModel vmodel = (BaseViewModel)contextObject.DataContext;
                                if (vmodel.Status.IsModify && vmodel.Status.IsSaved == false)
                                {
                                    if (MessageBox.Show("您尚未儲存，要繼續嗎?", "關閉前確認", MessageBoxButton.YesNo) == MessageBoxResult.No)
                                    {
                                        return;
                                    }
                                }
                            }

                            InnerWorkspaces.Items.Remove(currentworking);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProjectViewer_OpenNewTab(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = string.Empty;

                object SharedModel = null;

                if (e.OriginalSource is ProjectContractViewModel)
                {
                    ProjectContractViewModel model = (ProjectContractViewModel)e.OriginalSource;
                    SharedModel = model;
                    Header = string.Format("合約-{0}[{1}]", model.Projects.ShortName, model.ContractNumber);
                    addWorkarea = new ClosableTabItem() { Header = Header };
                }

                bool isExisted = false;

                foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
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
                    if (e.OriginalSource != null && e.OriginalSource is ManufacturersViewModel)
                    {
                        var vm = new ManufacturersManageView() { Margin = new Thickness(0) };
                      
                        vm.DataContext = SharedModel;
                        vm.LoginedUser = LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }


                    if (e.OriginalSource != null && e.OriginalSource is ProjectContractViewModel)
                    {
                        var vm = new ContractManager() { Margin = new Thickness(0) };
                        ((ProjectContractViewModel)SharedModel).Query();
                        vm.DataContext = SharedModel;
                        vm.LoginedUser = LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void MI_Projects_Order_1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型訂製單";
                addWorkarea = new ClosableTabItem() { Header = Header };


                bool isExisted = false;

                foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
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
                    var vm = new AluminumExtrusionOrderSheetView() { Margin = new Thickness(0) };

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    Binding LoginedUserBinding = new Binding();
                    LoginedUserBinding.Source = LoginedUser;

                    vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                    InnerWorkspaces.Items.Add(addWorkarea);
                    InnerWorkspaces.SelectedItem = addWorkarea;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_Order_2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型請款單";
                addWorkarea = new ClosableTabItem() { Header = Header };

                bool isExisted = false;

                foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
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
                    var vm = new InvoiceView() { Margin = new Thickness(0) };

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    //Binding LoginedUserBinding = new Binding();
                    //LoginedUserBinding.Source = LoginedUser;

                    //vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                    InnerWorkspaces.Items.Add(addWorkarea);
                    InnerWorkspaces.SelectedItem = addWorkarea;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MI_Projects_Order_3_Click(object sender, RoutedEventArgs e)
        {
            //RecvMaterialView
            try
            {
                e.Handled = true;

                ClosableTabItem addWorkarea = null;
                string Header = "鋁擠型收料單";

                addWorkarea = new ClosableTabItem() { Header = Header };

                bool isExisted = false;

                foreach (ClosableTabItem item in InnerWorkspaces.Items.OfType<ClosableTabItem>())
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

                    var vm = new RecvMaterialView() { Margin = new Thickness(0) };

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

                    //Binding LoginedUserBinding = new Binding();
                    //LoginedUserBinding.Source = LoginedUser;

                    //vm.SetBinding(AluminumExtrusionOrderSheetView.LoginedUserProperty, LoginedUserBinding);

                    InnerWorkspaces.Items.Add(addWorkarea);
                    InnerWorkspaces.SelectedItem = addWorkarea;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
