using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class BaseViewModelWithPOCOClass<TPOCO> : ISingleBaseViewModel where TPOCO : class
    {
        protected TPOCO CopyofPOCOInstance;

        public BaseViewModelWithPOCOClass()
        {
            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
            EntityType = typeof(TPOCO);
            Initialized();
        }

        public BaseViewModelWithPOCOClass(TPOCO entity)
        {
            Initialized();
            Status.IsNewInstance = false;
            CopyofPOCOInstance = entity;
            EntityType = entity.GetType();
        }

        public virtual void Initialized()
        {
            Status = new DocumentStatusViewModel();
            Status.IsNewInstance = true;
            Status.IsModify = false;
            Status.IsSaved = false;
        }

        protected Type _EntityType;

        public virtual Type EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set { _Errors = value; if (_Errors.Any()) { _HasError = true; } } }

        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }

        private DocumentStatusViewModel _Status;
        public DocumentStatusViewModel Status
        {
            get => _Status;
            set
            {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            Status.IsModify = true;
            Status.IsSaved = false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public Guid Id
        {
            get { return (Guid)_EntityType.GetProperty("Id").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("Id").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("Id"); }
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        protected void BindingFromModel(TPOCO entity)
        {
            try
            {
                if (entity == null)
                    return;

                Type t = entity.GetType();
                Type ct = GetType();

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        if (t.IsGenericType && t.GetGenericTypeDefinition().Name == (typeof(ICollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.IsGenericType && ct.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(BaseViewModelCollection<>).Name))
                        {
                            continue;
                        }

                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {
                            if (prop.PropertyType == ctProp.PropertyType)
                            {
                                var entityvalue = prop.GetValue(entity);
                                var value = ctProp.GetValue(this);
                                ctProp.SetValue(this, entityvalue);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(ISingleBaseViewModel model, Exception ex)
        {
            if (model == null)
                model = (ISingleBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected static void setErrortoModel(ISingleBaseViewModel model, string Message)
        {
            if (model == null)
                model = (ISingleBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
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
            where TView : BaseViewModelWithPOCOClass<TPOCO>
            where TResult : class
        {
            TView viewmodel = null;

            try
            {
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = Type.GetType(controllerfullname);

                if (ControllerType == null)
                {
                    throw new Exception(string.Format("Controller '{0}' not found.", ControllerName));
                }

                var ctrl = Activator.CreateInstance(ControllerType);

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
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
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
        /// 儲存資料檢視模型
        /// </summary>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="isLast">控制旗標(多列更新使用)</param>
        public virtual void SaveModel(string ControllerName, bool isLast = true)
        {
            string ActionName = "CreateOrUpdate";

            try
            {
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = Type.GetType(controllerfullname);

                if (ControllerType == null)
                {
                    throw new Exception(string.Format("Controller '{0}' not found.", ControllerName));
                }

                var ctrl = Activator.CreateInstance(ControllerType);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                var method = ControllerType.GetMethod(ActionName);

                if (method != null)
                {
                    ExecuteResultEntity<TPOCO> result =
                        (ExecuteResultEntity<TPOCO>)method.Invoke(ctrl, new object[] { CopyofPOCOInstance, isLast });

                    if (!result.HasError)
                    {
                        CopyofPOCOInstance = result.Result;
                    }
                    else
                    {
                        
                        Errors = result.Errors;
                        HasError = true;
                        
                    }
                }
                else
                {
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
