using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TokikuNew.Controls;

namespace TokikuNew
{
    public class OpenNewPageContentCommand : ICommand
    {
      
        public OpenNewPageContentCommand()
        {
          
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
               
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          
        }
    }
}
