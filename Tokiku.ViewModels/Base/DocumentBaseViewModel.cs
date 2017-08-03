using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Tokiku.Entity;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq.Expressions;
using System.Reflection;

namespace Tokiku.ViewModels
{
    public class DocumentBaseViewModel<TPOCO> : WithLoginUserBaseViewModel, IDocumentBaseViewModel<TPOCO>
        where TPOCO : class
    {
        #region 主要檢視模型資料實體
        protected TPOCO CopyofPOCOInstance;

        /// <summary>
        /// 主要資料實體來源物件。
        /// </summary>
        public TPOCO Entity
        {
            get => CopyofPOCOInstance;
        }
        #endregion

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

        #region 文件狀態
        private IDocumentStatusViewModel _Status;
        /// <summary>
        /// 文件狀態
        /// </summary>
        public IDocumentStatusViewModel Status { get => _Status; set => _Status = value; }
        #endregion

        #region 文件操作模式
        private DocumentLifeCircle _Mode;

        /// <summary>
        /// 文件操作模式
        /// </summary>
        public DocumentLifeCircle Mode { get => _Mode; set => _Mode = value; }
        #endregion

        #region 模型 WPF MVVM命令
        protected ICommand _SaveCommand = null;

        /// <summary>
        /// 取得或設定當引發儲存時的命令項目。
        /// </summary>
        public ICommand SaveCommand { get => _SaveCommand; set => _SaveCommand = value; }


        protected ICommand _CreateNewCommand = null;
        /// <summary>
        /// 取得或設定當引發新建項目時的命令項目。
        /// </summary>
        public ICommand CreateNewCommand { get => _CreateNewCommand; set => _CreateNewCommand = value; }

        private ICommand _ReplyCommand;
        /// <summary>
        /// 取得或設定當引發來自其他項目時的命令項目。
        /// </summary>
        public ICommand RelayCommand { get => _ReplyCommand; set { _ReplyCommand = value; } }

        private ICommand _DeleteCommand;
        /// <summary>
        /// 取得或設定當引發刪除項目時的命令項目。
        /// </summary>
        public ICommand DeleteCommand { get => _DeleteCommand; set => _DeleteCommand = value; }

        private ICommand _QueryCommnand = null;
        /// <summary>
        /// 取得或設定當引發查詢項目時的命令項目。
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommnand; set => _QueryCommnand = value; }

        #endregion

        #region 異動紀錄
        private ObservableCollection<IAccessLogViewModel> _AccessLogs;
        /// <summary>
        /// 異動紀錄
        /// </summary>
        public ObservableCollection<IAccessLogViewModel> AccessLogs => _AccessLogs;
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

