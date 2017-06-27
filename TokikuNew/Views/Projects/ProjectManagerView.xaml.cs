using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.Controllers;
using Tokiku.Entity;
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
        private ProjectsController controller;
        private ProjectContractController projectcontroll;
        private ClientController clientcontroller;

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
            try
            {
                Binding selectProjectBinding = new Binding();
                selectProjectBinding.Source = DataContext;
                SetBinding(SelectedProjectProperty, selectProjectBinding);

                if (SelectedProject.ClientId.HasValue)
                {
                    if (SelectedClient != null)
                        SelectedClient.Refresh();

                    //SelectedClient = clientcontroller.Query(s => s.Id == SelectedProject.ClientId.Value);
                }

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
                if (e.OriginalSource is ClientViewModel)
                {
                    SelectedClient = (ClientViewModel)e.OriginalSource;
                    SelectedProject.Client = SelectedClient;
                    SelectedProject.ClientId = SelectedClient.Id;
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
                if (tbName.Text.Length > 0)
                {
                    tbShortName.Text = tbName.Text;
                }
                else
                {
                    tbShortName.Text = string.Empty;
                }
                if (SelectedProject != null)
                {
                    if (SelectedProject.ProjectContract.Any())
                    {
                        foreach (var foundcurrentNo in SelectedProject.ProjectContract)
                        {
                            foundcurrentNo.Name = tbName.Text;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ((Button)sender).DataContext));
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
                SelectedProject.Errors = null;
                Mode = (DocumentLifeCircle)e.OriginalSource;
                switch (Mode)
                {

                    case DocumentLifeCircle.Create:
                        //SelectedProject = new ProjectsViewModel(App.Resolve<ProjectsController>());

                        SelectedProject.Initialized();
                        SelectedProject.CreateUserId = LoginedUser.UserId;

                        SelectedProject.Status.IsModify = false;
                        SelectedProject.Status.IsSaved = false;
                        SelectedProject.Status.IsNewInstance = true;

                        break;
                    case DocumentLifeCircle.Save:
                        if (SelectedBIGuid != null && SelectedBIGuid != Guid.Empty)
                        {
                            var recvdata = SelectedProject.Suppliers.Where(w => w.Id == SelectedBIGuid).Single();
                            //recvdata.SiteContactPerson = TBSiteContactPerson.Text;
                            //recvdata.SiteContactPersonPhone = TBSiteContactPersonPhone.Text;
                        }

                        if (SelectedProject.CreateUserId == Guid.Empty)
                            SelectedProject.CreateUserId = LoginedUser.UserId;

                        if (SelectedClient != null)
                            SelectedProject.ClientId = SelectedClient.Id;

                        SelectedProject.SaveModel();

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

                        //Mode = ((DockBar)e.OriginalSource).DocumentMode;
                        //RaiseEvent(new RoutedEventArgs(DockBar.DocumentModeChangedEvent, this));
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

        private void btnAddContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedProject.ProjectContract == null)
                    SelectedProject.ProjectContract = new ProjectContractViewModelCollection();

                SelectedProject.ProjectContract.Add(new ProjectContractViewModel());
                // UpdateLayout();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource is ProjectContractViewModel)
                {
                    ProjectContractViewModel disableContract = (ProjectContractViewModel)e.OriginalSource;
                    //projectcontroll.Delete(disableContract);
                    UpdateLayout();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void btnShowClientSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (e.OriginalSource is ProjectContractViewModel)
                {

                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ClientList_SelectedClientChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientViewModel model = e.OriginalSource as ClientViewModel;

                if (model != null)
                {
                    SelectedClient = model;

                    SelectedProject.ClientId = SelectedClient.Id;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }

        private void ContractList_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ContractList.SelectedItem));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void ContractList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ContractList.SelectedItem));
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
                            ((ProjectsViewModel)DataContext).Client = dlg.SelectedClient;
                            ((ProjectsViewModel)DataContext).ClientId = dlg.SelectedClient.Id;
                            SelectedClient = SelectedProject.Client;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void ProjectSigningDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (SelectedProject != null)
                {
                    var foundcurrentNo = SelectedProject.ProjectContract.Where(w => w.ContractNumber == SelectedProject.Code).Single();
                    foundcurrentNo.SigningDate = SelectedProject.ProjectSigningDate;
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void ProjectContactSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedProject != null)
                {
                    SelectedProject.ProjectContract.Query((string)string.Empty);
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void ProjectContactSearchBar_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedProject != null)
                {
                    SelectedProject.ProjectContract.Query((string)e.OriginalSource);
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
                        ((ProjectsViewModel)DataContext).Client = dlg.SelectedClient;
                        ((ProjectsViewModel)DataContext).ClientId = dlg.SelectedClient.Id;
                        SelectedClient = SelectedProject.Client;
                    }
                }

            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void CBVandorSelectionForRecvAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //if (CBVandorSelectionForRecvAddress == null)
                //    return;

                //var selectedvalue = (Guid)CBVandorSelectionForRecvAddress.SelectedValue;

                //if (selectedvalue == null)
                //    return;

                //if (SelectedProject == null)
                //    return;

                //var newCBSource = SelectedProject.Suppliers.Where(s => s.ManufacturersId == selectedvalue)
                //    .Select(s => new
                //    {
                //        s.Id,
                //        s.ProjectId,
                //        s.ManufacturersName,
                //        s.PlaceofReceipt,
                //        s.Manufacturers.Contacts.Where(w => w.IsDefault == true).SingleOrDefault()?.Name,
                //        Phone = s.Manufacturers.Contacts.Where(w => w.IsDefault == true).SingleOrDefault()?.Phone ?? s.Manufacturers.Contacts.Where(w => w.IsDefault == true).SingleOrDefault()?.Mobile,
                //        s.SiteContactPerson,
                //        s.SiteContactPersonPhone,
                //        LastUpdateUser = LoginedUser.UserName
                //    }).ToList();

                //if (RecvDataGrid == null)
                //    return;

                //RecvDataGrid.ItemsSource = newCBSource;

            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private Guid SelectedBIGuid;

        private void CBVandorSelectionForRecvAddress_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCBSource = SelectedProject.Suppliers;
                //CBVandorSelectionForRecvAddress.ItemsSource = newCBSource;
                //CBVandorSelectionForRecvAddress.SelectedValuePath = "ManufacturersId";
                //btnAddSiteAddress.IsEnabled = false;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void RecvDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                dynamic newCBSource = e.AddedItems[0];
                SelectedBIGuid = (Guid)newCBSource.Id;
                //TBSiteContactPerson.Text = (string)newCBSource.SiteContactPerson;
                //TBSiteContactPersonPhone.Text = (string)newCBSource.SiteContactPersonPhone;
                //btnAddSiteAddress.IsEnabled = true;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void btnAddSiteAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (SelectedBIGuid != null || SelectedBIGuid != Guid.Empty)
                //{
                //    var recvdata = SelectedProject.Suppliers.Where(w => w.Id == SelectedBIGuid).Single();
                //    recvdata.SiteContactPerson = TBSiteContactPerson.Text;
                //    recvdata.SiteContactPersonPhone = TBSiteContactPersonPhone.Text;
                //}

                //btnAddSiteAddress.IsEnabled = false;
                //SelectedBIGuid = Guid.Empty;
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void ContractList_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            try
            {
                e.NewItem = new ProjectContractViewModel();
                ((ProjectContractViewModel)e.NewItem).ProjectId = ((ProjectsViewModel)DataContext).Id;
                ((ProjectContractViewModel)e.NewItem).Initialized();
                ((ProjectContractViewModel)e.NewItem).Id = Guid.NewGuid();
                if (string.IsNullOrEmpty(((ProjectContractViewModel)e.NewItem).ContractNumber))
                {
                    if (((ProjectsViewModel)DataContext) != null)
                        ((ProjectContractViewModel)e.NewItem).ContractNumber = ((ProjectsViewModel)DataContext).Code;
                }
                ((ProjectContractViewModel)e.NewItem).Name = ((ProjectsViewModel)DataContext).Name;
                ((ProjectContractViewModel)e.NewItem).SigningDate = ((ProjectsViewModel)DataContext).ProjectSigningDate;

                if (((ProjectsViewModel)DataContext).ProjectContract.Where(w => w.ContractNumber == ((ProjectContractViewModel)e.NewItem).ContractNumber).Any())
                {
                    var lastdata = ((ProjectsViewModel)DataContext).ProjectContract
                        .Where(w => w.ContractNumber.StartsWith(((ProjectContractViewModel)e.NewItem).ContractNumber))
                        .OrderByDescending(w => w.ContractNumber).FirstOrDefault();

                    if (lastdata != null)
                    {
                        int lastnumber = 0;

                        if (lastdata.ContractNumber.Length > 7)
                        {
                            if (!int.TryParse(lastdata.ContractNumber.Substring(8), out lastnumber))
                            {
                                ((ProjectContractViewModel)e.NewItem).ContractNumber = string.Empty;
                                return;
                            }
                        }

                        lastnumber += 1;
                        ((ProjectContractViewModel)e.NewItem).ContractNumber = string.Format("{0}-{1}", lastdata.ContractNumber.Substring(0, 7), lastnumber);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void userControl_Initialized(object sender, EventArgs e)
        {
            try
            {
                controller = App.Resolve<ProjectsController>();
                projectcontroll = App.Resolve<ProjectContractController>();
                clientcontroller = App.Resolve<ClientController>();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnProcessAltas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ((ProjectContractViewModel)((Button)sender).DataContext).ProcessingAtlas));
            }
            catch (Exception ex)
            {

                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnEngItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, ((ProjectContractViewModel)((Button)sender).DataContext).Engineerings));
            }
            catch (Exception ex)
            {

                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnConstructionAtlasView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, SelectedProject.ConstructionAtlas));
            }
            catch (Exception ex)
            {

                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void BtnAssemblyTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //目前專案的管控總表(需求/組裝總表)
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, new AssemblyTableView()));
            }
            catch (Exception ex)
            {

                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
