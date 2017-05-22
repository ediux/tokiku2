using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            LoginedUser = new Users()
            {
                UserId = Guid.Empty,
                UserName = "root",
                LoweredUserName = "root",
                IsAnonymous = false,
            };

            IsNew = true;
            IsModify = false;
            IsSaved = false;
            IsEditorMode = false;
            CanSave = false;
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

            foreach(var prop in props)
            {
                var ctProp = ct.GetProperty(prop.Name);
                if (ctProp != null)
                {
                    ctProp.SetValue(this, prop.GetValue(entity));                    
                }
            }
            IsEditorMode = false;
            IsModify = false;
            IsSaved = false;
            CanSave = false;
        }

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
        
        public void EnableEditor()
        {
            IsEditorMode = true;
            CanSave = true;
        }

        public void DisabledEditor()
        {
            IsEditorMode = false;
            CanSave = false;
        }

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

        public static readonly DependencyProperty IsNewProperty = DependencyProperty.Register("IsNew", typeof(bool), typeof(BaseViewModel));

        /// <summary>
        /// 是否為新增?
        /// </summary>
        public bool IsNew
        {
            get { return (bool)GetValue(IsNewProperty); }
            set { SetValue(IsNewProperty, value); }
        }

        public static readonly DependencyProperty IsEditorModeProperty = DependencyProperty.Register("IsEditorMode", typeof(bool), typeof(BaseViewModel));

        /// <summary>
        /// 是否在編輯模式?
        /// </summary>
        public bool IsEditorMode
        {
            get { return (bool)GetValue(IsEditorModeProperty); }
            set { SetValue(IsEditorModeProperty, value); }
        }

        public static readonly DependencyProperty IsModifyProperty = DependencyProperty.Register("IsModify", typeof(bool), typeof(BaseViewModel));

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        public bool IsModify
        {
            get { return (bool)GetValue(IsModifyProperty); }
            set { SetValue(IsModifyProperty, value); }
        }

        public static readonly DependencyProperty IsSavedProperty = DependencyProperty.Register("IsSaved", typeof(bool), typeof(BaseViewModel));

        /// <summary>
        /// 是否已存檔?
        /// </summary>
        public bool IsSaved
        {
            get { return (bool)GetValue(IsSavedProperty); }
            set { SetValue(IsSavedProperty, value); }
        }

        public static readonly DependencyProperty CanSaveProperty = DependencyProperty.Register("CanSave", typeof(bool), typeof(BaseViewModel));

        public bool CanSave
        {
            get
            {
                return (bool)GetValue(CanSaveProperty);
            }
            set
            {
                SetValue(CanSaveProperty, value);
            }
        }

        public static readonly DependencyProperty LoginedUserProperty = DependencyProperty.Register("LoginedUser", typeof(Users), typeof(BaseViewModel), new PropertyMetadata(default(Users)));
        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        public Users LoginedUser
        {
            get { return GetValue(LoginedUserProperty) as Users; }
            set
            {
                SetValue(LoginedUserProperty, value);
                RaisePropertyChanged("LoginedUser");
            }
        }

        internal static void DefaultFieldChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {

            if (!e.NewValue.Equals(e.OldValue))
            {
                source.SetValue(IsEditorModeProperty, true);
                source.SetValue(IsModifyProperty, true);
                source.SetValue(IsSavedProperty, false);
                source.SetValue(CanSaveProperty, true);
            }
        }
    }
}
