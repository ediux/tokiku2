using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class OpenWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RoutedViewResult routedvalues = null;

            if (parameter is RoutedViewResult)
                routedvalues = (RoutedViewResult)parameter;
            else
                return;

            if (routedvalues == null)
                return;

            if (routedvalues.RoutedValues["TargetInstance"] is Window)
            {
                if (routedvalues.ViewType.BaseType == typeof(Window))
                {
                    if (routedvalues.RoutedValues.ContainsKey("IsOwnerHide"))
                    {
                        if ((bool)routedvalues.RoutedValues["IsOwnerHide"])
                        {
                            ((Window)routedvalues.SourceInstance).Hide();
                        }

                    }

                    Window _win = (Window)routedvalues.RoutedValues["TargetInstance"];

                    if (routedvalues.RoutedValues.ContainsKey("IsDialog"))
                    {
                        if ((bool)routedvalues.RoutedValues["IsDialog"])
                        {
                            _win.ShowDialog();

                            if (routedvalues.RoutedValues.ContainsKey("IsOwnerHide"))
                            {
                                if ((bool)routedvalues.RoutedValues["IsOwnerHide"])
                                {
                                    CloseWindowCommand closecmd = new CloseWindowCommand();
                                    closecmd.Execute(parameter);
                                    return;
                                }

                            }
                        }
                        else
                        {
                            _win.Show();
                        }
                    }
                    else
                    {
                        _win.Show();
                    }



                    
                }

            }
        }
    }
}
