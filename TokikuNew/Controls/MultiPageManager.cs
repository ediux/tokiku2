using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TokikuNew.Commands;

namespace TokikuNew.Controls
{
    public class MultiPageManager : TabControl, ICommandSource
    {
        public MultiPageManager()
        {            
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
    DependencyProperty.Register(
        "Command",
        typeof(ICommand),
        typeof(MultiPageManager),
        new PropertyMetadata((ICommand)null,
        new PropertyChangedCallback(CommandChanged)));

        // Command dependency property change callback.
        private static void CommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            MultiPageManager cs = (MultiPageManager)d;
            cs.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
            if(e.NewValue is OpenNewTabItem)
            {
                ((OpenNewTabItem)e.NewValue).ControlSource = (TabControl)d;
            }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandPatameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandPatameter", typeof(object), typeof(MultiPageManager), new PropertyMetadata(null));


        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        

        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(MultiPageManager), new PropertyMetadata((IInputElement)null));

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

        //// If Command is defined, moving the slider will invoke the command;
        //// Otherwise, the slider will behave normally.
        //protected override void OnValueChanged(double oldValue, double newValue)
        //{
        //    base.OnValueChanged(oldValue, newValue);

        //    if (this.Command != null)
        //    {
        //        RoutedCommand command = Command as RoutedCommand;

        //        if (command != null)
        //        {
        //            command.Execute(CommandParameter, CommandTarget);
        //        }
        //        else
        //        {
        //            ((ICommand)Command).Execute(CommandParameter);
        //        }
        //    }
        //}
    }
}
