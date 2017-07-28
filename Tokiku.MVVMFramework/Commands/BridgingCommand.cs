using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Tokiku.MVVM.Commands
{
    public class BridgingCommand : ICommand
    {
        public object SourceInstance { get; set; }
        public Type TargetViewType { get; set; }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public BridgingCommand() : this((x) => { })
        {
        }

        public BridgingCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (SourceInstance != null && TargetViewType != null)
            {
                if (parameter is RoutedViewData)
                {
                    RoutedViewData routeddata = (RoutedViewData)parameter;

                    if (routeddata != null)
                    {
                        FrameworkElement elemenu = (FrameworkElement)SourceInstance;

                        if (elemenu != null)
                        {
                            if (routeddata.RoutedValues.ContainsKey("SoutceKey"))
                            {
                                var element = elemenu.TryFindResource((string)routeddata.RoutedValues["SourceKey"]);
                                if (element != null && element is ObjectDataProvider)
                                {
                                    ObjectDataProvider proiver = (ObjectDataProvider)element;
                                    if(proiver.Data!=null && proiver.Data is IBaseViewModel)
                                    {
                                        ((IBaseViewModel)proiver.Data).RelayCommand.Execute(parameter);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            this.execute(parameter);
        }
    }
}
