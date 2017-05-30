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

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectViewer.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectViewer : UserControl
    {
        private ProjectsController controller = new ProjectsController();
        private ProjectContractController projectcontractcontroller = new ProjectContractController();


        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProjectViewer), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ProjectViewer), new PropertyMetadata(default(UserViewModel)));

        public ProjectViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PMV.Mode = Mode;


            //註冊一個處理分頁關閉的事件處理器
            AddHandler(ClosableTabItem.OnPageClosingEvent, new RoutedEventHandler(ProjectViewer_OnPageClosing));
            AddHandler(ProjectManagerView.SendNewPageRequestEvent, new RoutedEventHandler(ProjectViewer_OpenNewTab));

        }

        private void ProjectViewer_OnPageClosing(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            try
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
                if (e.OriginalSource is ProjectContractViewModel)
                {

                    ProjectContractViewModel model = (ProjectContractViewModel)e.OriginalSource;

                    model = projectcontractcontroller.Query(s => s.Id == model.Id);

                    ClosableTabItem addWorkarea = new ClosableTabItem();
                    addWorkarea.Header = string.Format("合約:{0}", model.ContractNumber);

                    var vm = new ContractManager() { Margin = new Thickness(0) };
                    vm.DataContext = model;
                    vm.Mode = DocumentLifeCircle.Read;

                    //Binding bindinglogineduser = new Binding();
                    //bindinglogineduser.Source = LoginedUser;

                    //vm.SetBinding(ContractManager.LoginedUserProperty, bindinglogineduser);

                    addWorkarea.Content = vm;
                    addWorkarea.Margin = new Thickness(0);

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
