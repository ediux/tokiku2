using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class BaseViewModelWithPOCOClass<TPOCO> : ISingleBaseViewModel where TPOCO : class
    {
        protected TPOCO CopyofPOCOInstance;

        public TPOCO Entity
        {
            get => CopyofPOCOInstance;
        }

        public BaseViewModelWithPOCOClass()
        {
            SaveCommand = new SaveModelCommand(new Action<object>(SaveModel));
            CreateNewCommand = new CreateNewModelCommand(new Action<object>(Initialized));
            RelayCommand = new RelayCommand(new Action<object>(ReplyFrom));
            Status = new DocumentStatusViewModel();
            EntityType = typeof(TPOCO);
            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();

        }

        public BaseViewModelWithPOCOClass(TPOCO entity)
        {
            SaveCommand = new SaveModelCommand(new Action<object>(SaveModel));
            CreateNewCommand = new CreateNewModelCommand(new Action<object>(Initialized));
            RelayCommand = new RelayCommand(new Action<object>(ReplyFrom));
            Status = new DocumentStatusViewModel();
            if (entity != null)
            {
                EntityType = entity.GetType();
                CopyofPOCOInstance = entity;
            }
            else
            {
                EntityType = typeof(TPOCO);
                CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
                Initialized(null);
            }

            _Mode = DocumentLifeCircle.Read;
            Status.IsNewInstance = false;
        }


        /// <summary>
        /// 處理接收轉送來源的物件。
        /// </summary>
        /// <param name="source">轉送來源。</param>
        public virtual void ReplyFrom(object source)
        {

        }

        /// <summary>
        /// 檢視模型初始化
        /// </summary>
        public virtual void Initialized(object Parameter)
        {

            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
                _EntityType.GetProperty("Id").SetValue(CopyofPOCOInstance, Id);
            }

            Status.IsNewInstance = true;
            Status.IsModify = false;
            Status.IsSaved = false;
        }

        #region 資料實體反映
        protected Type _EntityType;

        /// <summary>
        /// 資料實體反映
        /// </summary>
        public virtual Type EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }
        #endregion

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

        #region Status
        private DocumentStatusViewModel _Status;
        /// <summary>
        /// 文件狀態
        /// </summary>
        public DocumentStatusViewModel Status
        {
            get => _Status;
            set
            {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }
        #endregion

        /// <summary>
        /// 屬性變更通知事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            if (Status != null)
            {
                Status.IsModify = true;
                Status.IsSaved = false;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #region ID
        /// <summary>
        /// 資料識別碼
        /// </summary>
        public Guid Id
        {
            get
            {
                try
                {
                    Guid _Id = (Guid)_EntityType.GetProperty("Id").GetValue(CopyofPOCOInstance);
                  
                    return _Id;
                }
                catch
                {
                    return Guid.Empty;
                }

            }
            set
            {
                try
                {
                    _EntityType.GetProperty("Id").SetValue(CopyofPOCOInstance, value);
                    RaisePropertyChanged("Id");
                }
                catch
                {

                }

            }
        }
        #endregion

        #region CreateTime

        /// <summary>
        /// 建立時間
        /// </summary>
        public virtual DateTime CreateTime
        {
            get
            {
                try
                {
                    DateTime _CreateTime = (DateTime)_EntityType.GetProperty("CreateTime").GetValue(CopyofPOCOInstance);

                    if (_CreateTime == default(DateTime))
                    {
                        _CreateTime = DateTime.Now;

                        _EntityType.GetProperty("CreateTime").SetValue(CopyofPOCOInstance, _CreateTime);
                    }

                    if (_CreateTime.Year < 1900)
                    {
                        _CreateTime = DateTime.Now;
                        _EntityType.GetProperty("CreateTime").SetValue(CopyofPOCOInstance, _CreateTime);
                    }

                    return _CreateTime;
                }
                catch
                {
                    return DateTime.Now;
                }

            }
            set
            {
                try
                {
                    _EntityType.GetProperty("CreateTime").SetValue(CopyofPOCOInstance, value);
                    RaisePropertyChanged("CreateTime");
                }
                catch
                {

                }
            }
        }

        #endregion

        #region CreateUserId
        private Users _LoginUser;
        /// <summary>
        /// 建立人員識別碼
        /// </summary>
        public virtual Guid CreateUserId
        {
            get
            {
                try
                {
                    var UserId = (Guid)_EntityType.GetProperty("CreateUserId").GetValue(CopyofPOCOInstance);

                    if (UserId == Guid.Empty)
                    {
                        if (_LoginUser == null)
                            _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");

                        if (_LoginUser != null)
                            UserId = _LoginUser.UserId;
                        else
                            UserId = Guid.Empty;

                    }

                    return UserId;
                }
                catch
                {
                    return Guid.Empty;
                }

            }
            set
            {
                try
                {
                    _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, value);
                    RaisePropertyChanged("CreateUserId");
                }
                catch
                {
                }
            }
        }
        #endregion

        #region CreateUser

        /// <summary>
        /// 建立人員
        /// </summary>
        public virtual Users CreateUser
        {
            get
            {
                try
                {
                    if (_LoginUser == null)
                        _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");

                    return _LoginUser;
                }
                catch
                {
                    return null;
                }

            }
            set
            {
                try
                {
                    _EntityType.GetProperty("CreateUser").SetValue(CopyofPOCOInstance, value);
                    RaisePropertyChanged("CreateUser");
                }
                catch
                {

                }
            }
        }


        #endregion

        #region 最後異動時間
        /// <summary>
        /// 最後異動時間
        /// </summary>
        public DateTime? LastUpdateDate
        {
            get
            {
                try
                {
                    return (DateTime?)_EntityType.GetProperty("LastUpdateDate").GetValue(CopyofPOCOInstance);
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                _EntityType.GetProperty("LastUpdateDate").SetValue(CopyofPOCOInstance, value);
                RaisePropertyChanged("LastUpdateDate");
            }
        }
        #endregion

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

        #region 儲存模型所對應的控制器
        protected string _SaveModelController = string.Empty;
        /// <summary>
        /// 儲存模型所對應的控制器
        /// </summary>
        public virtual string SaveModelController
        {
            get { return _SaveModelController ?? (_EntityType?.Name ?? string.Empty); }
            set { _SaveModelController = value; }
        }
        #endregion

        #region 模型 WPF MVVM命令
        protected ICommand _SaveCommand = new SaveModelCommand();
        /// <summary>
        /// 取得或設定當引發儲存時的命令項目。
        /// </summary>
        public ICommand SaveCommand { get => _SaveCommand; set => _SaveCommand = value; }
        protected ICommand _CreateNewCommand = new CreateNewModelCommand();
        /// <summary>
        /// 取得或設定當引發新建項目時的命令項目。
        /// </summary>
        public ICommand CreateNewCommand { get => _CreateNewCommand; set => _CreateNewCommand = value; }
        private ICommand _ReplyCommand;
        /// <summary>
        /// 取得或設定當引發來自其他項目時的命令項目。
        /// </summary>
        public ICommand RelayCommand { get => _ReplyCommand; set { _ReplyCommand = value; RaisePropertyChanged("ReplyCommand"); } }
        private ICommand _DeleteCommand;
        /// <summary>
        /// 取得或設定當引發刪除項目時的命令項目。
        /// </summary>
        public ICommand DeleteCommand { get => _DeleteCommand; set => _DeleteCommand = value; }
        private ICommand _QueryCommnand;
        /// <summary>
        /// 取得或設定當引發查詢項目時的命令項目。
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommnand; set => _QueryCommnand = value; }

        #endregion

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
                    method = ControllerType.GetMethod(ActionName, new Type[] { typeof(object[]) });

                    if(method != null)
                    {
                        ExecuteResultEntity<TResult> result =
                      (ExecuteResultEntity<TResult>)method.Invoke(ctrl, new object[] { values });

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
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                throw ex;
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

        private IBaseController<TPOCO> session_controller;

        private const string ActionName = "CreateOrUpdate";
        /// <summary>
        /// 儲存資料檢視模型
        /// </summary>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="isLast">控制旗標(多列更新使用)</param>
        public virtual void SaveModel(string ControllerName, bool isLast = true)
        {

            try
            {
                ExecuteAction<TPOCO>(ControllerName, ActionName, CopyofPOCOInstance, isLast);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        /// <summary>
        /// 儲存資料檢視模型
        /// </summary>
        /// <param name="ControllerName">控制器名稱</param>
        public virtual void SaveModel(object ControllerName)
        {
            _SaveModelController = ControllerName?.ToString() ?? _EntityType.Name;

            SaveModel(_SaveModelController, true);
        }

        /// <summary>
        /// 儲存資料檢視模型
        /// </summary>
        public void SaveModel()
        {
            SaveModel(SaveModelController);
        }

        //#region 查詢單一個體的檢視資料
        ///// <summary>
        ///// 查詢單一個體的檢視資料
        ///// </summary>
        ///// <param name="ManufacturersId"></param>
        //public TView Query<TView>(params object[] Parameters) where TView : BaseViewModelWithPOCOClass<TPOCO>
        //{
        //    try
        //    {
        //        TView viewmodel = Activator.CreateInstance<TView>();

        //        viewmodel=  QuerySingle<TView, TPOCO>(
        //            viewmodel.SaveModelController, "QuerySingle", Parameters);

        //        return viewmodel;
        //    }
        //    catch (Exception ex)
        //    {
        //        TView view = Activator.CreateInstance<TView>();
        //        setErrortoModel(view, ex);
        //        return view;
        //    }

        //}
        //#endregion
    }
}
