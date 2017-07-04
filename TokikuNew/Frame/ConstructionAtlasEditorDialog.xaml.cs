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

namespace TokikuNew
{
    /// <summary>
    /// ConstructionView.xaml 的互動邏輯
    /// </summary>
    public partial class ConstructionAtlasEditorDialog : Window
    {
        public ConstructionAtlasEditorDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((ConstructionAtlasViewModel)DataContext).ReplyContent == 6)
                {
                    if (string.IsNullOrEmpty(((ConstructionAtlasViewModel)DataContext).Comment))
                    {
                        MessageBox.Show("請輸入備註!", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                        DialogResult = false;
                        return;
                    }
                }

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogResult = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
