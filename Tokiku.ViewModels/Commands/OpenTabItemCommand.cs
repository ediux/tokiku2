using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class OpenNewTabItem : ICommand
    {
        static HashSet<TabControl> _control = new HashSet<TabControl>();

        public OpenNewTabItem()
        {
        }

        public OpenNewTabItem(TabControl source)
        {
            if (_control.Contains(source) == false)
                _control.Add(source);

        }

        public string Text { get; set; }

        public HashSet<TabControl> ControlSource { get => _control; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                RoutedViewResult executeresult = (parameter is RoutedViewResult) ? (RoutedViewResult)parameter : null;

                if (executeresult == null)
                    return;

                CommandRoutingManager.HandleCommand(this, parameter, executeresult.Name);



                if (executeresult.RoutedValues.ContainsKey("UIElement") && executeresult.RoutedValues["UIElement"] is TabControl)
                {
                    TabControl Workspaces = null;

                    if (executeresult.RoutedValues.ContainsKey("UIElement"))
                    {
                        Workspaces = (TabControl)executeresult.RoutedValues["UIElement"];

                        if (Workspaces == null)
                            return;

                        Workspaces = OpenTab(Workspaces, executeresult);
                        Workspaces.UpdateLayout();
                    }
                }

                if (executeresult.RoutedValues.ContainsKey("UIElement") && executeresult.RoutedValues["UIElement"] is DataGrid)
                {
                    DataGrid dg = (DataGrid)executeresult.RoutedValues["UIElement"];
                    executeresult.DataContent = dg.SelectedItem;
                    if (dg != null)
                    {
                        //TabControlName
                        if (executeresult.RoutedValues.ContainsKey("TabControlName"))
                        {
                            TabControl Workspaces = (TabControl)FindControl(dg, (string)executeresult.RoutedValues["TabControlName"]);

                            Workspaces = OpenTab(Workspaces, executeresult);
                            Workspaces.UpdateLayout();
                        }
                    }
                }

                if (executeresult.RoutedValues.ContainsKey("UIElement") && executeresult.RoutedValues["UIElement"] is MenuItem)
                {
                    MenuItem dg = (MenuItem)executeresult.RoutedValues["UIElement"];

                    if (dg != null)
                    {
                        //TabControlName
                        if (executeresult.RoutedValues.ContainsKey("TabControlName"))
                        {
                            TabControl Workspaces = (TabControl)FindControl(dg, (string)executeresult.RoutedValues["TabControlName"]);

                            Workspaces = OpenTab(Workspaces, executeresult);
                            Workspaces.UpdateLayout();
                        }
                    }
                }

                if (executeresult.RoutedValues.ContainsKey("UIElement") && executeresult.RoutedValues["UIElement"] is Button)
                {
                    Button dg = (Button)executeresult.RoutedValues["UIElement"];
                    executeresult.DataContent = dg.DataContext;
                    if (dg != null)
                    {
                        //TabControlName
                        if (executeresult.RoutedValues.ContainsKey("TabControlName"))
                        {
                            TabControl Workspaces = (TabControl)FindControl(dg, (string)executeresult.RoutedValues["TabControlName"]);

                            if (Workspaces == null)
                                return;

                            OpenTab(Workspaces, executeresult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FrameworkElement FindControl(FrameworkElement element, string name)
        {
            if (element == null)
                return null;

            FrameworkElement foundcontrol = (FrameworkElement)element.FindName(name);

            if (foundcontrol != null)
            {
                return foundcontrol;
            }

            if (element.Parent != null)
                return FindControl((FrameworkElement)element.Parent, name);
            else
                return null;
        }

        private TabControl OpenTab(TabControl Workspaces, RoutedViewResult executeresult)
        {
            TabItem addWorkarea = null;

            string Header = string.Empty;

            addWorkarea = (TabItem)Activator.CreateInstance(Assembly.Load("TokikuNew").GetType("TokikuNew.Controls.ClosableTabItem"));
            addWorkarea.Header = Header;

            if (executeresult.RoutingBinding != null && executeresult.RoutingBinding.Count > 0)
            {

                List<object> values = new List<object>();

                foreach (var k in executeresult.RoutingBinding.Keys)
                {
                    //尋找是否有路由綁定設定
                    if (executeresult.DataContent != null)
                    {
                        var fetchprop = executeresult.DataContent.GetType().GetProperty(executeresult.RoutingBinding[k]);

                        if (fetchprop != null)
                        {
                            values.Add(fetchprop.GetValue(executeresult.DataContent));

                        }
                    }
                }

                executeresult.FormatedParameters = values.ToArray();
            }

            if (!string.IsNullOrEmpty(executeresult.DisplayText))
                Header = executeresult.DisplayText;
            else
                Header = string.Format(executeresult.FormatedDisplay, executeresult.FormatedParameters);

            object SharedModel = executeresult.DataContent;

            addWorkarea = (TabItem)Activator.CreateInstance(Assembly.Load("TokikuNew").GetType("TokikuNew.Controls.ClosableTabItem"));
            addWorkarea.Header = Header;

            bool isExisted = false;

            foreach (TabItem item in Workspaces.Items.OfType<TabItem>())
            {
                if (item.Header.Equals(addWorkarea.Header))
                {
                    isExisted = true;
                    addWorkarea = item;
                    break;
                }
            }

            if (!isExisted)
            {
                var vm = Activator.CreateInstance(executeresult.ViewType);
                ProcessRouteValues(executeresult, SharedModel, vm);

                addWorkarea.Content = vm;
                addWorkarea.Margin = new Thickness(0);
                addWorkarea.Visibility = Visibility.Visible;
                addWorkarea.Focus();

                Workspaces.Items.Add(addWorkarea);
                Workspaces.SelectedItem = addWorkarea;
            }
            else
            {
                FrameworkElement vm = (FrameworkElement)addWorkarea.Content;

                ProcessRouteValues(executeresult, SharedModel, vm);

                Workspaces.SelectedItem = addWorkarea;
            }

            return Workspaces;
        }

        private static void ProcessRouteValues(RoutedViewResult executeresult, object SharedModel, object vm)
        {
            if (vm != null)
            {
                if (SharedModel != null)
                {
                    ((FrameworkElement)vm).DataContext = SharedModel;
                }
                //executeresult.ViewType.GetProperty("DataContext")

                if (executeresult.ViewType.GetProperty("Mode") != null)
                {
                    executeresult.ViewType.GetProperty("Mode").SetValue(vm, DocumentLifeCircle.Read);
                }

                if (executeresult.DataContent != null)
                {
                    foreach (var bk in executeresult.RoutingBinding.Keys)
                    {
                        var propb = executeresult.DataContent.GetType().GetProperty(executeresult.RoutingBinding[bk]);

                        if (propb != null)
                        {
                            if (executeresult.RoutedValues.ContainsKey(bk))
                                executeresult.RoutedValues[bk] = propb.GetValue(executeresult.DataContent);
                        }
                    }
                }

                if (executeresult.RoutedValues != null && executeresult.RoutedValues.Count > 0)
                {
                    foreach (var k in executeresult.RoutedValues.Keys)
                    {
                        if (k == "TargetViewModelInstance")
                        {
                            IBaseViewModel model = (IBaseViewModel)executeresult.RoutedValues["TargetViewModelInstance"];

                            if (model != null)
                            {
                                model.RelayCommand.Execute(executeresult);
                            }
                        }

                        var props = executeresult.SourceViewType.GetProperty(k);

                        if (props != null)
                        {
                            var propb = executeresult.ViewType.GetProperty(k);

                            if (propb != null)
                            {
                                var sourceval = props.GetValue(executeresult.SourceInstance);

                                if (sourceval != null)
                                {
                                    propb.SetValue(vm, sourceval);
                                    continue;
                                }
                            }
                        }

                        var prop = executeresult.ViewType.GetProperty(k);

                        if (prop != null)
                        {
                            prop.SetValue(vm, executeresult.RoutedValues[k]);
                        }
                    }
                }
            }
        }
    }
}
