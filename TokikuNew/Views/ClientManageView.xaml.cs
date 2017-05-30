﻿using System;
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
using Tokiku.ViewModels;
using TokikuNew.Controls;
using WinForm = System.Windows.Forms;

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

        private Tokiku.Controllers.ClientController controller = new Tokiku.Controllers.ClientController();
        private Tokiku.Controllers.ContactController contactcontroller = new Tokiku.Controllers.ContactController();

        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ClientManageView), new PropertyMetadata(DocumentLifeCircle.Create));



        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUserProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ClientManageView), new PropertyMetadata(default(UserViewModel)));

        private void sSearchBar_Search(object sender, RoutedEventArgs e)
        {
            ManufacturersViewModel model = (ManufacturersViewModel)DataContext;
            ContractList.ItemsSource = contactcontroller.SearchByText((string)e.OriginalSource, model.Id, true);
        }

        #region 分頁關閉事件

        public static readonly RoutedEvent OnPageClosingEvent = EventManager.RegisterRoutedEvent(
"OnPageClosingEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClientManageView));

        public event RoutedEventHandler OnPageClosing
        {
            add { AddHandler(OnPageClosingEvent, value); }
            remove { RemoveHandler(OnPageClosingEvent, value); }
        }

        #endregion

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            ManufacturersViewModel model = (ManufacturersViewModel)DataContext;

            ContractList.ItemsSource = model.Contracts;
        }

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

        private void ContractList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void dockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClientViewModel SelectedManufacturers = (ClientViewModel)DataContext;

                DocumentLifeCircle mode = (DocumentLifeCircle)e.OriginalSource;
                switch (mode)
                {

                    case DocumentLifeCircle.Create:
                        this.DataContext = controller.CreateNew();

                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            dockBar.DocumentMode = DocumentLifeCircle.Read;
                        }

                        break;
                    case DocumentLifeCircle.Save:
                        if (SelectedManufacturers.CreateUserId == Guid.Empty)
                        {
                            SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                        }

                        if (SelectedManufacturers.Contracts != null)
                        {
                            if (SelectedManufacturers.Contracts.Count > 0)
                            {
                                foreach (ContactsViewModel model in SelectedManufacturers.Contracts)
                                {
                                    if (model.CreateUserId == Guid.Empty)
                                    {
                                        model.CreateUserId = LoginedUser.UserId;
                                    }
                                }
                            }
                        }

                        if (SelectedManufacturers.Engineerings != null)
                        {
                            if (SelectedManufacturers.Engineerings.Count > 0)
                            {
                                foreach (EngineeringViewModel model in SelectedManufacturers.Engineerings)
                                {

                                }
                            }
                        }

                        if (SelectedManufacturers.Materials == null)
                            SelectedManufacturers.Materials = new MaterialsViewModelCollection();
                      
                        controller.SaveModel(SelectedManufacturers);

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            dockBar.DocumentMode = DocumentLifeCircle.Update;
                        }
                        else
                        {
                            dockBar.DocumentMode = DocumentLifeCircle.Read;
                        }
                        RaiseEvent(new RoutedEventArgs(OnPageClosingEvent, this));
                        break;
                    case DocumentLifeCircle.Update:

                        break;
                }
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Binding DocumentModeBinding = new Binding();
            DocumentModeBinding.Source = Mode;

            dockBar.SetBinding(DockBar.DocumentModeProperty, DocumentModeBinding);

           
        }
    }
}
