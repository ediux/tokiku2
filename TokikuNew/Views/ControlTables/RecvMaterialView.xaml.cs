using System;
using System.Windows;
using System.Windows.Controls;
using Tokiku.ViewModels;
using TokikuNew.Controls;

namespace TokikuNew
{
    /// <summary>
    /// RecvMaterialView.xaml 的互動邏輯
    /// </summary>
    public partial class RecvMaterialView : UserControl
    {
        public RecvMaterialView()
        {
            InitializeComponent();

            InitialSpreadRecvMaterial();
        }

        private void RecvMaterialView_Loaded(object sender, RoutedEventArgs e)
        {
            RecvMaterialViewModelCollection ctrl = new RecvMaterialViewModelCollection();
            CheckGrid.DataContext = ctrl;
            RecvMaterialViewModelCollection.Query();
        }

        private void InitialSpreadRecvMaterial()
        {
            //this.gcRecvMaterial.TabStripVisibility = System.Windows.Visibility.Collapsed;
            //this.gcRecvMaterial.StartSheetIndex = 0;
            //this.gcRecvMaterial.Sheets.Clear();

            //Worksheet RMSheet = new Worksheet();
            //RMSheet.ColumnHeader.AutoText = HeaderAutoText.Letters;
            //this.gcRecvMaterial.Sheets.Add(RMSheet);
            //this.gcRecvMaterial.CanUserEditFormula = false;
            //this.gcRecvMaterial.CanUserUndo = true;
            //this.gcRecvMaterial.CanUserZoom = true;
            //var sheet = this.gcRecvMaterial.ActiveSheet;

            //RMSheet.ColumnHeader.Columns[0].Label = "訂製單號";
            //RMSheet.ColumnHeader.Columns[1].Label = "批號";
            //RMSheet.ColumnHeader.Columns[2].Label = "項次";
            //RMSheet.ColumnHeader.Columns[3].Label = "東菊編號";
            //RMSheet.ColumnHeader.Columns[4].Label = "大同編號";
            //RMSheet.ColumnHeader.Columns[5].Label = "材質";
            //RMSheet.ColumnHeader.Columns[6].Label = "單位重(kg/m)";
            //RMSheet.ColumnHeader.Columns[7].Label = "訂購長度(mm)";
            //RMSheet.ColumnHeader.Columns[8].Label = "下單數量";
            //RMSheet.ColumnHeader.Columns[9].Label = "出貨順序";
            //RMSheet.ColumnHeader.Columns[10].Label = "重量";
            //RMSheet.ColumnHeader.Columns[11].Label = "缺料";
            //RMSheet.ColumnHeader.Columns[12].Label = "*收料量*";
            //RMSheet.ColumnHeader.Columns[13].Label = "[備註]";

            //RMSheet.Columns[0].Width = 100;
            //RMSheet.Columns[1].Width = 100;
            //RMSheet.Columns[2].Width = 100;
            //RMSheet.Columns[3].Width = 120;
            //RMSheet.Columns[4].Width = 120;
            //RMSheet.Columns[5].Width = 120;
            //RMSheet.Columns[6].Width = 100;
            //RMSheet.Columns[7].Width = 100;
            //RMSheet.Columns[8].Width = 100;
            //RMSheet.Columns[9].Width = 100;
            //RMSheet.Columns[10].Width = 100;
            //RMSheet.Columns[11].Width = 100;
            //RMSheet.Columns[12].Width = 100;
            //RMSheet.Columns[13].Width = 100;
        }

        private void BtnAddNewForm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                RaiseEvent(new RoutedEventArgs(ClosableTabItem.SendNewPageRequestEvent, "產生加工訂製單"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
