using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        #region Mode
        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(ClientManageView), new PropertyMetadata(DocumentLifeCircle.Create));
        #endregion

        #region LoginedUser
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginedUserProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(ClientManageView), new PropertyMetadata(default(UserViewModel)));

        #endregion

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
                        DataContext = new ClientViewModel();
                        SelectedManufacturers = (ClientViewModel)DataContext;
                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                        SelectedManufacturers.CreateTime = DateTime.Now;
                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;
                            //dockBar.DocumentMode = DocumentLifeCircle.Read;
                        }
                        SelectedManufacturers.Status.IsNewInstance = true;
                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = false;
                        break;
                    case DocumentLifeCircle.Save:
                        
                        SelectedManufacturers.SaveModel();

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;                      
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
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void EngList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (EngList.SelectedItem != null)
                {
                    RaiseEvent(new RoutedEventArgs(ProjectSelectListView.SelectedProjectChangedEvent, EngList.SelectedItem));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
           
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tbShortName.Text = tbName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(dockBar_DocumentModeChanged));
            ClientViewModel SelectedManufacturers = (ClientViewModel)DataContext;
            SelectedManufacturers.ClientForProjects.QueryByClient(SelectedManufacturers.Id);
            SelectedManufacturers.Contracts.Query("", SelectedManufacturers.Id, SelectedManufacturers.IsClient);
        }
    }
}
