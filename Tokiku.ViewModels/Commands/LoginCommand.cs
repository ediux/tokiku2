using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class LoginCommand : RelayCommand
    {
        public object SourceInstance
        {
            get;
            set;
        }

        private Action<object> execute;

        public LoginCommand() : this((x) => { })
        {
        }

        public LoginCommand(Action<object> execute) : base(execute)
        {
            this.execute = execute;
        }

        public LoginCommand(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {
        }



    }
}
