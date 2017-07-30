using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Controllers
{
    public class LoginViewModel
    {
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string Password { get; set; }
    }
}
