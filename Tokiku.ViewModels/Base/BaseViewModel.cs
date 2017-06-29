using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Tokiku.ViewModels
{

    public class BaseViewModel : DependencyObject, IBaseViewModel
    {
        public BaseViewModel()
        {
            Initialized();
        }

        #region Helper Functions
        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                                                     new DispatcherOperationCallback(ExitFrame),
                                                     frame);
            Dispatcher.PushFrame(frame);
        }

        private object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        protected void BindingFromModel<TViewB, TB>(TB entity, TViewB ViewModel) where TViewB : IBaseViewModel where TB : class
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<TB, TViewB>(BindingFromModel), DispatcherPriority.Normal, entity, ViewModel);
            }
            else
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
                            if (t.IsGenericType && t.GetGenericTypeDefinition().Name == (typeof(ICollection<>).Name))
                            {
                                continue;
                            }

                            if (ct.IsGenericType && ct.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }

                            if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }

                            if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(BaseViewModelCollection<>).Name))
                            {
                                continue;
                            }

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
        }



        /// <summary>
        /// 將檢視模型的內容抄寫到非資料實體模型物件。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel<TViewB, TB>(TB entity, TViewB ViewModel) where TViewB : IBaseViewModel where TB : class
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<TB, TViewB>(CopyToModel), DispatcherPriority.Normal, entity, ViewModel);
            }
            else
            {
                try
                {

                    if (entity == null)
                    {
                        entity = Activator.CreateInstance<TB>();
                    }

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

                                if (ViewModelProperty.PropertyType.BaseType.IsGenericType && ViewModelProperty.PropertyType.BaseType.GetGenericTypeDefinition().Name == (typeof(BaseViewModelCollection<>).Name))
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

        #endregion

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
            set
            {
                SetValue(ErrorProperty, value); if (value != null) { HasError = true; } else { HasError = false; }
            }
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

        #region 相依屬性內容值變更處理委派方法
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
        #endregion

        #region 檢視模型初始化作業(建構式會呼叫)
        /// <summary>
        /// 檢視模型初始化作業(建構式會呼叫)
        /// </summary>
        public virtual void Initialized()
        {
            try
            {
#if DEBUG
                Debug.WriteLine("BaseViewModel initialized.");
#endif

                Errors = null;
                HasError = false;

                Status = new DocumentStatusViewModel();
                Status.IsModify = false;
                Status.IsSaved = false;
                Status.IsNewInstance = true;

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }
        #endregion

        /// <summary>
        /// 立即對資料庫執行預設的查詢動作。
        /// </summary>
        /// <remarks>
        /// 查詢條件依據相依屬性做為資料來源。
        /// </remarks>
        public virtual void Query()
        {
            Status.IsNewInstance = false;
            Status.IsModify = false;
            Status.IsSaved = false;
            DoEvents();
        }

        /// <summary>
        /// 對模型啟用非同步查詢作業。
        /// </summary>
        /// <returns></returns>
        public virtual Task QueryAsync()
        {
            return Task.Factory.StartNew(new Action(Query));
        }
        /// <summary>
        /// 儲存變更
        /// </summary>
        public virtual void SaveModel()
        {
            Status.IsNewInstance = false;
            Status.IsModify = false;
            Status.IsSaved = true;
            DoEvents();
        }

        /// <summary>
        /// 重新整理檢視模型
        /// </summary>
        public virtual void Refresh()
        {
            DoEvents();
            Query();
        }

        public virtual void SetModel(dynamic entity)
        {
            Status.IsNewInstance = false;
            Status.IsModify = false;
            Status.IsSaved = false;
            DoEvents();
        }

        public static void BindToDataGridView<T, TCollection>(TCollection source, DataGrid Grid) where T : IBaseViewModel where TCollection : BaseViewModelCollection<T>
        {
            if (Grid != null)
            {
                Grid.Columns.Clear();
                Grid.ItemsSource = source;



                Type type = typeof(T);
                var props = type.GetProperties();
                if (props.Any())
                {
                    foreach (var prop in props)
                    {
                        DisplayAttribute dispalyattr = prop.GetCustomAttributes(true).OfType<DisplayAttribute>().SingleOrDefault();

                        if (dispalyattr != null)
                        {
                            Binding fieldbinding = new Binding();
                            //fieldbinding.Source = prop.GetValue(source);
                            fieldbinding.Mode = BindingMode.TwoWay;
                            fieldbinding.Path = new PropertyPath(prop.Name);
                            fieldbinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                            DataGridTextColumn column = new DataGridTextColumn()
                            {
                                Header = dispalyattr.Name,
                                Visibility = Visibility.Visible,
                                Binding = fieldbinding
                            };
                            Grid.Columns.Add(column);

                            //column.DisplayIndex = dispalyattr.Order;
                            //Grid.Columns[dispalyattr.Order].Header = dispalyattr.Name;
                            //Grid.Columns[dispalyattr.Order].DisplayIndex = dispalyattr.Order;
                            //Grid.Columns[dispalyattr.Order].Visibility = Visibility.Visible;
                        }
                    }

                    foreach (var prop in props)
                    {
                        try
                        {
                            DisplayAttribute dispalyattr = prop.GetCustomAttributes(true).OfType<DisplayAttribute>().SingleOrDefault();

                            if (dispalyattr != null)
                            {
                                var field = Grid.Columns.Where(w => w.Header.Equals(dispalyattr.Name)).Single();
                                field.DisplayIndex = dispalyattr.Order;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }


            }
        }

        private void GetLastUpdateTime()
        {
            try
            {

            }
            catch (Exception ex)
            {

                setErrortoModel(this, ex);
            }
        }

        #region 最後更新時間
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime LastUpdateTime
        {
            get { return (DateTime)GetValue(LastUpdateTimeProperty); }
            set { SetValue(LastUpdateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateTimeProperty =
            RegisterDP<DateTime, BaseViewModel>("LastUpdateTime", DateTime.Now);

        #endregion

        #region 異動人員


        public string LastUpdateUser
        {
            get { return (string)GetValue(LastUpdateUserProperty); }
            set { SetValue(LastUpdateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateUserProperty =
            RegisterDP<string, BaseViewModel>("LastUpdateUser", string.Empty);

        #endregion

        #region 異動歷程




        #endregion

        #region 共用的相依性註冊方法
        protected static DependencyProperty RegisterDP<T, TView>(string PropertyName, object defaultValue = null) where TView : IBaseViewModel
        {
            if (defaultValue == null)
                return DependencyProperty.Register(PropertyName, typeof(T), typeof(TView), new PropertyMetadata(default(T), new PropertyChangedCallback(DefaultFieldChanged)));
            else
                return DependencyProperty.Register(PropertyName, typeof(T), typeof(TView), new PropertyMetadata((T)defaultValue, new PropertyChangedCallback(DefaultFieldChanged)));
        }
        #endregion
    }
}


