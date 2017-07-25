using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// Mvvm路由管理器
    /// </summary>
    public class CommandRoutingManager : DependencyObject, ICommandSource
    {
        public static void HandleCommand(ICommand cmd, object parameter, string RoutingName = "Default")
        {
            try
            {
                if (cmd == null)
                    return;
                if (parameter == null)
                    return;

                Type CommandType = cmd.GetType();

                RoutedViewResult externaldata = (RoutedViewResult)parameter;

                var prop = CommandType.GetProperty("RoutingName");

                if (prop != null)
                {
                    var cmdRoutingName = (string)prop.GetValue(cmd);

                    if (RoutingName != cmdRoutingName)
                        cmdRoutingName = RoutingName;
                }
                else
                {
                    if (string.IsNullOrEmpty(RoutingName))
                        return;
                }



                if (externaldata == null)
                    return;

                FrameworkElement element = null;

                element = _Mapping.Where(w => w.Key.Equals(externaldata.SourceInstance) && w.Value.Where(x => x.Name == RoutingName).Any()).Select(s => s.Key).SingleOrDefault();

                if (element == null)
                    return;

                string storaged_routingName = GetRoutingName(element);

                //if (storaged_routingName != RoutingName)
                //    RoutingName = storaged_routingName;

                if (_Mapping.ContainsKey(element))
                {
                    var foundroute = _Mapping[element].Where(s => s.Name == RoutingName).ToList();

                    if (foundroute.Any())
                    {


                        RoutedViewResult routingdata = foundroute.Single();

                        externaldata.SourceInstance = routingdata.SourceInstance;
                        externaldata.SourceViewType = routingdata.SourceViewType;
                        externaldata.ViewType = routingdata.ViewType;
                        externaldata.Name = routingdata.Name;
                        //foreach (var extkey in externaldata.RoutedValues.Keys)
                        //{
                        //    try
                        //    {
                        //        if (!routingdata.RoutedValues.ContainsKey(extkey))
                        //        {
                        //            routingdata.RoutedValues.Add(extkey, externaldata.RoutedValues[extkey]);
                        //        }
                        //        else
                        //        {
                        //            routingdata.RoutedValues[extkey] = externaldata.RoutedValues[extkey];
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        continue;
                        //    }

                        //}

                        //foreach (var extkey in externaldata.RoutingBinding.Keys)
                        //{
                        //    if (!routingdata.RoutingBinding.ContainsKey(extkey))
                        //    {
                        //        routingdata.RoutingBinding.Add(extkey, externaldata.RoutingBinding[extkey]);
                        //    }
                        //    else
                        //    {
                        //        routingdata.RoutingBinding[extkey] = externaldata.RoutingBinding[extkey];
                        //    }
                        //}

                        if (routingdata.RoutedValues.ContainsKey("View"))
                        {
                            routingdata.ViewType = (Type)routingdata.RoutedValues["View"];
                        }

                        object[] _ConstructionParameters = new object[] { };

                        if (routingdata.RoutedValues.ContainsKey("ViewParameters"))
                        {
                            _ConstructionParameters = (object[])routingdata.RoutedValues["ViewParameters"];
                        }

                        FrameworkElement targetelement = (FrameworkElement)Activator.CreateInstance(routingdata.ViewType, _ConstructionParameters);

                        if (targetelement != null)
                        {
                            if (routingdata.RoutedValues.ContainsKey("TargetInstance") == false)
                                routingdata.RoutedValues.Add("TargetInstance", targetelement);
                            else
                                routingdata.RoutedValues["TargetInstance"] = targetelement;
                        }


                        IBaseViewModel viewmodel = null;

                        Assembly LoadableAssembly = null;

                        if (routingdata.RoutedValues.ContainsKey("AssemblyName"))
                        {
                            LoadableAssembly = Assembly.Load(routingdata.RoutedValues["AssemblyName"].ToString());
                        }
                        else
                        {
                            LoadableAssembly = Assembly.GetExecutingAssembly();
                        }

                        object[] _ViewModelConstructionParameters = new object[] { };

                        if (routingdata.RoutedValues.ContainsKey("ViewModelParameters"))
                        {
                            _ViewModelConstructionParameters = (object[])routingdata.RoutedValues["ViewModelParameters"];
                        }

                        if (routingdata.RoutedValues.ContainsKey("TargetViewModel"))
                        {
                            viewmodel = (IBaseViewModel)Activator.CreateInstance(LoadableAssembly.GetType(routingdata.RoutedValues["TargetViewModel"].ToString()), _ViewModelConstructionParameters);
                            if (!routingdata.RoutedValues.ContainsKey("TargetViewModelInstance"))
                                routingdata.RoutedValues.Add("TargetViewModelInstance", viewmodel);
                            else
                                routingdata.RoutedValues["TargetViewModelInstance"] = viewmodel;
                        }

                        if (routingdata.RoutedValues.ContainsKey("ResourceKey"))
                        {
                            ObjectDataProvider provider = (ObjectDataProvider)targetelement.TryFindResource(routingdata.RoutedValues["ResourceKey"].ToString());

                            if (!routingdata.RoutedValues.ContainsKey("TargetViewModelProvider"))
                                routingdata.RoutedValues.Add("TargetViewModelProvider", provider);
                            else
                                routingdata.RoutedValues["TargetViewModelProvider"] = provider;

                            if (provider !=null)
                            {
                                

                                if (!routingdata.RoutedValues.ContainsKey("TargetViewModelInstance"))
                                    routingdata.RoutedValues.Add("TargetViewModelInstance", provider.Data);
                                else
                                    routingdata.RoutedValues["TargetViewModelInstance"] = provider.Data;
                            }
                        }

                        if (viewmodel != null)
                        {
                            viewmodel.RelayCommand.Execute(externaldata);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static void Redirect(FrameworkElement source, RoutedViewResult routingdata = null)
        //{
        //    if (source != null)
        //    {
        //        if (_Mapping.ContainsKey(source))
        //        {


        //            if (source is UserControl)
        //            {

        //                if (source is Control)
        //                {
        //                    var vm = Activator.CreateInstance(routedvalues.ViewType); //建立檢視頁面模型

        //                    if (vm == null)
        //                        return;

        //                    if (routedvalues.SourceInstance is TabControl)
        //                    {
        //                        //如果路由本身就是頁籤
        //                        TabControl control = (TabControl)routedvalues.SourceInstance;

        //                        if (control != null)
        //                        {
        //                            #region 頁籤控制項
        //                            TabItem addWorkarea = null;

        //                            string Header = string.Empty;

        //                            if (!string.IsNullOrEmpty(routedvalues.DisplayText))
        //                                Header = routedvalues.DisplayText;
        //                            else
        //                                Header = string.Format(routedvalues.FormatedDisplay, routedvalues.FormatedParameters);

        //                            #region 檢查是否有路由綁定
        //                            if (routedvalues.RoutedValues != null && routedvalues.RoutedValues.Count > 0)
        //                            {
        //                                List<string> _keys = routedvalues.RoutedValues.Keys.ToList();

        //                                foreach (var k in _keys)
        //                                {
        //                                    //尋找是否有路由綁定設定

        //                                    if (routedvalues.RoutingBinding.ContainsKey(k))
        //                                    {
        //                                        //有路由綁定設定
        //                                        if (routedvalues.SourceInstance != null)
        //                                        {
        //                                            var fetchprop = routedvalues.SourceViewType.GetProperty(routedvalues.RoutingBinding[k]);

        //                                            if (fetchprop != null)
        //                                            {
        //                                                routedvalues.RoutedValues[k] = fetchprop.GetValue(routedvalues.SourceInstance);
        //                                            }
        //                                        }


        //                                        if (routedvalues.DataContent != null)
        //                                        {
        //                                            var fetchprop = routedvalues.DataContent.GetType().GetProperty(routedvalues.RoutingBinding[k]);

        //                                            if (fetchprop != null)
        //                                            {
        //                                                routedvalues.RoutedValues[k] = fetchprop.GetValue(routedvalues.DataContent);
        //                                            }
        //                                        }
        //                                    }

        //                                    var prop = routedvalues.ViewType.GetProperty(k);

        //                                    if (prop != null)
        //                                    {
        //                                        prop.SetValue(vm, routedvalues.RoutedValues[k]);
        //                                    }
        //                                }
        //                            }
        //                            #endregion

        //                            #region 資料來源檢查
        //                            object SharedModel = null;

        //                            if (routedvalues.DataContent != null)
        //                                SharedModel = routedvalues.DataContent;

        //                            #endregion

        //                            #endregion

        //                            #region 建立頁籤控制項
        //                            addWorkarea = (TabItem)Activator.CreateInstance(Assembly.Load("TokikuNew").GetType("TokikuNew.Controls.ClosableTabItem"));
        //                            addWorkarea.Header = Header;
        //                            #endregion

        //                            #region 檢查頁籤是否存在
        //                            bool isExisted = false;

        //                            foreach (TabItem item in control.Items.OfType<TabItem>())
        //                            {
        //                                if (item.Header.Equals(addWorkarea.Header))
        //                                {
        //                                    isExisted = true;
        //                                    addWorkarea = item;
        //                                    break;
        //                                }
        //                            }
        //                            #endregion

        //                            if (!isExisted)
        //                            {
        //                                var modellist = routedvalues.RoutedValues.OfType<IBaseViewModel>().ToList();

        //                                foreach (var model in modellist)
        //                                {
        //                                    model.RelayCommand.Execute(routedvalues);
        //                                }

        //                                addWorkarea.Content = vm;
        //                                addWorkarea.Margin = new Thickness(0);

        //                                control.Items.Add(addWorkarea);
        //                                control.SelectedItem = addWorkarea;

        //                                return;
        //                            }
        //                            else
        //                            {
        //                                control.SelectedItem = addWorkarea;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (routedvalues.RoutedValues.ContainsKey("SourceViewType"))
        //                        {
        //                            if (routedvalues.RoutedValues.ContainsKey("TabControlName"))
        //                            {
        //                                var sourcekey = _Mapping.Keys.Where(w => w.GetType() == (Type)routedvalues.RoutedValues["SourceViewType"]).Single();

        //                                if (sourcekey != null)
        //                                {
        //                                    var foundcontrol = ((Control)sourcekey).FindName((string)routedvalues.RoutedValues["TabControlName"]);

        //                                    if (foundcontrol is TabControl)
        //                                    {
        //                                        var foundtabcontrol = ((TabControl)foundcontrol);

        //                                        if (foundtabcontrol != null)
        //                                        {
        //                                            TabItem addWorkarea = null;

        //                                            string Header = string.Empty;

        //                                            if (!string.IsNullOrEmpty(routedvalues.DisplayText))
        //                                                Header = routedvalues.DisplayText;
        //                                            else
        //                                            {
        //                                                if (routedvalues.SourceInstance != null)
        //                                                {
        //                                                    if (routedvalues.SourceInstance is DataGrid)
        //                                                    {
        //                                                        List<object> values = new List<object>();
        //                                                        Type datatype = ((DataGrid)routedvalues.SourceInstance).SelectedItem.GetType();
        //                                                        string[] Fields = (string[])routedvalues.FormatedParameters;

        //                                                        foreach (string field in Fields)
        //                                                        {
        //                                                            var prop = datatype.GetProperty(field);

        //                                                            if (prop != null)
        //                                                            {
        //                                                                values.Add(prop.GetValue(((DataGrid)routedvalues.SourceInstance).SelectedItem));
        //                                                            }
        //                                                        }

        //                                                        Header = string.Format(routedvalues.FormatedDisplay, values.ToArray());
        //                                                    }
        //                                                }
        //                                                else
        //                                                {
        //                                                    Header = string.Format(routedvalues.FormatedDisplay, routedvalues.FormatedParameters);
        //                                                }
        //                                            }

        //                                            object SharedModel = null;

        //                                            if (routedvalues.SourceInstance is DataGrid)
        //                                                SharedModel = ((DataGrid)routedvalues.SourceInstance).SelectedItem;

        //                                            #region 建立頁籤控制項
        //                                            addWorkarea = (TabItem)Activator.CreateInstance(Assembly.Load("TokikuNew").GetType("TokikuNew.Controls.ClosableTabItem"));
        //                                            addWorkarea.Header = Header;
        //                                            #endregion

        //                                            bool isExisted = false;

        //                                            foreach (TabItem item in foundtabcontrol.Items.OfType<TabItem>())
        //                                            {
        //                                                if (item.Header.Equals(addWorkarea.Header))
        //                                                {
        //                                                    isExisted = true;
        //                                                    addWorkarea = item;
        //                                                    break;
        //                                                }
        //                                            }

        //                                            if (!isExisted)
        //                                            {
        //                                                if (vm != null)
        //                                                {
        //                                                    if (routedvalues.RoutedValues != null && routedvalues.RoutedValues.Count > 0)
        //                                                    {
        //                                                        List<string> _keys = routedvalues.RoutedValues.Keys.ToList();

        //                                                        foreach (var k in _keys)
        //                                                        {
        //                                                            //尋找是否有路由綁定設定

        //                                                            if (routedvalues.RoutingBinding.ContainsKey(k))
        //                                                            {
        //                                                                //有路由綁定設定
        //                                                                if (routedvalues.SourceInstance != null)
        //                                                                {
        //                                                                    var fetchprop = routedvalues.SourceViewType.GetProperty(routedvalues.RoutingBinding[k]);

        //                                                                    if (fetchprop != null)
        //                                                                    {
        //                                                                        routedvalues.RoutedValues[k] = fetchprop.GetValue(routedvalues.SourceInstance);
        //                                                                    }
        //                                                                }


        //                                                                if (routedvalues.DataContent != null)
        //                                                                {
        //                                                                    var fetchprop = routedvalues.DataContent.GetType().GetProperty(routedvalues.RoutingBinding[k]);

        //                                                                    if (fetchprop != null)
        //                                                                    {
        //                                                                        routedvalues.RoutedValues[k] = fetchprop.GetValue(routedvalues.DataContent);
        //                                                                    }
        //                                                                }

        //                                                                var prop = routedvalues.ViewType.GetProperty(k);

        //                                                                if (prop != null)
        //                                                                {
        //                                                                    prop.SetValue(vm, routedvalues.RoutedValues[k]);
        //                                                                }

        //                                                            }
        //                                                        }


        //                                                    }


        //                                                    if (routedvalues.RoutedValues.ContainsKey("ViewModel"))
        //                                                    {
        //                                                        ObjectDataProvider provider = ((ObjectDataProvider)((FrameworkElement)routedvalues.SourceInstance).TryFindResource(routedvalues.RoutedValues["ViewModel"]));

        //                                                        if (provider != null)
        //                                                        {
        //                                                            IBaseViewModel viewmodel = (IBaseViewModel)provider.Data;

        //                                                            if (viewmodel != null)
        //                                                            {
        //                                                                viewmodel.RelayCommand.Execute(SharedModel);

        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                viewmodel = (IBaseViewModel)((FrameworkElement)vm).TryFindResource(routedvalues.RoutedValues["ViewModel"]);
        //                                                                if (viewmodel != null)
        //                                                                    viewmodel.RelayCommand.Execute(SharedModel);
        //                                                            }
        //                                                        }

        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (SharedModel is IBaseViewModel)
        //                                                        {
        //                                                            IBaseViewModel viewmodel = (IBaseViewModel)SharedModel;
        //                                                            viewmodel.RelayCommand.Execute(routedvalues);
        //                                                        }
        //                                                    }

        //                                                    //var modellist = routedvalues.RoutedValues.OfType<IBaseViewModel>().ToList();

        //                                                    //foreach (var model in modellist)
        //                                                    //{
        //                                                    //    model.RelayCommand.Execute(routedvalues);
        //                                                    //}
        //                                                }

        //                                                addWorkarea.Content = vm;
        //                                                addWorkarea.Margin = new Thickness(0);

        //                                                foundtabcontrol.Items.Add(addWorkarea);
        //                                                foundtabcontrol.SelectedItem = addWorkarea;

        //                                            }
        //                                            else
        //                                            {
        //                                                foundtabcontrol.SelectedItem = addWorkarea;
        //                                            }

        //                                            foundtabcontrol.UpdateLayout();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }

        //                    }
        //                }

        //            }

        //            if (source is Page)
        //            {
        //                if (routedvalues.RoutedValues.ContainsKey("View"))
        //                {
        //                    Uri xamlurl = new Uri((string)routedvalues.RoutedValues["View"], UriKind.Relative);
        //                    System.Windows.Navigation.NavigationService.GetNavigationService(source).Navigate(xamlurl, routedvalues.DataContent);
        //                }
        //            }

        //        }
        //    }

        //}

        public static void Register(FrameworkElement source, RoutedViewResult routingdata, string RoutingName)
        {
            try
            {
                if (_Mapping == null)
                    _Mapping = new Dictionary<FrameworkElement, HashSet<RoutedViewResult>>();

                if (_Mapping.Count > 0 && _Mapping.ContainsKey(source))
                    _Mapping[source].RemoveWhere(w => w.Name == routingdata.Name);

                routingdata.SourceInstance = source;
                routingdata.SourceViewType = routingdata.SourceInstance.GetType();

                routingdata.DataContent = source.DataContext;

                if (routingdata.RoutedValues.ContainsKey("SourceViewType"))
                    routingdata.RoutedValues.Remove("SourceViewType");

                if (routingdata.RoutedValues.ContainsKey("View") == false)
                    routingdata.RoutedValues.Add("View", routingdata.ViewType);

                if (!routingdata.RoutedValues.ContainsKey("IsDialog"))
                    routingdata.RoutedValues.Add("IsDialog", true);

                if (_Mapping.ContainsKey(source) == false)
                {
                    _Mapping.Add(source, new HashSet<RoutedViewResult>());
                    _Mapping[source].Add(routingdata); 
                }
                else
                {
                    if (!_Mapping[source].Where(w => w.Name == routingdata.Name).Any())
                        _Mapping[source].Add(routingdata);                    
                }
            }
            catch
            {
                throw;
            }
        }

        public static void UnRegister(FrameworkElement source, string RoutingName)
        {
            try
            {
                if (_Mapping == null)
                {
                    _Mapping = new Dictionary<FrameworkElement, HashSet<RoutedViewResult>>();
                    return;
                }

                _Mapping[source].RemoveWhere(w => w.Name == RoutingName);

            }
            catch
            {

                throw;
            }
        }

        private static Dictionary<FrameworkElement, HashSet<RoutedViewResult>> _Mapping;

        public CommandRoutingManager()
        {

        }

        #region Routing Name


        public static string GetRoutingName(DependencyObject obj)
        {
            return (string)obj.GetValue(RoutingNameProperty);
        }

        public static void SetRoutingName(DependencyObject obj, string value)
        {
            obj.SetValue(RoutingNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for RoutingName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutingNameProperty =
            DependencyProperty.RegisterAttached("RoutingName", typeof(string), typeof(CommandRoutingManager), new PropertyMetadata("Default"));


        #endregion
        #region Command
        public static ICommand GetCommand(DependencyObject obj)
        {
            try
            {
                return (ICommand)obj.GetValue(CommandProperty);
            }
            catch
            {
                return null;
            }

        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            try
            {
                obj.SetValue(CommandProperty, value);
            }
            catch
            {
            }

        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandRoutingManager),
                new PropertyMetadata(null, new PropertyChangedCallback(CommandChange)));

        private static void CommandChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {

                if (d is FrameworkElement)
                {
                    var cmdt = e.NewValue.GetType().GetProperty("SourceInstance");

                    if (cmdt != null)
                    {
                        cmdt.SetValue(e.NewValue, FindRootElement((FrameworkElement)d));


                    }

                    var p = ((UIElement)d).GetType().GetProperty("Command");

                    if (p != null)
                    {
                        if (e.OldValue != null)
                        {
                            p.SetValue(d, null);
                        }

                        if (e.NewValue != null)
                        {
                            p.SetValue(d, e.NewValue);
                        }

                    }
                    //var cmdt2 = e.NewValue.GetType().GetProperty("RoutingName");

                    //if (cmdt2 != null)
                    //{
                    //    SetRoutingName((DependencyObject)e.NewValue, cmdt2.GetValue(e.NewValue).ToString());
                    //}

                    if (string.IsNullOrEmpty(((FrameworkElement)d).Name))
                    {
                        if (string.IsNullOrEmpty(GetRoutingName(d)))
                            SetRoutingName(d, string.Format("Route_{0}_{1}", d.GetType().Name, Guid.NewGuid().ToString("N")));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(GetRoutingName(d)))
                            SetRoutingName(d, string.Format("Route_{0}", ((FrameworkElement)d).Name));
                    }

                    if (d is Control)
                    {
                        if (d is CheckBox)
                        {

                        }

                        Control c = (Control)d;

                        if (c != null)
                            c.MouseDoubleClick += Button_MouseDoubleClick;

                    }

                    //ICommand cmd = (ICommand)e.NewValue;
                    //Register(FindRootElement((FrameworkElement)d),(RoutedViewResult)e.NewValue, GetRoutingName(d) ?? ((RoutedViewResult)e.NewValue).Name);
                }
            }
            catch
            {
            }
        }

        private static void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            RoutedViewResult route = (RoutedViewResult)GetCommandParameter((DependencyObject)sender);

            if (sender is DataGrid)
                route.DataContent = ((DataGrid)sender).SelectedItem;

            GetCommand((DependencyObject)sender).Execute(route);
        }

        private static void CanExecuteChanged(object sender, EventArgs e)
        {
            try
            {

                if (sender == null)
                    return;

                Type t = sender.GetType();
                var depobject = (DependencyObject)sender;
                ICommand command = GetCommand(depobject);
                var prop = t.GetProperty("IsEnabled");
                if (command != null)
                {

                    // If a RoutedCommand.
                    if (command != null)
                    {
                        if (command.CanExecute(GetCommandParameter(depobject)))
                        {
                            if (prop != null)
                            {
                                prop.SetValue(sender, true);
                            }

                        }
                        else
                        {
                            if (prop != null)
                            {
                                prop.SetValue(sender, false);
                            }
                        }
                    }
                    // If a not RoutedCommand.
                    else
                    {
                        if (command.CanExecute(GetCommandParameter(depobject)))
                        {
                            if (prop != null)
                            {
                                prop.SetValue(sender, true);
                            }

                        }
                        else
                        {
                            if (prop != null)
                            {
                                prop.SetValue(sender, false);
                            }
                        }
                    }
                }
            }
            catch
            {

            }

        }



        #endregion

        #region Command Parameter
        public static object GetCommandParameter(DependencyObject obj)
        {
            try
            {
                return obj.GetValue(CommandParameterProperty);
            }
            catch
            {

                return null;
            }

        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }
        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandRoutingManager),
                new PropertyMetadata(null, new PropertyChangedCallback(ParameterChange)));

        public static FrameworkElement FindRootElement(FrameworkElement element)
        {
            if (element != null && element.Parent == null)
                return element;

            return FindRootElement((FrameworkElement)element.Parent);
        }

        private static void ParameterChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is UIElement)
                {
                    if (e.NewValue is RoutedViewResult)
                    {
                        RoutedViewResult routeitem = (RoutedViewResult)e.NewValue;

                        if (routeitem.RoutedValues.ContainsKey("UIElement") == false)
                            routeitem.RoutedValues.Add("UIElement", d);
                        else
                            routeitem.RoutedValues["UIElement"] = d;

                        //if (string.IsNullOrEmpty(GetRoutingName(d)))
                        //    SetRoutingName(d, string.Format("Route_{0}_{1}", d.GetType().Name, Guid.NewGuid().ToString("N")));

                        if (string.IsNullOrEmpty(routeitem.Name))
                            routeitem.Name = GetRoutingName(d);
                        else
                            SetRoutingName(d, routeitem.Name);

                        Register(FindRootElement((FrameworkElement)d), routeitem, routeitem.Name);
                    }

                    var cmdp = ((UIElement)d).GetType().GetProperty("CommandParameter");

                    if (cmdp != null)
                    {
                        cmdp.SetValue(d, e.NewValue);
                    }

                }

                if (d is Control)
                {
                    if (d is CheckBox)
                    {

                    }

                    Control c = (Control)d;

                    if (c != null)
                        c.MouseDoubleClick += Button_MouseDoubleClick;

                }
            }
            catch
            {

            }
        }

        #endregion

        #region Command Target
        public static IInputElement GetCommandTarget(DependencyObject obj)
        {
            try
            {
                return (IInputElement)obj.GetValue(CommandTargetProperty);
            }
            catch
            {
                return null;
            }

        }

        public static void SetCommandTarget(DependencyObject obj, IInputElement value)
        {
            try
            {
                obj.SetValue(CommandTargetProperty, value);
            }
            catch
            {


            }

        }

        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.RegisterAttached("CommandTarget", typeof(IInputElement), typeof(CommandRoutingManager),
                new PropertyMetadata(null, new PropertyChangedCallback(TargetChange)));


        private static void TargetChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is UIElement)
                {
                    var p = ((UIElement)d).GetType().GetProperty("CommandTarget");

                    if (p != null)
                    {
                        if (e.OldValue != null)
                        {
                            p.SetValue(d, null);
                        }

                        if (e.NewValue != null)
                        {
                            p.SetValue(d, e.NewValue);
                        }
                        return;
                    }

                }
            }
            catch
            {


            }



        }

        #endregion

        public ICommand Command => (ICommand)GetValue(CommandProperty);

        public object CommandParameter => GetValue(CommandParameterProperty);

        public IInputElement CommandTarget => (IInputElement)GetValue(CommandTargetProperty);

    }
}
