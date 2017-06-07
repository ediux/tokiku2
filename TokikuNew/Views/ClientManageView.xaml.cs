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
        private Tokiku.Controllers.ContactPersonManageController contactcontroller = new Tokiku.Controllers.ContactPersonManageController();

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

        //private void sSearchBar_Search(object sender, RoutedEventArgs e)
        //{
        //    ManufacturersViewModel model = (ManufacturersViewModel)DataContext;
        //    ContractList.DataContext = contactcontroller.SearchByText((string)e.OriginalSource, model.Id, true);
        //}



        //private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        //{
        //    ManufacturersViewModel model = (ManufacturersViewModel)DataContext;

        //    ContractList.DataContext = model.Contracts;
        //}

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



        private void dockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ClientViewModel SelectedManufacturers = (ClientViewModel)DataContext;

                Mode = (DocumentLifeCircle)e.OriginalSource;
                switch (Mode)
                {

                    case DocumentLifeCircle.Create:
                        DataContext= new ClientViewModel();
                        SelectedManufacturers = (ClientViewModel)DataContext;
                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;
                            dockBar.DocumentMode = DocumentLifeCircle.Read;
                        }

                        break;
                    case DocumentLifeCircle.Save:
                        SelectedManufacturers.SaveModel();

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;
                            Mode = dockBar.LastState;
                            break;
                        }

                        if (SelectedManufacturers.Status.IsNewInstance)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
                        }

                        Mode = DocumentLifeCircle.Read;

                        SelectedManufacturers.Status.IsNewInstance = false;
                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = true;
                        break;
                    case DocumentLifeCircle.Update:
                        SelectedManufacturers.Status.IsNewInstance = false;
                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = false;
                        break;
                }
                UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {



        }
    }
}
