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
using TokikuNew.Controls;

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

        #region Document Mode


        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(MaterialsTotalView));
        #endregion


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 0, "圖例");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 1, "使用位置");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 2, "專案名稱");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 3, "東菊編號");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 4, "廠商編號");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 5, "材質");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 6, "單位重(KG/M)");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 7, "表面處理");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 8, "烤漆面積");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 9, "皮膜處理(KG)");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 10, "最低產量");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 11, "模具費用");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 12, "訂單總重量");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 13, "模具使用狀況");
            //MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 14, "備註");
            //MoldsWorkBookImports.Sheets[0].Name = "模具總表";
            if (!IsLoaded)
            {
                //datasource.Query();
                LoadFromDatabase();
            }
            else
            {
                if (datasource.Count == 0)
                {
                    //datasource.Query();
                    LoadFromDatabase();
                }
            }
           


        }

        private void LoadFromDatabase()
        {
            int rowi = 0;
            //foreach (var row in datasource)
            //{
            //    if (rowi > MoldsWorkBookImports.Sheets[0].ActiveRowIndex)
            //    {
            //        MoldsWorkBookImports.Sheets[0].AddRows(rowi, 1);
            //    }

            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 0, row.LegendMoldReduction);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 1, row.UsePosition);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 2, row.ProjectName);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 3, row.Code);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 4, row.SerialNumber);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 5, row.Name1);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 6, row.UnitWeight);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 7, row.SurfaceTreatment);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 8, row.PaintArea);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 9, row.MembraneTreatment);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 10, row.MinimumYield);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 11, row.ProductionIngot);
            //    MoldsWorkBookImports.Sheets[0].SetValue(rowi, 12, row.TotalOrderWeight);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 13, row.Name2);
            //    MoldsWorkBookImports.Sheets[0].SetText(rowi, 14, row.Comment);
            //    rowi++;
            //}
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MoldsViewModelCollection.ImportFromExcel(openFileDialog.FileName);
                //    MoldsWorkBookImports.OpenExcel(openFileDialog.FileName);
                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 0, "圖例");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 1, "使用位置");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 2, "專案名稱");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 3, "東菊編號");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 4, "廠商編號");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 5, "材質");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 6, "單位重(KG/M)");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 7, "表面處理");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 8, "烤漆面積");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 9, "皮膜處理(KG)");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 10, "最低產量");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 11, "模具費用");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 12, "訂單總重量");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 13, "模具使用狀況");

                //    MoldsWorkBookImports.Sheets[0].SetColumnLabel(0, 14, "備註");

                //    MoldsWorkBookImports.Sheets[0].RemoveRows(0, 1);

                //    MoldsViewModelCollection imports = new MoldsViewModelCollection();

                //    for (int rowi = 0; rowi < MoldsWorkBookImports.Sheets[0].RowCount; rowi++)
                //    {
                //        MoldsViewModel model = new MoldsViewModel();
                //        var Sheet = MoldsWorkBookImports.Sheets[0];

                //        model.LegendMoldReduction = Sheet.GetText(rowi, 0);
                //        if (string.IsNullOrEmpty(model.LegendMoldReduction))
                //        {
                //            continue;
                //        }
                //        model.UsePosition = Sheet.GetText(rowi, 1);
                //        if (string.IsNullOrEmpty(model.UsePosition))
                //        {
                //            continue;
                //        }
                //        model.ProjectName = Sheet.GetText(rowi, 2);
                //        if (string.IsNullOrEmpty(model.ProjectName))
                //        {
                //            continue;
                //        }
                //        model.Code = Sheet.GetText(rowi, 3);
                //        if (string.IsNullOrEmpty(model.Code))
                //        {
                //            continue;
                //        }
                //        model.SerialNumber = Sheet.GetText(rowi, 4);
                //        model.Materials = new MaterialsViewModel();
                //        model.Materials.QueryByName(Sheet.GetText(rowi, 5));

                //        if (!model.Materials.HasError)
                //        {
                //            model.MaterialId = model.Materials.Id;
                //        }
                //        else
                //        {
                //            model.Materials.Name = Sheet.GetText(rowi, 5);
                //            model.Materials.Status.IsNewInstance = true;
                //        }


                //        model.UnitWeight = ConvertCellValue(Sheet.GetText(rowi, 6));
                //        model.SurfaceTreatment = Sheet.GetText(rowi, 7);
                //        model.PaintArea = ConvertCellValue(Sheet.GetText(rowi, 8));
                //        model.MembraneTreatment = ConvertCellValue(Sheet.GetText(rowi, 9));
                //        model.MinimumYield = ConvertCellValue(Sheet.GetText(rowi, 10));
                //        model.ProductionIngot = ConvertCellValue(Sheet.GetText(rowi, 11));
                //        model.TotalOrderWeight = ConvertCellValue(Sheet.GetText(rowi, 12));
                //        model.MoldUseStatus = new MoldUseStatusViewModel();
                //        model.MoldUseStatus.QueryByName(Sheet.GetText(rowi, 13));
                //        if (!model.MoldUseStatus.HasError)
                //        {
                //            model.MoldUseStatusId = model.MoldUseStatus.Id;
                //        }
                //        //model.MoldUseStatus.Name;
                //        model.Comment = Sheet.GetText(rowi, 14);
                //        model.OpenDate = new DateTime(1754, 1, 1);
                //        imports.Add(model);
                //    }


                //    imports.SaveModel();
                //    datasource.Refresh();

            }
        }

        private float ConvertCellValue(object value)
        {
            try
            {
                float back_value = 0F;
                if (value is string)
                {
                    if (!float.TryParse((string)value, out back_value))
                        back_value = 0F;
                }
                return back_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return 0F;
            }
        }

        MoldsViewModelCollection datasource;

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            datasource = (MoldsViewModelCollection)FindResource("MoldListItems");
        }

       
        private void SearchBar_Search(object sender, RoutedEventArgs e)
        {
            int rowi=0;
            int coli = 0;
            //MoldsWorkBookImports.Sheets[0].Search((string)e.OriginalSource, out rowi, out coli);
            //if(rowi>=0 && coli >=0)
            //{
            //    MoldsWorkBookImports.Sheets[0].SetSelection(rowi, coli, 1, 1);
            //}
            
        }
    }
}
