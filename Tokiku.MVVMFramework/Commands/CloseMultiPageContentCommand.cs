using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Tokiku.MVVM.Commands
{
    public class CloseMultiPageContentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {

                if(parameter is Button)
                {
 try
                    {
                        RoutedEventArgs eu = new RoutedEventArgs(ButtonBase.ClickEvent, ((Button)parameter));
                        ((Button)parameter).RaiseEvent(eu);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FrameworkElement FindTableControl(FrameworkElement element)
        {

            if (element == null)
                return null;

            if (element is TabControl)
                return element;

            if (element.Parent != null)
                return FindTableControl((FrameworkElement)element.Parent);
            else
                return null;
        }

        private FrameworkElement FindTableItem(FrameworkElement element)
        {

            if (element == null)
                return null;

            if (element is TabItem)
                return element;

            if (element.Parent != null)
                return FindTableItem((FrameworkElement)element.Parent);
            else
                return null;
        }
    }


}