                        _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, UserId);
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
        public virtual IUserViewModel CreateUser
        {
            get
            {
                try
                {
                    var _CreateUser = (Users)_EntityType.GetProperty("CreateUser").GetValue(CopyofPOCOInstance);

                    if (_CreateUser == null)
                    {
                        if (_LoginUser == null)
                            _CreateUser = _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");
                        else
                            _CreateUser = _LoginUser;

                        _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, _CreateUser.UserId);
                    }

                    return new UserViewModel(_CreateUser);
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
                    _EntityType.GetProperty("CreateUser")?.SetValue(CopyofPOCOInstance, value);
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
                    var _lastupdateUseridprop = AccessLogs.OrderByDescending(o => o.AccessTime).FirstOrDefault();

                    if (_lastupdateUseridprop != null)
                        return _lastupdateUseridprop.AccessTime;

                    var log = ExecuteAction<AccessLog>("AccessLog", "QueryLastUpdateLog", Id.ToString());

                    if (log != null)
                    {
                        return log.CreateTime;
                    }

                    return CreateTime;
                }
                catch
                {
                    return null;
                }
            }

        }
        #endregion

        #region 最後異動人員
        /// <summary>
        /// 最後異動人員ID
        /// </summary>
        public virtual Guid? LastUpdateUserId
        {
            get
            {
                var _lastupdateUseridprop = _EntityType.GetProperty("LastUpdateUserId");

                if (_lastupdateUseridprop != null)
                    return (Guid?)_lastupdateUseridprop.GetValue(CopyofPOCOInstance);

                var log = ExecuteAction<AccessLog>("AccessLog", "QueryLastUpdateLog", Id.ToString());

                if (log != null)
                {
                    return log.UserId;
                }

                return Guid.Empty;
            }

        }

        /// <summary>
        /// 最後異動人員
        /// </summary>
        public IUserViewModel LastUpadateUser
        {
            get
            {
                try
                {
                    var _lastupdateUseridprop = _EntityType.GetProperty("LastUpdateUser");

                    if (_lastupdateUseridprop != null)
                        return new UserViewModel((Users)_lastupdateUseridprop.GetValue(CopyofPOCOInstance));

                    var log = ExecuteAction<AccessLog>("AccessLog", "QueryLastUpdateLog", Id.ToString());

                    if (log != null)
                    {
                        var lastupdateuser = ExecuteAction<Users>("System", "GetUserById", log.UserId);
                        return new UserViewModel(lastupdateuser);
                    }

                    return null;
                }
                catch
                {
                    return null;
                }

            }

        }

        #endregion

        #region 查詢條件式(ORM)
        Expression<Func<TPOCO, bool>> _Filiter = default(Expression<Func<TPOCO, bool>>);
        /// <summary>
        /// 取得或設定查詢條件式
        /// </summary>
        public Expression<Func<TPOCO, bool>> Filiter { get => _Filiter; set => _Filiter = value; }
        #endregion

        public DocumentBaseViewModel()
        {
            _SaveCommand = new RelayCommand(Save);
            _QueryCommnand = new RelayCommand(Load);
            _DeleteCommand = new RelayCommand(Delete);
            _CreateNewCommand = new RelayCommand(CreateNew);
            _ReplyCommand = new RelayCommand<object>(Relay);

            EntityType = typeof(TPOCO);

            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();

            var prop = _EntityType.GetProperty("CreateUserId");

            if (prop != null)
            {
                var UserId = (Guid)prop.GetValue(CopyofPOCOInstance);

                if (UserId == Guid.Empty)
                {
                    if (_LoginUser == null)
                        _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");

                    if (_LoginUser != null)
                        UserId = _LoginUser.UserId;
                    else
                        UserId = Guid.Empty;

                    prop.SetValue(CopyofPOCOInstance, UserId);
                }
            }



        }

        public DocumentBaseViewModel(TPOCO entity)
        {
            _SaveCommand = new RelayCommand(Save);
            _QueryCommnand = new RelayCommand(Load);
            _DeleteCommand = new RelayCommand(Delete);
            _CreateNewCommand = new RelayCommand(CreateNew);
            _ReplyCommand = new RelayCommand<object>(Relay);

            if (entity != null)
            {
                EntityType = entity.GetType();
                CopyofPOCOInstance = entity;
            }
            else
            {
                EntityType = typeof(TPOCO);
                CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
            }

            var prop = _EntityType.GetProperty("CreateUserId");

            if (prop != null)
            {
                var UserId = (Guid)prop.GetValue(CopyofPOCOInstance);

                if (UserId == Guid.Empty)
                {
                    if (_LoginUser == null)
                        _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");

                    if (_LoginUser != null)
                        UserId = _LoginUser.UserId;
                    else
                        UserId = Guid.Empty;

                    prop.SetValue(CopyofPOCOInstance, UserId);
                }
            }
        }

        public virtual void Relay(object source)
        {

        }

        /// <summary>
        /// 向前相容性方法
        /// </summary>
        public virtual void Query()
        {
            Load();
        }

        public virtual void Load()
        {
            try
            {
                ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                if (attr != null)
                {
                    if (Filiter != null)
                    {
                        ExecuteAction<TPOCO>(attr.Name, "Query", Filiter);
                    }
                    else
                    {
                        ExecuteAction<TPOCO>(attr.Name, "Query");
                    }

                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        protected const string ActionName = "CreateOrUpdate";

        public virtual void Save()
        {
            try
            {
                ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                if (attr != null)
                {
                    ExecuteAction<TPOCO>(attr.Name, ActionName, CopyofPOCOInstance, true);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public virtual void CreateNew()
        {
            try
            {
                ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                if (attr != null)
                {
                    ExecuteAction<TPOCO>(attr.Name, "CreateNew");
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public virtual void Delete()
        {
            try
            {
                ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                if (attr != null)
                {
                    ExecuteAction<TPOCO>(attr.Name, "Delete", CopyofPOCOInstance, true);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
