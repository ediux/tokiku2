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
        private ICoreDataService _SystemService;

        [PreferredConstructor]
        public LoginViewModel(IFrameNavigationService navigationService, ICoreDataService systemService)
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
        /// <summary>
        /// 登入系統命令
        /// </summary>
        public RelayCommand LoginCommand { get => _LoginCommand; set { _LoginCommand = value; RaisePropertyChanged("LoginCommand"); } }

        private RelayCommand<Window> _ExitCommand;
        /// <summary>
        /// 登出系統命令
        /// </summary>
        public RelayCommand<Window> ExitCommand { get => _ExitCommand; set { _ExitCommand = value; RaisePropertyChanged("ExitCommand"); } }

        /// <summary>
        /// 處理登入作業
        /// </summary>
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
                RaisePropertyChanged("Errors");
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                RaisePropertyChanged("Errors");
            }
        }

        /// <summary>
        /// 處理登出作業
        /// </summary>
        /// <param name="win">要進行系統登出的視窗執行個體。</param>
        public void Exit(Window win)
        {
            try
            {
                _SystemService.Logout();
                win.Close();
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
