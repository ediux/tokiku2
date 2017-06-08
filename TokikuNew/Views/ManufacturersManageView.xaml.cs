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
    /// ManufacturersManageView.xaml 的互動邏輯
    /// </summary>
    public partial class ManufacturersManageView : UserControl
    {
        private ManufacturersManageController controller = new ManufacturersManageController();

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

        #region PaymentTypes
        /// <summary>
        /// 支付方式定義表
        /// </summary>
        public PaymentTypesManageViewModelCollection PaymentTypes
        {
            get { return (PaymentTypesManageViewModelCollection)GetValue(PaymentTypesProperty); }
            set { SetValue(PaymentTypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypesProperty =
            DependencyProperty.Register("PaymentTypes", typeof(PaymentTypesManageViewModelCollection),
                typeof(ManufacturersManageView),
                new PropertyMetadata(default(PaymentTypesManageViewModelCollection)
                    ));
        #endregion

        #region MaterialCategories
        public MaterialCategoriesViewModelCollection MaterialCategories
        {
            get { return (MaterialCategoriesViewModelCollection)GetValue(MaterialCategoriesProperty); }
            set { SetValue(MaterialCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesProperty =
            DependencyProperty.Register("MaterialCategories", typeof(MaterialCategoriesViewModelCollection), typeof(ManufacturersManageView), new PropertyMetadata(default(MaterialCategoriesViewModelCollection)));

        #endregion



        #region TicketPeriods

        public TicketPeriodsViewModelCollection TicketPeriods
        {
            get { return (TicketPeriodsViewModelCollection)GetValue(TicketPeriodsProperty); }
            set { SetValue(TicketPeriodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TicketPeriods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicketPeriodsProperty =
            DependencyProperty.Register("TicketPeriods", typeof(TicketPeriodsViewModelCollection), typeof(ManufacturersManageView), new PropertyMetadata(default(TicketPeriodsViewModelCollection)));


        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Binding BindingDataContext = new Binding();
                BindingDataContext.Source = DataContext;

                SetBinding(SelectedManufacturersProperty, BindingDataContext);



                PaymentTypes = new PaymentTypesManageViewModelCollection();
                PaymentTypes.Query();

                TicketPeriods = new TicketPeriodsViewModelCollection();
                TicketPeriods.Query();

                if (!((ManufacturersViewModel)DataContext).Status.IsNewInstance)
                {
                    //當不是新建模式 則查詢設為預設的聯絡人顯示
                    var maincontact = ((ManufacturersViewModel)DataContext).Contracts.Where(w => w.IsDefault == true).SingleOrDefault();
                    if (maincontact != null)
                    {
                        ((ManufacturersViewModel)DataContext).MainContactPerson = maincontact.Name;
                        ((ManufacturersViewModel)DataContext).Extension = maincontact.ExtensionNumber;
                    }
                    else
                    {
                        ((ManufacturersViewModel)DataContext).MainContactPerson = string.Empty;
                        ((ManufacturersViewModel)DataContext).Extension = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

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
                        //SelectedManufacturers = (ManufacturersViewModel)DataContext;
                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;
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

                        ((ManufacturersViewModel)DataContext).SaveModel();

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            Mode = dockBar.LastState;
                            SelectedManufacturers.Errors = null;
                            //DataContext = controller.CreateNew();
                            break;
                        }

                        if (dockBar.LastState == DocumentLifeCircle.Create)
                        {
                            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this.Parent));
                        }

                        Mode = DocumentLifeCircle.Read;

                        SelectedManufacturers.Status.IsModify = false;
                        SelectedManufacturers.Status.IsSaved = true;
                        SelectedManufacturers.Status.IsNewInstance = false;

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
