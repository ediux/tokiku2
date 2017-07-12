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
    /// InventoryListView.xaml 的互動邏輯
    /// </summary>
    public partial class InventoryListView : UserControl
    {
        public InventoryListView()
        {
            InitializeComponent();
        }

        private void InventoryListView_Loaded(object sender, RoutedEventArgs e)
        {
            InventoryListViewModelCollection ctrl = new InventoryListViewModelCollection();
            CheckGrid.DataContext = ctrl;
            ctrl.Query();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
