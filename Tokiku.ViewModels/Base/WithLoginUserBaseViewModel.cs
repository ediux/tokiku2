using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public abstract class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel()
        {
           
        }

        public WithLoginUserBaseViewModel(Users entity) 
        {

        }



        #region Logined User
        private IUserViewModel _LoginedUser;

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public IUserViewModel LoginedUser
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
        #endregion

        public ICommand QueryCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand SaveCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand CreateNewCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand DeleteCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand RelayCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Type EntityType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
