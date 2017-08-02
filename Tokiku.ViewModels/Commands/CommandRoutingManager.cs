using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
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
    public class CommandRoutingManager : FrameworkElement, ICommandSource
    {
        //private static Dictionary<string, RoutedViewResult> _Mapping = new Dictionary<string, RoutedViewResult>();

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

        #region Event Routing Mapping

        public static string GetEventMapping(DependencyObject obj)
        {
            return (string)obj.GetValue(EventMappingProperty);
        }

        public static void SetEventMapping(DependencyObject obj, string value)
        {
            obj.SetValue(EventMappingProperty, value);
        }

        // Using a DependencyProperty as the backing store for EventMapping.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventMappingProperty =
            DependencyProperty.RegisterAttached("EventMapping", typeof(string), typeof(CommandRoutingManager), new PropertyMetadata(string.Empty, new PropertyChangedCallback(EventMappingChange)));

        private static void EventMappingChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                string prefix = string.Empty;

                Type tExForm = GetPrefix(d, ref prefix);

                string EventName = e.NewValue.ToString();

                if (string.IsNullOrEmpty(EventName))
                    return;

                EventInfo evDyEvent = tExForm.GetEvent(EventName);

                Type tDelegate = typeof(RoutedEventHandler);

                //Type returnType = GetDelegateReturnType(tDelegate);

                //if (returnType != typeof(void))
                //    throw new ApplicationException("Delegate has a return type.");

                //Type[] ParameterTypes = GetDelegateParameterTypes(tDelegate);

                //DynamicMethod handler = new DynamicMethod("",
                //          null,
                //          ParameterTypes,
                //          typeof(CommandRoutingManager));

                //var Prop_Handled = ParameterTypes[1].GetProperty("Handled");
                //var Prop_Handled_GetVal = Prop_Handled.PropertyType.GetMethod("SetVal");

                //ParameterExpression senderParam = System.Linq.Expressions.Expression.Parameter(ParameterTypes[0], "sender");
                //ParameterExpression numParam = System.Linq.Expressions.Expression.Parameter(ParameterTypes[1], "e");

                //var exp1 = System.Linq.Expressions.Expression.MakeMemberAccess(numParam, ParameterTypes[1].GetMember("Handled", MemberTypes.Property, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.SetProperty).First());
                //var exp2 = System.Linq.Expressions.Expression.Constant(true);
                //var exp3 = System.Linq.Expressions.Expression.Assign(exp1, exp2);
                //DataGrid.MouseDoubleClickEvent
                var eventfield = typeof(Control).GetField(EventName + "Event", BindingFlags.Static | BindingFlags.Public);

                if (eventfield != null)
                    ((FrameworkElement)d).AddHandler((RoutedEvent)eventfield.GetValue(d),
                        Delegate.CreateDelegate(tDelegate, typeof(CommandRoutingManager).GetMethod("Button_MouseDoubleClick", BindingFlags.NonPublic | BindingFlags.Static)));
                //System.Linq.Expressions.Expression.Lambda(tDelegate,,,)
            }
            catch
            {

            }
        }

        private static Type GetPrefix(DependencyObject d, ref string prefix)
        {
            Type tExForm = d.GetType();

            var Prop_Name = tExForm.GetProperty("Name");

            if (Prop_Name != null)
            {
                var PropVal_Name = (string)Prop_Name.GetValue(d);

                if (!string.IsNullOrEmpty(PropVal_Name))
                {
                    prefix = string.Format("WPF_{0}_{1}", PropVal_Name, Guid.NewGuid().ToString("N"));
                }
                else
                {
                    prefix = string.Format("WPF_{0}_{1}", tExForm.FullName.Replace(".", "_"), Guid.NewGuid().ToString("N"));
                }
            }

            return tExForm;
        }

        private static Type[] GetDelegateParameterTypes(Type d)
        {
            if (d.BaseType != typeof(MulticastDelegate))
                throw new ApplicationException("Not a delegate.");

            MethodInfo invoke = d.GetMethod("Invoke");
            if (invoke == null)
                throw new ApplicationException("Not a delegate.");

            ParameterInfo[] parameters = invoke.GetParameters();
            Type[] typeParameters = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                typeParameters[i] = parameters[i].ParameterType;
            }
            return typeParameters;
        }

        private static Type GetDelegateReturnType(Type d)
        {
            if (d.BaseType != typeof(MulticastDelegate))
                throw new ApplicationException("Not a delegate.");

            MethodInfo invoke = d.GetMethod("Invoke");
            if (invoke == null)
                throw new ApplicationException("Not a delegate.");

            return invoke.ReturnType;
        }
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

                    //if (string.IsNullOrEmpty(((FrameworkElement)d).Name))
                    //{
                    //    if (string.IsNullOrEmpty(GetRoutingName(d)))
                    //        SetRoutingName(d, string.Format("Route_{0}_{1}", d.GetType().Name, Guid.NewGuid().ToString("N")));
                    //}
                    //else
                    //{
                    //    if (string.IsNullOrEmpty(GetRoutingName(d)))
                    //        SetRoutingName(d, string.Format("Route_{0}", ((FrameworkElement)d).Name));
                    //}
                    //DataGrid.MouseDoubleClickEvent
                    //if (d is Control && e.NewValue != null)
                    //{
                    //    if (d is CheckBox)
                    //    {

                    //    }

                    //    Control c = (Control)d;

                    //    if (c != null)
                    //        c.MouseDoubleClick += Button_MouseDoubleClick;

                    //}

                    //ICommand cmd = (ICommand)e.NewValue;
                    //Register(FindRootElement((FrameworkElement)d),(RoutedViewResult)e.NewValue, GetRoutingName(d) ?? ((RoutedViewResult)e.NewValue).Name);
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

        private static void ParameterChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is UIElement)
                {

                    if (e.NewValue is RoutedViewResult)
                    {
                        RoutedViewResult routeitem = (RoutedViewResult)e.NewValue;

                        var p = d.GetType().GetProperty("CommandParameter");

                        if (p != null)
                        {
                            object val = p.GetValue(d);

                            if (val is RoutedViewResult)
                            {
                                foreach (var k in ((RoutedViewResult)val).RoutedValues.Keys)
                                {
                                    if (!routeitem.RoutedValues.ContainsKey(k))
                                        routeitem.RoutedValues.Add(k, ((RoutedViewResult)val).RoutedValues[k]);
                                }

                                p.SetValue(d, routeitem);
                            }
                        }

                        if (routeitem.RoutedValues.ContainsKey("UIElement") == false)
                            routeitem.RoutedValues.Add("UIElement", d);
                        else
                            routeitem.RoutedValues["UIElement"] = d;

                        routeitem.SourceInstance = FindRootElement((FrameworkElement)d);

                        if (routeitem.RoutedValues.ContainsKey("UIElementRoot") == false)
                            routeitem.RoutedValues.Add("UIElementRoot", routeitem.SourceInstance);
                        else
                            routeitem.RoutedValues["UIElementRoot"] = routeitem.SourceInstance;

                        if (p != null)
                            p.SetValue(d, routeitem);
                       

                        //IBaseViewModel viewmodel = null;

                        //Assembly LoadableAssembly = null;

                        //if (routeitem.RoutedValues.ContainsKey("AssemblyName"))
                        //{
                        //    LoadableAssembly = Assembly.Load(routeitem.RoutedValues["AssemblyName"].ToString());
                        //}
                        //else
                        //{
                        //    LoadableAssembly = Assembly.GetExecutingAssembly();
                        //}

                        //object[] _ViewModelConstructionParameters = new object[] { };

                        //if (routeitem.RoutedValues.ContainsKey("ViewModelParameters"))
                        //{
                        //    _ViewModelConstructionParameters = (object[])routeitem.RoutedValues["ViewModelParameters"];
                        //}

                        //if (routeitem.RoutedValues.ContainsKey("TargetViewModel"))
                        //{
                        //    viewmodel = (IBaseViewModel)Activator.CreateInstance(LoadableAssembly.GetType(routeitem.RoutedValues["TargetViewModel"].ToString()), _ViewModelConstructionParameters);

                        //    if (!routeitem.RoutedValues.ContainsKey("TargetViewModelInstance"))
                        //        routeitem.RoutedValues.Add("TargetViewModelInstance", viewmodel);
                        //    else
                        //        routeitem.RoutedValues["TargetViewModelInstance"] = viewmodel;
                        //}

                        //if (routeitem.RoutedValues.ContainsKey("ResourceKey"))
                        //{
                        //    ObjectDataProvider provider = (ObjectDataProvider)targetelement.TryFindResource(routeitem.RoutedValues["ResourceKey"].ToString());

                        //    if (!routeitem.RoutedValues.ContainsKey("TargetViewModelProvider"))
                        //        routeitem.RoutedValues.Add("TargetViewModelProvider", provider);
                        //    else
                        //        routeitem.RoutedValues["TargetViewModelProvider"] = provider;

                        //    //if (provider != null)
                        //    //{
                        //    //    if (!routeitem.RoutedValues.ContainsKey("TargetViewModelProviderData"))
                        //    //        routeitem.RoutedValues.Add("TargetViewModelProviderData", provider.Data);
                        //    //    else
                        //    //        routeitem.RoutedValues["TargetViewModelProviderData"] = provider.Data;
                        //    //}
                        //}

                        //if (string.IsNullOrEmpty(GetRoutingName(d)))
                        //    SetRoutingName(d, string.Format("Route_{0}_{1}", d.GetType().Name, Guid.NewGuid().ToString("N")));

                        //if (string.IsNullOrEmpty(routeitem.Name))
                        //    routeitem.Name = GetRoutingName(d);
                        //else
                        //    SetRoutingName(d, routeitem.Name);

                        //Register(FindRootElement((FrameworkElement)d), routeitem, routeitem.Name);
                    }

                    //var cmdp = ((UIElement)d).GetType().GetProperty("CommandParameter");

                    //if (cmdp != null)
                    //{
                    //    cmdp.SetValue(d, e.NewValue);
                    //}

                }

                //if (d is Control)
                //{
                //    if (d is CheckBox)
                //    {

                //    }

                //    Control c = (Control)d;

                //    if (c != null)
                //        c.MouseDoubleClick += Button_MouseDoubleClick;

                //}
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

        #region Command Source
        public ICommand Command => (ICommand)GetValue(CommandProperty);

        public object CommandParameter => GetValue(CommandParameterProperty);

        public IInputElement CommandTarget => (IInputElement)GetValue(CommandTargetProperty);
        #endregion

        #region Manager Helper Functions
        public static FrameworkElement FindRootElement(FrameworkElement element)
        {
            if (element != null && element.Parent == null)
                return element;

            return FindRootElement((FrameworkElement)element.Parent);
        }



        public static void HandleCommand(ICommand cmd, object parameter, string RoutingName = "Default")
        {
            try
            {
                if (cmd == null)
                    return;

                if (parameter == null)
                    return;

                Type CommandType = cmd.GetType();

                if (!(parameter is RoutedViewResult))
                    return;

                RoutedViewResult externaldata = (RoutedViewResult)parameter;

                //if (cmd.CanExecute(externaldata))
                //    cmd.Execute(externaldata);

                //var prop = CommandType.GetProperty("RoutingName");

                //if (prop != null)
                //{
                //    var cmdRoutingName = (string)prop.GetValue(cmd);

                //    if (RoutingName != cmdRoutingName)
                //    {
                //        prop.SetValue(cmd, RoutingName);
                //        cmdRoutingName = RoutingName;
                //    }

                //}
                //else
                //{
                //    if (string.IsNullOrEmpty(RoutingName))
                //        return;
                //}

                //if (externaldata == null)
                //    return;


                //FrameworkElement element = FindElement<FrameworkElement>(RoutingName);

                //element = FindElement<FrameworkElement>( _Mapping.Where(w => w.Key.Equals(externaldata.SourceInstance) && w.Value.s RoutingName).Any()).Select(s => s.Key).SingleOrDefault();

                //if (element == null)
                //    return;

                //RoutedViewResult routingdata = FindRegisterData(RoutingName);

                //if (routingdata == null)
                //    return;

                //externaldata.SourceInstance = routingdata.SourceInstance;
                //externaldata.SourceViewType = routingdata.SourceViewType;
                //externaldata.ViewType = routingdata.ViewType;
                //externaldata.Name = routingdata.Name;


                //if (routingdata.RoutedValues.ContainsKey("View"))
                //{
                //    routingdata.ViewType = (Type)routingdata.RoutedValues["View"];
                //}

                //object[] _ConstructionParameters = new object[] { };

                //if (routingdata.RoutedValues.ContainsKey("ViewParameters"))
                //{
                //    _ConstructionParameters = (object[])routingdata.RoutedValues["ViewParameters"];
                //}
                //else
                //{
                //    _ConstructionParameters = new object[] { };
                //}

                //FrameworkElement targetelement = (FrameworkElement)Activator.CreateInstance(routingdata.ViewType, _ConstructionParameters);

                //if (targetelement != null)
                //{
                //    if (routingdata.RoutedValues.ContainsKey("TargetInstance") == false)
                //        routingdata.RoutedValues.Add("TargetInstance", targetelement);
                //    else
                //        routingdata.RoutedValues["TargetInstance"] = targetelement;
                //}

                //IBaseViewModel viewmodel = null;

                //Assembly LoadableAssembly = null;

                //if (routingdata.RoutedValues.ContainsKey("AssemblyName"))
                //{
                //    LoadableAssembly = Assembly.Load(routingdata.RoutedValues["AssemblyName"].ToString());
                //}
                //else
                //{
                //    LoadableAssembly = Assembly.GetExecutingAssembly();
                //}

                //object[] _ViewModelConstructionParameters = new object[] { };

                //if (routingdata.RoutedValues.ContainsKey("ViewModelParameters"))
                //{
                //    _ViewModelConstructionParameters = (object[])routingdata.RoutedValues["ViewModelParameters"];
                //}

                //if (routingdata.RoutedValues.ContainsKey("TargetViewModel"))
                //{
                //    viewmodel = (IBaseViewModel)Activator.CreateInstance(LoadableAssembly.GetType(routingdata.RoutedValues["TargetViewModel"].ToString()), _ViewModelConstructionParameters);
                //    if (!routingdata.RoutedValues.ContainsKey("TargetViewModelInstance"))
                //        routingdata.RoutedValues.Add("TargetViewModelInstance", viewmodel);
                //    else
                //        routingdata.RoutedValues["TargetViewModelInstance"] = viewmodel;
                //}

                //if (routingdata.RoutedValues.ContainsKey("ResourceKey"))
                //{
                //    ObjectDataProvider provider = (ObjectDataProvider)targetelement.TryFindResource(routingdata.RoutedValues["ResourceKey"].ToString());

                //    if (!routingdata.RoutedValues.ContainsKey("TargetViewModelProvider"))
                //        routingdata.RoutedValues.Add("TargetViewModelProvider", provider);
                //    else
                //        routingdata.RoutedValues["TargetViewModelProvider"] = provider;

                //    if (provider != null)
                //    {


                //        if (!routingdata.RoutedValues.ContainsKey("TargetViewModelInstance"))
                //            routingdata.RoutedValues.Add("TargetViewModelInstance", provider.Data);
                //        else
                //            routingdata.RoutedValues["TargetViewModelInstance"] = provider.Data;
                //    }
                //}

                //if (viewmodel != null)
                //{
                //    viewmodel.RelayCommand.Execute(externaldata);
                //}

                //string storaged_routingName = GetRoutingName(element);

                //if (storaged_routingName != RoutingName)
                //    RoutingName = storaged_routingName;

                //if (_Mapping.ContainsKey(element))
                //{
                //    var foundroute = _Mapping[element].Where(s => s.Name == RoutingName).ToList();

                //    if (foundroute.Any())
                //    {


                //         foundroute.Single();


                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static void Register(FrameworkElement source, RoutedViewResult routingdata, string RoutingName)
        //{
        //    try
        //    {
        //        string prefix = string.Empty;

        //        Type tExForm = GetPrefix(source, ref prefix);

        //        Guid UID = Guid.NewGuid();

        //        if (string.IsNullOrEmpty(routingdata.Uid))
        //        {
        //            routingdata.Uid = UID.ToString();
        //        }

        //        string testuid = (RoutingName ?? (routingdata?.Name)) ?? tExForm.Name;

        //        string finduid = string.Format("WPF_{0}_{1}", (RoutingName ?? (routingdata?.Name)) ?? tExForm.Name, routingdata.Uid);

        //        if (_Mapping == null)
        //            _Mapping = new Dictionary<string, RoutedViewResult>();

        //        IEnumerable<RoutedViewResult> routedata = FindRegisterData(testuid);

        //        if (routedata != null && routedata.Count() > 0)
        //        {
        //            routedata = routingdata;
        //            _Mapping.Add(finduid, routedata);
        //        }
        //        else
        //        {
        //            routedata = _Mapping[finduid] = routingdata;
        //        }



        //        routedata.SourceInstance = source;
        //        routedata.SourceViewType = routingdata.SourceInstance.GetType();

        //        routedata.DataContent = source.DataContext;

        //        if (routedata.RoutedValues.ContainsKey("SourceViewType"))
        //            routedata.RoutedValues.Remove("SourceViewType");

        //        if (routedata.RoutedValues.ContainsKey("View") == false)
        //            routedata.RoutedValues.Add("View", routingdata.ViewType);

        //        if (!routedata.RoutedValues.ContainsKey("IsDialog"))
        //            routedata.RoutedValues.Add("IsDialog", true);

        //        //if (_Mapping.ContainsKey(source) == false)
        //        //{
        //        //    _Mapping.Add(source, new HashSet<RoutedViewResult>());
        //        //    _Mapping[source].Add(routingdata);
        //        //}
        //        //else
        //        //{
        //        //    if (!_Mapping[source].Where(w => w.Name == routingdata.Name).Any())
        //        //        _Mapping[source].Add(routingdata);
        //        //}
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public static void UnRegister(FrameworkElement source, string RoutingName)
        //{
        //    try
        //    {
        //        if (_Mapping == null)
        //        {
        //            _Mapping = new Dictionary<string, RoutedViewResult>();
        //            return;
        //        }

        //        string key = _Mapping.Where(w => w.Key.StartsWith(string.Format("WPF_{0}", RoutingName))).Select(s => s.Key).Single();

        //        _Mapping.Remove(key);
        //        // .RemoveWhere(w => w.Name == RoutingName);

        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //private static IEnumerable<RoutedViewResult> FindRegisterData(string Name)
        //{
        //    try
        //    {
        //        return _Mapping.Where(w => w.Key.StartsWith(string.Format("WPF_{0}", Name))).Select(s => s.Value).AsEnumerable();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        private static void Button_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (sender == null)
                    return;

                RoutedViewResult route = (RoutedViewResult)GetCommandParameter((DependencyObject)sender);

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
    }
}
