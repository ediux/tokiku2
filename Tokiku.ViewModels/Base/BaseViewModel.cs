using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{

    public abstract class BaseViewModel : DependencyObject, IBaseViewModel
    {
        #region 常數區
        #region 反映存取常數
        /// <summary>
        /// 控制器名稱格式
        /// </summary>
        protected const string ControllerFullNameFormat = "Tokiku.Controllers.{0}Controller";
        /// <summary>
        /// 控制器根命名空間
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

        #region 建構式
        public BaseViewModel()
        {
            Errors = new string[] { };
            HasError = false;
            _ControllerName = GetType().Name.Replace("Controller", string.Empty);
        }
        #endregion

        #region 錯誤訊息

        #region 儲存多個錯誤訊息
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors
        {
            get { return (IEnumerable<string>)GetValue(ErrorProperty); }
            set
            {
                SetValue(ErrorProperty, value); if (value != null) { HasError = true; } else { HasError = false; }
            }
        }

        // Using a DependencyProperty as the backing store for Error.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(IEnumerable<string>), typeof(BaseViewModel),
                new PropertyMetadata(default(Exception)));
        #endregion

        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); RaisePropertyChanged("HasError"); }
        }

        // Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(BaseViewModel), new PropertyMetadata(false));
        #endregion

        #region 對應的控制器名稱
        protected string _ControllerName = string.Empty;
        /// <summary>
        /// 取得對應的控制器名稱。
        /// </summary>
        public virtual string ControllerName { get => _ControllerName; }
        #endregion

        #region PropertyChanged 事件
        /// <summary>
        /// 屬性變更事件。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
            catch
            {

            }

        }
        #endregion

        #region 查詢控制器方法
        /// <summary>
        /// 對指定控制器發出單一查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定檢視模型。</returns>
        public static TView QuerySingle<TView, TResult>(string ControllerName, string ActionName, params object[] values)
            where TView : ISingleBaseViewModel<TResult>
            where TResult : class
        {
            TView viewmodel = default(TView);

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
                        viewmodel = (TView)Activator.CreateInstance(typeof(TView),
                           result.Result);

                        return viewmodel;
                    }
                    else
                    {
                        viewmodel = Activator.CreateInstance<TView>();
                        viewmodel.Errors = result.Errors;
                        viewmodel.HasError = true;
                        return viewmodel;
                    }
                }
                else
                {
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                if (viewmodel == null)
                    viewmodel = Activator.CreateInstance<TView>();
                Tools.setErrortoModel(viewmodel, ex);
                return viewmodel;
            }
        }

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
        public static TCollection Query<TCollection, TView, TResult>(string ControllerName, string ActionName, params object[] values)
            where TCollection : IMultiBaseViewModel<TView, TResult>
            where TView : ISingleBaseViewModel<TResult>
            where TResult : class
        {
            TCollection collection = default(TCollection);

            try
            {
                return (TCollection)Activator.CreateInstance(typeof(TCollection), ExecuteAction<TResult>(ControllerName, ActionName, values));
            }
            catch (Exception ex)
            {
                if (collection == null)
                    collection = Activator.CreateInstance<TCollection>();

                collection.setErrortoModel(ex);
                return collection;
            }
        }
        /// <summary>
        /// 對指定控制器發出查詢呼叫。
        /// </summary>
        /// <typeparam name="TView">單一元素資料檢視模型</typeparam>
        /// <typeparam name="TPOCO">對應的資料庫實體型別</typeparam>
        /// <param name="parameters">要傳遞到控制器的參數</param>
        /// <returns>傳回指定檢視模型。</returns>
        public virtual TView Query<TView, TPOCO>(params object[] parameters) where TView : IBaseViewModel where TPOCO : class
        {
            try
            {
                return (TView)Activator.CreateInstance(typeof(TView), ExecuteAction<TPOCO>(ControllerName, QuerySingleRowActionName, parameters));
            }
            catch (Exception ex)
            {
                TView coll = Activator.CreateInstance<TView>();
                coll.setErrortoModel(ex);
                return coll;
            }
        }
        #endregion
        
        #region 檢視模型初始化作業(建構式會呼叫)
        /// <summary>
        /// 檢視模型初始化作業(建構式會呼叫)
        /// </summary>
        public virtual void Initialized()
        {

        }
        public virtual void Initialized(object Parameter)
        {

        }
        /// <summary>
        /// 檢視模型初始化作業(WPF命令會呼叫)
        /// </summary>
        /// <param name="Parameter">命令傳入的參考物件。</param>
        public static void CreateNew(object Parameter)
        {

        }
        #endregion

        #region 儲存檢視模型方法
        /// <summary>
        /// 儲存檢視模型的方法。
        /// </summary>
        public virtual void SaveModel()
        {
            SaveModel(true);
        }

        /// <summary>
        /// 對資料庫發出變更的處理方法。
        /// </summary>
        /// <param name="isLast">指出是否為最後一筆資料!</param>
        public virtual void SaveModel(bool isLast = true)
        {
            try
            {

                var callActionInstance = GetType().GetMethod("ExecuteAction", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public);
                var prop = GetType().GetProperty("EntityType");
                var prop2 = GetType().GetProperty("Entity");

                if (prop != null && prop2 != null)
                {
                    var callAction = callActionInstance.MakeGenericMethod((Type)prop.GetValue(this));
                    callAction.Invoke(this, new object[] { ControllerName, SaveActionName, prop2.GetValue(this), isLast });
                }

            }
            catch (Exception ex)
            {
                this.setErrortoModel(ex);
            }

        }


        #endregion

    }
}


