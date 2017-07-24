using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class CloseWindwCommand : ICommand
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
            if(SourceInstance is Window)
            {
                ((Window)SourceInstance).Close();
            }
        }
    }
}
