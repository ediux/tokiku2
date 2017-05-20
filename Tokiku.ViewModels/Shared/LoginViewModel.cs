using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Tokiku.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get { return (string)GetValue(UserNameProperty); } set { SetValue(UserNameProperty, value); RaisePropertyChanged("UserName"); } }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get { return (string)GetValue(PasswordProperty); } set { SetValue(PasswordProperty, value); RaisePropertyChanged("Password"); } }

        public Entity.Users Login()
        {
            try
            {
                Controllers.Shared.UserController userctrl = new Controllers.Shared.UserController();
                return userctrl.Login(UserName, Password);
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
