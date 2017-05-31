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
    /// ManufacturersManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ManufacturersManageView : UserControl
    {
        private ManufacturersController controller = new ManufacturersController();

        public ManufacturersManageView()
        {
            InitializeComponent();
        }

        #region 目前操作的廠商資料

        public ManufacturersViewModel SelectedManufacturers
        {
            get { return (ManufacturersViewModel)GetValue(SelectedManufacturersProperty); }
            set { SetValue(SelectedManufacturersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedManufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedManufacturersProperty =
            DependencyProperty.Register("SelectedManufacturers", typeof(ManufacturersViewModel), typeof(ManufacturersManageView), new PropertyMetadata(default(ManufacturersViewModel)));

        #endregion

        #region 登入人員

        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ManufacturersManageView), new PropertyMetadata(default(UserViewModel)));


        #endregion

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ManufacturersManageView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Binding SelectedManufacturersBinding = new Binding();
            SelectedManufacturersBinding.Source = DataContext;
            SetBinding(SelectedManufacturersProperty, SelectedManufacturersBinding);
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                if (tbName.Text.Length >= 4)
                {
                    tbShortName.Text = tbName.Text.Substring(0, Math.Min(4, tbName.Text.Length));
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

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                Mode = (DocumentLifeCircle)e.OriginalSource;

                switch (Mode)
                {
                    case DocumentLifeCircle.Create:

                        DataContext = controller.CreateNew();
                        SelectedManufacturers = (ManufacturersViewModel)DataContext;
                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            dockBar.DocumentMode = DocumentLifeCircle.Read;
                            break;
                        }
                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = false;
                        SelectedManufacturers.Status.IsNewInstance = true;

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
                                    if (model.CreateUserId == Guid.Empty)
                                    {
                                        model.CreateUserId = LoginedUser.UserId;
                                    }
                                }
                            }
                        }

                        if (SelectedManufacturers.Materials == null)
                            SelectedManufacturers.Materials = new MaterialsViewModelCollection();

                        controller.SaveModel(SelectedManufacturers);

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            Mode = dockBar.LastState;
                           
                            break;
                        }

                        if (dockBar.LastState == DocumentLifeCircle.Create)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this.Parent));
                        }
                        Mode = DocumentLifeCircle.Read;
                        break;
                    case DocumentLifeCircle.Update:
                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = false;
                        SelectedManufacturers.Status.IsNewInstance = false;
                        break;
                }
                UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
