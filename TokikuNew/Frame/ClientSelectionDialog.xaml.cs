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
using System.Windows.Shapes;
using Tokiku.ViewModels;

namespace TokikuNew.Frame
{
    /// <summary>
    /// ClientSelectionDialog.xaml 的互動邏輯
    /// </summary>
    public partial class ClientSelectionDialog : Window
    {
        public ClientSelectionDialog()
        {
            InitializeComponent();
        }





        public ClientViewModel SelectedClient
        {
            get { return (ClientViewModel)GetValue(SelectedClientProperty); }
            set { SetValue(SelectedClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedClientProperty =
            DependencyProperty.Register("SelectedClient", typeof(ClientViewModel), typeof(ClientSelectionDialog), new PropertyMetadata(default(ClientViewModel)));





        private void ClientListView_SelectedClientChanged(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            e.Handled = true;
            SelectedClient = (ClientViewModel)e.OriginalSource;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var model = new ClientViewModelCollection();
            model.Query();
            ClientSelectionList.DataContext = model;
        }
    }
}
