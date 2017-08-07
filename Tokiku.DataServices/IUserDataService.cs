using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    public interface IUserDataService : IDataService
    {
        /// <summary>
        /// 登入系統。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool? Login(ILoginViewModel model);
        /// <summary>
        /// 登出系統
        /// </summary>
        /// <returns></returns>
        bool? Logout();

        /// <summary>
        /// 取得目前登入的使用者。
        /// </summary>
        /// <returns></returns>
        IUserViewModel GetCurrentLoginedUser();
    }
}