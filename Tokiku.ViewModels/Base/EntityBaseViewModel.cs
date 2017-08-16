using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 以資料實體為基底的檢視模型
    /// </summary>
    public abstract class EntityBaseViewModel<TPOCO> : BaseViewModel, IEntityBaseViewModel<TPOCO> where TPOCO : class
    {
        #region 主要檢視模型資料實體
        protected TPOCO CopyofPOCOInstance;

        /// <summary>
        /// 主要資料實體來源物件。
        /// </summary>
        public virtual TPOCO Entity
        {
            get => CopyofPOCOInstance;
            protected set
            {
                CopyofPOCOInstance = value;
                RaisePropertyChanged("Entity");
            }
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

        #region 建構式
        [PreferredConstructor]
        public EntityBaseViewModel()
        {
            _SaveCommand = new RelayCommand(Save);
            _QueryCommnand = new RelayCommand<object>(Query);
            _DeleteCommand = new RelayCommand(Delete);
            _CreateNewCommand = new RelayCommand(CreateNew);
            _ReplyCommand = new RelayCommand<object>(Relay);

            EntityType = typeof(TPOCO);

            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
        }

        public EntityBaseViewModel(TPOCO entity)
        {
            _SaveCommand = new RelayCommand(Save);
            _QueryCommnand = new RelayCommand<object>(Query);
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

        }
        #endregion

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

        #region 查詢條件式(ORM)

        Expression<Func<TPOCO, bool>> _Filiter = default(Expression<Func<TPOCO, bool>>);

        /// <summary>
        /// 取得或設定查詢條件式
        /// </summary>
        public Expression<Func<TPOCO, bool>> Filiter { get => _Filiter; set => _Filiter = value; }
        #endregion

        protected virtual void CreateNew()
        {

        }

        protected virtual void Delete()
        {
        }

        /// <summary>
        /// 向前相容性方法
        /// </summary>
        protected virtual void Query(object Parameter)
        {

        }

        protected virtual void Relay(object source)
        {

        }

        protected virtual void Save()
        {

        }

        public virtual void SetEntity(TPOCO entity)
        {
            CopyofPOCOInstance = entity;
            RaisePropertyChanged<TPOCO>(broadcast: true);
        }
    }
}