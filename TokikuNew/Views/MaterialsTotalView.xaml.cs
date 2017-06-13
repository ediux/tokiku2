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
using Tokiku.ViewModels;

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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MoldsViewModelCollection datasource = new MoldsViewModelCollection();
            await datasource.QueryAsync();
            MoldsWorkBookImports.Sheets[0].DataSource = datasource;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MoldsWorkBookImports.OpenExcel(openFileDialog.FileName);
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 0, "圖例");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(0, "LegendMoldReduction");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 1, "使用位置");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(1, "UsePosition");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 2, "專案名稱");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(2, "ProjectName");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 3, "東菊編號");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(3, "Code");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 4, "廠商編號");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(4, "Manufacturers.Name");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 5, "材質");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(5, "Material");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 6, "單位重(KG/M)");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(6, "UnitWeight");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 7, "表面處理");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(7, "SurfaceTreatment");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 8, "烤漆面積");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(8, "PaintArea");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 9, "皮膜處理(KG)");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(9, "MembraneTreatment");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 10, "最低產量");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(10, "MinimumYield");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 11, "模具費用");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(11, "ProductionIngot");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 12, "訂單總重量");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(12, "TotalOrderWeight");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 13, "模具使用狀況");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(13, "MoldUseStatusId");
                MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 14, "備註");
                MoldsWorkBookImports.Sheets[0].BindDataColumn(14, "Comment");

                MoldsViewModelCollection imports = new MoldsViewModelCollection();

                for (int rowi = 0; rowi < MoldsWorkBookImports.Sheets[0].RowCount; rowi++)
                {
                    MoldsViewModel model = new MoldsViewModel();

                    for (int coli = 0; coli < 16; coli++)
                    {
                        var data = MoldsWorkBookImports.Sheets[0].GetValue(rowi, coli);

                    }

                    imports.Add(model);
                }

                imports.SaveModel();

            }
        }
    }
}
