using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TokikuNew.Commands;

namespace TokikuNew
{
    public class CommandAttachManager : DependencyObject
    {

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandAttachManager),
                new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChange)));

        private static void CommandChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand cmd = GetCommand(d);


            //CommandAttachManager mgr = (CommandAttachManager)d;

            EventHandler handler = CanExecuteChanged;

            if (e.OldValue != null)
                ((ICommand)e.OldValue).CanExecuteChanged -= handler;
            ((ICommand)e.NewValue).CanExecuteChanged += handler;

            if (cmd is OpenNewTabItem)
            {
                OpenNewTabItem x = (OpenNewTabItem)cmd;

                
                if (d is TabControl)
                    x.ControlSource.Add((TabControl)d);
            }
            //mgr.Command = ((ICommand)e.NewValue);
        }



        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandAttachManager), new PropertyMetadata(null));



        private static void CanExecuteChanged(object sender, EventArgs e)
        {
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
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandProperty, value); }
        }



        public static IInputElement GetCommandTarget(DependencyObject obj)
        {
            return (IInputElement)obj.GetValue(CommandTargetProperty);
        }

        public static void SetCommandTarget(DependencyObject obj, IInputElement value)
        {
            obj.SetValue(CommandTargetProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.RegisterAttached("CommandTarget", typeof(IInputElement), typeof(CommandAttachManager), new PropertyMetadata((IInputElement)null));


        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }



        public static Helpers.RoutedViewResult GetRoutedViewParameter(DependencyObject obj)
        {
            return (Helpers.RoutedViewResult)obj.GetValue(RoutedViewParameterProperty);
        }

        public static void SetRoutedViewParameter(DependencyObject obj, Helpers.RoutedViewResult value)
        {
            obj.SetValue(RoutedViewParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for RoutedViewParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoutedViewParameterProperty =
            DependencyProperty.RegisterAttached("RoutedViewParameter", typeof(Helpers.RoutedViewResult), typeof(CommandAttachManager), new PropertyMetadata(default(Helpers.RoutedViewResult)));

    }
}
