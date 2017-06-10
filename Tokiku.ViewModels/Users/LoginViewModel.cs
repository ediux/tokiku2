using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class LoginViewModel : BaseViewModel, IBaseViewModel
    {
        private StartUpWindowController _controller = null;

        public LoginViewModel(StartUpWindowController controller)
        {
            _controller = controller;
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get { return (string)GetValue(UserNameProperty); } set { SetValue(UserNameProperty, value); } }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get { return (string)GetValue(PasswordProperty); } set { SetValue(PasswordProperty, value); RaisePropertyChanged("Password"); } }

        public UserViewModel Login()
        {
            var reult = _controller.Login(UserName, Password);

            if (!reult.HasError)
            {
                UserViewModel model = new UserViewModel();
                BindingFromModel(reult.Result, model);
                return model;
            }
            else
            {
                return new UserViewModel()
                {
                    Errors = reult.Errors,
                    HasError = reult.HasError
                };
            }

        }
    }
}
