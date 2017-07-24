using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using TokikuNew.Frame;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{
    /// <summary>
    /// ProjectManagerView.xaml 的互動邏輯
    /// </summary>
    public partial class ProjectManagerView : UserControl
    {
        //private ProjectsController controller;
        //private ProjectContractController projectcontroll;
        //private ClientController clientcontroller;

        public ProjectManagerView()
        {
            InitializeComponent();


        }

        #region SelectedProjectId
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid),
                typeof(ProjectManagerView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(SelectedProjectIdChange)));

        public static void SelectedProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is ProjectManagerView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((ProjectManagerView)sender).TryFindResource("ProjectSource");

                    if (source != null)
                    {
                        source.MethodParameters[0] = e.NewValue;
                        source.Refresh();
                    }

                    //RoutedViewResult result = (RoutedViewResult)((ProjectManagerView)sender).TryFindResource("OpenControlTable");

                    //if (result != null)
                    //{
                    //    result.RoutedValues = new System.Collections.Generic.Dictionary<string, object>();
                    //    result.RoutedValues.Add("SelectedProject", (ProjectsViewModel)source.Data);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
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
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ProjectManagerView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region IsShowClientSelection

        #endregion

        public static readonly RoutedEvent NewDocumentPageEvent =
EventManager.RegisterRoutedEvent("NewDocumentPage", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ProjectManagerView));

        public event RoutedEventHandler NewDocumentPage
        {
            add { AddHandler(NewDocumentPageEvent, value); }
            remove { RemoveHandler(NewDocumentPageEvent, value); }
        }

        private void userControl_Initialized(object sender, EventArgs e)
        {
            try
            {
                Binding selectProjectBinding = new Binding();
                selectProjectBinding.Source = TryFindResource("ProjectSource");
                selectProjectBinding.Path = new PropertyPath("MethodParameters[0]");
                selectProjectBinding.BindsDirectlyToSource = true;
                selectProjectBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                SetBinding(SelectedProjectIdProperty, selectProjectBinding);

                //controller = App.Resolve<ProjectsController>();
                //projectcontroll = App.Resolve<ProjectContractController>();
                //clientcontroller = App.Resolve<ClientController>();
                if (Mode == default(DocumentLifeCircle))
                {
                    Mode = DocumentLifeCircle.Read;
                }


            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                //RoutedViewResult result = (RoutedViewResult)TryFindResource("OpenControlTable");
                //ProjectsViewModel viewmodel = (ProjectsViewModel)((ObjectDataProvider)TryFindResource("ProjectSource")).Data;

                //if (result != null && viewmodel != null)
                //{
                //    //result.RoutedValues = new System.Collections.Generic.Dictionary<string, object>();
                //    result.RoutedValues["SelectedProject"] = viewmodel;
                //}

                //Binding selectProjectBinding = new Binding();
                //selectProjectBinding.Source = DataContext;
                //SetBinding(SelectedProjectProperty, selectProjectBinding);

                //if (SelectedProject != null)
                //{
                //    if (SelectedProject.ClientId.HasValue)
                //    {
                //        //if (SelectedClient != null)
                //        //    SelectedClient.Refresh();
                //    }
                //}


                AddHandler(ClientListView.SelectedClientChangedEvent, new RoutedEventHandler(UserControl_OnSelectionClientChanged));
                AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void UserControl_OnSelectionClientChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.OriginalSource is ClientViewModel)
                {
                    SelectedClient = (ClientViewModel)e.OriginalSource;
                    //SelectedProject.Client = SelectedClient;
                    //SelectedProject.ClientId = SelectedClient.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        /// <summary>
        /// 當輸入專案全名的連動作業
        /// </summary>
        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (tbName.Text.Length > 0)
                {
                    tbShortName.Text = tbName.Text;
                }
                else
                {
                    tbShortName.Text = string.Empty;
                }
                //if (SelectedProject != null)
                //{
                //    //if (SelectedProject.ProjectContract != null && SelectedProject.ProjectContract.Any())
                //    //{
                //    //    foreach (var foundcurrentNo in SelectedProject.ProjectContract)
                //    //    {
                //    //        foundcurrentNo.Name = tbName.Text;
                //    //    }
                //    //}
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                ProjectsViewModel SelectedProject = (ProjectsViewModel)((ObjectDataProvider)TryFindResource("ProjectSource")).Data;
                //SelectedProject.Errors = new string[] { };
                Mode = (DocumentLifeCircle)e.OriginalSource;
                switch (Mode)
                {

                    case DocumentLifeCircle.Create:

                        if (SelectedProject.Status.IsNewInstance == false)
                        {
                            RoutedUICommand command = (RoutedUICommand)TryFindResource("OpenNewTabItem");
                            RoutedViewResult viewparam = (RoutedViewResult)TryFindResource("OpenNewProjectView");
                            if (command != null)
                            {
                                command.Execute(viewparam, this);
                            }
                            //RaiseEvent(new RoutedEventArgs(NewDocumentPageEvent, this));
                            break;
                        }

                        SelectedProject = new ProjectsViewModel();

                        SelectedProject.Initialized(null);
                        SelectedProject.CreateUserId = LoginedUser.UserId;

                        SelectedProject.Status.IsModify = false;
                        SelectedProject.Status.IsSaved = false;
                        SelectedProject.Status.IsNewInstance = true;

                        break;
                    case DocumentLifeCircle.Save:

                        //if (SelectedBIGuid != null && SelectedBIGuid != Guid.Empty)
                        //{
                        //    var recvdata = SelectedProject.Suppliers.Where(w => w.Id == SelectedBIGuid).Single();
                        //    //recvdata.SiteContactPerson = TBSiteContactPerson.Text;
                        //    //recvdata.SiteContactPersonPhone = TBSiteContactPersonPhone.Text;
                        //}

                        if (SelectedProject.CreateUserId == Guid.Empty)
                            SelectedProject.CreateUserId = LoginedUser.UserId;

                        if (SelectedClient != null)
                            SelectedProject.ClientId = SelectedClient.Id;

                        SelectedProject.SaveModel("ProjectManagerView");

                        if (SelectedProject.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedProject.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                            SelectedProject.Errors = null;
                            //Mode = dockBar.LastState;
                            break;
                        }

                        if (SelectedProject.Status.IsNewInstance)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
                        }

                        Mode = DocumentLifeCircle.Read;

                        ((ObjectDataProvider)TryFindResource("ProjectSource")).Refresh();

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
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //dockBar.QueryFunctionButtonEnabled = true;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //dockBar.QueryFunctionButtonEnabled = false;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.F4)
                {
                    ClientSelectionDialog dlg = new ClientSelectionDialog();
                    if (dlg.ShowDialog() == true)
                    {
                        if (dlg.SelectedClient != null)
                        {
                            //((ProjectsViewModel)DataContext).Client = dlg.SelectedClient;
                            ((ProjectsViewModel)DataContext).ClientId = dlg.SelectedClient.Id;
                            //SelectedClient = SelectedProject.Client;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void btnClientDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientSelectionDialog dlg = new ClientSelectionDialog();
                if (dlg.ShowDialog() == true)
                {
                    if (dlg.SelectedClient != null)
                    {
                        //((ProjectsViewModel)DataContext).Client = dlg.SelectedClient;
                        ((ProjectsViewModel)DataContext).ClientId = dlg.SelectedClient.Id;
                        //SelectedClient = SelectedProject.Client;
                    }
                }

            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void ReplyCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                ObjectDataProvider source = (ObjectDataProvider)FindResource("ProjectSource");

                if (source != null)
                {
                    source.MethodParameters.Clear();
                    source.MethodParameters.Add(((object[])e.Parameter)[0]);
                    source.Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Btn2_PreviewCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }
    }
}
