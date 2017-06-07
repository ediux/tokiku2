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
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// ClientListView.xaml 的互動邏輯
    /// </summary>
    public partial class ClientListView : UserControl
    {
        private ClientController controller = new ClientController();

        public ClientListView()
        {
            InitializeComponent();
        }

        #region 選擇客戶變更事件
        public static readonly RoutedEvent SelectedClientChangedEvent = EventManager.RegisterRoutedEvent(
          "SelectedClientChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ClientListView));

        /// <summary>
        /// 選擇客戶變更事件
        /// </summary>
        public event RoutedEventHandler SelectedClientChanged
        {
            add { AddHandler(SelectedClientChangedEvent, value); }
            remove { RemoveHandler(SelectedClientChangedEvent, value); }
        }
        #endregion

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Controls.ClosableTabItem.SendNewPageRequestEvent, e.OriginalSource));
        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            ((ClientViewModelCollection)DataContext).Refresh();            
        }

        private void sSearchBar_Search(object sender, RoutedEventArgs e)
        {
            
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
                        RaiseEvent(new RoutedEventArgs(SelectedClientChangedEvent, ClientList.SelectedItem));
                }
            }
        }

        private void ClientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SelectedClientChangedEvent, ClientList.SelectedItem));
        }
    }
}
