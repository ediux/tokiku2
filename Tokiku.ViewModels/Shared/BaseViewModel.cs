using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{

    public abstract class WithOutBaseViewModel : DependencyObject, IBaseViewModel
    {
        public WithOutBaseViewModel()
        {
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected void BindingFromModel<T>(T entity) where T : class
        {
            Type t = typeof(T);
            Type ct = this.GetType();

            var props = t.GetProperties();

            foreach (var prop in props)
            {
                var ctProp = ct.GetProperty(prop.Name);
                if (ctProp != null)
                {
                    ctProp.SetValue(this, prop.GetValue(entity));
                }
            }
        }

        /// <summary>
        /// 將檢視模型抄寫到資料實體物件
        /// </summary>
        /// <typeparam name="T">目標資料實體物件型別</typeparam>
        /// <param name="entity">資料實體物件執行個體。</param>
        /// <returns></returns>
        protected T CopyToModel<T>(T entity) where T : class
        {

            Type t = this.GetType();
            Type ct = typeof(T);

            var props = t.GetProperties();

            foreach (var prop in props)
            {
                var ctProp = ct.GetProperty(prop.Name);
                if (ctProp != null)
                {
                    ctProp.SetValue(entity, prop.GetValue(this));
                }
            }

            return entity;
        }

        /// <summary>
        /// 啟用編輯模式
        /// </summary>
        public virtual void EnableEditor()
        {
            CanSave = true;
        }

        /// <summary>
        /// 關閉編輯模式
        /// </summary>
        public virtual void DisabledEditor()
        {

            CanSave = false;
        }

        #region PropertyChanged 事件
        /// <summary>
        /// 屬性變更事件。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion


        /// <summary>
        /// 指出目前是否處於初始化狀態
        /// </summary>
        public bool IsNewInstance
        {
            get { return (bool)GetValue(IsNewInstanceProperty); }
            set { SetValue(IsNewInstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsNewInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsNewInstanceProperty =
            DependencyProperty.Register("IsNewInstance", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(true,new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 指出是否可以建立新資料
        /// </summary>
        public bool CanNew
        {
            get { return (bool)GetValue(CanNewProperty); }
            set { SetValue(CanNewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanNew.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanNewProperty =
            DependencyProperty.Register("CanNew", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(true, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 指出是否可以被編輯
        /// </summary>
        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(true, new PropertyChangedCallback(DefaultFieldChanged)));


        /// <summary>
        /// 指出是否可以被刪除(停用)
        /// </summary>
        public bool CanDelete
        {
            get { return (bool)GetValue(CanDeleteProperty); }
            set { SetValue(CanDeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanDelete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanDeleteProperty =
            DependencyProperty.Register("CanDelete", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty IsModifyProperty = DependencyProperty.Register("IsModify", typeof(bool), typeof(WithOutBaseViewModel),new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        public bool IsModify
        {
            get { return (bool)GetValue(IsModifyProperty); }
            set { SetValue(IsModifyProperty, value); RaisePropertyChanged("IsModify"); }
        }

        public static readonly DependencyProperty IsSavedProperty = DependencyProperty.Register("IsSaved", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 是否已存檔?
        /// </summary>
        public bool IsSaved
        {
            get { return (bool)GetValue(IsSavedProperty); }
            set {
                SetValue(IsSavedProperty, value);
                RaisePropertyChanged("IsSaved");
                SetValue(CanSaveProperty, !value);
                RaisePropertyChanged("CanSave"); }
        }

        public static readonly DependencyProperty CanSaveProperty = DependencyProperty.Register("CanSave", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false, new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 指出是否可以存檔?
        /// </summary>
        public bool CanSave
        {
            get
            {
                return (bool)GetValue(CanSaveProperty);
            }
            set
            {
                SetValue(CanSaveProperty, value);
                RaisePropertyChanged("Can");
            }
        }

        /// <summary>
        /// 判定各內容狀態
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        internal static void DefaultFieldChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.OldValue != null)
                    source.SetValue(IsNewInstanceProperty, false);

                if (!e.NewValue.Equals(e.OldValue))
                {
                    source.SetValue(IsModifyProperty, true);    //設定已被修改
                    source.SetValue(IsSavedProperty, false);    //設定尚未儲存
                    source.SetValue(CanSaveProperty, true);     //設定可以存檔
                    source.SetValue(CanDeleteProperty, true);
                    source.SetValue(CanEditProperty, false);
                    source.SetValue(CanNewProperty, true);          
                }
            }
            else
            {
                if (e.OldValue != null)
                {
                    source.SetValue(IsModifyProperty, true);    //設定已被修改
                    source.SetValue(IsSavedProperty, false);    //設定尚未儲存
                    source.SetValue(CanSaveProperty, true);     //設定可以存檔
                    source.SetValue(CanDeleteProperty, true);
                    source.SetValue(CanEditProperty, false);
                    source.SetValue(CanNewProperty, true);
                    
                }
            }
          
        }


        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors
        {
            get { return (IEnumerable<string>)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); if (value != null) { HasError = true; } }
        }

        // Using a DependencyProperty as the backing store for Error.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(IEnumerable<string>), typeof(WithOutBaseViewModel), 
                new PropertyMetadata(default(Exception),new PropertyChangedCallback(DefaultFieldChanged)));

        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); RaisePropertyChanged("HasError"); }
        }

        // Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false,
                new PropertyChangedCallback(DefaultFieldChanged)));



        public bool CanQuery
        {
            get { return (bool)GetValue(CanQueryProperty); }
            set { SetValue(CanQueryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanQuery.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanQueryProperty =
            DependencyProperty.Register("CanQuery", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));



        public bool CanCommit
        {
            get { return (bool)GetValue(CanCommitProperty); }
            set { SetValue(CanCommitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanQuery.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCommitProperty =
            DependencyProperty.Register("CanCommit", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));




        public bool CanUseFeatures
        {
            get { return (bool)GetValue(CanUseFeaturesProperty); }
            set { SetValue(CanUseFeaturesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanUseFeatures.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanUseFeaturesProperty =
            DependencyProperty.Register("CanUseFeatures", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));



        public bool CanRunExcel
        {
            get { return (bool)GetValue(CanRunExcelProperty); }
            set { SetValue(CanRunExcelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanRunExcel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanRunExcelProperty =
            DependencyProperty.Register("CanRunExcel", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));



        public bool CanPrint
        {
            get { return (bool)GetValue(CanPrintProperty); }
            set { SetValue(CanPrintProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanPrint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanPrintProperty =
            DependencyProperty.Register("CanPrint", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(true
                , new PropertyChangedCallback(DefaultFieldChanged)));





        public bool CanCancel
        {
            get { return (bool)GetValue(CanCancelProperty); }
            set { SetValue(CanCancelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanCancel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCancelProperty =
            DependencyProperty.Register("CanCancel", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));




        public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanClose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCloseProperty =
            DependencyProperty.Register("CanClose", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));



        public bool CanAddColumn
        {
            get { return (bool)GetValue(CanAddColumnProperty); }
            set { SetValue(CanAddColumnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddColumnProperty =
            DependencyProperty.Register("CanAddColumn", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                , new PropertyChangedCallback(DefaultFieldChanged)));




        public bool CanAddRow
        {
            get { return (bool)GetValue(CanAddRowProperty); }
            set { SetValue(CanAddRowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddRowProperty =
            DependencyProperty.Register("CanAddRow", typeof(bool), typeof(WithOutBaseViewModel), new PropertyMetadata(false
                ,new PropertyChangedCallback(DefaultFieldChanged)));




    }

    public abstract class BaseViewModel : WithOutBaseViewModel, IBaseViewModelWithLoginedUser
    {
        public BaseViewModel()
        {
            LoginedUser = new UserViewModel()
            {
                UserId = Guid.Empty,
                UserName = "root",
                LoweredUserName = "root",
                IsAnonymous = false,
            };
        }

        public static readonly DependencyProperty LoginedUserProperty = DependencyProperty.Register("LoginedUser", typeof(UserViewModel), typeof(WithOutBaseViewModel), new PropertyMetadata(default(UserViewModel),
            new PropertyChangedCallback(DefaultFieldChanged)));
        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public UserViewModel LoginedUser
        {
            get { return GetValue(LoginedUserProperty) as UserViewModel; }
            set
            {
                SetValue(LoginedUserProperty, value);
            }
        }
    }
}


