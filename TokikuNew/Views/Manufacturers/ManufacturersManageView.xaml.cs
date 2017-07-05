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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AddHandler(DockBar.DocumentModeChangedEvent, new RoutedEventHandler(DockBar_DocumentModeChanged));

                Binding BindingDataContext = new Binding();
                BindingDataContext.Source = DataContext;
                SetBinding(SelectedManufacturersProperty, BindingDataContext);

                //查詢營業項目
                SelectedManufacturers.ManufacturersBussinessItems.QueryAsync(SelectedManufacturers.Id);

                //當不是新建模式 則查詢設為預設的聯絡人顯示
                ((ManufacturersViewModel)DataContext).Contracts.Query("", SelectedManufacturers.Id, false);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }



        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (tbName.Text.Length > 0)
            //{
            //    tbShortName.Text = tbName.Text;
            //    tbBankAccountName.Text = tbName.Text;
            //}
            //else
            //{
            //    tbShortName.Text = string.Empty;
            //}
        }

        private void DockBar_DocumentModeChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                ManufacturersViewModel SelectedManufacturers = (ManufacturersViewModel)DataContext;
                Mode = (DocumentLifeCircle)e.OriginalSource;

                switch (Mode)
                {
                    case DocumentLifeCircle.Create:
                        DataContext = new ManufacturersViewModel();
                        SelectedManufacturers = (ManufacturersViewModel)DataContext;
                        SelectedManufacturers.CreateUserId = LoginedUser.UserId;

                        if (SelectedManufacturers.HasError)
                        {
                            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                            SelectedManufacturers.Errors = null;

                        }
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


                //            SelectedManufacturers.Errors = null;
                //            dockBar.DocumentMode = DocumentLifeCircle.Read;
                //            break;

                //        SelectedManufacturers.Status.IsModify = false;
                //        SelectedManufacturers.Status.IsSaved = false;
                //        SelectedManufacturers.Status.IsNewInstance = true;

                //        break;

                //        if (SelectedManufacturers.CreateUserId == Guid.Empty)
                //        {
                //            SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                //        }

                //        MaterialCategoriesViewModelCollection MaterialCategories = (MaterialCategoriesViewModelCollection)FindResource("MaterialCategoriesSource");
                //        TranscationCategoriesViewModelCollection TranscationCategories = (TranscationCategoriesViewModelCollection)FindResource("TranscationCategoriesSource");
                //        PaymentTypesManageViewModelCollection PaymentTypes = (PaymentTypesManageViewModelCollection)FindResource("PaymentTypesSource");
                //        TicketPeriodsViewModelCollection TicketPeriods = (TicketPeriodsViewModelCollection)FindResource("TicketPeriodsSource");

                //        Worksheet BISheet = BussinessItemSheet.Sheets[0];

                //        ManufacturersBussinessItemsViewModelColletion CurrentSheet = new ManufacturersBussinessItemsViewModelColletion();

                //        for (int i = 0; i < BussinessItemSheet.Sheets[0].RowCount; i++)
                //        {
                //            try
                //            {
                //                ManufacturersBussinessItemsViewModel entity = new ManufacturersBussinessItemsViewModel();
                //                entity.Id = Guid.NewGuid();

                //                entity.ManufacturersId = SelectedManufacturers.Id;

                //                string column_1 = BISheet.Rows[i].GetText(0);
                //                entity.MaterialCategories = column_1;
                //                entity.MaterialCategoriesId = MaterialCategories.Where(w => w.Name == column_1).Single().Id;

                //                string column_2 = BISheet.Rows[i].GetText(1);

                //                entity.Name = column_2;

                //                string column_3 = BISheet.Rows[i].GetText(2);
                //                entity.TranscationCategories = column_3;
                //                entity.TranscationCategoriesId = TranscationCategories.Where(w => w.Name == column_3).Single().Id;

                //                string column_4 = BISheet.Rows[i].GetText(3);
                //                entity.PaymentTypeName = column_4;
                //                entity.PaymentTypeId = PaymentTypes.Where(w => w.PaymentTypeName == column_4).Single().Id;

                //                string column_5 = BISheet.Rows[i].GetText(4);

                //                entity.TicketPeriod = column_5;
                //                entity.TicketPeriodId = TicketPeriods.Where(w => w.Name == column_5).Single().Id;

                //                var founditemset = SelectedManufacturers.ManufacturersBussinessItems
                //                    .Where(w => w.ManufacturersId == entity.ManufacturersId &&
                //                    w.MaterialCategories == entity.MaterialCategories
                //                    && w.Name == entity.Name && w.PaymentTypeName == entity.PaymentTypeName
                //                    && w.TicketPeriod == entity.TicketPeriod && w.TranscationCategories == entity.TranscationCategories);

                //                if (founditemset.Any())
                //                {
                //                    entity.Id = founditemset.Single().Id;
                //                }

                //                CurrentSheet.Add(entity);
                //            }
                //            catch
                //            {
                //                continue;
                //            }
                //        }

                //        var toAdd = CurrentSheet.Except(SelectedManufacturers.ManufacturersBussinessItems).ToList();
                //        var toDel = SelectedManufacturers.ManufacturersBussinessItems.Except(CurrentSheet).ToList();

                //        foreach (var delitem in toDel)
                //        {
                //            SelectedManufacturers.ManufacturersBussinessItems.Remove(delitem);
                //        }

                //        foreach (var additem in toAdd)
                //        {
                //            SelectedManufacturers.ManufacturersBussinessItems.Add(additem);
                //        }

                //        ((ManufacturersViewModel)DataContext).SaveModel();

                //        if (SelectedManufacturers.HasError)
                //        {
                //            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                //            Mode = dockBar.LastState;
                //            SelectedManufacturers.Errors = null;
                //            //DataContext = controller.CreateNew();
                //            break;
                //        }

                //        if (dockBar.LastState == DocumentLifeCircle.Create)
                //        {
                //            RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this.Parent));
                //        }

                //        Mode = DocumentLifeCircle.Read;

                //        SelectedManufacturers.Status.IsModify = false;
                //        SelectedManufacturers.Status.IsSaved = true;
                //        SelectedManufacturers.Status.IsNewInstance = false;

                //        break;
                //    case DocumentLifeCircle.Update:
                //        SelectedManufacturers.Status.IsModify = false;
                //        SelectedManufacturers.Status.IsSaved = false;
                //        SelectedManufacturers.Status.IsNewInstance = false;
                //        break;
                //}
                //UpdateLayout();
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnAddMBI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                ManufacturersBussinessItemsViewModel newitem = new ManufacturersBussinessItemsViewModel();
                newitem.Id = Guid.NewGuid();
                newitem.ManufacturersId = SelectedManufacturers.Id;
                newitem.MaterialCategoriesId = ((MaterialCategoriesViewModel)cbMaterialCategoriesList.SelectedItem).Id;
                newitem.MaterialCategories = ((MaterialCategoriesViewModel)cbMaterialCategoriesList.SelectedItem).Name;
                newitem.Name = tbTrancationItem.Text;
                newitem.PaymentTypeId = (byte)cbPaymentTypeBI.SelectedValue;
                newitem.PaymentTypeName = ((PaymentTypesManageViewModel)cbPaymentTypeBI.SelectedItem).PaymentTypeName;
                newitem.TicketPeriodId = (int)cbTicketPeriodBI.SelectedValue;
                newitem.TicketPeriod = ((TicketPeriodsViewModel)cbTicketPeriodBI.SelectedItem).Name;
                newitem.TranscationCategoriesId = (int)cbTranscationCategories.SelectedValue;
                newitem.TranscationCategories = ((TranscationCategoriesViewModel)cbTranscationCategories.SelectedItem).Name;

                SelectedManufacturers.ManufacturersBussinessItems.Add(newitem);

                if (SelectedManufacturers.ManufacturersBussinessItems.Any())
                {
                    Worksheet BISheet = BussinessItemSheet.Sheets[0];

                    for (int i = 0; i < SelectedManufacturers.ManufacturersBussinessItems.Count; i++)
                    {
                        BISheet.Rows[i].SetText(0, SelectedManufacturers.ManufacturersBussinessItems[i].MaterialCategories);    // 材料類別
                        BISheet.Rows[i].SetText(1, SelectedManufacturers.ManufacturersBussinessItems[i].Name);                  // 交易品項
                        BISheet.Rows[i].SetText(2, SelectedManufacturers.ManufacturersBussinessItems[i].TranscationCategories); // 交易類別
                        BISheet.Rows[i].SetText(3, SelectedManufacturers.ManufacturersBussinessItems[i].PaymentTypeName);       // 支付方式
                        BISheet.Rows[i].SetText(4, SelectedManufacturers.ManufacturersBussinessItems[i].TicketPeriod);          // 票期
                    }
                } // */
            }
            catch (Exception ex)
            {
                WinForm.MessageBox.Show(ex.Message, "錯誤", WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error, WinForm.MessageBoxDefaultButton.Button1, WinForm.MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void tbAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //if (!tbInvoiceAddress.IsEnabled)
                //{
                //    tbInvoiceAddress.Text = tbAddress.Text;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            }
        }

        private void userControl_ManufacturersManageView_Initialized(object sender, EventArgs e)
        {
            //Dictionary<GrapeCity.Windows.SpreadSheet.UI.KeyStroke, GrapeCity.Windows.SpreadSheet.UI.SpreadAction> keyMap = BussinessItemSheet.View.KeyMap;
            //keyMap.Add(new GrapeCity.Windows.SpreadSheet.UI.KeyStroke(Key.F12, ModifierKeys.None), new GrapeCity.Windows.SpreadSheet.UI.SpreadAction(OnInsertSumFormula));
        }

        private void checkcopyaddress_Checked(object sender, RoutedEventArgs e)
        {
            tbInvoiceAddress.Text = tbAddress.Text;
        }

        private void checkcopyaddress_Unchecked(object sender, RoutedEventArgs e)
        {
            tbInvoiceAddress.Text = string.Empty;
        }
    }
}
