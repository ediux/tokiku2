using GrapeCity.Windows.SpreadSheet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;
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
                //Binding BindingDataContext = new Binding();
                //BindingDataContext.Source = DataContext;

                //SetBinding(SelectedManufacturersProperty, BindingDataContext);


                ////當不是新建模式 則查詢設為預設的聯絡人顯示
                //var maincontact = ((ManufacturersViewModel)DataContext).Contracts.Where(w => w.IsDefault == true).SingleOrDefault();
                //if (maincontact != null)
                //{
                //    ((ManufacturersViewModel)DataContext).MainContactPerson = maincontact.Name;
                //    ((ManufacturersViewModel)DataContext).Extension = maincontact.ExtensionNumber;
                //}
                //else
                //{
                //    ((ManufacturersViewModel)DataContext).MainContactPerson = string.Empty;
                //    ((ManufacturersViewModel)DataContext).Extension = string.Empty;
                //}


                ////營業項目Sheet顯示

                ////UI設定
                //BussinessItemSheet.StartSheetIndex = 0;
               


                ////BussinessItemSheet.Sheets.Clear();
                //Worksheet BISheet = BussinessItemSheet.Sheets[0];

                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[0].Label = "材料類別";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[0].DataField = "MaterialCategories";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[1].Label = "交易品項";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[1].DataField = "Name";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[2].Label = "交易類別";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[2].DataField = "TranscationCategories";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[3].Label = "支付方式";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[3].DataField = "PaymentTypeName";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[4].Label = "票期設定";
                //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[4].DataField = "TicketPeriod";

                //if (SelectedManufacturers.ManufacturersBussinessItems.Any())
                //{
                //    for (int i = 0; i < SelectedManufacturers.ManufacturersBussinessItems.Count; i++)
                //    {
                //        BISheet.Rows[i].SetText(0, SelectedManufacturers.ManufacturersBussinessItems[i].MaterialCategories);
                //        BISheet.Rows[i].SetText(1, SelectedManufacturers.ManufacturersBussinessItems[i].Name);
                //        BISheet.Rows[i].SetText(2, SelectedManufacturers.ManufacturersBussinessItems[i].TranscationCategories);
                //        BISheet.Rows[i].SetText(3, SelectedManufacturers.ManufacturersBussinessItems[i].PaymentTypeName);
                //        BISheet.Rows[i].SetText(4, SelectedManufacturers.ManufacturersBussinessItems[i].TicketPeriod);
                //    }
                //}

                //BussinessItemSheet.Invalidate();
                //if (BussinessItemSheet.SheetCount > 0)
                //{
                //    BussinessItemSheet.Sheets[0].Name = "營業項目";
                //    //BussinessItemSheet.Sheets[0].DataSource = SelectedManufacturers.ManufacturersBussinessItems;

                //    if (BussinessItemSheet.Sheets[0].ColumnCount >= 5)
                //    {
                //        int count = BussinessItemSheet.Sheets[0].ColumnCount - 5;

                //        for (int i = 0; i < count; i++)
                //        {
                //            BussinessItemSheet.Sheets[0].ColumnHeader.Columns[0].Remove();
                //        }

                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[1].Remove();
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[4].Remove();
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[8].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[9].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[11].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[12].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[13].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[14].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[15].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[16].IsVisible = false;
                //        //BussinessItemSheet.Sheets[0].ColumnHeader.Columns[17].IsVisible = false;

                //        //BussinessItemSheet.Sheets[0].BindDataColumn(0, "MaterialCategories");
                //        //BussinessItemSheet.Sheets[0].BindDataColumn(1, "Name");
                //        //BussinessItemSheet.Sheets[0].BindDataColumn(2, "MaterialCategories");
                //        //BussinessItemSheet.Sheets[0].BindDataColumn(3, "MaterialCategories");
                //        //BussinessItemSheet.Sheets[0].BindDataColumn(4, "MaterialCategories");


                //    }

                //}


                //Worksheet BISheet = new Worksheet();
                //BISheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
                //BussinessItemSheet.Sheets.Add(BISheet);
                //BussinessItemSheet.CanUserEditFormula = false;
                //BussinessItemSheet.CanUserUndo = true;
                //BussinessItemSheet.CanUserZoom = true;

                //MaterialCategoriesViewModelCollection MaterialCategories = (MaterialCategoriesViewModelCollection)FindResource("MaterialCategoriesSource");

                //if (MaterialCategories != null)
                //{
                //    MaterialCategories.Refresh();
                //}

                //BISheet.AddRows(0, SelectedManufacturers.ManufacturersBussinessItems.Count);
                //BISheet.Name = "營業項目";
                //BISheet.ColumnHeader.Columns[0].Label = "材料類別";
                //BISheet.ColumnHeader.Columns[1].Label = "交易品項";
                //BISheet.ColumnHeader.Columns[2].Label = "交易類別";
                //BISheet.ColumnHeader.Columns[3].Label = "支付方式";
                //BISheet.ColumnHeader.Columns[4].Label = "票期設定";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void OnInsertSumFormula(object sender, GrapeCity.Windows.SpreadSheet.UI.ActionEventArgs args)
        {
          
            //BussinessItemSheet.Sheets[0].AddRows(BussinessItemSheet.Sheets[0].RowCount, 1);

            //for (int c = 0; c < 5; c++)
            //{
            //    BussinessItemSheet.Sheets[0].AddColumns(c, 1);
            //}
         
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
                //e.Handled = true;

                //Mode = (DocumentLifeCircle)e.OriginalSource;

                //switch (Mode)
                //{
                //    case DocumentLifeCircle.Create:

                //        DataContext = controller.CreateNew();
                //        //SelectedManufacturers = (ManufacturersViewModel)DataContext;
                //        SelectedManufacturers.CreateUserId = LoginedUser.UserId;
                //        if (SelectedManufacturers.HasError)
                //        {
                //            MessageBox.Show(string.Join("\n", SelectedManufacturers.Errors.ToArray()));
                //            SelectedManufacturers.Errors = null;
                //            dockBar.DocumentMode = DocumentLifeCircle.Read;
                //            break;
                //        }
                //        SelectedManufacturers.Status.IsModify = false;
                //        SelectedManufacturers.Status.IsSaved = false;
                //        SelectedManufacturers.Status.IsNewInstance = true;

                //        break;
                //    case DocumentLifeCircle.Save:
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
                //ManufacturersBussinessItemsViewModel newitem = new ManufacturersBussinessItemsViewModel();
                //newitem.Id = Guid.NewGuid();
                //newitem.ManufacturersId = SelectedManufacturers.Id;
                //newitem.MaterialCategoriesId = ((MaterialCategoriesViewModel)cbMaterialCategoriesList.SelectedItem).Id;
                //newitem.MaterialCategories = ((MaterialCategoriesViewModel)cbMaterialCategoriesList.SelectedItem).Name;
                //newitem.Name = tbTrancationItem.Text;
                //newitem.PaymentTypeId = (byte)cbPaymentTypeBI.SelectedValue;
                //newitem.PaymentTypeName = ((PaymentTypesManageViewModel)cbPaymentTypeBI.SelectedItem).PaymentTypeName;
                //newitem.TicketPeriodId = (int)cbTicketPeriodBI.SelectedValue;
                //newitem.TicketPeriod = ((TicketPeriodsViewModel)cbTicketPeriodBI.SelectedItem).Name;
                //newitem.TranscationCategoriesId = (int)cbTranscationCategories.SelectedValue;
                //newitem.TranscationCategories = ((TranscationCategoriesViewModel)cbTranscationCategories.SelectedItem).Name;

                //SelectedManufacturers.ManufacturersBussinessItems.Add(newitem);

                //if (SelectedManufacturers.ManufacturersBussinessItems.Any())
                //{
                //    Worksheet BISheet = BussinessItemSheet.Sheets[0];

                //    for (int i = 0; i < SelectedManufacturers.ManufacturersBussinessItems.Count; i++)
                //    {
                //        BISheet.Rows[i].SetText(0, SelectedManufacturers.ManufacturersBussinessItems[i].MaterialCategories);
                //        BISheet.Rows[i].SetText(1, SelectedManufacturers.ManufacturersBussinessItems[i].Name);
                //        BISheet.Rows[i].SetText(2, SelectedManufacturers.ManufacturersBussinessItems[i].TranscationCategories);
                //        BISheet.Rows[i].SetText(3, SelectedManufacturers.ManufacturersBussinessItems[i].PaymentTypeName);
                //        BISheet.Rows[i].SetText(4, SelectedManufacturers.ManufacturersBussinessItems[i].TicketPeriod);
                //    }
                //}
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
    }
}
