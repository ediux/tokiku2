using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// Mvvm路由管理器
    /// </summary>
    public class CommandRoutingManager : DependencyObject, ICommandSource
    {
        public static void Redirect(UIElement source)
        {
            if (source != null)
            {
                if (_Mapping.ContainsKey(source))
                {
                    RoutedViewResult routedvalues = _Mapping[source];

                    if (source is Window)
                    {
                        if (routedvalues.ViewType.BaseType == typeof(Window))
                        {
                            Window _win = (Window)Activator.CreateInstance(routedvalues.ViewType);
                            if (routedvalues.RoutedValues.ContainsKey("IsDialog"))
                            {
                                if ((bool)routedvalues.RoutedValues["IsDialog"])
                                {
                                    _win.ShowDialog();
                                }
                                return;
                            }

                            _win.Show();
                            return;
                        }
                    }

                    if (source is UserControl)
                    {
                        if (routedvalues.ViewType.BaseType == typeof(Window))
                        {
                            Window _win = (Window)Activator.CreateInstance(routedvalues.ViewType);
                            if (routedvalues.RoutedValues.ContainsKey("IsDialog"))
                            {
                                if ((bool)routedvalues.RoutedValues["IsDialog"])
                                {
                                    _win.ShowDialog();
                                }
                                else
                                {
                                    _win.Show();
                                }
                            }
                            return;
                        }

                        if (source is Control)
                        {
                            if (routedvalues.SourceInstance is TabControl)
                            {
                                TabControl control = (TabControl)routedvalues.SourceInstance;

                                if (control != null)
                                {
                                    TabItem addWorkarea = null;

                                    string Header = string.Empty;

                                    if (!string.IsNullOrEmpty(routedvalues.DisplayText))
                                        Header = routedvalues.DisplayText;
                                    else
                                        Header = string.Format(routedvalues.FormatedDisplay, routedvalues.FormatedParameters);

                                    object SharedModel = routedvalues.DataContent;

                                    addWorkarea = new TabItem() { Header = Header };

                                    bool isExisted = false;

                                    foreach (TabItem item in control.Items.OfType<TabItem>())
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

                                        var vm = Activator.CreateInstance(routedvalues.ViewType);

                                        if (vm != null)
                                        {
                                            var modellist = routedvalues.RoutedValues.OfType<IBaseViewModel>().ToList();

                                            foreach (var model in modellist)
                                            {
                                                model.ReplyCommand.Execute(routedvalues);
                                            }
                                        }

                                        addWorkarea = (TabItem)Activator.CreateInstance(Assembly.Load("TokikuNew").GetType("TokikuNew.Controls.ClosableTabItem"));

                                        addWorkarea.Header = Header;
                                        addWorkarea.Content = vm;
                                        addWorkarea.Margin = new Thickness(0);

                                        control.Items.Add(addWorkarea);
                                        control.SelectedItem = addWorkarea;


                                        return;
                                    }
                                    else
                                    {
                                        control.SelectedItem = addWorkarea;
                                    }


                                }
                            }
                        }

                    }

                    if (source is Page)
                    {
                        if (routedvalues.RoutedValues.ContainsKey("View"))
                        {
                            Uri xamlurl = new Uri((string)routedvalues.RoutedValues["View"], UriKind.Relative);
                            System.Windows.Navigation.NavigationService.GetNavigationService(source).Navigate(xamlurl, routedvalues.DataContent);
                        }
                    }

                }
            }

        }

        private static Dictionary<UIElement, RoutedViewResult> _Mapping;

        public CommandRoutingManager()
        {
            if (_Mapping == null)
                _Mapping = new Dictionary<UIElement, RoutedViewResult>();
        }

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
                if (_Mapping == null)
                    _Mapping = new Dictionary<UIElement, RoutedViewResult>();

                if (d is UIElement)
                {


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
                        return;
                    }

                }

                if (d is Control)
                {
                    Control c = (Control)d;

                    c.MouseDoubleClick += Button_MouseDoubleClick;

                }

                ICommand cmd = (ICommand)e.NewValue;

                if (cmd is RedirectCommand)
                {
                    RedirectCommand redirect = (RedirectCommand)cmd;

                    if (_Mapping.ContainsKey((UIElement)redirect.SourceInstance) == false)
                    {
                        _Mapping.Add((UIElement)redirect.SourceInstance, (RoutedViewResult)GetCommandParameter(d));
                    }
                }

            }
            catch
            {
            }
        }

        private static void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetCommand((DependencyObject)sender).Execute(GetCommandParameter((DependencyObject)sender));
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
                if (_Mapping == null)
                    _Mapping = new Dictionary<UIElement, RoutedViewResult>();

                if (d is UIElement)
                {

                    if (e.NewValue is RoutedViewResult)
                    {
                        RoutedViewResult routeitem = (RoutedViewResult)e.NewValue;

                        if (routeitem.SourceInstance == null)
                            routeitem.SourceInstance = d;

                        if (!_Mapping.ContainsKey((UIElement)routeitem.SourceInstance))
                        {
                            _Mapping.Add(FindRootElement((FrameworkElement)d), routeitem);
                        }
                        else
                        {
                            _Mapping[FindRootElement((FrameworkElement)d)] = routeitem;
                        }

                    }

                    var cmdp = ((UIElement)d).GetType().GetProperty("CommandParameter");

                    if (cmdp == null)
                    {
                        cmdp.SetValue(d, e.NewValue);
                    }
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

        public IInputElement CommandTarget => throw new NotImplementedException();

    }
}
