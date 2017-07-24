using System;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class CreateNewModelCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public CreateNewModelCommand():this((x)=> { })
        {

        }

        public CreateNewModelCommand(Action<object> execute,Func<object,bool> canExecute = null)
        {

        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged.Invoke(parameter, new EventArgs());
            }

            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                this.execute(parameter);
                //        if (SelectedProject.Status.IsNewInstance == false)
                //        {
                //            RoutedUICommand command = (RoutedUICommand)TryFindResource("OpenNewTabItem");
                //            RoutedViewResult viewparam = (RoutedViewResult)TryFindResource("OpenNewProjectView");
                //            if (command != null)
                //            {
                //                command.Execute(viewparam, this);
                //            }
                //            //RaiseEvent(new RoutedEventArgs(NewDocumentPageEvent, this));
                //            break;
                //        }

                //        SelectedProject = new ProjectsViewModel();

                //        SelectedProject.Initialized();
                //        SelectedProject.CreateUserId = LoginedUser.UserId;

                //        SelectedProject.Status.IsModify = false;
                //        SelectedProject.Status.IsSaved = false;
                //        SelectedProject.Status.IsNewInstance = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "錯誤", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }

        }
    }
}
