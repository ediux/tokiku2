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

namespace TokikuNew.Views
{
    /// <summary>
    /// 本約工程ViewUC.xaml 的互動邏輯
    /// </summary>
    public partial class 本約工程ViewUC : UserControl
    {
        public 本約工程ViewUC()
        {
            InitializeComponent();
        }

        private void 本約工程ViewUC_Loaded(object sender, RoutedEventArgs e)
        {
            //UC.DataContext = new Tokiku.ViewModels.本約工程ViewModelCollection();
        }
    }
}
