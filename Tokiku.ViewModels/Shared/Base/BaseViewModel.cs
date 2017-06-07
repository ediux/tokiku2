using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;

namespace Tokiku.ViewModels
{

    public class BaseViewModel : DependencyObject, IBaseViewModel
    {
        public BaseViewModel()
        {
            Initialized();
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected void BindingFromModel<TViewB, TB>(TB entity, TViewB ViewModel) where TViewB : IBaseViewModel where TB : class
        {


            try
            {
                if (entity == null)
                    return;

                Type t = entity.GetType();
                Type ct = ViewModel.GetType();
#if DEBUG
                Debug.WriteLine("BindingFromModel");
                Debug.WriteLine(string.Format("資料實體{0},檢視模型為{1}", t.Name, ct.Name));
                Debug.WriteLine("開始抄寫.");
#endif
                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {

                            if (prop.PropertyType == ctProp.PropertyType)
                            {

                                var entityvalue = prop.GetValue(entity);
                                var value = ctProp.GetValue(ViewModel);

#if DEBUG
                                Debug.Write(string.Format("資料實體屬性 {0}({2}) 內容值為 {1}(null).\n", prop.Name, entityvalue, prop.PropertyType.Name));
                                Debug.Write(string.Format("檢視模型屬性 {0}({2}) 內容值為 {1}(null).\n", ctProp.Name, value, ctProp.PropertyType.Name));
#endif

                                ctProp.SetValue(ViewModel, entityvalue);
                            }
                        }
                    }
#if DEBUG
                    catch (Exception ex)
#else
                    catch
#endif

                    {
#if DEBUG
                        Debug.WriteLine(ex.Message);

#endif
                        continue;
                    }

                }
#if DEBUG
                Debug.WriteLine("結束抄寫.");
#endif
               
            }
            catch (Exception ex)
            {
                ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
                
            }
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected TViewB BindingFromModel<TViewB, TB>(TB entity) where TViewB : IBaseViewModel where TB : class
        {
            TViewB ViewModel = Activator.CreateInstance<TViewB>();

            try
            {
                Type t = typeof(TB);
                Type ct = typeof(TViewB);
#if DEBUG
                Debug.WriteLine("BindingFromModel");
                Debug.WriteLine(string.Format("資料實體{0},檢視模型為{1}", t.Name, ct.Name));
                Debug.WriteLine("開始抄寫.");
#endif
                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {

                            if (prop.PropertyType == ctProp.PropertyType)
                            {

                                var entityvalue = prop.GetValue(entity);
                                var value = ctProp.GetValue(ViewModel);

#if DEBUG
                                Debug.Write(string.Format("資料實體屬性 {0}({2}) 內容值為 {1}(null).\n", prop.Name, entityvalue, prop.PropertyType.Name));
                                Debug.Write(string.Format("檢視模型屬性 {0}({2}) 內容值為 {1}(null).\n", ctProp.Name, value, ctProp.PropertyType.Name));
#endif

                                ctProp.SetValue(ViewModel, entityvalue);
                            }
                        }
                    }
#if DEBUG
                    catch (Exception ex)
#else
                    catch
#endif

                    {
#if DEBUG
                        Debug.WriteLine(ex.Message);

#endif
                        continue;
                    }

                }
#if DEBUG
                Debug.WriteLine("結束抄寫.");
#endif
                return ViewModel;
            }
            catch (Exception ex)
            {
                ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
                return ViewModel;
            }
        }

        /// <summary>
        /// 將檢視模型的內容抄寫到非資料實體模型物件。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel<TViewB, TB>(TB entity, TViewB ViewModel) where TViewB : IBaseViewModel where TB : class
        {
            try
            {

                Type CurrentViewModelType = ViewModel.GetType();
                Type TargetEntity = entity.GetType();
#if DEBUG
                Debug.WriteLine("CopyToModel");
                Debug.WriteLine(string.Format("資料實體{0},檢視模型為{1}", TargetEntity.Name, CurrentViewModelType.Name));
                Debug.WriteLine("開始抄寫.");
#endif
                var CurrentViewModel_Property = CurrentViewModelType.GetProperties();

                foreach (var ViewModelProperty in CurrentViewModel_Property)
                {
                    try
                    {
                        var EntityProperty = TargetEntity.GetProperty(ViewModelProperty.Name);
                        if (EntityProperty != null)
                        {
                            var entityvalue = EntityProperty.GetValue(entity);
                            var value = ViewModelProperty.GetValue(ViewModel);

                            if (EntityProperty.PropertyType.IsGenericType && EntityProperty.PropertyType.GetGenericTypeDefinition().Name == (typeof(ICollection<>).Name))
                            {
                                continue;
                            }



                            if (ViewModelProperty.PropertyType.IsGenericType && ViewModelProperty.PropertyType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }

                            if (ViewModelProperty.PropertyType.BaseType.IsGenericType && ViewModelProperty.PropertyType.BaseType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }
#if DEBUG
                            Debug.WriteLine(string.Format("資料實體屬性 {0}({2}) 內容值為 {1}.\n", EntityProperty.Name, entityvalue, EntityProperty.PropertyType.Name));
                            Debug.WriteLine(string.Format("檢視模型屬性 {0}({2}) 內容值為 {1}.\n", ViewModelProperty.Name, value, ViewModelProperty.PropertyType.Name));
#endif
                            if (value != null && !value.Equals(entityvalue))
                            {
                                EntityProperty.SetValue(entity, value);
                            }
#if DEBUG
                            Debug.WriteLine(string.Format("抄寫後資料實體屬性 {0}({2}) 內容值為 {1}.\n", EntityProperty.Name, EntityProperty.GetValue(entity), EntityProperty.PropertyType.Name));
#endif
                        }
                    }
                    catch (Exception ex)
                    {
                        setErrortoModel(ViewModel, ex);
                        continue;
                    }

                }
#if DEBUG
                Debug.WriteLine("結束抄寫.");
#endif

            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                    ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(IBaseViewModel model, Exception ex)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected static void setErrortoModel(IBaseViewModel model, string Message)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }

        private static void ScanErrorMessage(Exception ex, List<string> messageQueue)
        {
            if (ex.InnerException != null)
            {
                ScanErrorMessage(ex.InnerException, messageQueue);
            }

            messageQueue.Add(ex.Message);

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

        #region 錯誤訊息
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
        #endregion

        #region 文件狀態
        /// <summary>
        /// 文件狀態
        /// </summary>
        public DocumentStatusViewModel Status
        {
            get { return (DocumentStatusViewModel)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(DocumentStatusViewModel), typeof(BaseViewModel), new PropertyMetadata(default(DocumentStatusViewModel))); 
        #endregion

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
        /// 檢視模型初始化作業
        /// </summary>
        public virtual void Initialized()
        {
            Errors = null;
            HasError = false;

            Status = new DocumentStatusViewModel();
            Status.IsModify = false;
            Status.IsSaved = false;
            Status.IsNewInstance = true;
        }

        /// <summary>
        /// 當啟動時的第一次查詢作業，這通常搭配OnLoad事件使用。
        /// </summary>
        public virtual void StartUp_Query()
        {
            Query();
        }

        /// <summary>
        /// 立即對資料庫執行預設的查詢動作。
        /// </summary>
        /// <remarks>
        /// 查詢條件依據相依屬性做為資料來源。
        /// </remarks>
        public virtual void Query()
        {
        
        }

        /// <summary>
        /// 儲存變更
        /// </summary>
        public virtual void SaveModel()
        {
            
        }

        /// <summary>
        /// 重新整理檢視模型
        /// </summary>
        public virtual void Refresh()
        {
            Query();
        }

    }


}


