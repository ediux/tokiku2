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

namespace TokikuNew.Controls
{
    /// <summary>
    /// OrdersSelector.xaml 的互動邏輯
    /// </summary>
    public partial class OrdersSelector : UserControl
    {
        public OrdersSelector()
        {
            InitializeComponent();
        }

        #region 已選擇的專案


        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(OrdersSelector), new PropertyMetadata(Guid.Empty,new PropertyChangedCallback(ProjectIdChange)));

        public static void ProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //if (sender is ShippingMaterialViewUC)
                //{
                //    ShippingMaterialViewUC currentview = (ShippingMaterialViewUC)sender;

                //    ObjectDataProvider provider = (ObjectDataProvider)currentview.TryFindResource("ShippingMaterialSource");

                //    if (provider != null)
                //    {
                //        provider.MethodParameters[0] = currentview.SelectedShippingId;
                //        provider.MethodParameters[1] = e.NewValue;

                //        provider.Refresh();
                //    }

                //    ObjectDataProvider provider2 = (ObjectDataProvider)currentview.TryFindResource("ShippingMaterialDetailsSource");

                //    if (provider2 != null)
                //    {
                //        provider2.MethodParameters[0] = ((ShippingMaterialViewModel)provider.Data).Id;
                //        provider2.Refresh();
                //    }

                //    _masterEntity = ((ShippingMaterialViewModel)provider.Data).Entity;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion
    }
}
