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
             "SelectedProjectChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(VendorListView));

        public event RoutedEventHandler SelectedVendorChanged
        {
            add { AddHandler(SelectedVendorChangedEvent, value); }
            remove { RemoveHandler(SelectedVendorChangedEvent, value); }
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VendorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
