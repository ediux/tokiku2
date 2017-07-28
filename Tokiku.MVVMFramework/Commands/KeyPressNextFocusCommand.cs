using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tokiku.MVVM.Commands
{
    public class KeyPressNextFocusCommand : ICommand
    {
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
            try
            {
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}