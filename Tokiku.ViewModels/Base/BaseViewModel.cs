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
        protected const string SaveActionName = "CreateOrUpdate";

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
        /// <summary>
        /// 取得對應的控制器名稱。
        /// </summary>
        public virtual string ControllerName { get { if (this == null) return string.Empty; return GetType().Name; } }
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        /// <summary>
        /// 對指定控制器發出單一查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定檢視模型。</returns>
        public static TView QuerySingle<TView, TResult>(string ControllerName, string ActionName, params object[] values)
            where TView : BaseViewModelWithPOCOClass<TResult>
            where TResult : class
        {
            TView viewmodel = null;

            try
            {
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = System.Reflection.Assembly.Load("Tokiku.Controllers").GetType(controllerfullname);

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
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = System.Reflection.Assembly.Load("Tokiku.Controllers").GetType(controllerfullname);

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
        public static TCollection Query<TCollection, TResult>(string ControllerName, string ActionName, params object[] values)
            where TCollection : IMultiBaseViewModel
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

        

        #region 檢視模型初始化作業(建構式會呼叫)
        /// <summary>
        /// 檢視模型初始化作業(建構式會呼叫)
        /// </summary>
        /// <param name="Parameter">命令傳入的參考物件。</param>
        public virtual void Initialized(object Parameter)
        {

        }
        #endregion

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
            catch (Exception)
            {

                throw;
            }

        }
    }
}


