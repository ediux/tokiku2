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
    /// AluminumExtrusionOrderMiscellaneousView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionOrderMiscellaneousView : UserControl
    {
        public AluminumExtrusionOrderMiscellaneousView()
        {
            InitializeComponent();
            
        }

        private void AluminumExtrusionOrderMiscellaneousView_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                AluminumExtrusionOrderMiscellaneousViewModelCollection coll = new AluminumExtrusionOrderMiscellaneousViewModelCollection();
                雜項DG.DataContext = coll;
                coll.Query();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
