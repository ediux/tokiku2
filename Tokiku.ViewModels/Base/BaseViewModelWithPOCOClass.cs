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
            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
            CopyofPOCOInstance = entity;
            EntityType = entity.GetType();
            _Mode = DocumentLifeCircle.Read;
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

        #region CreateTime

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)_EntityType.GetProperty("CreateTime").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("CreateTime").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("CreateTime"); }
        }


        #endregion

        #region CreateUserId
        /// <summary>
        /// 建立人員識別碼
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)_EntityType.GetProperty("CreateUserId").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("CreateUserId"); }
        }
        #endregion

        #region CreateUser

        /// <summary>
        /// 建立人員
        /// </summary>
        public Users CreateUser
        {
            get { return (Users)_EntityType.GetProperty("CreateUser").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("CreateUser").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("CreateUser"); }
        }


        #endregion

        /// <summary>
        /// 最後異動時間
        /// </summary>
        public DateTime? LastUpdateDate
        {
            get { return (DateTime?)_EntityType.GetProperty("LastUpdateDate").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("LastUpdateDate").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("LastUpdateDate"); }
        }

        private DocumentLifeCircle _Mode = DocumentLifeCircle.None;
        public DocumentLifeCircle Mode
        {
            get { return _Mode; }
            set { _Mode = value; RaisePropertyChanged("Mode"); }
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
        public virtual void SaveModel(bool isLast = true)
        {
            SaveModel(typeof(TPOCO).Name, isLast);
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
