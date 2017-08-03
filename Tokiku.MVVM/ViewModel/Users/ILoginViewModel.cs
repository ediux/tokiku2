using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface ILoginViewModel : IBaseViewModel
    {
        string Password { get; set; }
       
        string UserName { get; set; }

        RelayCommand LoginCommand { get; set; }

        RelayCommand<Window> ExitCommand { get; set; }

        void Login();
    }
}