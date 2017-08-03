using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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

namespace Tokiku.ViewModels
{

    public abstract class BaseViewModel : ViewModelBase, IBaseViewModel
    {
        public BaseViewModel()
        {
            _Errors = new string[] { };
            _HasError = false;
        }

        #region Error
        private IEnumerable<string> _Errors;
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors { get => _Errors; set { _Errors = value; if (_Errors.Any()) { _HasError = true; } } }

        private bool _HasError = false;
        /// <summary>
        /// 指出是否有發生錯誤
        /// </summary>
        public bool HasError { get => _HasError; set => _HasError = value; }
        #endregion

       

        #region Helper Functions
        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(IBaseViewModel model, Exception ex)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            List<string> _Messages = new List<string>();
            ScanErrorMessage(ex, _Messages);

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = _Messages.AsEnumerable();

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected static void setErrortoModel(IBaseViewModel model, string Message)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }

        /// <summary>
        /// 掃描深度錯誤訊息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="messageQueue"></param>
        private static void ScanErrorMessage(Exception ex, List<string> messageQueue)
        {
            if (ex.InnerException != null)
            {
                ScanErrorMessage(ex.InnerException, messageQueue);
            }

            messageQueue.Add(ex.Message);

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
            where TCollection : ICollection<TView>
            where TView : IBaseViewModel
            where TResult : class
        {
            TCollection collection = default(TCollection);

            try
            {
                Type ControllerType;
                object ctrl;

                GetController(ControllerName, out ControllerType, out ctrl);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                var method = ControllerType.GetMethod(ActionName, values.Select(s => s != null ? s.GetType() : typeof(object)).ToArray());

                if (method != null)
                {
                    ExecuteResultEntity<ICollection<TResult>> result =
                        (ExecuteResultEntity<ICollection<TResult>>)method.Invoke(ctrl, values);

                    if (!result.HasError)
                    {
                        collection = (TCollection)Activator.CreateInstance(typeof(TCollection),
                           result.Result.Select(s => (TView)Activator.CreateInstance(typeof(TView), s)).ToList());

                        return collection;
                    }
                    else
                    {
                        collection = Activator.CreateInstance<TCollection>();
                        var model = Activator.CreateInstance<TView>();
                        model.Errors = result.Errors;
                        model.HasError = true;
                        collection.Add(model);
                        return collection;
                    }
                }
                else
                {
                    throw new Exception(string.Format("找不到動作方法 '{0}' !", ActionName));
                }

            }
            catch (Exception ex)
            {
                if (collection == null)
                    collection = Activator.CreateInstance<TCollection>();
                var model = Activator.CreateInstance<TView>();
                List<string> _Message = new List<string>();
                ScanErrorMessage(ex, _Message);
                model.Errors = _Message.AsEnumerable();
                model.HasError = true;
                collection.Add(model);
                return collection;
            }
        }

        protected static void GetController(string ControllerName, out Type ControllerType, out object ctrl)
        {
            if (string.IsNullOrEmpty(ControllerName))
                throw new ArgumentNullException("ControllerName");

            string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

            ControllerType = Assembly.Load("Tokiku.Controllers").GetType(controllerfullname);

            if (ControllerType == null)
            {
                throw new Exception(string.Format("找不到控制器 '{0}' !", ControllerName));
            }

            ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().DeclaringType.GetCustomAttribute<ControllerMappingAttribute>();

            if (attr != null)
            {
                ControllerType = attr.ControllerType;
            }

            var getcontroller = SimpleIoc.Default.GetType().GetMethod("GetInstance", BindingFlags.CreateInstance | BindingFlags.Public);

            if (getcontroller == null)
                throw new NotImplementedException("找不到此控制器的實作類別!請確認控制器物件是否正確註冊?");

            var getinstance = getcontroller.MakeGenericMethod(ControllerType);

            ctrl = getinstance.Invoke(SimpleIoc.Default, new object[] { });
        }

        /// <summary>
        /// 對指定控制器發出單一查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定檢視模型。</returns>
        public static TView QuerySingle<TView, TResult>(string ControllerName, string ActionName, params object[] values)
            where TView : IBaseViewModel
            where TResult : class
        {
            TView viewmodel = default(TView);

            try
            {
                Type ControllerType;
                object ctrl;

                GetController(ControllerName, out ControllerType, out ctrl);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                var method = ControllerType.GetMethod(ActionName);

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
                    throw new Exception(string.Format("找不到動作方法 '{0}' !", ActionName));
                }

            }
            catch (Exception ex)
            {
                if (viewmodel == null)
                    viewmodel = Activator.CreateInstance<TView>();

                setErrortoModel(viewmodel, ex);
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
                Type ControllerType;
                object ctrl;

                GetController(ControllerName, out ControllerType, out ctrl);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                //object[] prarms = 
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
                    throw new Exception(string.Format("找不到動作方法 '{0}' !", ActionName));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}


