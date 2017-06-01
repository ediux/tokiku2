using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Tokiku.ViewModels
{

    public class BaseViewModel : DependencyObject, IBaseViewModel
    {
        public BaseViewModel()
        {
            Status = new DocumentStatusViewModel();
        }

        protected static void DefaultFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                if (!e.OldValue.Equals(e.NewValue))
                {
                    if (d.GetType().GetInterface("IBaseViewModel") == typeof(IBaseViewModel))
                    {
                        BaseViewModel model = ((BaseViewModel)d);
                        model.Status.IsModify = true;
                        model.Status.IsSaved = false;
                        model.PropertyChanged?.Invoke(model, new PropertyChangedEventArgs(e.Property.Name));
                    }
                }
            }

        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void BindingFromModel<T>(T entity) where T : class
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
                    RaisePropertyChanged(ctProp.Name);
                }
            }
        }

        /// <summary>
        /// 將檢視模型抄寫到資料實體物件
        /// </summary>
        /// <typeparam name="T">目標資料實體物件型別</typeparam>
        /// <param name="entity">資料實體物件執行個體。</param>
        /// <returns></returns>
        public T CopyToModel<T>(T entity) where T : class
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
                    RaisePropertyChanged(ctProp.Name);
                }
            }

            return entity;
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
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors
        {
            get { return (IEnumerable<string>)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); if (value != null) { HasError = true; } else { HasError = false; } }
        }

        // Using a DependencyProperty as the backing store for Error.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(IEnumerable<string>), typeof(BaseViewModel),
                new PropertyMetadata(default(Exception)));

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
            DependencyProperty.Register("HasError", typeof(bool), typeof(BaseViewModel), new PropertyMetadata(false));



        public DocumentStatusViewModel Status
        {
            get { return (DocumentStatusViewModel)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(DocumentStatusViewModel), typeof(BaseViewModel), new PropertyMetadata(default(DocumentStatusViewModel)));


    }


}


