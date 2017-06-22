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
    /// BOMDataImportsView.xaml 的互動邏輯
    /// </summary>
    public partial class BOMDataImportsView : UserControl
    {
        public BOMDataImportsView()
        {
            InitializeComponent();
        }



        public BOMViewModelCollection BOMImports
        {
            get { return (BOMViewModelCollection)GetValue(BOMImportsProperty); }
            set { SetValue(BOMImportsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BOMImportsProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(BOMDataImportsView), new PropertyMetadata(0));


        private void SearchBox_ResetSearch(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            BOMImports = new BOMViewModelCollection();
            BaseViewModel.BindToDataGridView<BOMViewModel>(BOMGrid);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            GrapeCity.Windows.SpreadSheet.UI.GcSpreadSheet sheet = new GrapeCity.Windows.SpreadSheet.UI.GcSpreadSheet();
            Microsoft.Win32.OpenFileDialog opendialog = new Microsoft.Win32.OpenFileDialog();
            var dialogresult = opendialog.ShowDialog();
            if (dialogresult.HasValue && dialogresult.Value)
            {
                sheet.OpenExcel(opendialog.FileName);

                if (sheet.Sheets.Count > 0)
                {
                    
                }
            }
        }
    }
}
