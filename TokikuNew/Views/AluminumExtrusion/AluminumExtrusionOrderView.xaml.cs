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
    /// AluminumExtrusionOrderView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionOrderView : UserControl
    {
        public AluminumExtrusionOrderView()
        {
            InitializeComponent();
            
        }

        private void AluminumExtrusionOrderView_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                AluminumExtrusionOrderViewModelCollection coll = new AluminumExtrusionOrderViewModelCollection();
                鋁擠型訂製單DG.DataContext = coll;
                coll.Query();
            }catch (Exception ex) {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
