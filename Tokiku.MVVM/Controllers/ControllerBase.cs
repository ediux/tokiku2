using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public abstract class ControllerBase : IViewController
    {
        public void Execute(ControllerContext context, params object[] Paramters)
        {
            Assembly loadableasm = Assembly.Load(context.AssemblyName);
            var ControllerClassName = string.Format("{0}Controller", context.Controller);
            List<Type> findctrtypes = loadableasm.GetTypes().Where(w => w.Name == ControllerClassName && w.Namespace.ToLowerInvariant().EndsWith("controllers")).ToList();
            if (findctrtypes.Any())
            {
                foreach (var type in findctrtypes)
                {
                    var findresult = type.GetMethods().Where(w => w.Name == context.Action);

                    foreach (var methodinfo in findresult)
                    {
                        var ptypes = methodinfo.GetParameters().Select(s => s.GetType()).ToArray();

                    }
                }
            }

        }

        #region Helper Functions


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
            catch
            {
                if (collection == null)
                    collection = Activator.CreateInstance<TCollection>();
                var model = Activator.CreateInstance<TView>();
                List<string> _Message = new List<string>();
                //setErrortoModel(model, ex);
                //ScanErrorMessage(ex, _Message);
                //model.Errors = _Message.AsEnumerable();
                //model.HasError = true;
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
            catch (Exception)
            {
                if (viewmodel == null)
                    viewmodel = Activator.CreateInstance<TView>();
                
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
        protected ActionResult View<TModel>(TModel model) where TModel : IBaseViewModel
        {
            return null;
        }

        protected ActionResult View<TModel>(string ViewName, TModel model) where TModel : IBaseViewModel { return null; }

        protected ActionResult PartialView<TModel>(string ViewName, TModel model) where TModel : IBaseViewModel { return null; }

        protected ActionResult Redirect(string ViewName, string Action, params object[] RouteValues) { return null; }
    }
}