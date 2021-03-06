﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using WinForm = System.Windows.Forms;

namespace TokikuNew.Views
{
    /// <summary>
    /// ContactPersonManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ContactPersonManageView : UserControl
    {
        public ContactPersonManageView()
        {
            InitializeComponent();
        }

        //#region IsClient
        //public bool IsClient
        //{
        //    get { return (bool)GetValue(IsClientProperty); }
        //    set { SetValue(IsClientProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IsClient.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IsClientProperty =
        //    DependencyProperty.Register("IsClient", typeof(bool), typeof(ContactPersonManageView), new PropertyMetadata(false));

        //#endregion

        //#region Document Mode

        ///// <summary>
        ///// 文件模式
        ///// </summary>
        //public DocumentLifeCircle Mode
        //{
        //    get { return (DocumentLifeCircle)GetValue(ModeProperty); }
        //    set { SetValue(ModeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ModeProperty =
        //    DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ContactPersonManageView), new PropertyMetadata(DocumentLifeCircle.Read));
        //#endregion

        //#region SelectedContact
        ///// <summary>
        ///// 選擇的聯絡人
        ///// </summary>
        //public ContactsViewModel SelectedContact
        //{
        //    get { return (ContactsViewModel)GetValue(SelectedContactProperty); }
        //    set { SetValue(SelectedContactProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedContact.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedContactProperty =
        //    DependencyProperty.Register("SelectedContact", typeof(ContactsViewModel),
        //        typeof(ContactPersonManageView), new PropertyMetadata(default(ContactsViewModel)));
        //#endregion

        //#region 聯絡人選擇變更事件
        //public static readonly RoutedEvent SelectedContactChangedEvent = EventManager.RegisterRoutedEvent(
        //  "SelectedClientChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContactPersonManageView));

        //public event RoutedEventHandler SelectedContactChanged
        //{
        //    add { AddHandler(SelectedContactChangedEvent, value); }
        //    remove { RemoveHandler(SelectedContactChangedEvent, value); }
        //}
        //#endregion

        //#region 預設聯絡人變更事件
        //public static readonly RoutedEvent DefaultContactChangedEvent = EventManager.RegisterRoutedEvent(
        // "DefaultContactChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContactPersonManageView));

        //public event RoutedEventHandler DefaultContactChanged
        //{
        //    add { AddHandler(DefaultContactChangedEvent, value); }
        //    remove { RemoveHandler(DefaultContactChangedEvent, value); }
        //}
        //#endregion

        //#region 資料來源副本(廠商/聯絡人)
        //public Guid SelectedManufacturerId
        //{
        //    get { return (Guid)GetValue(SelectedManufacturerIdProperty); }
        //    set { SetValue(SelectedManufacturerIdProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Contracts.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedManufacturerIdProperty =
        //    DependencyProperty.Register("SelectedManufacturerId", typeof(Guid)
        //        , typeof(ContactPersonManageView), new PropertyMetadata(Guid.Empty,
        //            new PropertyChangedCallback(SelectedManufacturerIdChange)));

        //public static void SelectedManufacturerIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    try
        //    {

        //        if (sender is ContactPersonManageView)
        //        {

        //            ObjectDataProvider source = (ObjectDataProvider)((ContactPersonManageView)sender).TryFindResource("ContractSource");

        //            if (source != null)
        //            {
        //                source.MethodParameters[0] = "";
        //                source.MethodParameters[1] = (Guid)e.NewValue;
        //                source.MethodParameters[2] = ((ContactPersonManageView)sender).IsClient;
        //                source.Refresh();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}
        //#endregion

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;

        //        Mode = (DocumentLifeCircle)e.OriginalSource;
        //        switch (Mode)
        //        {
        //            case DocumentLifeCircle.Save:

        //                ObjectDataProvider source = (ObjectDataProvider)((ContactPersonManageView)sender).TryFindResource("ContractSource");

        //                if (source != null)
        //                {
        //                    ((ContractManagementViewModelCollection)source.Data).SaveModel();

        //                    if (((ContractManagementViewModelCollection)source.Data).HasError)
        //                    {
        //                        MessageBox.Show(string.Join("\n", ((ContractManagementViewModelCollection)source.Data).Errors.ToArray()));
        //                    }
        //                }
        //                //if (SelectedManufacturer.CreateUserId == Guid.Empty)
        //                //{
        //                //    SelectedManufacturer.CreateUserId = LoginedUser.UserId;
        //                //}
        //                //if (SelectedManufacturer.Contracts.Count > 0)
        //                //{
        //                //    foreach (ContactsViewModel model in SelectedManufacturer.Contracts)
        //                //    {
        //                //        if (model.CreateUserId == Guid.Empty)
        //                //        {
        //                //            model.CreateUserId = LoginedUser.UserId;
        //                //        }
        //                //    }
        //                //}



        //                break;

        //        }
        //        UpdateLayout();
        //    }
        //    catch (Exception ex)
        //    {
        //        WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}

        //private void ContractList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count > 0)
        //    {
        //        var obj = e.AddedItems[0];
        //        if (obj != null && obj is ContactsViewModel)
        //        {
        //            SelectedContact = (ContactsViewModel)obj;
        //            SelectedContact.Status.IsNewInstance = false;
        //            RaiseEvent(new RoutedEventArgs(SelectedContactChangedEvent, obj));
        //        }
        //    }
        //}

        //void OnChecked(object sender, RoutedEventArgs e)
        //{
        //    DataGridCell cell = (DataGridCell)sender;
        //    CheckBox cb = (CheckBox)e.Source;
        //    ContactsViewModel currentrow = (ContactsViewModel)cell.DataContext;

        //    if (ContractList.DataContext is ContactsViewModelCollection)
        //    {
        //        var founddefuts = ((ContactsViewModelCollection)ContractList.DataContext)
        //            .Where(w => w.IsDefault == true && w.Id != currentrow.Id);

        //        if (founddefuts.Any())
        //        {
        //            if (founddefuts.Count() > 0)
        //            {
        //                foreach (var fix in founddefuts)
        //                {
        //                    fix.IsDefault = false;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (ContractList.DataContext is ManufacturersViewModel)
        //        {
        //            //      var founddefuts = ((ManufacturersViewModel)ContractList.DataContext).Contracts
        //            //.Where(w => w.IsDefault == true);

        //            //      if (founddefuts.Any())
        //            //      {
        //            //          if (founddefuts.Count() > 0)
        //            //          {
        //            //              foreach (var fix in founddefuts)
        //            //              {
        //            //                  fix.IsDefault = false;
        //            //              }
        //            //          }
        //            //      }
        //        }
        //        else
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //    }

        //    if (currentrow.IsDefault == false)
        //    {
        //        currentrow.IsDefault = true;
        //        RaiseEvent(new RoutedEventArgs(DefaultContactChangedEvent, currentrow));
        //    }


        //}
    }
}
