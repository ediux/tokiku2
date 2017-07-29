using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Tokiku.Entity;
using Tokiku.MVVM.Commands;

namespace Tokiku.ViewModels
{
    public abstract class WithLoginUserBaseViewModel : BaseViewModel, IBaseViewModelWithLoginedUser
    {
        public WithLoginUserBaseViewModel()
        {
            SaveCommand = new SaveModelCommand(new Action<object>(SaveModel));
            CreateNewCommand = new CreateNewModelCommand(new Action<object>(Initialized));
            RelayCommand = new RelayCommand(new Action<object>(ReplyFrom));
        }

        #region 目前文件操作模式
        private DocumentLifeCircle _Mode = DocumentLifeCircle.None;

        /// <summary>
        /// 目前文件操作模式
        /// </summary>
        public DocumentLifeCircle Mode
        {
            get { return _Mode; }
            set { _Mode = value; RaisePropertyChanged("Mode"); }
        }
        #endregion

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
                {
                    var UserEntity = ExecuteAction<Users>(SystemControllerName, GetLoginedUserActionName);
                    _LoginedUser = new UserViewModel(UserEntity);
                }

                return _LoginedUser;
            }
            set
            {
                _LoginedUser = value;
                RaisePropertyChanged("LoginedUser");
            }
        }
        #endregion

        #region WPF命令處理區

        #region 查詢
        private ICommand _QueryCommnand;
        /// <summary>
        /// 取得或設定當引發查詢項目時的命令項目。
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommnand; set => _QueryCommnand = value; }

        #endregion

        #region 儲存
        protected ICommand _SaveCommand = new SaveModelCommand();
        /// <summary>
        /// 取得或設定當引發儲存時的命令項目。
        /// </summary>
        public ICommand SaveCommand { get => _SaveCommand; set => _SaveCommand = value; }

        /// <summary>
        /// 處理儲存命令時使用的處理方法
        /// </summary>
        /// <param name="Parameter"></param>
        internal virtual void SaveModel(object Parameter)
        {

        }
        #endregion

        #region 新建
        protected ICommand _CreateNewCommand;
        /// <summary>
        /// 取得或設定當引發新建項目時的命令項目。
        /// </summary>
        public ICommand CreateNewCommand { get => _CreateNewCommand; set => _CreateNewCommand = value; }
        #endregion

        #region 刪除
        private ICommand _DeleteCommand;
        /// <summary>
        /// 取得或設定當引發刪除項目時的命令項目。
        /// </summary>
        public ICommand DeleteCommand { get => _DeleteCommand; set => _DeleteCommand = value; }
        #endregion

        #region 轉送
        private ICommand _RelayCommand;

        /// <summary>
        /// 取得或設定當引發來自其他項目時的命令項目。
        /// </summary>
        public ICommand RelayCommand { get => _RelayCommand; set { _RelayCommand = value; } }

        /// <summary>
        /// 處理接收轉送來源的物件。
        /// </summary>
        /// <param name="source">轉送來源。</param>
        public virtual void ReplyFrom(object source)
        {
        }

        #endregion

        #endregion

    }
}
