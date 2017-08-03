using System;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 具有目前登入帳號資訊的檢視模型
    /// </summary>
    [ControllerMapping(typeof(SystemController))]
    public abstract class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel() : base()
        {

        }

        private UserViewModel _LoginedUser;

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public IUserViewModel LoginedUser
        {
            get
            {
                if (_LoginedUser == null)
                {
                    var loginedUserEntity = ExecuteAction<Users>("System", "GetCurrentLoginUser");
                    _LoginedUser = new UserViewModel(loginedUserEntity);
                }

                return _LoginedUser;
            }
            set
            {
                if (_LoginedUser != value)
                {
                    //重新登入
                    var loginedUserEntity = ExecuteAction<Users>("System", "Relogin", _LoginedUser, value);
                    _LoginedUser = new UserViewModel(loginedUserEntity);
                    RaisePropertyChanged("LoginedUser");
                }
            }
        }
    }
}
