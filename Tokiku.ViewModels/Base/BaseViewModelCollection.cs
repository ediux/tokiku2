using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelCollection<TView> : ObservableCollection<TView>, IBaseViewModel where TView : ISingleBaseViewModel
    {
        public BaseViewModelCollection()
        {
            _Replay = new RelayCommand((x) => ReplyFrom(x), (x) => true);
            _SaveCommand = new SaveModelCommand((x) => SaveModel(x));
            _CreateNewCommand = new CreateNewModelCommand();

            Initialized();
        }

        public BaseViewModelCollection(IEnumerable<TView> source) : base(source)
        {
            _Replay = new RelayCommand((x) => ReplyFrom(x), (x) => true);
            _SaveCommand = new SaveModelCommand((x) => SaveModel(x));
            _CreateNewCommand = new CreateNewModelCommand();

            Initialized();
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        public static void setErrortoModel(BaseViewModelCollection<TView> model, Exception ex)
        {
            if (model == null)
                model = (BaseViewModelCollection<TView>)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        public static void setErrortoModel(BaseViewModelCollection<TView> model, string Message)
        {
            if (model == null)
                model = (BaseViewModelCollection<TView>)Activator.CreateInstance(model.GetType());

            if (model == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }


        /// <summary>
        /// 錯誤訊息。
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
        /// <summary>
        /// 指出是否發生錯誤。
        /// </summary>
        public bool HasError { get; set; }

        public virtual string SaveModelController
        {
            get
            {
                ISingleBaseViewModel view = Activator.CreateInstance<TView>();

                if (view != null)
                    return view.SaveModelController;
                else
                    return string.Empty;
            }
        }

        protected ICommand _SaveCommand = new SaveModelCommand();
        /// <summary>
        /// 取得或設定當引發儲存時的命令項目。
        /// </summary>
        public ICommand SaveCommand { get => _SaveCommand; set => _SaveCommand = value; }
        protected ICommand _CreateNewCommand = new CreateNewModelCommand();
        /// <summary>
        /// 取得或設定當引發新建項目時的命令項目。
        /// </summary>
        public ICommand CreateNewCommand { get => _CreateNewCommand; set => _CreateNewCommand = value; }
        private ICommand _Replay;
        /// <summary>
        /// 轉送命令
        /// </summary>
        public ICommand RelayCommand { get => _Replay; set => _Replay = value; }
        private ICommand _DeleteCommand;
        /// <summary>
        /// 刪除命令
        /// </summary>
        public ICommand DeleteCommand { get => _DeleteCommand; set => _DeleteCommand = value; }

        private ICommand _QueryCommand;
        /// <summary>
        /// 
        /// </summary>
        public ICommand QueryCommand { get => _QueryCommand; set => _QueryCommand = value; }

        public virtual void ReplyFrom(object source)
        {

        }

        /// <summary>
        /// 檢視模型初始化作業
        /// </summary>
        public virtual void Initialized()
        {
            Errors = null;
            HasError = false;
        }

        /// <summary>
        /// 對指定控制器發出查詢呼叫。
        /// </summary>
        /// <typeparam name="TResult">回傳的資料實體類別。</typeparam>
        /// <param name="ControllerName">控制器名稱</param>
        /// <param name="ActionName">動作名稱(方法名稱)</param>
        /// <param name="values">動作方法參數</param>
        /// <returns>傳回指定檢視模型集合。</returns>
        public static TCollection Query<TCollection, TResult>(string ControllerName, string ActionName, params object[] values)
            where TCollection : BaseViewModelCollection<TView>
            where TResult : class
        {
            TCollection collection = null;

            try
            {
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = System.Reflection.Assembly.Load("Tokiku.Controllers").GetType(controllerfullname);

                if (ControllerType == null)
                {
                    throw new Exception(string.Format("Controller '{0}' not found.", ControllerName));
                }

                var ctrl = Activator.CreateInstance(ControllerType);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                var method = ControllerType.GetMethod(ActionName, values.Select(s => s.GetType()).ToArray());

                if (method != null)
                {
                    ExecuteResultEntity<ICollection<TResult>> result =
                        (ExecuteResultEntity<ICollection<TResult>>)method.Invoke(ctrl, values);

                    if (!result.HasError)
                    {
                        collection = (TCollection)Activator.CreateInstance(typeof(TCollection),
                           result.Result.Select(s => (TView)Activator.CreateInstance(typeof(TView), s)).ToList());

                        return collection;
                    }
                    else
                    {
                        collection = Activator.CreateInstance<TCollection>();
                        collection.Errors = result.Errors;
                        collection.HasError = true;
                        return collection;
                    }
                }
                else
                {
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                if (collection == null)
                    collection = Activator.CreateInstance<TCollection>();

                setErrortoModel(collection, ex);
                return collection;
            }
        }

        public static ICollection<TResult> ExecuteAction<TResult>(string ControllerName, string ActionName, params object[] values)
            where TResult : class
        {
            ICollection<TResult> collection = null;

            try
            {
                string controllerfullname = string.Format("Tokiku.Controllers.{0}Controller", ControllerName);

                Type ControllerType = System.Reflection.Assembly.Load("Tokiku.Controllers").GetType(controllerfullname);

                if (ControllerType == null)
                {
                    throw new Exception(string.Format("Controller '{0}' not found.", ControllerName));
                }

                var ctrl = Activator.CreateInstance(ControllerType);

                if (ctrl == null)
                {
                    throw new NullReferenceException();
                }

                var method = ControllerType.GetMethod(ActionName, values.Select(s => s.GetType()).ToArray());

                if (method != null)
                {
                    var result = method.Invoke(ctrl, values);

                    if (result is ExecuteResultEntity)
                    {
                        ExecuteResultEntity resultc = (ExecuteResultEntity)result;

                        if (!resultc.HasError)
                        {
                            collection = new Collection<TResult>();
                            return collection;
                        }
                        else
                        {
                            collection = Activator.CreateInstance<Collection<TResult>>();
                            return collection;
                        }
                    }
                    else
                    {
                        if (result is ExecuteResultEntity<TResult>)
                        {
                            ExecuteResultEntity<TResult> resultc = (ExecuteResultEntity<TResult>)result;

                            if (!resultc.HasError)
                            {
                                collection = new Collection<TResult>();
                                collection.Add(resultc.Result);
                                return collection;
                            }
                            else
                            {
                                collection = Activator.CreateInstance<Collection<TResult>>();
                                return collection;
                            }
                        }
                        else
                        {
                            if (result is ExecuteResultEntity<ICollection<TResult>>)
                            {
                                ExecuteResultEntity<ICollection<TResult>> resultc = (ExecuteResultEntity<ICollection<TResult>>)result;

                                if (!resultc.HasError)
                                {
                                    collection = resultc.Result;
                                    return collection;
                                }
                                else
                                {
                                    collection = Activator.CreateInstance<Collection<TResult>>();
                                    return collection;
                                }
                            }
                            else
                            {
                                collection = Activator.CreateInstance<Collection<TResult>>();
                                return collection;
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception(string.Format("Action '{0}' not found.", ActionName));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 儲存或更新檢視模型
        /// </summary>
        public virtual void SaveModel(string ControllerName)
        {
            try
            {
                int i = 0;
                List<string> message = new List<string>();
                foreach (var item in Items)
                {
                    item.SaveModel(ControllerName, i == (Items.Count - 1));
                    if (item.HasError)
                    {
                        message.AddRange(item.Errors);
                    }
                    i++;
                }
                if (message.Count > 0)
                {
                    Errors = message.ToArray();
                    HasError = true;
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
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
        /// <param name="entity"></param>
        protected TView BindingFromModel<TB>(TB entity) where TB : class
        {

            TView ViewModel = default(TView);
            try
            {
                if (entity == null)
                    return ViewModel;

                ViewModel = Activator.CreateInstance<TView>();

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

                if (ViewModel == null)
                    ViewModel = Activator.CreateInstance<TView>();

                ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }

            return ViewModel;
        }

        /// <summary>
        /// 將檢視模型的內容抄寫到非資料實體模型物件。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel<TB>(TB entity, TView ViewModel) where TB : class
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
                        setErrortoModel(this, ex);
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

        public void SaveModel()
        {
            SaveModel(SaveModelController);
        }

        public void Initialized(object Parameter)
        {
            throw new NotImplementedException();
        }
    }
}
