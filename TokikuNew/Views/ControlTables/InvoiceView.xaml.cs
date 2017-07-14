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
    /// InvoiceView.xaml 的互動邏輯
    /// </summary>
    public partial class InvoiceView : UserControl
    {
        public InvoiceView()
        {
            InitializeComponent();

            InitialSpreadMaterialList();
            InitialSpreadMaterialDetail();
            InitialSpreadMaterialMoney();
            InitialSpreadOtherMoney();
            InitialSpreadReserveMoney();
            InitialSpreadPrepayments();
        }

        private void InvoiceView_Loaded(object sender, RoutedEventArgs e)
        {
            InvoicesViewModelCollection ctrl = new InvoicesViewModelCollection();
            CheckGrid.DataContext = ctrl;
            InvoicesViewModelCollection.Query();
        }

        //UI設定
        private void InitialSpreadMaterialList()
        {
            //收料單勾選
            //this.gcMaterialList.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //gcMaterialList.StartSheetIndex = 0;
            //gcMaterialList.Sheets.Clear();

            //Worksheet MLSheet = new Worksheet();
            //MLSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //gcMaterialList.Sheets.Add(MLSheet);
            //gcMaterialList.CanUserEditFormula = false;
            //gcMaterialList.CanUserUndo = true;
            //gcMaterialList.CanUserZoom = true;
            //var sheet = this.gcMaterialList.ActiveSheet;

            //MLSheet.ColumnHeader.Columns[0].Label = "收料日期";
            //MLSheet.ColumnHeader.Columns[1].Label = "收料單號";
            //MLSheet.ColumnHeader.Columns[2].Label = "廠商來料單號";
            //MLSheet.ColumnHeader.Columns[3].Label = "收料數量";
            //MLSheet.ColumnHeader.Columns[4].Label = "已請款數量";
            //MLSheet.ColumnHeader.Columns[5].Label = "待請款數量";
            //MLSheet.ColumnHeader.Columns[6].Label = "本次請款數量";
            //MLSheet.ColumnHeader.Columns[7].Label = "勾選";

            //MLSheet.Columns[0].Width = 100;
            //MLSheet.Columns[1].Width = 100;
            //MLSheet.Columns[2].Width = 150;
            //MLSheet.Columns[3].Width = 120;
            //MLSheet.Columns[4].Width = 120;
            //MLSheet.Columns[5].Width = 120;
            //MLSheet.Columns[6].Width = 150;
            //MLSheet.Columns[7].Width = 100;

        }

        private void InitialSpreadMaterialDetail()
        {
            // 收料單明細
            //this.gcMaterialDetail.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //gcMaterialDetail.StartSheetIndex = 0;
            //gcMaterialDetail.Sheets.Clear();

            //Worksheet MDSheet = new Worksheet();
            //MDSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //gcMaterialDetail.Sheets.Add(MDSheet);
            //gcMaterialDetail.CanUserEditFormula = false;
            //gcMaterialDetail.CanUserUndo = true;
            //gcMaterialDetail.CanUserZoom = true;
            //var sheet = this.gcMaterialDetail.ActiveSheet;

            //MDSheet.ColumnHeader.Columns[0].Label = "訂製單號";
            //MDSheet.ColumnHeader.Columns[1].Label = "批號";
            //MDSheet.ColumnHeader.Columns[2].Label = "東菊編號";
            //MDSheet.ColumnHeader.Columns[3].Label = "大同編號";
            //MDSheet.ColumnHeader.Columns[4].Label = "材質";
            //MDSheet.ColumnHeader.Columns[5].Label = "單位重(kg/m)";
            //MDSheet.ColumnHeader.Columns[6].Label = "訂購長度(mm)";
            //MDSheet.ColumnHeader.Columns[7].Label = "訂製數量";
            //MDSheet.ColumnHeader.Columns[8].Label = "總收料數量";
            //MDSheet.ColumnHeader.Columns[9].Label = "已請款數量";
            //MDSheet.ColumnHeader.Columns[10].Label = "待請款數量";
            //MDSheet.ColumnHeader.Columns[11].Label = "本單請款數量";
            //MDSheet.ColumnHeader.Columns[12].Label = "本單收料數量";
            //MDSheet.ColumnHeader.Columns[13].Label = "保留款比例(%)";
            //MDSheet.ColumnHeader.Columns[14].Label = "kg單價";
            //MDSheet.ColumnHeader.Columns[15].Label = "保留款金額";
            //MDSheet.ColumnHeader.Columns[16].Label = DateTime.Now.ToString("yyyy-MM-dd");

            //MDSheet.Columns[0].Width = 100;
            //MDSheet.Columns[1].Width = 100;
            //MDSheet.Columns[2].Width = 150;
            //MDSheet.Columns[3].Width = 120;
            //MDSheet.Columns[4].Width = 120;
            //MDSheet.Columns[5].Width = 120;
            //MDSheet.Columns[6].Width = 150;
            //MDSheet.Columns[7].Width = 100;
            //MDSheet.Columns[8].Width = 100;
            //MDSheet.Columns[9].Width = 100;
            //MDSheet.Columns[10].Width = 100;
            //MDSheet.Columns[11].Width = 100;
            //MDSheet.Columns[12].Width = 100;
            //MDSheet.Columns[13].Width = 100;
            //MDSheet.Columns[14].Width = 100;
            //MDSheet.Columns[15].Width = 100;
            //MDSheet.Columns[16].Width = 100;
        }

        private void InitialSpreadMaterialMoney()
        {
            //收料單款項
            //this.gcMaterialMoney.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcMaterialMoney.StartSheetIndex = 0;
            //this.gcMaterialMoney.Sheets.Clear();

            //Worksheet MMSheet = new Worksheet();
            //MMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcMaterialMoney.Sheets.Add(MMSheet);
            //this.gcMaterialMoney.CanUserEditFormula = false;
            //this.gcMaterialMoney.CanUserUndo = true;
            //this.gcMaterialMoney.CanUserZoom = true;
            //var sheet = this.gcMaterialMoney.ActiveSheet;

            //MMSheet.ColumnHeader.Columns[0].Label = "材質";
            //MMSheet.ColumnHeader.Columns[1].Label = "kg單價";
            //MMSheet.ColumnHeader.Columns[2].Label = "重量";
            //MMSheet.ColumnHeader.Columns[3].Label = "總價";
            //MMSheet.ColumnHeader.Columns[4].Label = "數量";

            //MMSheet.Columns[0].Width = 100;
            //MMSheet.Columns[1].Width = 100;
            //MMSheet.Columns[2].Width = 150;
            //MMSheet.Columns[3].Width = 100;
            //MMSheet.Columns[4].Width = 100;

        }

        private void InitialSpreadOtherMoney()
        {
            //this.gcOtherMoney.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcOtherMoney.StartSheetIndex = 0;
            //this.gcOtherMoney.Sheets.Clear();

            //Worksheet OMSheet = new Worksheet();
            //OMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcOtherMoney.Sheets.Add(OMSheet);
            //this.gcOtherMoney.CanUserEditFormula = false;
            //this.gcOtherMoney.CanUserUndo = true;
            //this.gcOtherMoney.CanUserZoom = true;
            //var sheet = this.gcOtherMoney.ActiveSheet;

            //OMSheet.ColumnHeader.Columns[0].Label = "訂製單號";
            //OMSheet.ColumnHeader.Columns[1].Label = "批號";
            //OMSheet.ColumnHeader.Columns[2].Label = "項目";
            //OMSheet.ColumnHeader.Columns[3].Label = "說明";
            //OMSheet.ColumnHeader.Columns[4].Label = "單價";
            //OMSheet.ColumnHeader.Columns[5].Label = "數量";
            //OMSheet.ColumnHeader.Columns[6].Label = "金額";
            //OMSheet.ColumnHeader.Columns[7].Label = "已請款";
            //OMSheet.ColumnHeader.Columns[8].Label = "待請款";
            //OMSheet.ColumnHeader.Columns[9].Label = "本次請款";

            //OMSheet.Columns[0].Width = 100;
            //OMSheet.Columns[1].Width = 100;
            //OMSheet.Columns[2].Width = 150;
            //OMSheet.Columns[3].Width = 120;
            //OMSheet.Columns[4].Width = 120;
            //OMSheet.Columns[5].Width = 120;
            //OMSheet.Columns[6].Width = 150;
            //OMSheet.Columns[7].Width = 100;
            //OMSheet.Columns[8].Width = 100;
            //OMSheet.Columns[9].Width = 100;
        }

        private void InitialSpreadReserveMoney()
        {
            //保留款

            //this.gcReserveMoney.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcReserveMoney.StartSheetIndex = 0;
            //this.gcReserveMoney.Sheets.Clear();

            //Worksheet RMSheet = new Worksheet();
            //RMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcReserveMoney.Sheets.Add(RMSheet);
            //this.gcReserveMoney.CanUserEditFormula = false;
            //this.gcReserveMoney.CanUserUndo = true;
            //this.gcReserveMoney.CanUserZoom = true;
            //var sheet = this.gcReserveMoney.ActiveSheet;

            //RMSheet.ColumnHeader.Columns[0].Label = "請款單號";
            //RMSheet.ColumnHeader.Columns[1].Label = "保留款金額";
            //RMSheet.ColumnHeader.Columns[2].Label = "已請款";
            //RMSheet.ColumnHeader.Columns[3].Label = "待請款";
            //RMSheet.ColumnHeader.Columns[4].Label = "本次請款";

            //RMSheet.Columns[0].Width = 100;
            //RMSheet.Columns[1].Width = 100;
            //RMSheet.Columns[2].Width = 100;
            //RMSheet.Columns[3].Width = 100;
            //RMSheet.Columns[4].Width = 100;
        }

        private void InitialSpreadPrepayments()
        {
            //預付款
            //this.gcPrepayments.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcPrepayments.StartSheetIndex = 0;
            //this.gcPrepayments.Sheets.Clear();

            //Worksheet PMSheet = new Worksheet();
            //PMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcPrepayments.Sheets.Add(PMSheet);
            //this.gcPrepayments.CanUserEditFormula = false;
            //this.gcPrepayments.CanUserUndo = true;
            //this.gcPrepayments.CanUserZoom = true;
            //var sheet = this.gcPrepayments.ActiveSheet;

            //PMSheet.ColumnHeader.Columns[0].Label = "預付款說明";
            //PMSheet.ColumnHeader.Columns[1].Label = "金額";
            //PMSheet.ColumnHeader.Columns[2].Label = "已沖銷金額";

            //PMSheet.Columns[0].Width = 150;
            //PMSheet.Columns[1].Width = 120;
            //PMSheet.Columns[2].Width = 120;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
