﻿using GalaSoft.MvvmLight.Ioc;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 具有目前登入帳號資訊的檢視模型
    /// </summary>
    public abstract class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        protected ICoreDataService _CoreDataService;

        public WithLoginUserBaseViewModel(ICoreDataService CoreDataService) : base()
        {
            _CoreDataService = CoreDataService;
        }

        private IUserViewModel _LoginedUser;

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public IUserViewModel LoginedUser
        {
            get
            {
                if (_LoginedUser == null)
                {
                    _LoginedUser = _CoreDataService.GetCurrentLoginedUser();
                }

                return _LoginedUser;
            }
            set
            {
                if (_LoginedUser != value)
                {
                    //重新登入
                    _CoreDataService.Logout();
                    ILoginViewModel model = SimpleIoc.Default.GetInstance<ILoginViewModel>();
                    model.UserName = value.UserName;
                    model.Password = value.Password;
                    _CoreDataService.Login(model);
                }
            }
        }
    }
}
