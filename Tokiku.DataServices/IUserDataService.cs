using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    public interface IUserDataService : IDataService<IUsers>,IDataService<Contacts>
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

        #region 聯絡人
        /// <summary>
        /// 搜尋聯絡人用
        /// </summary>
        /// <param name="filiter"></param>
        /// <param name="ManufactoryId"></param>
        /// <param name="isClient"></param>
        /// <returns></returns>
        ICollection<Contacts> SearchByText(string filiter, Guid ManufactoryId, bool isClient);
        #endregion
    }
}