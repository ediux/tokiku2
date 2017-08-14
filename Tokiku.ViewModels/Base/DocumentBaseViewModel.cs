using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public abstract class DocumentBaseViewModel : WithLoginUserBaseViewModel, IDocumentBaseViewModel
    {
        public DocumentBaseViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);

            _Status = new DocumentStatusViewModel();

            _SaveCommand = new RelayCommand(Save);
            _QueryCommnand = new RelayCommand<object>(Query);
            _DeleteCommand = new RelayCommand(Delete);
            _CreateNewCommand = new RelayCommand(CreateNew);
            _ReplyCommand = new RelayCommand<object>(Relay);

            Messenger.Default.Register<NotificationMessage<IBaseViewModel>>(this, RecviceFromOthers);
        }

        #region 文件狀態
        private IDocumentStatusViewModel _Status;
        /// <summary>
        /// 文件狀態
        /// </summary>
        public IDocumentStatusViewModel Status { get => _Status; set => _Status = value; }
        #endregion

        #region 文件操作模式
        protected DocumentLifeCircle _Mode;

        /// <summary>
        /// 文件操作模式
        /// </summary>
        public virtual DocumentLifeCircle Mode { get => _Mode; set { _Mode = value; RaisePropertyChanged("Mode"); } }
        #endregion

        #region 異動紀錄
        private ObservableCollection<IAccessLogViewModel> _AccessLogs = null;
        /// <summary>
        /// 異動紀錄
        /// </summary>
        public ObservableCollection<IAccessLogViewModel> AccessLogs => _AccessLogs;
        #endregion

        #region 文件生命週期變更命令

        private ICommand _ModeChangedCommand;
        /// <summary>
        /// 取得或設定文件生命週期變更命令物件參考。
        /// </summary>
        public ICommand ModeChangedCommand { get => _ModeChangedCommand; set { _ModeChangedCommand = value; RaisePropertyChanged("ModeChangedCommand"); } }

        #endregion

        protected virtual void RecviceFromOthers(NotificationMessage<IBaseViewModel> model)
        {
            QueryCommand?.Execute(model.Content);
        }
        protected virtual void RunModeChanged(DocumentLifeCircle Mode)
        {
            _Mode = Mode;
            RaisePropertyChanged("Mode");
        }

        #region 模型 WPF MVVM命令
        private ICommand _CreateNewCommand = null;

        private ICommand _DeleteCommand;

        private ICommand _QueryCommnand = null;

        private ICommand _ReplyCommand;

        private ICommand _SaveCommand = null;

        /// <summary>
        /// 取得或設定當引發新建項目時的命令項目。
        /// </summary>
        public ICommand CreateNewCommand { get => _CreateNewCommand; set => _CreateNewCommand = value; }

        /// <summary>
        /// 取得或設定當引發刪除項目時的命令項目。
        /// </summary>
        public ICommand DeleteCommand { get => _DeleteCommand; set => _DeleteCommand = value; }

        /// <summary>
        /// 取得或設定當引發查詢項目時的命令項目。
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommnand; set => _QueryCommnand = value; }

        /// <summary>
        /// 取得或設定當引發來自其他項目時的命令項目。
        /// </summary>
        public ICommand RelayCommand { get => _ReplyCommand; set { _ReplyCommand = value; } }

        /// <summary>
        /// 取得或設定當引發儲存時的命令項目。
        /// </summary>
        public ICommand SaveCommand { get => _SaveCommand; set => _SaveCommand = value; }

        #endregion

        #region 命令處理方法
        public virtual void CreateNew()
        {
            try
            {
                //ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                //if (attr != null)
                //{
                //    //ExecuteAction<TPOCO>(attr.Name, "CreateNew");
                //}
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

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public virtual void Load()
        {
            try
            {
                //ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                //if (attr != null)
                //{
                //    if (Filiter != null)
                //    {
                //        ExecuteAction<TPOCO>(attr.Name, "Query", Filiter);
                //    }
                //    else
                //    {
                //        ExecuteAction<TPOCO>(attr.Name, "Query");
                //    }

                //}
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        /// <summary>
        /// 向前相容性方法
        /// </summary>
        public virtual void Query(object Parameter)
        {
            Load();
        }

        public virtual void Relay(object source)
        {

        }

        public virtual void Save()
        {
            try
            {
                //ControllerMappingAttribute attr = MethodBase.GetCurrentMethod().GetCustomAttribute<ControllerMappingAttribute>();

                //if (attr != null)
                //{
                //    ExecuteAction<TPOCO>(attr.Name, ActionName, CopyofPOCOInstance, true);
                //}
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
        #endregion
    }

    /// <summary>
    /// 以文件為輸入模式的檢視模型抽象基底類別
    /// </summary>
    public abstract class DocumentBaseViewModel<TPOCO> : EntityBaseViewModel<TPOCO>, IDocumentBaseViewModel<TPOCO>
            where TPOCO : class
    {

        protected ICoreDataService _CoreDataService;


        #region 文件狀態
        private IDocumentStatusViewModel _Status;
        /// <summary>
        /// 文件狀態
        /// </summary>
        public IDocumentStatusViewModel Status { get => _Status; set => _Status = value; }
        #endregion

        #region 文件操作模式
        protected DocumentLifeCircle _Mode;

        /// <summary>
        /// 文件操作模式
        /// </summary>
        public virtual DocumentLifeCircle Mode { get => _Mode; set { _Mode = value; RaisePropertyChanged("Mode"); } }
        #endregion

        #region 資料識別碼
        private Guid _Id = Guid.Empty;
        /// <summary>
        /// 資料識別碼
        /// </summary>
        public virtual Guid Id
        {
            get => _Id;
            set { _Id = value; RaisePropertyChanged("Id"); }
        }
        #endregion

        #region 異動紀錄
        private ObservableCollection<IAccessLogViewModel> _AccessLogs = null;
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
                        _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, CreateUser.UserId);
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
                        _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, _CoreDataService.GetCurrentLoginedUser());
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

                    var log = _CoreDataService.GetLastUpdateTime(typeof(TPOCO).Name, Id.ToString());

                    if (log != null)
                    {
                        return log;
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

                var log = LastUpadateUser;

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

                    var log = _CoreDataService.GetLastUpdateUser(typeof(TPOCO).Name, Id.ToString());
                    return log;
                }
                catch
                {
                    return null;
                }

            }

        }


        #endregion

        #region 文件生命週期變更命令

        private ICommand _ModeChangedCommand;
        /// <summary>
        /// 取得或設定文件生命週期變更命令物件參考。
        /// </summary>
        public ICommand ModeChangedCommand { get => _ModeChangedCommand; set { _ModeChangedCommand = value; RaisePropertyChanged("ModeChangedCommand"); } }

        #endregion

        [PreferredConstructor]
        public DocumentBaseViewModel(ICoreDataService CoreDataService)
        {
            _CoreDataService = CoreDataService;
            _Status = new DocumentStatusViewModel();
            _ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);

            var prop = _EntityType.GetProperty("CreateUserId");

            if (prop != null)
            {
                var UserId = (Guid)prop.GetValue(CopyofPOCOInstance);

                if (UserId == Guid.Empty)
                {


                    prop.SetValue(CopyofPOCOInstance, UserId);
                }
            }
        }

        public DocumentBaseViewModel(TPOCO entity, ICoreDataService CoreDataService) : base(entity)
        {
            _CoreDataService = CoreDataService;
            _Status = new DocumentStatusViewModel();
            _ModeChangedCommand = new RelayCommand<DocumentLifeCircle>(RunModeChanged);

            var prop = _EntityType.GetProperty("CreateUserId");

            if (prop != null)
            {
                var UserId = (Guid)prop.GetValue(CopyofPOCOInstance);

                if (UserId == Guid.Empty)
                {

                    UserId = _CoreDataService.GetCurrentLoginedUser().UserId;

                    prop.SetValue(CopyofPOCOInstance, UserId);
                }
            }
        }

        protected virtual void RunModeChanged(DocumentLifeCircle Mode)
        {
            _Mode = Mode;
            RaisePropertyChanged("Mode");
        }
    }
}
