using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 登入畫面檢視模型介面
    /// </summary>
    public interface ILoginViewModel : IBaseViewModel
    {
        string Password { get; set; }

        string UserName { get; set; }

        RelayCommand LoginCommand { get; set; }

        RelayCommand<Window> ExitCommand { get; set; }

        void Login();
    }
}