using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 使用者帳號資料存取服務
    /// </summary>
    public interface IUserDataService : IDataService<IUsers>
    {
        #region 使用者帳號存取
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
        #endregion

    }
}