using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Tokiku.MVVM.Data;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
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

                RoutedViewData externaldata = (RoutedViewData)parameter;

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


                        RoutedViewData routingdata = foundroute.Single();

                        externaldata.SourceInstance = routingdata.SourceInstance;
                        externaldata.SourceViewType = routingdata.SourceViewType;
                        externaldata.ViewType = routingdata.ViewType;
                        externaldata.Name = routingdata.Name;


                        if (routingdata.RoutedValues.ContainsKey("View"))
                        {
                            routingdata.ViewType = (Type)routingdata.RoutedValues["View"];
                        }

                        object[] _ConstructionParameters = new object[] { };

                        if (routingdata.RoutedValues.ContainsKey("ViewParameters"))
                        {
                            _ConstructionParameters = (object[])routingdata.RoutedValues["ViewParameters"];
                        }
                        else
                        {
                            _ConstructionParameters = new object[] { };
                        }

                        FrameworkElement targetelement = (FrameworkElement)Activator.CreateInstance(routingdata.ViewType, _ConstructionParameters);

                        if (targetelement != null)
                        {
                            if (routingdata.RoutedValues.ContainsKey("TargetInstance") == false)
                                routingdata.RoutedValues.Add("TargetInstance", targetelement);
                            else
                                routingdata.RoutedValues["TargetInstance"] = targetelement;
                        }


                        IBaseViewModelWithLoginedUser viewmodel = null;

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
                            viewmodel = (IBaseViewModelWithLoginedUser)Activator.CreateInstance(LoadableAssembly.GetType(routingdata.RoutedValues["TargetViewModel"].ToString()), _ViewModelConstructionParameters);
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

                            if (provider != null)
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

        public static void Register(FrameworkElement source, RoutedViewData routingdata, string RoutingName)
        {
            try
            {
                if (_Mapping == null)
                    _Mapping = new Dictionary<FrameworkElement, HashSet<RoutedViewData>>();

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
                    _Mapping.Add(source, new HashSet<RoutedViewData>());
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
                    _Mapping = new Dictionary<FrameworkElement, HashSet<RoutedViewData>>();
                    return;
                }

                _Mapping[source].RemoveWhere(w => w.Name == RoutingName);

            }
            catch
            {

                throw;
            }
        }

        private static Dictionary<FrameworkElement, HashSet<RoutedViewData>> _Mapping;

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

                    if (d is Control && e.NewValue != null)
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
            try
            {
                e.Handled = true;

                if (sender == null)
                    return;

                RoutedViewData route = (RoutedViewData)GetCommandParameter((DependencyObject)sender);

                if (sender is DataGrid)
                    route.DataContent = ((DataGrid)sender)?.SelectedItem;

                GetCommand((DependencyObject)sender)?.Execute(route);
            }
            catch (Exception ex)
            {

            }

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
                    if (e.NewValue is RoutedViewData)
                    {
                        RoutedViewData routeitem = (RoutedViewData)e.NewValue;

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
