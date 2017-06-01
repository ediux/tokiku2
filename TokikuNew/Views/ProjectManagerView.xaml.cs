using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.Controllers;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectManagerView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectManagerView : UserControl
    {
        private ProjectsController controller = new ProjectsController();
        private ProjectContractController projectcontroll = new ProjectContractController();
        private ClientController clientcontroller = new ClientController();

        public ProjectManagerView()
        {
            InitializeComponent();
        }

        #region SelectedProject
        public ProjectsViewModel SelectedProject
        {
            get { return (ProjectsViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(ProjectsViewModel), typeof(ProjectManagerView), new PropertyMetadata(default(ProjectsViewModel)));

        #endregion

        #region 已選擇的客戶
        public ClientViewModel SelectedClient
        {
            get { return (ClientViewModel)GetValue(SelectedClientProperty); }
            set { SetValue(SelectedClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedClientProperty =
            DependencyProperty.Register("SelectedClient", typeof(ClientViewModel), typeof(ProjectManagerView), new PropertyMetadata(default(ClientViewModel)));
        #endregion

        #region 系統登入者
        /// <summary>
        /// 目前已登入者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ProjectManagerView), new PropertyMetadata(default(UserViewModel)));
        #endregion

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProjectManagerView));
        #endregion

        #region IsShowClientSelection

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Binding selectProjectBinding = new Binding();
            selectProjectBinding.Source = DataContext;
            SetBinding(SelectedProjectProperty, selectProjectBinding);

            if (SelectedProject.ClientId.HasValue)
            {
                SelectedClient = clientcontroller.Query(s => s.Id == SelectedProject.ClientId.Value);
            }

        }

        /// <summary>
        /// 當輸入專案全名的連動作業
        /// </summary>
        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                if (tbName.Text.Length >= 2)
                {
                    tbShortName.Text = tbName.Text.Substring(0, Math.Min(2, tbName.Text.Length));
                }
                else
                {
                    tbShortName.Text = tbName.Text;
                }
            }
            else
            {
                tbShortName.Text = string.Empty;
            }
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

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                SelectedProject.Errors = null;
                Mode = (DocumentLifeCircle)e.OriginalSource;
                switch (Mode)
                {

                    case DocumentLifeCircle.Create:

                        DataContext = SelectedProject = controller.CreateNew();
                        SelectedProject.CreateUserId = LoginedUser.UserId;


                        SelectedProject.Status.IsModify = false;
                        SelectedProject.Status.IsSaved = false;
                        SelectedProject.Status.IsNewInstance = true;

                        break;
                    case DocumentLifeCircle.Save:
                        if (SelectedProject.CreateUserId == Guid.Empty)
                        {
                            SelectedProject.CreateUserId = LoginedUser.UserId;
                        }
                        if (SelectedProject.ProjectContract.Count > 0)
                        {
                            foreach (ProjectContractViewModel model in SelectedProject.ProjectContract)
                            {
                                if (model.CreateUserId == Guid.Empty)
                                {
                                    model.CreateUserId = LoginedUser.UserId;
                                }

                                model.ProjectId = SelectedProject.Id;
                            }
                        }

                        if (SelectedClient != null)
                            SelectedProject.ClientId = SelectedClient.Id;


                        controller.SaveModel(SelectedProject);

                        if (SelectedProject.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedProject.Errors.ToArray()));
                            SelectedProject.Errors = null;
                            Mode = dockBar.LastState;
                            break;
                        }

                        if (SelectedProject.Status.IsNewInstance)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
                        }

                        Mode = DocumentLifeCircle.Read;

                        SelectedProject.Status.IsModify = false;
                        SelectedProject.Status.IsSaved = true;
                        SelectedProject.Status.IsNewInstance = false;
                        break;
                    case DocumentLifeCircle.Update:
                        SelectedProject.Status.IsModify = false;
                        SelectedProject.Status.IsSaved = false;
                        SelectedProject.Status.IsNewInstance = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnAddContract_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProject.ProjectContract == null)
                SelectedProject.ProjectContract = new ProjectContractViewModelCollection();

            SelectedProject.ProjectContract.Add(new ProjectContractViewModel());
            // UpdateLayout();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is ProjectContractViewModel)
            {
                ProjectContractViewModel disableContract = (ProjectContractViewModel)e.OriginalSource;
                projectcontroll.Delete(disableContract);
                UpdateLayout();
                //disableContract.Void
            }
        }

        private void btnShowClientSelection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientList_SelectedClientChanged(object sender, RoutedEventArgs e)
        {
            ClientViewModel model = e.OriginalSource as ClientViewModel;

            if (model != null)
            {
                SelectedClient = model;

                SelectedProject.ClientId = SelectedClient.Id;

            }
        }

        private void ContractList_Selected(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SendNewPageRequestEvent, ContractList.SelectedItem));
        }

        private void ContractList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SendNewPageRequestEvent, ContractList.SelectedItem));
        }

        private void ContractList_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
