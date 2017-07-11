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
    /// AluminumExtrusionOrderSheetView.xaml 的互動邏輯
    /// </summary>
    public partial class AluminumExtrusionOrderSheetView : UserControl
    {
        //private UserControl uc = null; // 顯示頁籤內容的變數

        public AluminumExtrusionOrderSheetView()
        {
            InitializeComponent();

            //uc = new AluminumExtrusionOrderView();
            //this.訂製單內容.Children.Add(uc); // 頁籤初始內容設定
        }

        #region Document Mode

        /// <summary>
        /// 目前載入的文件所處的模式
        /// </summary>
        public DocumentLifeCircle Mode
        {
            get { return (DocumentLifeCircle)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DocumentLifeCircle), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(DocumentLifeCircle.Read));
        #endregion

        #region 登入的使用者
        // Using a DependencyProperty as the backing store for LoginedUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginedUserProperty =
            DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(default(UserViewModel)));

        /// <summary>
        /// 登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return (UserViewModel)GetValue(LoginedUserProperty); }
            set { SetValue(LoginedUserProperty, value); }
        }
        #endregion

        #region SelectedProject
        public ProjectsViewModel SelectedProject
        {
            get { return (ProjectsViewModel)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedProject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(ProjectsViewModel), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(default(ProjectsViewModel)));

        #endregion



        public Guid FormDetailId
        {
            get { return (Guid)GetValue(FormDetailIdProperty); }
            set { SetValue(FormDetailIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormDetailId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormDetailIdProperty =
            DependencyProperty.Register("FormDetailId", typeof(Guid), typeof(AluminumExtrusionOrderSheetView), new PropertyMetadata(Guid.Empty));



        private void InitSample()
        {
            try
            {
                //this.gcSpreadSheet1.AutoRefresh = false;
                //this.gcSpreadSheet1.SuspendEvent();

                //var sheet = this.gcSpreadSheet1.ActiveSheet;

                //// fill table styles
                //var properties = typeof(TableStyles).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                //foreach (var property in properties)
                //{
                //    //this.cboTableStyle.Items.Add(property.Name);
                //}
                ////cboTableStyle.SelectedIndex = 0;

                //if (sheet.FindTable("sampleTable1") == null)
                //    sheet.AddTable("sampleTable1", 0, 0, 10, 10, TableStyles.Medium3);
                //if (sheet.FindTable("sampleTable2") == null)
                //    sheet.AddTable("sampleTable2", 12, 1, 6, 4, TableStyles.Medium4);
                //if (sheet.FindTable("sampleTable3") == null)
                //    sheet.AddTable("sampleTable3", 12, 7, 6, 4, TableStyles.Medium5);

                //this.gcSpreadSheet1.ResumeEvent();
                //this.gcSpreadSheet1.AutoRefresh = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                Binding datasourcebinding = new Binding();
                datasourcebinding.Source = DataContext;
                datasourcebinding.Mode = BindingMode.TwoWay;
                datasourcebinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                datasourcebinding.Path = new PropertyPath(DataContextProperty);

                SetBinding(SelectedProjectProperty, datasourcebinding);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        private void InitUI()
        {
            try
            {
                //this.actionAndSettings.Text = SpreadSheetDemoExplorer.Properties.Resources.ActionsAndSettings;
                //this.addGroup.Content = SpreadSheetDemoExplorer.Properties.Resources.Group;
                //this.removeGroup.Content = SpreadSheetDemoExplorer.Properties.Resources.Ungroup;
                //this.showDetail.Content = SpreadSheetDemoExplorer.Properties.Resources.ShowDetail;
                //this.hideDetail.Content = SpreadSheetDemoExplorer.Properties.Resources.HideDetail;
                //this.summaryRow.Content = SpreadSheetDemoExplorer.Properties.Resources.SummaryRowsBelowDetail;
                //this.summaryColumn.Content = SpreadSheetDemoExplorer.Properties.Resources.SummaryColumnsToRightOfDetail;
                //this.backgroundText.Text = SpreadSheetDemoExplorer.Properties.Resources.background;
                //this.borderBrushText.Text = SpreadSheetDemoExplorer.Properties.Resources.setBorderBrush;
                //this.lineStrokeText.Text = SpreadSheetDemoExplorer.Properties.Resources.setLineStroke;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }
        private void InitializeSample()
        {
            try
            {
                // Range group
                //this.gcSpreadSheet1.AutoRefresh = false;
                //this.gcSpreadSheet1.SuspendEvent();

                //Worksheet sheet = this.gcSpreadSheet1.Sheets[0];
                //sheet.Name = "訂製單";
                //sheet.ColumnCount = 9;
                //sheet.RowCount = 34;
                //sheet.Columns[0].Width = sheet.Columns[1].Width = 80;
                //sheet.Columns[2].Width = 110;
                //sheet.AddSelection(0, 0, 1, 1);

                //Worksheet sheet2 = new Worksheet("材質估價");
                //gcSpreadSheet1.Sheets.Add(sheet2);

                //Worksheet sheet3 = new Worksheet("雜項");
                //gcSpreadSheet1.Sheets.Add(sheet3);

                //// set value
                //var t = new object[,]
                //                 {
                //               {"= Eastern ==========", "", "", 0, 0, "", 0},
                //               {"Eastern", "Atlantic", "Celtics", 57, 19, "-", 0.750},
                //               {"Eastern", "Atlantic", "76ers", 38, 35, 17.5, 0.521},
                //               {"Eastern", "Atlantic", "Nets", 31, 44, 25.5, 0.413},
                //               {"Eastern", "Atlantic", "Raptors", 29, 45, 27, 0.392},
                //               {"Eastern", "Atlantic", "Knicks", 29, 46, 27.5, 0.387},
                //               {"Eastern", "Central", "Cavaliers", 61, 13, "-", 0.824},
                //               {"Eastern", "Central", "Pistons", 36, 39, 25.5, 0.480},
                //               {"Eastern", "Central", "Bulls", 36, 40, 26, 0.474},
                //               {"Eastern", "Central", "Pacers", 32, 43, 29.5, 0.427},
                //               {"Eastern", "Central", "Bucks", 32, 44, 30, 0.421},
                //               {"Eastern", "Southeast", "Magic", 55, 19, "-", 0.743},
                //               {"Eastern", "Southeast", "Hawks", 43, 32, 12.5, 0.573},
                //               {"Eastern", "Southeast", "Heat", 39, 36, 16.5, 0.520},
                //               {"Eastern", "Southeast", "Bobcats", 34, 41, 21.5, 0.453},
                //               {"Eastern", "Southeast", "Wizards", 17, 59, 39, 0.224},
                //               {"= Total ==========", "", "", 0, 0, "", 0},
                //               {"= Western ==========", "", "", 0, 0, "", 0},
                //               {"Western", "Northwest", "Nuggets", 49, 26, "-", 0.653},
                //               {"Western", "Northwest", "Trail Blazers", 47, 27, 1.5, 0.635},
                //               {"Western", "Northwest", "Jazz", 46, 28, 2.5, 0.622},
                //               {"Western", "Northwest", "Thunder", 21, 53, 27.5, 0.284},
                //               {"Western", "Northwest", "Timberwolves", 21, 54, 28, 0.280},
                //               {"Western", "Pacific", "Lakers", 59, 16, "-", 0.787},
                //               {"Western", "Pacific", "Suns", 41, 34, 18, 0.547},
                //               {"Western", "Pacific", "Warriors", 26, 49, 33, 0.347},
                //               {"Western", "Pacific", "Clippers", 18, 57, 41, 0.240},
                //               {"Western", "Pacific", "Kings", 16, 58, 42.5, 0.216},
                //               {"Western", "Southwest", "Spurs", 48, 29, "-", 0.649},
                //               {"Western", "Southwest", "Rockets", 48, 27, 0.5, 0.640},
                //               {"Western", "Southwest", "Hornets", 47, 27, 1, 0.635},
                //               {"Western", "Southwest", "Mavericks", 45, 30, 3.5, 0.600},
                //               {"Western", "Southwest", "Grizzlies", 20, 54, 28, 0.270},
                //               {"= Total ==========", "", "", 0, 0, "", 0},
                //                 };

                //for (int r = 0; r <= t.GetUpperBound(0); r++)
                //{
                //    for (int c = 0; c <= t.GetUpperBound(1); c++)
                //    {
                //        sheet.SetValue(r, c, t[r, c]);
                //    }
                //}
                //sheet.Cells[0, 0].ColumnSpan = 7;
                //sheet.Cells[16, 0].ColumnSpan = 3;
                //sheet.Cells[17, 0].ColumnSpan = 7;
                //sheet.Cells[33, 0].ColumnSpan = 3;
                //sheet.ColumnHeader.RowCount = 2;
                //sheet.ColumnHeader.AutoTextIndex = 1;
                //sheet.ColumnHeader.Cells[0, 0].Value = "2008-09 NBA Regular Season Standings";
                //sheet.ColumnHeader.Cells[0, 0].ColumnSpan = 9;
                //sheet.ColumnHeader.Cells[0, 0].FontFamily = new FontFamily("Arial");
                //sheet.ColumnHeader.Cells[0, 0].FontSize = 14;
                //sheet.ColumnHeader.Cells[0, 0].HorizontalAlignment = CellHorizontalAlignment.Center;
                //sheet.ColumnHeader.Cells[0, 0].VerticalAlignment = CellVerticalAlignment.Center;
                //sheet.ColumnHeader.Cells[0, 0].Foreground = new SolidColorBrush(Colors.Gray);
                //sheet.ColumnHeader.Rows[0].Height = 30;

                //sheet.Columns[2].Foreground = new SolidColorBrush(Colors.Blue);
                //sheet.Cells[19, 2].Foreground = new SolidColorBrush(Colors.Blue);
                //sheet.Columns[0].Label = "東菊編號";
                //sheet.Columns[1].Label = "大同編號";
                //sheet.Columns[2].Label = "材質";
                //sheet.Columns[3].Label = "單位重";
                //sheet.Columns[4].Label = "訂購長度";
                //sheet.Columns[5].Label = "需求數量";
                //sheet.Columns[6].Label = "備品數量";
                //sheet.Columns[7].Label = "下單數量";
                //sheet.Columns[8].Label = "備註";

                //// set row range group
                //sheet.RowRangeGroup.Group(1, 15); // eastern
                //sheet.RowRangeGroup.Group(1, 4);
                //sheet.RowRangeGroup.Group(6, 4);
                //sheet.RowRangeGroup.Group(11, 4);
                //sheet.RowRangeGroup.Group(18, 15); // western
                //sheet.RowRangeGroup.Group(18, 4);
                //sheet.RowRangeGroup.Group(23, 4);
                //sheet.RowRangeGroup.Group(28, 4);
                //// set column group
                //sheet.ColumnRangeGroup.Group(2, 1);
                //// sheet.RowRangeGroup.Expand(1, false);

                //InitializeComboBox();

                //this.background.SelectionChanged += background_SelectionChanged;
                //this.borderBrush.SelectionChanged += borderBrush_SelectionChanged;
                //this.lineStroke.SelectionChanged += lineStroke_SelectionChanged;
                //sheet.SelectionChanged += Sheet_SelectionChanged;
                //sheet.CellChanged += Sheet_CellChanged;

                //gcSpreadSheet1.CellClick += GcSpreadSheet1_CellClick;
                //this.gcSpreadSheet1.ResumeEvent();
                //this.gcSpreadSheet1.AutoRefresh = true;
                //summaryRow.IsChecked = true;
                //summaryColumn.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        //private void Sheet_CellChanged(object sender, CellChangedEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        //    }
        //}

        //private void GcSpreadSheet1_CellClick(object sender, GrapeCity.Windows.SpreadSheet.UI.CellClickEventArgs e)
        //{
        //    try
        //    {
        //        //Double sum = 0;
        //        //int count = 0, avgCount = 0;

        //        //if (gcSpreadSheet1.ActiveSheet.Rows.RowHeader == true)
        //        //{
        //        //    for (int i = 0; i <= fpSpread1.ActiveSheet.GetLastNonEmptyColumn(FarPoint.Win.Spread.NonEmptyItemFlag.Data); i++)
        //        //    {
        //        //        try
        //        //        {
        //        //            if (fpSpread1.ActiveSheet.Cells[e.Row, i].Text != string.Empty)
        //        //            {
        //        //                sum = sum + Double.Parse(fpSpread1.ActiveSheet.Cells[e.Row, i].Text);
        //        //                avgCount++;
        //        //                count++;
        //        //            }
        //        //        }
        //        //        catch
        //        //        {
        //        //            if (fpSpread1.ActiveSheet.Cells[e.Row, i].Text != string.Empty)
        //        //                count++;
        //        //        }
        //        //    }
        //        //}
        //        //else if (e.ColumnHeader == true)
        //        //{
        //        //    for (int i = 0; i <= fpSpread1.ActiveSheet.GetLastNonEmptyRow(FarPoint.Win.Spread.NonEmptyItemFlag.Data); i++)
        //        //    {
        //        //        try
        //        //        {
        //        //            if (fpSpread1.ActiveSheet.Cells[i, e.Column].Text != string.Empty)
        //        //            {
        //        //                sum = sum + Double.Parse(fpSpread1.ActiveSheet.Cells[i, e.Column].Text);
        //        //                avgCount++;
        //        //                count++;
        //        //            }
        //        //        }

        //        //        catch
        //        //        {
        //        //            if (fpSpread1.ActiveSheet.Cells[i, e.Column].Text != string.Empty)
        //        //                count++;
        //        //        }
        //        //    }
        //        //}
        //        //LblSum.Text = "Sum: " + sum;
        //        //if (avgCount > 0)
        //        //    LblAVG.Text = "Average: " + (sum / (Double)avgCount);
        //        //else
        //        //    LblAVG.Text = "Average: 0";
        //        //LblCNT.Text = "Count: " + count;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        //    }

        //}

        int _iRowCount;
        int _iColumnCount;
        private void Sheet_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                Double sum = 0;
                int count = 0, avgCount = 0;
                //if (e.Column == -1)
                //{
                //    for (int i = e.Row; i < e.Row + e.RowCount; i++)
                //    {
                //        for (int j = 0; j <= gcSpreadSheet1.ActiveSheet.GetLastDirtyColumn(StorageType.Data); j++)
                //            try
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                {
                //                    sum = sum + Double.Parse(gcSpreadSheet1.ActiveSheet.Cells[i, j].Text);
                //                    avgCount++;
                //                    count++;
                //                }
                //            }
                //            catch
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                    count++;
                //            }
                //    }
                //}
                //else if (e.Row == -1)
                //{
                //    for (int i = 0; i <= gcSpreadSheet1.ActiveSheet.GetLastDirtyRow(StorageType.Data); i++)
                //    {
                //        for (int j = e.Column; j < e.Column + e.ColumnCount; j++)
                //            try
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                {
                //                    sum = sum + Double.Parse(gcSpreadSheet1.ActiveSheet.Cells[i, j].Text);
                //                    avgCount++;
                //                    count++;
                //                }
                //            }
                //            catch
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                    count++;
                //            }
                //    }
                //}
                //else
                //{
                //    for (int i = e.Row; i < e.Row + e.RowCount; i++)
                //    {
                //        for (int j = e.Column; j < e.Column + e.ColumnCount; j++)
                //            try
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                {
                //                    sum = sum + Double.Parse(gcSpreadSheet1.ActiveSheet.Cells[i, j].Text);
                //                    avgCount++;
                //                    count++;
                //                }
                //            }
                //            catch
                //            {
                //                if (gcSpreadSheet1.ActiveSheet.Cells[i, j].Text != string.Empty)
                //                    count++;
                //            }
                //    }
                //}
                //LblSum.Text = "Sum: " + sum;
                //if (avgCount > 0)
                //    LblAVG.Text = "Average: " + (sum / (Double)avgCount);
                //else
                //    LblAVG.Text = "Average: 0";
                //LblCNT.Text = "Count: " + count;
                SpeardStatusBarItem.Content = string.Format("共選擇{0}個項目，總計:{1}", count, sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void groupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Worksheet sheet = this.gcSpreadSheet1.ActiveSheet;
                //CellRange cr = sheet.Selections[0];
                //if (cr.Column == -1 && cr.Row == -1) // sheet selection
                //{

                //}
                //else if (cr.Column == -1) // row selection
                //{
                //    sheet.RowRangeGroup.Group(cr.Row, cr.RowCount);
                //}
                //else if (cr.Row == -1) // column selection
                //{
                //    sheet.ColumnRangeGroup.Group(cr.Column, cr.ColumnCount);
                //}
                //else // cell range selection
                //{
                //    MessageBox.Show("Please select row or column for group");

                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void ungroupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Worksheet sheet = this.gcSpreadSheet1.ActiveSheet;
                //CellRange cr = sheet.Selections[0];
                //if (cr.Column == -1 && cr.Row == -1) // sheet selection
                //{

                //}
                //else if (cr.Column == -1) // row selection
                //{
                //    sheet.RowRangeGroup.Ungroup(cr.Row, cr.RowCount);
                //}
                //else if (cr.Row == -1) // column selection
                //{
                //    sheet.ColumnRangeGroup.Ungroup(cr.Column, cr.ColumnCount);
                //}
                //else // cell range selection
                //{
                //    MessageBox.Show("Please select row or column which are in a group");

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void showDetailButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Worksheet sheet = this.gcSpreadSheet1.Sheets[0];
                //CellRange cr = sheet.Selections[0];
                //if (cr.Column == -1 && cr.Row == -1) // sheet selection
                //{

                //}
                //else if (cr.Column == -1) // row selection
                //{
                //    for (int i = 0; i < cr.RowCount; i++)
                //    {
                //        var rgi = sheet.RowRangeGroup.Find(i + cr.Row, 0);
                //        if (rgi != null)
                //        {
                //            sheet.RowRangeGroup.Expand(rgi, true);
                //        }
                //    }
                //}
                //else if (cr.Row == -1) // column selection
                //{
                //    for (int i = 0; i < cr.ColumnCount; i++)
                //    {
                //        var rgi = sheet.ColumnRangeGroup.Find(i + cr.Column, 0);
                //        if (rgi != null)
                //        {
                //            sheet.ColumnRangeGroup.Expand(rgi, true);
                //        }
                //    }
                //}
                //else // cell range selection
                //{
                //    MessageBox.Show("Please select row or column which are in a group");

                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void hideDetailButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Worksheet sheet = this.gcSpreadSheet1.Sheets[0];
                //CellRange cr = sheet.Selections[0];
                //if (cr.Column == -1 && cr.Row == -1) // sheet selection
                //{

                //}
                //else if (cr.Column == -1) // row selection
                //{
                //    for (int i = 0; i < cr.RowCount; i++)
                //    {
                //        var rgi = sheet.RowRangeGroup.Find(i + cr.Row, 0);
                //        if (rgi != null)
                //        {
                //            sheet.RowRangeGroup.Expand(rgi, false);
                //        }
                //    }
                //}
                //else if (cr.Row == -1) // column selection
                //{
                //    for (int i = 0; i < cr.ColumnCount; i++)
                //    {
                //        var rgi = sheet.ColumnRangeGroup.Find(i + cr.Column, 0);
                //        if (rgi != null)
                //        {
                //            sheet.ColumnRangeGroup.Expand(rgi, false);
                //        }
                //    }
                //}
                //else // cell range selection
                //{
                //    MessageBox.Show("Please select row or column which are in a group");

                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void summaryRow_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //this.gcSpreadSheet1.ActiveSheet.RowRangeGroup.Direction = this.summaryRow.IsChecked == true ? RangeGroupDirection.Forward : RangeGroupDirection.Backward;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }

        private void summaryColumn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            //this.gcSpreadSheet1.ActiveSheet.ColumnRangeGroup.Direction = this.summaryColumn.IsChecked == true ? RangeGroupDirection.Forward : RangeGroupDirection.Backward;
        }

        private void InitializeComboBox()
        {
            try
            {
                System.Reflection.PropertyInfo[] properties = typeof(Colors).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                //foreach (var property in properties)
                //{
                //    this.background.Items.Add(property.Name);
                //    this.borderBrush.Items.Add(property.Name);
                //    this.lineStroke.Items.Add(property.Name);
                //}
                //this.background.SelectedIndex = 0;
                //this.borderBrush.SelectedIndex = 0;
                //this.lineStroke.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private Color getSelectedColor(string name)
        {
            try
            {
                return (Color)typeof(Colors).GetProperty(name).GetValue(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                throw ex;
            }

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生退貨單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "退貨單列表"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生請款單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "請款單列表"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生出貨單"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "出貨單列表"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        // ========== 頁籤切換顯示內容功能 ==========↓
        //private void 訂製單_Click(object sender, RoutedEventArgs e)
        //{
        //    this.訂製單內容.Children.Remove(uc); // 移除現有內容元素
        //    uc = new AluminumExtrusionOrderView();
        //    this.訂製單內容.Children.Add(uc); // 顯示鋁擠型訂製單
        //}

        //private void 材質估價_Click(object sender, RoutedEventArgs e)
        //{
        //    this.訂製單內容.Children.Remove(uc); // 移除現有內容元素
        //    uc = new AluminumExtrusionOrderMaterialValuationView();
        //    this.訂製單內容.Children.Add(uc); // 顯示鋁擠型訂製單材質估價
        //}

        //private void 雜項_Click(object sender, RoutedEventArgs e)
        //{
        //    this.訂製單內容.Children.Remove(uc); // 移除現有內容元素
        //    uc = new AluminumExtrusionOrderMiscellaneousView();
        //    this.訂製單內容.Children.Add(uc); // 顯示鋁擠型訂製單雜項
        //}
        // ========== 頁籤切換顯示內容功能 ==========↑

    }
}
