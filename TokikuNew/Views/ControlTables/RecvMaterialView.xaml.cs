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
                        provider.MethodParameters[0] = currentview.SelectedRecvId;
                        provider.MethodParameters[1] = e.NewValue;
                        
                        provider.Refresh();
                    }

                    //ObjectDataProvider provider2 = (ObjectDataProvider)currentview.TryFindResource("RecvMaterialDetailsSource");

                    //if (provider2 != null)
                    //{
                       
                    //    provider2.MethodParameters[0] = e.NewValue;
                    //    provider2.MethodParameters[1] = ((RecvMaterialViewModel)provider.Data).Entity.Id;

                    //    provider2.Refresh();

                    //    _masterEntity = ((RecvMaterialViewModel)provider.Data).Entity;

                    //    _masterEntity.ReceiptDetails = new Collection<ReceiveDetails>(
                    //        ((RecvMaterialDetailsViewModelCollection)provider2.Data).Select(s=>s.Entity).ToList());
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion

        #region SelectedRecvId


        public Guid SelectedRecvId
        {
            get { return (Guid)GetValue(SelectedRecvIdProperty); }
            set { SetValue(SelectedRecvIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedRecvId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedRecvIdProperty =
            DependencyProperty.Register("SelectedRecvId", typeof(Guid), typeof(RecvMaterialView), new PropertyMetadata(Guid.Empty));


        #endregion

        private void RecvMaterialView_Loaded(object sender, RoutedEventArgs e)
        {
           
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
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void StockPickSelector_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObjectDataProvider provider = (ObjectDataProvider)TryFindResource("StockPickSource");

                if (provider != null)
                {
                    StockViewModelCollection stocks = (StockViewModelCollection)provider.Data;

                    var textBox = e.OriginalSource as TextBox;

                    var query_result = stocks.Where(w => w.Name == textBox.Text);

                    if (!query_result.Any())
                    {
                        stocks.Add(new StockViewModel()
                        {
                            Id = Guid.NewGuid(),
                            Name = textBox.Text,
                            CreateTime = DateTime.Now
                        });

                        provider.Refresh();
                    }
                }
            }
            catch
            {

            }
        }
    }

}
