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
        private Tokiku.Controllers.ManufacturersController controller = new Tokiku.Controllers.ManufacturersController();
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

        public static readonly RoutedEvent SendNewPageRequestEvent = EventManager.RegisterRoutedEvent("SendNewPageRequest", RoutingStrategy.Bubble
    , typeof(RoutedEventHandler), typeof(VendorListView));

        public event RoutedEventHandler SendNewPageRequest
        {
            add { AddHandler(SendNewPageRequestEvent, value); }
            remove { RemoveHandler(SendNewPageRequestEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //搜尋框
            VendorList.ItemsSource = controller.SearchByText((string)e.OriginalSource);
        }

        private void VendorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var obj = e.AddedItems[0];
                RaiseEvent(new RoutedEventArgs(SelectedVendorChangedEvent, obj));
            }
        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            VendorList.ItemsSource = controller.QueryAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SendNewPageRequestEvent, e.OriginalSource));
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
                        RaiseEvent(new RoutedEventArgs(SelectedVendorChangedEvent, obj));
                }
            }

        }

        private void VendorList_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }
}
