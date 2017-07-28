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

        private UserViewModel _LoginedUser;

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get
            {
                if (_LoginedUser == null)
                    _LoginedUser = new UserViewModel(CopyofPOCOInstance);

                return _LoginedUser;
            }
            set
            {
                CopyofPOCOInstance = value.Entity;
                _LoginedUser = new UserViewModel(CopyofPOCOInstance);
                RaisePropertyChanged("LoginedUser");
            }
        }
    }
}
