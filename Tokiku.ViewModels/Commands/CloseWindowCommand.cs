using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class CloseWindowCommand : ICommand
    {
        public object SourceInstance
        {
            get;
            set;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RoutedViewResult executeresult = (parameter is RoutedViewResult) ? (RoutedViewResult)parameter : null;

            if (executeresult.SourceInstance is Window)
            {
                ((Window)executeresult.SourceInstance).Close();
            }
        }
    }
}
