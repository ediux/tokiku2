using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tokiku.Entity;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// RecvMaterialView.xaml 的互動邏輯
    /// </summary>
    public partial class RecvMaterialView : UserControl
    {
        public RecvMaterialView()
        {
            InitializeComponent();

            InitialSpreadRecvMaterial();
        }



        #region SelectedProjectId
        /// <summary>
        /// 目前已選擇的專案ID
        /// </summary>
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(RecvMaterialView), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));

        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is RecvMaterialView)
                {
                    RecvMaterialView currentview = (RecvMaterialView)sender;

                    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("RecvMaterialSource");

                    if (provider != null)
                    {
                        provider.MethodParameters[0] = e.NewValue;
                        provider.Refresh();
                    }

                    ObjectDataProvider provider2 = (ObjectDataProvider)currentview.TryFindResource("RecvMaterialDetailsSource");

                    if (provider2 != null)
                    {
                        provider2.MethodParameters[0] = e.NewValue;
                        provider2.MethodParameters[1] = ((RecvMaterialViewModel)provider.Data).Entity.Id;

                        provider2.Refresh();

                        ((RecvMaterialViewModel)provider.Data).Entity.ReceiptDetails = (Collection<Tokiku.Entity.ReceiveDetails>)provider2.Data;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion

        private void RecvMaterialView_Loaded(object sender, RoutedEventArgs e)
        {
            //RecvMaterialViewModelCollection ctrl = new RecvMaterialViewModelCollection();
            //CheckGrid.DataContext = ctrl;
            //RecvMaterialViewModelCollection.Query();
        }

        private void InitialSpreadRecvMaterial()
        {
            //this.gcRecvMaterial.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcRecvMaterial.StartSheetIndex = 0;
            //this.gcRecvMaterial.Sheets.Clear();

            //Worksheet RMSheet = new Worksheet();
            //RMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcRecvMaterial.Sheets.Add(RMSheet);
            //this.gcRecvMaterial.CanUserEditFormula = false;
            //this.gcRecvMaterial.CanUserUndo = true;
            //this.gcRecvMaterial.CanUserZoom = true;
            //var sheet = this.gcRecvMaterial.ActiveSheet;

            //RMSheet.ColumnHeader.Columns[0].Label = "訂製單號";
            //RMSheet.ColumnHeader.Columns[1].Label = "批號";
            //RMSheet.ColumnHeader.Columns[2].Label = "項次";
            //RMSheet.ColumnHeader.Columns[3].Label = "東菊編號";
            //RMSheet.ColumnHeader.Columns[4].Label = "大同編號";
            //RMSheet.ColumnHeader.Columns[5].Label = "材質";
            //RMSheet.ColumnHeader.Columns[6].Label = "單位重(kg/m)";
            //RMSheet.ColumnHeader.Columns[7].Label = "訂購長度(mm)";
            //RMSheet.ColumnHeader.Columns[8].Label = "下單數量";
            //RMSheet.ColumnHeader.Columns[9].Label = "出貨順序";
            //RMSheet.ColumnHeader.Columns[10].Label = "重量";
            //RMSheet.ColumnHeader.Columns[11].Label = "缺料";
            //RMSheet.ColumnHeader.Columns[12].Label = "*收料量*";
            //RMSheet.ColumnHeader.Columns[13].Label = "[備註]";

            //RMSheet.Columns[0].Width = 100;
            //RMSheet.Columns[1].Width = 100;
            //RMSheet.Columns[2].Width = 100;
            //RMSheet.Columns[3].Width = 120;
            //RMSheet.Columns[4].Width = 120;
            //RMSheet.Columns[5].Width = 120;
            //RMSheet.Columns[6].Width = 100;
            //RMSheet.Columns[7].Width = 100;
            //RMSheet.Columns[8].Width = 100;
            //RMSheet.Columns[9].Width = 100;
            //RMSheet.Columns[10].Width = 100;
            //RMSheet.Columns[11].Width = 100;
            //RMSheet.Columns[12].Width = 100;
            //RMSheet.Columns[13].Width = 100;
        }

        private void BtnAddNewForm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生加工訂製單"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RecvMaterialViewModel master = (RecvMaterialViewModel)((ObjectDataProvider)TryFindResource("RecvMaterialSource")).Data;
                //OrderDetailViewModelCollection details = (OrderDetailViewModelCollection)((ObjectDataProvider)TryFindResource("AluminumExtrusionOrderSource2")).Data;
                //AluminumExtrusionOrderMaterialValuationViewModelCollection OrderMaterialValuation = (AluminumExtrusionOrderMaterialValuationViewModelCollection)((ObjectDataProvider)TryFindResource("MaterialValuationViewSource")).Data;
                //OrderMiscellaneousViewModelCollection misc = (OrderMiscellaneousViewModelCollection)((ObjectDataProvider)TryFindResource("OrderMiscellaneousSource")).Data;

                if (master == null)
                    return;
              
                master.CreateTime = DateTime.Now;

                //if (master.MakingTime.HasValue == false)
                //    master.MakingTime = DateTime.Now;

                //if (details.Count > 0)
                //{

                //    master.Entity.OrderDetails = new Collection<OrderDetails>();
                //    foreach (var item in details)
                //    {
                //        item.CreateTime = DateTime.Now;
                //        item.Entity.Orders = master.Entity;
                //        item.Entity.OrderId = master.Id;

                //        if (item.Entity.Id == Guid.Empty)
                //            item.Entity.Id = Guid.NewGuid();

                //        master.Entity.OrderDetails.Add(item.Entity);
                //    }



                //}

               
                master.SaveModel("RecvMaterial");

                if (master.HasError)
                {
                    MessageBox.Show(string.Join("\n", master.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    master.Errors = new string[] { };
                    master.HasError = false;
                    return;
                }

                RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));
                //var provider = (ObjectDataProvider)TryFindResource("RequiredSource");
                //provider.MethodName = "Query";
                //provider.MethodParameters.Clear();
                //provider.MethodParameters.Add(master.Id);
                //provider.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }

}
