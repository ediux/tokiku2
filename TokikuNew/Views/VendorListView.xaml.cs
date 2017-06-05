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
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// VendorListView.xaml 的互動邏輯
    /// </summary>
    public partial class VendorListView : UserControl
    {
        private Tokiku.Controllers.ManufacturersManageController controller = new Tokiku.Controllers.ManufacturersManageController();
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
            //搜尋框
            VendorList.ItemsSource = controller.SearchByText((string)e.OriginalSource).Result;
        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            VendorList.ItemsSource = controller.QueryAll().Result;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Controls.ClosableTabItem.SendNewPageRequestEvent, this));
        }

        private void VendorList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
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

        private void VendorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(SelectedManufacturer!=null)
            {
                RaiseEvent(new RoutedEventArgs(SelectedVendorChangedEvent, SelectedManufacturer));
            }
        }
    }
}
