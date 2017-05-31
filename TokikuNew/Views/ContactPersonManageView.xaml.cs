﻿using System;
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
    /// ContactPersonManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ContactPersonManageView : UserControl
    {
        private ContactController controller = new ContactController();

        public ContactPersonManageView()
        {
            InitializeComponent();
        }


        #region 登入人員

        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ContactPersonManageView), new PropertyMetadata(default(UserViewModel)));


        #endregion

        #region Document Mode

        /// <summary>
        /// 文件模式
        /// </summary>
        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ContactPersonManageView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region SelectedContact
        /// <summary>
        /// 選擇的聯絡人
        /// </summary>
        public ContactsViewModel SelectedContact
        {
            get { return (ContactsViewModel)GetValue(SelectedContactProperty); }
            set { SetValue(SelectedContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedContact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedContactProperty =
            DependencyProperty.Register("SelectedContact", typeof(ContactsViewModel),
                typeof(ContactPersonManageView), new PropertyMetadata(default(ContactsViewModel)));
        #endregion

        #region 分頁關閉事件
        public static readonly RoutedEvent OnPageClosingEvent = 
            EventManager.RegisterRoutedEvent("OnPageClosingEvent", 
                RoutingStrategy.Bubble, 
                typeof(RoutedEventHandler),
                typeof(ContactPersonManageView));
        
        /// <summary>
        /// 發出關閉分頁事件
        /// </summary>
        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }
        #endregion

        #region 聯絡人選擇變更事件
        public static readonly RoutedEvent SelectedContactChangedEvent = EventManager.RegisterRoutedEvent(
          "SelectedClientChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContactPersonManageView));

        public event RoutedEventHandler SelectedContactChanged
        {
            add { AddHandler(SelectedContactChangedEvent, value); }
            remove { RemoveHandler(SelectedContactChangedEvent, value); }
        }
        #endregion

        #region 資料來源副本(廠商/聯絡人)
        public ManufacturersViewModel SelectedManufacturer
        {
            get { return (ManufacturersViewModel)GetValue(SelectedManufacturerProperty); }
            set { SetValue(SelectedManufacturerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contracts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedManufacturerProperty =
            DependencyProperty.Register("SelectedManufacturer", typeof(ManufacturersViewModel)
                , typeof(ContactPersonManageView), new PropertyMetadata(default(ManufacturersViewModel)));
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));
            Binding sourceBinding = new Binding();
            sourceBinding.Source = DataContext;

            SetBinding(SelectedManufacturerProperty, sourceBinding);
        }

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                Mode = (DocumentLifeCircle)e.OriginalSource;
                switch (Mode)
                {
                    case DocumentLifeCircle.Save:
                        if (SelectedManufacturer.CreateUserId == Guid.Empty)
                        {
                            SelectedManufacturer.CreateUserId = LoginedUser.UserId;
                        }
                        if (SelectedManufacturer.Contracts.Count > 0)
                        {
                            foreach (ContactsViewModel model in SelectedManufacturer.Contracts)
                            {
                                if (model.CreateUserId == Guid.Empty)
                                {
                                    model.CreateUserId = LoginedUser.UserId;
                                }
                            }
                        }

                        if (SelectedManufacturer.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturer.Errors.ToArray()));
                        }

                        break;

                }
                UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ContractSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            DataContext = controller.QueryAll();
        }

        private void ContractSearchBar_Search(object sender, RoutedEventArgs e)
        {
            DataContext = controller.SearchByText((string)e.OriginalSource, SelectedManufacturer.Id, SelectedManufacturer.IsClient);
        }

        private void ContractList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var obj = e.AddedItems[0];
                if (obj != null && obj is ContactsViewModel)
                {
                    SelectedContact = (ContactsViewModel)obj;
                    SelectedContact.Status.IsNewInstance = false;
                    RaiseEvent(new RoutedEventArgs(SelectedContactChangedEvent, obj));
                }
            }
        }
    }
}
