using System;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class WithLoginUserBaseViewModel : BaseViewModelWithPOCOClass<Users>, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel()
        {

        }

        public WithLoginUserBaseViewModel(Users entity) : base(entity)
        {

        }

        private UserViewModel _LoginedUser = new UserViewModel()
        {
            UserId = Guid.Empty,
            UserName = "root",
            LoweredUserName = "root",
            IsAnonymous = false,
        };
        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get
            {

                return _LoginedUser;
            }
            set
            {

            }
        }
    }
}
