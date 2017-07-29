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
    /// SelectSupplierListView.xaml 的互動邏輯
    /// </summary>
    public partial class SelectSupplierListView : UserControl
    {
        public SelectSupplierListView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 取得或設定是否顯示工廠地址清單
        /// </summary>
        public bool IsShowFactoryList
        {
            get { return (bool)GetValue(IsShowFactoryListProperty); }
            set { SetValue(IsShowFactoryListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowFactoryList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowFactoryListProperty =
            DependencyProperty.Register("IsShowFactoryList", typeof(bool), typeof(SelectSupplierListView), new PropertyMetadata(true));



        #region 取得或設定專案ID
        /// <summary>
        /// 取得或設定專案ID
        /// </summary>
        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid),
                typeof(SelectSupplierListView),
                new PropertyMetadata(Guid.Empty, new PropertyChangedCallback(SelectedProjectIdChange)));

        public static void SelectedProjectIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is SelectSupplierListView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((SelectSupplierListView)sender).TryFindResource("SuppliersListSource");

                    if (source != null)
                    {
                        source.MethodParameters[0] = e.NewValue;
                        source.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion

        #region 取得或設定已經選擇的供應商
        public Guid SupplierManufactuterId
        {
            get { return (Guid)GetValue(SupplierManufactuterIdProperty); }
            set { SetValue(SupplierManufactuterIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SupplierManufactuterId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SupplierManufactuterIdProperty =
            DependencyProperty.Register("SupplierManufactuterId",
                typeof(Guid), typeof(SelectSupplierListView),
                new PropertyMetadata(Guid.Empty,
                    new PropertyChangedCallback(SelectedManufactuterIdChange)));

        public static void SelectedManufactuterIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender is SelectSupplierListView)
                {

                    ObjectDataProvider source = (ObjectDataProvider)((SelectSupplierListView)sender).TryFindResource("ManufacturerFactoryList");

                    if (source != null)
                    {
                        source.MethodParameters[0] = e.NewValue;
                        source.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion

        #region 取得或設定已選擇的工廠地址ID
        /// <summary>
        /// 取得或設定已選擇的工廠地址ID
        /// </summary>
        public Guid SelectedFactoryId
        {
            get { return (Guid)GetValue(SelectedFactoryIdProperty); }
            set { SetValue(SelectedFactoryIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedFactoryId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedFactoryIdProperty =
            DependencyProperty.Register("SelectedFactoryId", typeof(Guid), typeof(SelectSupplierListView), new PropertyMetadata(Guid.Empty));

        #endregion


        private void ManufacturerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetValue(SupplierManufactuterIdProperty, ((Tokiku.ViewModels.SuppliersViewModel)e.AddedItems[0]).ManufacturersId);
        }

        private void ManufacturerFactoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetValue(SelectedFactoryIdProperty, ((Tokiku.ViewModels.ManufacturerFactoryViewModel)e.AddedItems[0]).Id);

        }
    }
}
