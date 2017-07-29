using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Commands;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelWithPOCOClass<TPOCO> : WithLoginUserBaseViewModel, ISingleBaseViewModel<TPOCO> where TPOCO : class
    {
        #region 建構式
        public BaseViewModelWithPOCOClass()
        {

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

            Mode = DocumentLifeCircle.Read;
            Status.IsNewInstance = false;
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

        #region Entity
        protected TPOCO CopyofPOCOInstance;

        /// <summary>
        /// 取得資料實體的副本。
        /// </summary>
        public TPOCO Entity => CopyofPOCOInstance;



        #endregion

        #region 文件狀態
        /// <summary>
        /// 文件狀態
        /// </summary>
        public IDocumentStatusViewModel Status
        {
            get { return (DocumentStatusViewModel)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(IDocumentStatusViewModel), typeof(BaseViewModel), new PropertyMetadata(default(IDocumentStatusViewModel)));
        #endregion

        #region 覆寫方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Parameter"></param>
        public override void Initialized()
        {
            Status.IsNewInstance = true;
            Status.IsModify = false;
            Status.IsSaved = false;
        }

        public virtual TView Query<TView>(params object[] parameters) where TView : ISingleBaseViewModel<TPOCO>
        {
            try
            {
                return QuerySingle<TView, TPOCO>(ControllerName, QuerySingleRowActionName, parameters);
            }
            catch (Exception ex)
            {
                TView coll = Activator.CreateInstance<TView>();
                coll.setErrortoModel(ex);
                return coll;
            }
        }
        #endregion

        #region 共用資料屬性

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
                    return (Guid)_EntityType.GetProperty("Id").GetValue(CopyofPOCOInstance);
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
                        return DateTime.Now;
                    }

                    if (_CreateTime.Year < 1900)
                    {
                        return DateTime.Now;
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
                    _EntityType.GetProperty("CreateTime").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("CreateTime");
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
                    _EntityType.GetProperty("CreateUserId").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("CreateUserId");
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
                    if (_LoginUser == null)
                        _LoginUser = ExecuteAction<Users>("System", "GetCurrentLoginUser");

                    return new UserViewModel(_LoginUser);
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
                    _EntityType.GetProperty("CreateUser").SetValue(this, value); RaisePropertyChanged("CreateUser");
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
            set { _EntityType.GetProperty("LastUpdateDate").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("LastUpdateDate"); }
        }
        #endregion

        #region 最後更新人員ID
        /// <summary>
        /// 最後更新人員ID
        /// </summary>
        public virtual Guid? LastUpdateUserId { get{

                try
                {
                    ExecuteAction<Users>("AccessLog", QueryActionName, Id);
                }
                catch (Exception ex)
                {
                    this.setErrortoModel(ex);
                    
                }
            } set => throw new NotImplementedException(); }
        #endregion

        #region 最後更新人員
        /// <summary>
        /// 最後更新人員
        /// </summary>
        public virtual IUserViewModel LastUpdateUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        #endregion

        /// <summary>
        /// 取得詳細清單
        /// </summary>
        public IMultiBaseViewModel<ISingleBaseViewModel<TPOCO>, TPOCO> Details => null;
        #endregion


    }
}
