using Microsoft.Win32;
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
    /// MaterialsTotalView.xaml 的互動邏輯
    /// </summary>
    public partial class MaterialsTotalView : UserControl
    {
        public MaterialsTotalView()
        {
            InitializeComponent();
        }

        public readonly static RoutedEvent OnImportExcelOpenFileEvent = EventManager.RegisterRoutedEvent(
"OnImportExcelOpenFile", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MaterialsTotalView));

        /// <summary>
        /// 指派或移除處理關閉分頁的事件處理器。
        /// </summary>
        public event RoutedEventHandler OnImportExcelOpenFile
        {
            add { AddHandler(OnImportExcelOpenFileEvent, value); }
            remove { RemoveHandler(OnImportExcelOpenFileEvent, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MoldsWorkBookImports.OpenExcel(openFileDialog.FileName);
            }
        }
    }
}
