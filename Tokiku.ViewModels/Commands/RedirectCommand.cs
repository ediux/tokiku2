using System;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class RedirectCommand : ICommand
    {
        public string RoutingName { get; set; }

        public RedirectCommand()
        {
            RoutingName = "Default";
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                try
                {
                    CommandManager.RequerySuggested += value;
                }
                catch
                {

                }

            }
            remove
            {
                try
                {
                    CommandManager.RequerySuggested -= value;
                }
                catch
                {
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RoutedViewResult routingdata = (parameter is RoutedViewResult) ? (RoutedViewResult)parameter : null;

            if (routingdata == null)
                return;

            CommandRoutingManager.HandleCommand(this, parameter, routingdata.Name);

            if (routingdata.RoutedValues.ContainsKey("TargetInstance"))
            {
                if (routingdata.RoutedValues["TargetInstance"] is Window)
                {
                    OpenWindowCommand openwindowcmd = new OpenWindowCommand();
                    openwindowcmd.Execute(parameter);
                }
            }
        }
    }
}
