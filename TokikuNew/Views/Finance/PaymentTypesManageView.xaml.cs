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
    /// PaymentTypesManageView.xaml 的互動邏輯
    /// </summary>
    public partial class PaymentTypesManageView : UserControl
    {
        public PaymentTypesManageView()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {                
                var sheet = PaymentTypesList.Sheets[0];

                if (sheet != null)
                {
                    sheet.AutoGenerateColumns = false;
                    
                }
            }
        }
    }
}
