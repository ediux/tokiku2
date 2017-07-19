﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace TokikuNew.Controls
{
    public class CustomDataGrid : DataGrid
    {
        public CustomDataGrid()
        {
            try
            {                
                AutoGenerateColumns = false;

                if (ItemsSource != null)
                    DataSourceType = ItemsSource.GetType();
                CommandManager.RegisterClassCommandBinding(typeof(CustomDataGrid), new CommandBinding(
        ApplicationCommands.Paste,
        new ExecutedRoutedEventHandler(CustomDataGrid_Executed),
        new CanExecuteRoutedEventHandler(CustomDataGrid_CanExecute)));

                CommandManager.RegisterClassCommandBinding(typeof(CustomDataGrid), new CommandBinding(
        ApplicationCommands.Copy,
        new ExecutedRoutedEventHandler(CustomDataGrid_Executed),
        new CanExecuteRoutedEventHandler(CustomDataGrid_CanExecute)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }



        public Type DataSourceType
        {
            get { return (Type)GetValue(DataSourceTypeProperty); }
            set { SetValue(DataSourceTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSourceType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceTypeProperty =
            DependencyProperty.Register("DataSourceType", typeof(Type), typeof(CustomDataGrid));



        public bool AllowExecuteSystemCommand
        {
            get { return (bool)GetValue(AllowExecuteSystemCommandProperty); }
            set { SetValue(AllowExecuteSystemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowExecuteSystemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowExecuteSystemCommandProperty =
            DependencyProperty.Register("AllowExecuteSystemCommand", typeof(bool), typeof(CustomDataGrid), new PropertyMetadata(true));



        private void CustomDataGrid_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (sender is CustomDataGrid)
                {
                    CustomDataGrid data = (CustomDataGrid)sender;
                    if (data.DataSourceType == this.DataSourceType)
                    {
                        if (e.Command == ApplicationCommands.Paste) { e.CanExecute = AllowExecuteSystemCommand; }
                        if (e.Command == ApplicationCommands.Copy) { e.CanExecute = AllowExecuteSystemCommand; }
                    }

                }
                else
                {
                    e.CanExecute = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
        static bool IsNullable<T>(T obj)
        {
            if (obj == null) return true; // obvious
            Type type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }
        private void CustomDataGrid_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.Command == ApplicationCommands.Paste)
                {
                    // parse the clipboard data
                    List<string[]> rowData = ClipboardHelper.ParseClipboardData();
                    bool hasAddedNewRow = false;

                    // call OnPastingCellClipboardContent for each cell
                    int minRowIndex = Math.Max(Items.IndexOf(CurrentItem), 0);
                    int maxRowIndex = Items.Count - 1;
                    int minColumnDisplayIndex = (SelectionUnit != DataGridSelectionUnit.FullRow) ? Columns.IndexOf(CurrentColumn) : 0;
                    int maxColumnDisplayIndex = Columns.Count;

                    int rowDataIndex = 0;


                    for (int i = minRowIndex; i <= maxRowIndex && rowDataIndex < rowData.Count; i++, rowDataIndex++)
                    {
                        if (i == maxRowIndex)
                        {
                            // add a new row to be pasted to
                            ICollectionView cv = CollectionViewSource.GetDefaultView(Items);
                            IEditableCollectionView iecv = cv as IEditableCollectionView;
                            if (iecv != null)
                            {
                                hasAddedNewRow = true;
                                iecv.AddNew();
                                if (rowDataIndex + 1 < rowData.Count)
                                {
                                    // still has more items to paste, update the maxRowIndex
                                    maxRowIndex = Items.Count - 1;
                                }
                            }
                        }
                        else if (i == maxRowIndex)
                        {
                            continue;
                        }

                        int columnDataIndex = 0;
                        for (int j = minColumnDisplayIndex; j < maxColumnDisplayIndex && columnDataIndex < rowData[rowDataIndex].Length; j++, columnDataIndex++)
                        {
                            DataGridColumn column = ColumnFromDisplayIndex(j);
                            string propertyName = ((column as DataGridBoundColumn).Binding as Binding).Path.Path;
                            object item = Items[i];
                            object value = rowData[rowDataIndex][columnDataIndex];
                            PropertyInfo pi = item.GetType().GetProperty(propertyName);
                            if (pi != null)
                            {
                                try
                                {
                                    var propinfo = item.GetType().GetProperty(propertyName);

                                    if (propinfo != null)
                                    {
                                        try
                                        {
                                            propinfo.SetValue(item, Convert.ChangeType(value, propinfo.PropertyType));
                                        }
                                        catch
                                        {
                                            if (IsNullable(item))
                                            {
                                                object convertedValue = null;
                                                convertedValue = Convert.ChangeType(value,
                                                    Nullable.GetUnderlyingType(propinfo.PropertyType));
                                                propinfo.SetValue(item, convertedValue);
                                            }
                                        }


                                    }

                                }
                                catch
                                {
                                    //跳過轉型失敗的欄位值
                                    continue;
                                }

                            }
                        }
                    }
                }

                if (e.Command == ApplicationCommands.Copy)
                {
                    if (this.SelectedItems.Count > 0)
                    {
                        List<string> converttomatrix = new List<string>();
                        foreach (var row in SelectedItems)
                        {
                            Type data = row.GetType();

                            var dataobject_column_values = data.GetProperties()
                                .Select(s => string.Format("{0}", s.GetValue(row)))
                                .ToArray();

                            converttomatrix.Add(string.Join("\t", dataobject_column_values));
                        }
                        string rawdata = string.Join("\n", converttomatrix.ToArray());
                        Clipboard.SetText(rawdata);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }


        }
    }
}

