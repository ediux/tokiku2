using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// VendorListView.xaml 的互動邏輯
    /// </summary>
    public partial class VendorListView : UserControl
    {

        public VendorListView()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent SelectedVendorChangedEvent = EventManager.RegisterRoutedEvent(
             "SelectedVendorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(VendorListView));

        public event RoutedEventHandler SelectedVendorChanged
        {
            add { AddHandler(SelectedVendorChangedEvent, value); }
            remove { RemoveHandler(SelectedVendorChangedEvent, value); }
        }



        public ManufacturersViewModel SelectedManufacturer
        {
            get { return (ManufacturersViewModel)GetValue(SelectedManufacturerProperty); }
            set { SetValue(SelectedManufacturerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedManufacturer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedManufacturerProperty =
            DependencyProperty.Register("SelectedManufacturer", typeof(ManufacturersViewModel), typeof(VendorListView), new PropertyMetadata(default(ManufacturersViewModel)));



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ManufacturersViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            //搜尋框


        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ManufacturersViewModelCollection)DataContext).Query();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                RaiseEvent(new RoutedEventArgs(Controls.ClosableTabItem.SendNewPageRequestEvent, this));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void VendorList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (e.AddedCells.Any())
                {
                    var obj = e.AddedCells.First().Item;
                    var header = e.AddedCells.First().Column.DisplayIndex;

                    if (header == 0)
                    {
                        if (obj != null)
                        {
                            SelectedManufacturer = (ManufacturersViewModel)obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }



        }

        private void VendorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (SelectedManufacturer != null)
                {
                    RaiseEvent(new RoutedEventArgs(SelectedVendorChangedEvent, SelectedManufacturer));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataContext != null)
                {
                    ManufacturersViewModelCollection DataSource = (ManufacturersViewModelCollection)DataContext;
                    if (DataSource != null && DataSource.Count == 0)
                    {
                        Dispatcher.Invoke(DataSource.Query, DispatcherPriority.Background);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
    }
}
