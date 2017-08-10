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
using GalaSoft.MvvmLight.Ioc;
using Tokiku.DataServices;

namespace Tokiku.ViewModels
{
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
        public virtual DocumentLifeCircle Mode { get => _Mode; set { _Mode = value;  RaisePropertyChanged("Mode"); } }
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


        [PreferredConstructor]
        public DocumentBaseViewModel(ICoreDataService CoreDataService)
        {
            _CoreDataService = CoreDataService;

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

        public virtual void SetEntity(TPOCO entity)
        {
            CopyofPOCOInstance = entity;
            RaisePropertyChanged<TPOCO>(broadcast: true);
        }
    }
}
