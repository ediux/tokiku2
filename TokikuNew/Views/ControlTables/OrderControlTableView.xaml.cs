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
    /// OrderControlTableView.xaml 的互動邏輯
    /// </summary>
    public partial class OrderControlTableView : UserControl
    {
        public OrderControlTableView()
        {
            InitializeComponent();
        }



        public Guid SelectedProjectId
        {
            get { return (Guid)GetValue(SelectedProjectIdProperty); }
            set { SetValue(SelectedProjectIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProjectId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectIdProperty =
            DependencyProperty.Register("SelectedProjectId", typeof(Guid), typeof(OrderControlTableView), new PropertyMetadata(Guid.Empty));



        private void OrderControlTableView_Loaded(object sender, RoutedEventArgs e)
        {
            OrderControlTableViewModelCollection ctrl = new OrderControlTableViewModelCollection();
            CheckGrid.DataContext = ctrl;
            OrderControlTableViewModelCollection.Query();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }
    }
}
