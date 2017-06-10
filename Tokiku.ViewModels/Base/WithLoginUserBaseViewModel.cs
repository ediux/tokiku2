using System;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel()
        {
            LoginedUser = new UserViewModel()
            {
                UserId = Guid.Empty,
                UserName = "root",
                LoweredUserName = "root",
                IsAnonymous = false,
            };
        }

        public static readonly DependencyProperty LoginedUserProperty = DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(BaseViewModel), new PropertyMetadata(default(UserViewModel),
            new PropertyChangedCallback(DefaultFieldChanged)));
        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return GetValue(LoginedUserProperty) as UserViewModel; }
            set
            {
                SetValue(LoginedUserProperty, value);
            }
        }
    }
}
