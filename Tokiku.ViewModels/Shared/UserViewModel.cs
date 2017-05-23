using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class UserViewModel : DependencyObject, INotifyPropertyChanged
    {
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

        public static readonly DependencyProperty IsNewProperty = DependencyProperty.Register("IsNew", typeof(bool), typeof(UserViewModel));

        /// <summary>
        /// 是否為新增?
        /// </summary>
        public bool IsNew
        {
            get { return (bool)GetValue(IsNewProperty); }
            set { SetValue(IsNewProperty, value); }
        }

        public static readonly DependencyProperty IsEditorModeProperty = DependencyProperty.Register("IsEditorMode", typeof(bool), typeof(UserViewModel));

        /// <summary>
        /// 是否在編輯模式?
        /// </summary>
        public bool IsEditorMode
        {
            get { return (bool)GetValue(IsEditorModeProperty); }
            set { SetValue(IsEditorModeProperty, value); }
        }

        public static readonly DependencyProperty IsModifyProperty = DependencyProperty.Register("IsModify", typeof(bool), typeof(UserViewModel));

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        public bool IsModify
        {
            get { return (bool)GetValue(IsModifyProperty); }
            set { SetValue(IsModifyProperty, value); }
        }

        public static readonly DependencyProperty IsSavedProperty = DependencyProperty.Register("IsSaved", typeof(bool), typeof(UserViewModel));

        /// <summary>
        /// 是否已存檔?
        /// </summary>
        public bool IsSaved
        {
            get { return (bool)GetValue(IsSavedProperty); }
            set { SetValue(IsSavedProperty, value); }
        }

        public static readonly DependencyProperty CanSaveProperty = DependencyProperty.Register("CanSave", typeof(bool), typeof(UserViewModel));

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



        public Exception Error
        {
            get { return (Exception)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); if (value != null) { HasError = true; } }
        }

        // Using a DependencyProperty as the backing store for Error.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(Exception), typeof(UserViewModel), new PropertyMetadata(default(Exception)));




        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(UserViewModel), new PropertyMetadata(false));




        public bool CanCreateNew
        {
            get { return (bool)GetValue(CanCreateNewProperty); }
            set { SetValue(CanCreateNewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanCreateNew.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCreateNewProperty =
            DependencyProperty.Register("CanCreateNew", typeof(bool), typeof(UserViewModel), new PropertyMetadata(false));



        public Guid UserId
        {
            get { return (Guid )GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserIdProperty =
            DependencyProperty.Register("UserId", typeof(Guid ), typeof(UserViewModel), new PropertyMetadata(Guid.NewGuid()));



        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty));


        public string LoweredUserName
        {
            get { return (string)GetValue(LoweredUserNameProperty); }
            set { SetValue(LoweredUserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoweredUserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoweredUserNameProperty =
            DependencyProperty.Register("LoweredUserName", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty));




        public string MobileAlias
        {
            get { return (string)GetValue(MobileAliasProperty); }
            set { SetValue(MobileAliasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MobileAlias.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MobileAliasProperty =
            DependencyProperty.Register("MobileAlias", typeof(string), typeof(UserViewModel), new PropertyMetadata(string.Empty));



        public bool IsAnonymous
        {
            get { return (bool)GetValue(IsAnonymousProperty); }
            set { SetValue(IsAnonymousProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAnonymous.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnonymousProperty =
            DependencyProperty.Register("IsAnonymous", typeof(bool), typeof(UserViewModel), new PropertyMetadata(false));




        public DateTime LastActivityDate
        {
            get { return (DateTime)GetValue(LastActivityDateProperty); }
            set { SetValue(LastActivityDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastActivityDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastActivityDateProperty =
            DependencyProperty.Register("LastActivityDate", typeof(DateTime), typeof(UserViewModel), new PropertyMetadata(DateTime.Now));

    }
}
