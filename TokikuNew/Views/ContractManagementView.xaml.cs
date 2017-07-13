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
    /// ContractManagementView.xaml 的互動邏輯
    /// </summary>
    public partial class ContractManagementView : UserControl
    {
        public ContractManagementView()
        {
            InitializeComponent();
        }

        private void ContractManagementView_Loaded(object sender, RoutedEventArgs e)
        {
            ContractManagementViewModelCollection ctrl = new ContractManagementViewModelCollection();
            CheckGrid.DataContext = ctrl;
            //ctrl.Query();
        }
    }
}
