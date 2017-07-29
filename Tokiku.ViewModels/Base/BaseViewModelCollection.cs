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

        #region 常數區
        #region 反映存取常數
        /// <summary>
        /// 控制器名稱格式
        /// </summary>
        protected const string ControllerFullNameFormat = "Tokiku.Controllers.{0}Controller";
        /// <summary>
        /// 控制器命名空間
        /// </summary>
        protected const string ControllerRootNamespace = "Tokiku.Controllers";
        #endregion

        #region 控制器
        /// <summary>
        /// 系統共用控制器
        /// </summary>
        public const string SystemControllerName = "System";
        /// <summary>
        /// 廠商/客戶管理控制器
        /// </summary>
        public const string ManufacturersManageControllerName = "ManufacturersManage";
        /// <summary>
        /// 聯絡人控制器
        /// </summary>
        public const string ContactPersonManageControllerName = "ContactPersonManage";
        #endregion

        #region 動作方法
        /// <summary>
        /// 查詢(全部)動作
        /// </summary>
        public const string QueryActionName = "Query";
        /// <summary>
        /// 查詢(有條件的)動作
        /// </summary>
        public const string QueryByActionName = "QueryBy";
        /// <summary>
        /// 查詢指定單一資料列動作
        /// </summary>
        public const string QuerySingleRowActionName = "QuerySingle";
        /// <summary>
        /// 加入資料庫動作
        /// </summary>
        public const string AddActionName = "Add";
        /// <summary>
        /// 發動資料庫更新動作
        /// </summary>
        public const string UpdateActionName = "Update";
        /// <summary>
        /// 發動刪除資料列動作
        /// </summary>
        public const string DeleteActionName = "Delete";
        /// <summary>
        /// 儲存動作
        /// </summary>
        public const string SaveActionName = "CreateOrUpdate";
        /// <summary>
        /// 取得登入帳號動作
        /// </summary>
        public const string GetLoginedUserActionName = "GetCurrentLoginUser";
        /// <summary>
        /// 查詢存取紀錄動作
        /// </summary>
        public const string QueryAccessLogActionName = "QueryAccessLog";
        #endregion

        #endregion

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

        #region 查詢控制器方法
        /// <summary>
        /// 對指定控制器發出單一查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定單一資料實體。</returns>
        public static TResult ExecuteAction<TResult>(string ControllerName, string ActionName, params object[] values)
            where TResult : class
        {
            TResult viewmodel = null;

            try
            {
                string controllerfullname = string.Format(ControllerFullNameFormat, ControllerName);

                Type ControllerType = Assembly.Load(ControllerRootNamespace).GetType(controllerfullname);

                if (ControllerType == null)
                {
                    throw new Exception(string.Format("Controller '{0}' not found.", ControllerName));
                }

                var ctrl = Activator.CreateInstance(ControllerType);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }


                var method = ControllerType.GetMethod(ActionName, values.Select(s => s != null ? s.GetType() : typeof(object)).ToArray());

                if (method != null)
                {
                    ExecuteResultEntity<TResult> result =
                        (ExecuteResultEntity<TResult>)method.Invoke(ctrl, values);

                    if (!result.HasError)
                    {

                        viewmodel = result?.Result;
                        return viewmodel;
                    }
                    else
                    {
                        throw new Exception(string.Join(",", result.Errors));
                    }
                }
                else
                {
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 對指定控制器發出查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定檢視模型集合。</returns>
        public static TCollection Query<TCollection>(string ControllerName, string ActionName, params object[] values)
            where TCollection : IMultiBaseViewModel<TView, TEntity>
        {
            TCollection collection = default(TCollection);

            try
            {
                return (TCollection)Activator.CreateInstance(typeof(TCollection), ExecuteAction<TEntity>(ControllerName, ActionName, values));
            }
            catch (Exception ex)
            {
                if (collection == null)
                    collection = Activator.CreateInstance<TCollection>();

                collection.setErrortoModel(ex);
                return collection;
            }
        }
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

        /// <summary>
        /// 覆寫當集合修改時候對應呼叫指定控制器動作方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                //當加入新元素時
                case NotifyCollectionChangedAction.Replace:
                    
                    break;
                case NotifyCollectionChangedAction.Reset:
                    //Reload
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Count > 0)
                    {
                        var callActionInstance = GetType().GetMethod("ExecuteAction", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public);
                        var callAction = callActionInstance.MakeGenericMethod(e.OldItems.GetType());

                        for (int i = 0; i < e.OldItems.Count; i++)
                        {

                            e.OldItems[i].GetType();
                            //callAction.Invoke(this, new object[] { ControllerName, "Delete", ((TView)e.OldItems[i]).Entity, false });
                            ExecuteAction<TEntity>(ControllerName, DeleteActionName, ((TView)e.OldItems[i]).Entity, false);
                        }
                    }
                    break;
            }
        }


        public virtual string ControllerName => GetType().Name.Replace("ViewModelCollection", "");

        public virtual void Initialized(object Parameter)
        {
            
        }

        public virtual void Initialized()
        {
            Initialized(null);
        }

        public virtual void SaveModel(bool isLast = true)
        {

        }

        public void SaveModel()
        {

        }

        public TCollection QueryAll<TCollection>(params object[] parameters) where TCollection : IMultiBaseViewModel<TView, TEntity>
        {
            return default(TCollection);
        }
    }
}
