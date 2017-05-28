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
using Tokiku.Controllers;

namespace TokikuNew.Views
{
    /// <summary>
    /// ClientListView.xaml 的互動邏輯
    /// </summary>
    public partial class ClientListView : UserControl
    {
        private ManufacturersController controller = new ManufacturersController();

        public ClientListView()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent SelectedClientChangedEvent = EventManager.RegisterRoutedEvent(
             "SelectedClientChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClientListView));

        public event RoutedEventHandler SelectedClientChanged
        {
            add { AddHandler(SelectedClientChangedEvent, value); }
            remove { RemoveHandler(SelectedClientChangedEvent, value); }
        }

        public static readonly RoutedEvent SendNewPageRequestEvent = EventManager.RegisterRoutedEvent("SendNewPageRequest", RoutingStrategy.Bubble
    , typeof(RoutedEventHandler), typeof(ClientListView));

        public event RoutedEventHandler SendNewPageRequest
        {
            add { AddHandler(SendNewPageRequestEvent, value); }
            remove { RemoveHandler(SendNewPageRequestEvent, value); }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SendNewPageRequestEvent, e.OriginalSource));
        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            ClientList.ItemsSource = controller.QueryAll();
        }

        private void sSearchBar_Search(object sender, RoutedEventArgs e)
        {
            ClientList.ItemsSource = controller.SearchByText((string)e.OriginalSource);
        }

        private void ClientList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Any())
            {
                var obj = e.AddedCells.First().Item;
                var header = e.AddedCells.First().Column.DisplayIndex;

                if (header == 0)
                {
                    if (obj != null)
                        RaiseEvent(new RoutedEventArgs(SelectedClientChangedEvent, obj));
                }
            }
        }

        private void ClientList_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }
}
