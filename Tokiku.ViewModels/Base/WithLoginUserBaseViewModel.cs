using System;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel()
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
