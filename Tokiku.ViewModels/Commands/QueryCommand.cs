using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class QueryCommand : DelegateCommand, ICommand
    {
        public QueryCommand():this((x)=> { })
        {

        }

        public QueryCommand(Action<object> execute, Func<object, bool> canExecute = null):base(execute,canExecute)
        {
      
        }
    }
}
