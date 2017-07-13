﻿using System;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class WithLoginUserBaseViewModel : BaseViewModelWithPOCOClass<Users>, IBaseViewModelWithLoginedUser
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

        private UserViewModel _LoginedUser;
        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get {
                
                return _LoginedUser; }
            set
            {
               
            }
        }
    }
}
