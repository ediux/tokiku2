using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.ViewModels;

namespace TokikuNew.Controls
{
    public class CustomDataGrid : DataGrid
    {
        public CustomDataGrid()
        {
            try
            {

                RoutedValues = new Dictionary<string, object>();
                FormatDisplayParametersMapping = new List<string>();

                AutoGenerateColumns = false;

                //CommandRoutingManager.SetCommand(this, new RedirectCommand());
                
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

        private void CustomDataGrid_Initialized(object sender, EventArgs e)
        {
            Items.Clear();
        }

        public Type OpenViewType
        {
            get { return (Type)GetValue(OpenViewTypeProperty); }
            set { SetValue(OpenViewTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenViewType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenViewTypeProperty =
            DependencyProperty.Register("OpenViewType", typeof(Type), typeof(CustomDataGrid), new PropertyMetadata((Type)null));




        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(CustomDataGrid), new PropertyMetadata(string.Empty));



        public string FormationDisplayText
        {
            get { return (string)GetValue(FormationDisplayTextProperty); }
            set { SetValue(FormationDisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormationDisplayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormationDisplayTextProperty =
            DependencyProperty.Register("FormationDisplayText", typeof(string), typeof(CustomDataGrid), new PropertyMetadata(string.Empty));



        public List<string> FormatDisplayParametersMapping
        {
            get { return (List<string>)GetValue(FormatDisplayParametersMappingProperty); }
            set { SetValue(FormatDisplayParametersMappingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FormatDisplayParametersMapping.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatDisplayParametersMappingProperty =
            DependencyProperty.Register("FormatDisplayParametersMapping", typeof(List<string>), typeof(CustomDataGrid), new PropertyMetadata(default(List<string>)));



        public string TriggerTargetElementName
        {
            get { return (string)GetValue(TriggerTargetElementNameProperty); }
            set { SetValue(TriggerTargetElementNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetElementName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriggerTargetElementNameProperty =
            DependencyProperty.Register("TriggerTargetElementName", typeof(string), typeof(CustomDataGrid), new PropertyMetadata(string.Empty));



        public Dictionary<string, object> RoutedValues
        {
            get { return (Dictionary<string, object>)GetValue(RoutedValuesProperty); }
            set { SetValue(RoutedValuesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RoutedValues.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutedValuesProperty =
            DependencyProperty.Register("RoutedValues", typeof(Dictionary<string, object>), typeof(CustomDataGrid), new PropertyMetadata(default(Dictionary<string, object>)));


        private void CustomDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;

                //if (Command is RedirectCommand)
                //{
                //    if (SelectedItem != null)
                //    {

                //        RedirectCommand command = (RedirectCommand)Command;

                //        if (command != null)
                //        {
                //            var routedvalue = new RoutedViewResult()
                //            {
                //                DisplayText = this.DisplayText,
                //                ViewType = this.OpenViewType,
                //                RoutedValues = new Dictionary<string, object>()
                //            };
                //            routedvalue.FormatedDisplay = this.FormationDisplayText;

                //            List<object> values = new List<object>();

                //            foreach (var key in FormatDisplayParametersMapping)
                //            {
                //                values.Add(DataSourceType.GetProperty(key).GetValue(SelectedItem));
                //            }
                //            routedvalue.FormatedParameters = values.ToArray();
                //            routedvalue.RoutedValues = new Dictionary<string, object>();
                //            foreach (var k in RoutedValues.Keys)
                //            {
                //                routedvalue.RoutedValues.Add(k, DataSourceType.GetProperty((string)RoutedValues[k]).GetValue(SelectedItem));
                //            }
                //            routedvalue.AttachedTargetElementName = TriggerTargetElementName;
                //            command.Execute(routedvalue);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CustomDataGrid), new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChanged)));

        // Command dependency property change callback.
        private static void CommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CustomDataGrid cs = (CustomDataGrid)d;
            cs.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        // Add a new command to the Command Property.
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers.
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand, newCommand);
            }
            AddCommand(oldCommand, newCommand);
        }

        // Remove an old command from the Command Property.
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }

        // Add the command.
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            //canExecuteChangedHandler = handler;
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += CanExecuteChanged;
            }
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;

                // If a RoutedCommand.
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
                // If a not RoutedCommand.
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
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

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CustomDataGrid), new PropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }


        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(CustomDataGrid), new PropertyMetadata((IInputElement)null));

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

                    if (data != null)
                    {
                        if (e.Command == ApplicationCommands.Paste) { e.CanExecute = AllowExecuteSystemCommand; }
                        if (e.Command == ApplicationCommands.Copy) { e.CanExecute = AllowExecuteSystemCommand; }

                    }
                    else
                    {
                        e.CanExecute = false;
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
                CustomDataGrid data = (CustomDataGrid)sender;

                if (data == null)
                    return;

                if (e.Command == ApplicationCommands.Paste)
                {
                    // parse the clipboard data
                    List<string[]> rowData = ClipboardHelper.ParseClipboardData();
                   

                    // call OnPastingCellClipboardContent for each cell
                    int minRowIndex = Math.Max(data.Items.IndexOf(data.CurrentItem), 0);
                    int maxRowIndex = data.Items.Count - 1;
                    int minColumnDisplayIndex = (data.SelectionUnit != DataGridSelectionUnit.FullRow) ? data.Columns.IndexOf(data.CurrentColumn) : 0;
                    int maxColumnDisplayIndex = data.Columns.Count;

                    int rowDataIndex = 0;


                    for (int i = minRowIndex; i <= maxRowIndex && rowDataIndex < rowData.Count; i++, rowDataIndex++)
                    {
                        if (i == maxRowIndex)
                        {
                            // add a new row to be pasted to
                            ICollectionView cv = CollectionViewSource.GetDefaultView(data.Items);
                            IEditableCollectionView iecv = cv as IEditableCollectionView;

                            if (iecv != null)
                            {                              
                                iecv.AddNew();
                                if (rowDataIndex + 1 < rowData.Count)
                                {
                                    // still has more items to paste, update the maxRowIndex
                                    maxRowIndex = data.Items.Count - 1;
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
                            DataGridColumn column = data.ColumnFromDisplayIndex(j);
                            string propertyName = ((column as DataGridBoundColumn).Binding as Binding).Path.Path;
                            object item = data.Items[i];
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
                    if (data.SelectedItems.Count > 0)
                    {
                        List<string> converttomatrix = new List<string>();
                        foreach (var row in data.SelectedItems)
                        {
                            Type dataitem = row.GetType();

                            var dataobject_column_values = dataitem.GetProperties()
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

