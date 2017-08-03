using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class LoginViewModel : ILoginViewModel
    {
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get; set; }

        public string SaveModelController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Login(object Parameter)
        {
            throw new NotImplementedException();
        }
    }
}
