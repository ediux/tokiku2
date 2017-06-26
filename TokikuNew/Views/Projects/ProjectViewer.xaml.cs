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

        #region DocumentModeChanged 事件

        public static readonly RoutedEvent DocumentModeChangedEvent =
            EventManager.RegisterRoutedEvent("DocumentModeChanged", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(ProjectViewer));
        /// <summary>
        /// 新增文件模式變更的路由事件。
        /// </summary>
        public event RoutedEventHandler DocumentModeChanged
        {
            add { AddHandler(DocumentModeChangedEvent, value); }
            remove { RemoveHandler(DocumentModeChangedEvent, value); }
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
                                if (contextObject.DataContext is BaseViewModel)
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

                if (e.OriginalSource is ConstructionAtlasViewModelCollection)
                {
                    ConstructionAtlasViewModelCollection model = (ConstructionAtlasViewModelCollection)e.OriginalSource;
                    SharedModel = model;
                    Header = "施工圖集";
                    addWorkarea = new ClosableTabItem() { Header = Header };

                }

                if (e.OriginalSource is ProcessingAtlasViewModelCollection)
                {
                    ProcessingAtlasViewModelCollection model = (ProcessingAtlasViewModelCollection)e.OriginalSource;
                    SharedModel = model;
                    Header = "加工圖集";
                    addWorkarea = new ClosableTabItem() { Header = Header };
                }

                if (e.OriginalSource is EngineeringViewModelCollection)
                {
                    EngineeringViewModelCollection model = (EngineeringViewModelCollection)e.OriginalSource;
                    SharedModel = model;
                    Header = "工程項目";
                    addWorkarea = new ClosableTabItem() { Header = Header };
                }

                if(e.OriginalSource is AssemblyTableView)
                {
                    Header = "組裝總表";
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

                        addWorkarea = new ClosableTabItem() { Header = Header };
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

                        addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }

                    if (e.OriginalSource != null && e.OriginalSource is ConstructionAtlasViewModelCollection)
                    {

                        var vm = new ConstructionAtlasView() { Margin = new Thickness(0) };
                        if (SharedModel != null)
                            ((ConstructionAtlasViewModelCollection)e.OriginalSource).Query();

                        vm.DataContext = SharedModel;
                        vm.LoginedUser = LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        //addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }

                    if (e.OriginalSource != null && e.OriginalSource is ProcessingAtlasViewModelCollection)
                    {

                        var vm = new ProcessingAtlasView() { Margin = new Thickness(0) };
                        if (SharedModel != null)
                            ((ProcessingAtlasViewModelCollection)SharedModel).Query();
                        vm.DataContext = SharedModel;
                        vm.LoginedUser = LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        //addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }

                    if (e.OriginalSource != null && e.OriginalSource is EngineeringViewModelCollection)
                    {

                        var vm = new ContractManager() { Margin = new Thickness(0) };
                        if (SharedModel != null)
                            ((EngineeringViewModelCollection)SharedModel).Query();

                        vm.DataContext = SharedModel;
                        vm.LoginedUser = LoginedUser;

                        vm.Mode = DocumentLifeCircle.Read;

                        //addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }

                    if(e.OriginalSource !=null && e.OriginalSource is AssemblyTableView)
                    {
                        var vm = new AssemblyTableView() { Margin = new Thickness(0) };
                      

                        //addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        InnerWorkspaces.Items.Add(addWorkarea);
                        InnerWorkspaces.SelectedItem = addWorkarea;
                        return;
                    }
                }
                else
                {
                    InnerWorkspaces.SelectedItem = addWorkarea;
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

   
        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            //e.Handled = true;
            //Mode = ((DockBar)sender).DocumentMode;
            Mode = (DocumentLifeCircle)e.OriginalSource;

            if (Mode == DocumentLifeCircle.Save)
                Mode = DocumentLifeCircle.Read;

            //switch (Mode)
            //{

            //    case DocumentLifeCircle.Create:
            //        //SelectedProject = new ProjectsViewModel(App.Resolve<ProjectsController>());

            //        //SelectedProject.Initialized();
            //        //SelectedProject.CreateUserId = LoginedUser.UserId;

            //        //SelectedProject.Status.IsModify = false;
            //        //SelectedProject.Status.IsSaved = false;
            //        //SelectedProject.Status.IsNewInstance = true;

            //        break;
            //    case DocumentLifeCircle.Save:


            //        //Mode = ((DockBar)e.OriginalSource).DocumentMode;
            //        //RaiseEvent(new RoutedEventArgs(DockBar.DocumentModeChangedEvent, this));

            //        break;
            //    case DocumentLifeCircle.Update:
            //        SelectedProject.Status.IsModify = false;
            //        SelectedProject.Status.IsSaved = false;
            //        SelectedProject.Status.IsNewInstance = false;
            //        break;
            //}
            //RaiseEvent(new RoutedEventArgs(DocumentModeChangedEvent, e.OriginalSource));
        }
    }
}
