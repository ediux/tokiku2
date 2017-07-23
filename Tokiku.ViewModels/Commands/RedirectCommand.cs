using System;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class RedirectCommand : ICommand
    {
        public object SourceInstance { get; set; }

        public RedirectCommand()
        {

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
            CommandRoutingManager.Redirect((UIElement)SourceInstance);
        }
    }
}
