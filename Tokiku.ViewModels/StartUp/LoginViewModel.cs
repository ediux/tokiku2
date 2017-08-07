using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tokiku.DataServices;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 登入畫面檢視模型
    /// </summary>
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private IFrameNavigationService _naviService;
        private IUserDataService _SystemService;

        [PreferredConstructor]
        public LoginViewModel(IFrameNavigationService navigationService, IUserDataService systemService)
        {
            _naviService = navigationService;
            _SystemService = systemService;

            _LoginCommand = new RelayCommand(Login);
            _ExitCommand = new RelayCommand<Window>(Exit);
            //_controller = controller;
        }

        private string _UserName = string.Empty;
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get => _UserName; set { _UserName = value; RaisePropertyChanged("UserName"); } }

        private string _Password = string.Empty;
        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password
        {
            get => _Password;

            set { _Password = value; RaisePropertyChanged("Password"); }
        }

        private RelayCommand _LoginCommand;
        public RelayCommand LoginCommand { get => _LoginCommand; set { _LoginCommand = value; RaisePropertyChanged("LoginCommand"); } }
        private RelayCommand<Window> _ExitCommand;
        public RelayCommand<Window> ExitCommand { get => _ExitCommand; set { _ExitCommand = value; RaisePropertyChanged("ExitCommand"); } }

        public void Login()
        {
            try
            {
                Errors = new string[] { };
                HasError = false;
                    
                if (_SystemService != null)
                {
                    var loginresult = _SystemService.Login(this);

                    if (loginresult.HasValue && loginresult.Value)
                    {
                        _naviService?.NavigateTo("MainWindow");
                        return;
                    }
                }

                Errors = _SystemService.Errors;
                HasError = true;
                    
                //var reult = ExecuteAction<Users>("StartUpWindow", "Login", (ILoginViewModel)this);

                //if (reult != null)
                //{

                //    //RelayCommand<ILoginViewModel> Login = (LoginCommand)RelayCommand;
                //    //RedirectCommand Redirect = new RedirectCommand();
                //    ////Redirect.SourceInstance = Login.SourceInstance;
                //    //Redirect.Execute(Parameter);
                //    //((Window)Redirect.SourceInstance).Close();
                //}
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                RaisePropertyChanged("Errors");
            }
        }

        public void Exit(Window win)
        {
            _SystemService.Logout();
            win.Close();
        }
    }
}
