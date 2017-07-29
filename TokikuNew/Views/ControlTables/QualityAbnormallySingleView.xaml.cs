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
    /// QualityAbnormallySingleView.xaml 的互動邏輯
    /// </summary>
    public partial class QualityAbnormallySingleView : UserControl
    {
        public QualityAbnormallySingleView()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 master = (ShippingMaterialViewModel)((ObjectDataProvider)TryFindResource("ShippingMaterialSource")).Data;

                if (master == null)
                    return;

                master.CreateTime = DateTime.Now;

                master.SaveModel();

                if (master.HasError)
                {
                    MessageBox.Show(string.Join("\n", master.Errors.ToArray()), "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    master.Errors = new string[] { };
                    master.HasError = false;
                    return;
                }

                RaiseEvent(new RoutedEventArgs(ClosableTabItem.OnPageClosingEvent, this));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
