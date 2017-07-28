using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tokiku.Entity;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew.Views
{
    /// <summary>
    /// ShippingMaterialViewUC.xaml 的互動邏輯
    /// </summary>
    public partial class ShippingMaterialViewUC : UserControl
    {
        public ShippingMaterialViewUC()
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
            DependencyProperty.Register("SelectedProjectId", 
                typeof(Guid), typeof(ShippingMaterialViewUC), new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(ProjectIdChange)));

        private static PickList _masterEntity;

        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is ShippingMaterialViewUC)
                {
                    ShippingMaterialViewUC currentview = (ShippingMaterialViewUC)sender;

                    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("ShippingMaterialSource");

                    if (provider != null)
                    {
                        provider.MethodParameters[0] = currentview.SelectedShippingId;
                        provider.MethodParameters[1] = e.NewValue;

                        provider.Refresh();
                    }

                    ObjectDataProvider provider2 = (ObjectDataProvider)currentview.TryFindResource("ShippingMaterialDetailsSource");

                    if (provider2 != null)
                    {

                        provider2.MethodParameters[0] = e.NewValue;
                        provider2.MethodParameters[1] = ((RecvMaterialViewModel)provider.Data).Entity.Id;

                        provider2.Refresh();

                        _masterEntity = ((ShippingMaterialViewModel)provider.Data).Entity;
                        _masterEntity.PickListDetails = (Collection<PickListDetails>)provider2.Data;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion

        #region SelectedRecvId


        public Guid SelectedShippingId
        {
            get { return (Guid)GetValue(SelectedShippingIdProperty); }
            set { SetValue(SelectedShippingIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedRecvId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedShippingIdProperty =
            DependencyProperty.Register("SelectedShippingId", typeof(Guid), typeof(ShippingMaterialViewUC), new PropertyMetadata(Guid.Empty));


        #endregion

        private void ShippingMaterialView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddNewForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生收料單"));
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
                ShippingMaterialViewModel master = (ShippingMaterialViewModel)((ObjectDataProvider)TryFindResource("ShippingMaterialSource")).Data;

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


                master.SaveModel();

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
                    }
                }
            }
            catch
            {

            }
        }
    }
}
