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

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 以文件為輸入模式的檢視模型抽象基底類別
    /// </summary>
    public abstract class DocumentBaseViewModel<TPOCO> : EntityBaseViewModel<TPOCO>, IDocumentBaseViewModel<TPOCO>
            where TPOCO : class
    {
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


        [PreferredConstructor]
        public DocumentBaseViewModel()
        {


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

        public DocumentBaseViewModel(TPOCO entity) : base(entity)
        {

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


    }
}
