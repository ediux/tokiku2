using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty;

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get { return _username; } set { _username = value; RaisePropertyChanged("UserName"); } }

        private string _password = string.Empty;

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get { return _password; } set { _password = value; RaisePropertyChanged("Password"); } }
    }
}
