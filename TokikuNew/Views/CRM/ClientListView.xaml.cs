using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Tokiku.Controllers;
using Tokiku.ViewModels;
using TokikuNew.Controls;

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
            RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, e.OriginalSource));
        }

        private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        {
            ((ClientViewModelCollection)DataContext).Query();
        }

        private void sSearchBar_Search(object sender, RoutedEventArgs e)
        {
            ((ClientViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
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
            e.Handled = true;
            RaiseEvent(new RoutedEventArgs(SelectedClientChangedEvent, ClientList.SelectedItem));
        }

        private void sSearchBar_RefreshResult(object sender, RoutedEventArgs e)
        {
            ((ClientViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
        }

        private bool IsStartUped = false;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var DataSource = ((ClientViewModelCollection)DataContext);
            if (!IsStartUped)
            {
                if (DataSource != null)
                {
                    Dispatcher.Invoke(DataSource.Query, DispatcherPriority.Background);
                }

                IsStartUped = true;
            }
        }
    }
}
