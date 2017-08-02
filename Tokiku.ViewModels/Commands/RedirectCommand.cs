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

            object[] _ConstructionParameters = new object[] { };

            if (routingdata.RoutedValues.ContainsKey("ViewParameters"))
            {
                _ConstructionParameters = (object[])routingdata.RoutedValues["ViewParameters"];
            }

            object targetelement = Activator.CreateInstance(routingdata.ViewType,
                _ConstructionParameters);

            if (routingdata.RoutedValues.ContainsKey("TargetInstance"))
            {
                routingdata.RoutedValues["TargetInstance"] = targetelement;
            }
            else
            {
                routingdata.RoutedValues.Add("TargetInstance", targetelement);
            }

            if (targetelement != null)
            {
                if (targetelement is Window)
                {
                    OpenWindowCommand openwindowcmd = new OpenWindowCommand();

                    if (!routingdata.RoutedValues.ContainsKey("IsOwnerHide"))
                        routingdata.RoutedValues.Add("IsOwnerHide", true);

                    openwindowcmd.Execute(parameter);
                }
            }


        }
    }
}
