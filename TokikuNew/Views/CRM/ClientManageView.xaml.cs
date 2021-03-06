﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ClientManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ClientManageView : UserControl
    {
        public ClientManageView()
        {
            InitializeComponent();
        }

        //#region Mode
        //public DocumentLifeCircle Mode
        //{
        //    get { return (DocumentLifeCircle)GetValue(ModeProperty); }
        //    set { SetValue(ModeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ModeProperty =
        //    DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ClientManageView), new PropertyMetadata(DocumentLifeCircle.Create));
        //#endregion

        //#region LoginedUser
        //public UserViewModel LoginedUser
        //{
        //    get { return (UserViewModel)GetValue(LoginedUserProperty); }
        //    set { SetValue(LoginedUserProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for LoginedUserProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LoginedUserProperty =
        //    DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ClientManageView), new PropertyMetadata(default(UserViewModel)));

        //#endregion

        //#region 目前操作的廠商資料

        //public Guid SelectedManufacturerId
        //{
        //    get { return (Guid)GetValue(SelectedManufacturerIdProperty); }
        //    set { SetValue(SelectedManufacturerIdProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedManufacturerId.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedManufacturerIdProperty =
        //    DependencyProperty.Register("SelectedManufacturerId", typeof(Guid),
        //        typeof(ClientManageView), new PropertyMetadata(Guid.Empty,
        //            new PropertyChangedCallback(SelectedManufacturerIdChange)));

        //public static void SelectedManufacturerIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (sender is ClientManageView)
        //        {

        //            ObjectDataProvider source = (ObjectDataProvider)((ClientManageView)sender).TryFindResource("ClientSource");

        //            if (source != null)
        //            {
        //                source.MethodParameters[0] = e.NewValue;
        //                source.Refresh();

        //                ((ClientManageView)sender).SetValue(SelectedManufacturersProperty, source.Data);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}

        //public ManufacturersViewModel SelectedManufacturers
        //{
        //    get { return (ManufacturersViewModel)GetValue(SelectedManufacturersProperty); }
        //    set { SetValue(SelectedManufacturersProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedManufacturers.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedManufacturersProperty =
        //    DependencyProperty.Register("SelectedManufacturers", typeof(ManufacturersViewModel), typeof(ManufacturersManageView), new PropertyMetadata(default(ManufacturersViewModel)));

        //#endregion

        //private void dockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;

        //        ClientViewModel SelectedManufacturers = (ClientViewModel)DataContext;

        //        Mode = (DocumentLifeCircle)e.OriginalSource;
        //        switch (Mode)
        //        {

        //            case DocumentLifeCircle.Create:
        //                DataContext = new ClientViewModel();
        //                SelectedManufacturers = (ClientViewModel)DataContext;
        //                SelectedManufacturers.CreateUserId = LoginedUser.UserId;
        //                SelectedManufacturers.CreateTime = DateTime.Now;
        //                if (SelectedManufacturers.HasError)
        //                {
        //                    MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
        //                    SelectedManufacturers.Errors = null;
        //                    //dockBar.DocumentMode = DocumentLifeCircle.Read;
        //                }
        //                SelectedManufacturers.Status.IsNewInstance = true;
        //                SelectedManufacturers.Status.IsModify = false;
        //                SelectedManufacturers.Status.IsSaved = false;
        //                break;
        //            case DocumentLifeCircle.Save:

        //                //if (SelectedManufacturers.Contracts.Count > 0 && !SelectedManufacturers.Contracts.Where(w => w.IsDefault == true).Any())
        //                //{
        //                //    MessageBox.Show("請勾選預設聯絡人!","錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //                //    SelectedManufacturers.Errors = null;
        //                //    return;
        //                //}

        //                SelectedManufacturers.SaveModel();

        //                if (SelectedManufacturers.HasError)
        //                {
        //                    MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
        //                    SelectedManufacturers.Errors = null;                      
        //                    break;
        //                }

        //                //var maincontact = SelectedManufacturers.Contracts.Where(w => w.IsDefault == true).SingleOrDefault();
        //                //if (maincontact != null)
        //                //{
        //                //    tblMainContractPerson.Text = maincontact.Name;
        //                //    tblExt.Text = maincontact.ExtensionNumber;
        //                //    tbMobile.Text = maincontact.Mobile;

        //                //    //((ManufacturersViewModel)DataContext).MainContactPerson = maincontact.Name;
        //                //    //((ManufacturersViewModel)DataContext).Extension = maincontact.ExtensionNumber;
        //                //}
        //                //else
        //                //{
        //                //    tblMainContractPerson.Text = string.Empty;
        //                //    tblExt.Text = string.Empty;
        //                //    tbMobile.Text = string.Empty;

        //                //}

        //                if (SelectedManufacturers.Status.IsNewInstance)
        //                {
        //                    RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
        //                }

        //                Mode = DocumentLifeCircle.Read;

        //                SelectedManufacturers.Status.IsNewInstance = false;
        //                SelectedManufacturers.Status.IsModify = false;
        //                SelectedManufacturers.Status.IsSaved = true;
        //                break;
        //            case DocumentLifeCircle.Update:
        //                SelectedManufacturers.Status.IsNewInstance = false;
        //                SelectedManufacturers.Status.IsModify = false;
        //                SelectedManufacturers.Status.IsSaved = false;
        //                break;
        //        }
        //        UpdateLayout();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}

        //private void EngList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;
        //        if (EngList.SelectedItem != null)
        //        {
        //            RaiseEvent(new RoutedEventArgs(ProjectSelectListView.SelectedProjectChangedEvent, EngList.SelectedItem));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
           
        //}

        //private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        tbShortName.Text = tbName.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }

        //}

        //private void userControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(dockBar_DocumentModeChanged));
        //    ClientViewModel SelectedManufacturers = (ClientViewModel)DataContext;
        //    //SelectedManufacturers.ClientForProjects.QueryByClient(SelectedManufacturers.Id);
        //    //SelectedManufacturers.Contracts.Query("", SelectedManufacturers.Id, SelectedManufacturers.IsClient);

        //    //var maincontact = SelectedManufacturers.Contracts.Where(w => w.IsDefault == true).SingleOrDefault();
        //    //if (maincontact != null)
        //    //{
        //    //    tblMainContractPerson.Text = maincontact.Name;
        //    //    tblExt.Text = maincontact.ExtensionNumber;
        //    //    tbMobile.Text = maincontact.Mobile;
              
        //    //    //((ManufacturersViewModel)DataContext).MainContactPerson = maincontact.Name;
        //    //    //((ManufacturersViewModel)DataContext).Extension = maincontact.ExtensionNumber;
        //    //}
        //    //else
        //    //{
        //    //    tblMainContractPerson.Text = string.Empty;
        //    //    tblExt.Text = string.Empty;
        //    //    tbMobile.Text = string.Empty;
               
        //    //}
        //}

        //private void ContractList_DefaultContactChanged(object sender, RoutedEventArgs e)
        //{
        //    e.Handled = true;
        //    ContactsViewModel defaultcontractperson = (ContactsViewModel)e.OriginalSource;
        //    if (defaultcontractperson != null)
        //    {
        //        tblMainContractPerson.Text = defaultcontractperson.Name;
        //        tblExt.Text = defaultcontractperson.ExtensionNumber;
        //        tbMobile.Text = defaultcontractperson.Mobile;             
        //    }
        //}
    }
}
