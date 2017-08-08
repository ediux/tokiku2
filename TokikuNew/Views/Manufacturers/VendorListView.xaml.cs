using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;

namespace TokikuNew.Views
{
    /// <summary>
    /// VendorListView.xaml 的互動邏輯
    /// </summary>
    public partial class VendorListView : UserControl
    {

        public VendorListView()
        {
            InitializeComponent();
        }

        //public static readonly RoutedEvent SelectedVendorChangedEvent = EventManager.RegisterRoutedEvent(
        //     "SelectedVendorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(VendorListView));

        //public event RoutedEventHandler SelectedVendorChanged
        //{
        //    add { AddHandler(SelectedVendorChangedEvent, value); }
        //    remove { RemoveHandler(SelectedVendorChangedEvent, value); }
        //}



        //public ManufacturersViewModel SelectedManufacturer
        //{
        //    get { return (ManufacturersViewModel)GetValue(SelectedManufacturerProperty); }
        //    set { SetValue(SelectedManufacturerProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedManufacturer.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedManufacturerProperty =
        //    DependencyProperty.Register("SelectedManufacturer", typeof(ManufacturersViewModel), typeof(VendorListView), new PropertyMetadata(default(ManufacturersViewModel)));



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;
        //        //((ManufacturersViewModelCollection)DataContext).QueryByText((string)e.OriginalSource);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }
        //    //搜尋框


        //}

        //private void sSearchBar_ResetSearch(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;
        //        ((ManufacturersViewModelCollection)DataContext).QueryByText("");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }

        //}

        //private void btnNew_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;
        //        RaiseEvent(new RoutedEventArgs(Controls.ClosableTabItem.SendNewPageRequestEvent, this));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }

        //}

        //private void VendorList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.AddedCells.Any())
        //        {
        //            var obj = e.AddedCells.First().Item;
        //            var header = e.AddedCells.First().Column.DisplayIndex;

        //            if (header == 0)
        //            {
        //                if (obj != null)
        //                {
        //                    SelectedManufacturer = (ManufacturersViewModel)obj;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }



        //}

        //private void VendorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;

        //        if (VendorList.SelectedItem != null)
        //        {
        //            SelectedManufacturer = (ManufacturersViewModel)VendorList.SelectedItem;
        //        }

        //        RoutedUICommand command = (RoutedUICommand)TryFindResource("OpenNewTabItem");

        //        if (command != null)
        //        {
        //            var routedvalue = new RoutedViewResult()
        //            {
        //                FormatedDisplay = "廠商:{0}-{1}",
        //                FormatedParameters = new object[] { SelectedManufacturer.Code, SelectedManufacturer.ShortName },
        //                ViewType = typeof(ManufacturersManageView),
        //                RoutedValues = new Dictionary<string, object>()
        //            };
        //            routedvalue.RoutedValues.Add("SelectedManufacturerId", SelectedManufacturer.Id);
        //            command.Execute(routedvalue, VendorList);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        //    }

        //}

        //private void QueryCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.Handled = true;
        //    e.CanExecute = true;
        //}

        //private void QueryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    try
        //    {
        //        ObjectDataProvider provider = (ObjectDataProvider)TryFindResource("ManufacturerListSource");
        //        if (provider != null)
        //        {
        //            provider.MethodName = "QueryByText";
        //            provider.MethodParameters.Clear();
        //            provider.MethodParameters.Add(e.Parameter);
        //            provider.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        //    }
        //}

        //private void QueryRefreshCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.Handled = true;
        //    e.CanExecute = true;
        //}

        //private void QueryRefreshCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    try
        //    {
        //        ObjectDataProvider provider = (ObjectDataProvider)TryFindResource("ManufacturerListSource");
        //        if (provider != null)
        //        {
        //            provider.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        //    }
        //}

        //private void btnNew_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.Handled = true;
        //    e.CanExecute = true;
        //}

        //private void ResetFiliterCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.Handled = true;
        //    e.CanExecute = true;
        //}

        //private void ResetFiliterCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    try
        //    {
        //        e.Handled = true;

        //        ObjectDataProvider provider = (ObjectDataProvider)FindResource("ManufacturerListSource");

        //        if (provider != null)
        //        {
        //            provider.MethodName = "Query";
        //            provider.MethodParameters.Clear();
        //            provider.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        //    }
        //}
    }
}
