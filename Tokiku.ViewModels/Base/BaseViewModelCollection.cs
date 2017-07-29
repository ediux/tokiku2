using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Tokiku.Entity;
using Tokiku.MVVM.Commands;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelCollection<TView, TEntity> : ObservableCollection<TView>, IMultiBaseViewModel<TView, TEntity> 
        where TView : ISingleBaseViewModel<TEntity> 
        where TEntity : class
    {
        public BaseViewModelCollection()
        {
            _RelayCommand = new DelegateCommand((x) => ReplyFrom(x));
            _SaveCommand = new DelegateCommand((x) => SaveModel(x));
            _CreateNewCommand = new DelegateCommand();
            _QueryCommnand = new DelegateCommand((x) => QueryModel(x));
            _DeleteCommand = new DelegateCommand();

            Initialized();
        }

        public BaseViewModelCollection(IEnumerable<TView> source) : base(source)
        {
            _RelayCommand = new DelegateCommand((x) => ReplyFrom(x));
            _SaveCommand = new DelegateCommand((x) => SaveModel(x));
            _CreateNewCommand = new DelegateCommand();
            _QueryCommnand = new DelegateCommand((x) => QueryModel(x));
            _DeleteCommand = new DelegateCommand();

            Initialized();
        }

        #region WPF命令處理區

        #region 查詢
        private ICommand _QueryCommnand;
        /// <summary>
        /// 取得或設定當引發查詢項目時的命令項目。
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommnand; set => _QueryCommnand = value; }
        /// <summary>
        /// 查詢資料
        /// </summary>
        /// <param name="Parameter">參數物件。</param>
        internal static void QueryModel(object Parameter)
        {

        }
        /// <summary>
        /// 查詢資料
        /// </summary>
        protected virtual void QueryModel()
        {

        }

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
        internal static void SaveModel(object Parameter)
        {

        }
        #endregion

        #region 新建
        protected ICommand _CreateNewCommand = new CreateNewModelCommand();
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

        /// <summary>
        /// 取得主表檢視模型
        /// </summary>
        /// <remarks>
        /// 如果無此關聯性，請永遠回傳NULL。
        /// </remarks>
        public virtual TView Master => default(TView);

        #region 錯誤訊息

        #region 儲存多個錯誤訊息
        private string[] _Errors = new string[] { };
        
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors
        {
            get => _Errors;
            set => _Errors = value.ToArray();            
        }

        #endregion
        private bool _HasError = false;

        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        public bool HasError
        {
            get => _HasError;
            set => _HasError = value;
        }

        // Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(BaseViewModel), new PropertyMetadata(false));
        #endregion

        public virtual string ControllerName => GetType().Name.Replace("ViewModel","");

        public virtual void Initialized()
        {

        }

        public virtual void SaveModel(bool isLast = true)
        {
            throw new NotImplementedException();
        }

        public void SaveModel()
        {
            SaveModel(true);
        }

        public TCollection QueryAll<TCollection>(params object[] parameters) where TCollection : IMultiBaseViewModel<TView, TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
