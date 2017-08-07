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
        bool? Logout();
        
    }
}