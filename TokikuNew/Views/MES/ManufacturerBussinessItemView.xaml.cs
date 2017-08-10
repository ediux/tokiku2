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
    /// ManufacturerBussinessItemView.xaml 的互動邏輯
    /// </summary>
    public partial class ManufacturerBussinessItemView : UserControl
    {
        public ManufacturerBussinessItemView()
        {
            InitializeComponent();
        }

        //#region Document Mode


        //public DocumentLifeCircle Mode
        //{
        //    get { return (DocumentLifeCircle)GetValue(ModeProperty); }
        //    set { SetValue(ModeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ModeProperty =
        //    DependencyProperty.Register("Mode", typeof(DocumentLifeCircle),
        //        typeof(ManufacturerBussinessItemView),
        //        new PropertyMetadata(DocumentLifeCircle.Read,
        //            new PropertyChangedCallback(DocumentModeChange)));

        ///// <summary>
        ///// 處理當文件模式變更時的處理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public static void DocumentModeChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (sender is ManufacturerBussinessItemView)
        //        {
        //            ManufacturerBussinessItemView view = (ManufacturerBussinessItemView)sender;

        //            if (view != null)
        //            {
        //                DocumentLifeCircle _mode = (DocumentLifeCircle)e.NewValue;
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}
        //#endregion

        //#region SelectedManufacturerId
        //public Guid SelectedManufacturerId
        //{
        //    get { return (Guid)GetValue(SelectedManufacturerIdProperty); }
        //    set { SetValue(SelectedManufacturerIdProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedManufacturerId.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedManufacturerIdProperty =
        //    DependencyProperty.Register("SelectedManufacturerId", typeof(Guid),
        //        typeof(ManufacturerBussinessItemView), new PropertyMetadata(Guid.Empty,
        //            new PropertyChangedCallback(SelectedManufacturerIdChange)));

        ///// <summary>
        ///// 當廠商/客戶ID變更時的委派處理方法
        ///// </summary>
        ///// <param name="sender">引發事件的物件</param>
        ///// <param name="e">事件引數</param>
        //public static void SelectedManufacturerIdChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (sender is ManufacturerBussinessItemView)
        //        {

        //            ObjectDataProvider source = (ObjectDataProvider)((ManufacturerBussinessItemView)sender).TryFindResource("BusinessItemsSource");

        //            if (source != null)
        //            {
        //                source.MethodParameters[0] = e.NewValue;
        //                source.Refresh();

        //                //((ManufacturerBussinessItemView)sender).SetValue(SelectedManufacturersProperty, source.Data);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //}
        //#endregion


    }

}
