using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tokiku.ViewModels;
using TokikuNew.Controls;
using TokikuNew.Helpers;

namespace TokikuNew.Commands
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
                RoutedViewResult executeresult = parameter as RoutedViewResult;

                ClosableTabItem addWorkarea = null;

                foreach (var Workspaces in _control)
                {
                    if (string.IsNullOrEmpty(Workspaces.Name))
                        continue;

                    string specName = executeresult.AttachedTargetElementName;

                    if (Workspaces.Name != specName)
                        continue;

                    string Header = string.Empty;

                    if (!string.IsNullOrEmpty(executeresult.DisplayText))
                        Header = executeresult.DisplayText;
                    else
                        Header = string.Format(executeresult.FormatedDisplay, executeresult.FormatedParameters);

                    object SharedModel = executeresult.DataContent;

                    addWorkarea = new ClosableTabItem() { Header = Header };

                    bool isExisted = false;

                    foreach (ClosableTabItem item in Workspaces.Items.OfType<ClosableTabItem>())
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

                        if (vm != null)
                        {
                            if (SharedModel != null)
                            {
                                executeresult.ViewType.GetProperty("DataContext").SetValue(vm, SharedModel);
                            }

                            if (executeresult.ViewType.GetProperty("Mode") != null)
                            {
                                executeresult.ViewType.GetProperty("Mode").SetValue(vm, DocumentLifeCircle.Read);
                            }

                            if (executeresult.RoutedValues != null && executeresult.RoutedValues.Count > 0)
                            {
                                List<string> _keys = executeresult.RoutedValues.Keys.ToList();

                                foreach (var k in _keys)
                                {
                                    //尋找是否有路由綁定設定

                                    if (executeresult.RoutingBinding.ContainsKey(k))
                                    {
                                        //有路由綁定設定
                                        if (executeresult.SourceInstance != null)
                                        {
                                            var fetchprop = executeresult.SourceViewType.GetProperty(executeresult.RoutingBinding[k]);

                                            if (fetchprop != null)
                                            {
                                                executeresult.RoutedValues[k] = fetchprop.GetValue(executeresult.SourceInstance);
                                            }
                                        }

                                        if (executeresult.DataContent != null)
                                        {
                                            var fetchprop = executeresult.DataContent.GetType().GetProperty(executeresult.RoutingBinding[k]);

                                            if (fetchprop != null)
                                            {
                                                executeresult.RoutedValues[k] = fetchprop.GetValue(executeresult.DataContent);
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

                        addWorkarea = new ClosableTabItem() { Header = Header };
                        addWorkarea.Content = vm;
                        addWorkarea.Margin = new Thickness(0);

                        Workspaces.Items.Add(addWorkarea);
                        Workspaces.SelectedItem = addWorkarea;


                        return;
                    }
                    else
                    {
                        Workspaces.SelectedItem = addWorkarea;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
