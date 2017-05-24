using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TokikuNew.Controls
{   
    /// <summary>
    /// ClosableTab.xaml 的互動邏輯
    /// </summary>
    public partial class ClosableTab : UserControl
    {
        public ClosableTab()
        {
            InitializeComponent();
        }

        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs eu = new RoutedEventArgs(ButtonBase.ClickEvent, btnTabClose);
            base.RaiseEvent(eu);
        }
    }
}
