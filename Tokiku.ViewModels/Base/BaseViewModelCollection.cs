using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        protected string _ControllerName = string.Empty;

        public virtual string SaveModelController
        {
            get
            {
                Type t = GetType();

                if (string.IsNullOrEmpty(_ControllerName))
                {
                    if (t != null)
                        _ControllerName = t.Name.Replace("ViewModelCollection", "");

                    t = typeof(TView);

                    if (t != null)
                        _ControllerName = t.Name.Replace("ViewModel", "");

                }

                return _ControllerName;
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

                var method = ControllerType.GetMethod(ActionName, values.Select(s => s != null ? s.GetType() : typeof(object)).ToArray());

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

                var method = ControllerType.GetMethod(ActionName, values.Select(s => s != null ? s.GetType() : typeof(object)).ToArray());

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
        public virtual void SaveModel(object ControllerName)
        {
            try
            {
                int i = 0;
                List<string> message = new List<string>();
                foreach (var item in Items)
                {
                    item.SaveModel(SaveModelController, i == (Items.Count - 1));

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

        public void SaveModel()
        {
            SaveModel(SaveModelController);
        }

        public void Initialized(object Parameter)
        {
            Initialized();
        }

        //protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        //{
        //    Type vt = typeof(TView);

        //    var prop = vt.GetProperty("EntityType");

        //    if (prop == null)
        //    {
        //        return;
        //    }

        //    switch (e.Action)
        //    {
        //        case NotifyCollectionChangedAction.Replace:
        //            for (int i = e.NewStartingIndex; i < e.NewStartingIndex + e.NewItems.Count; i++)
        //            {
        //                if (prop != null)
        //                {
        //                    var m = typeof(BaseViewModelCollection<TView>).GetMethod("ExecuteAction", BindingFlags.Static | BindingFlags.CreateInstance | BindingFlags.InvokeMethod | BindingFlags.Public);

        //                    if (m != null)
        //                    {
        //                        var k = m.MakeGenericMethod(((TView)e.NewItems[i]).EntityType);
        //                        k.Invoke(this, new object[] {SaveModelController, "Update", new object[]{
        //                            typeof(TView).GetProperty("Entity").GetValue(e.NewItems[i])
        //                            , i == (e.NewItems.Count - 1) } });
        //                    }
        //                }
        //            }
        //            break;
        //        case NotifyCollectionChangedAction.Add:
        //            for (int i = 0; i < e.NewItems.Count; i++)
        //            {
        //                if (prop != null)
        //                {

        //                    var m = typeof(BaseViewModelCollection<TView>).GetMethod("ExecuteAction", BindingFlags.Static | BindingFlags.CreateInstance | BindingFlags.InvokeMethod | BindingFlags.Public);

        //                    if (m != null)
        //                    {
        //                        var k = m.MakeGenericMethod(((TView)e.NewItems[i]).EntityType);
        //                        k.Invoke(this, new object[] {SaveModelController, "Add", new object[]{ typeof(TView).GetProperty("Entity").GetValue(e.NewItems[i])
        //                            , i == (e.NewItems.Count - 1) } });
        //                    }

        //                }
        //            }
        //            break;
        //        case NotifyCollectionChangedAction.Remove:
        //            for (int i = 0; i < e.OldItems.Count; i++)
        //            {

        //                if (prop != null)
        //                {
        //                    var m = typeof(BaseViewModelCollection<TView>).GetMethod("ExecuteAction", BindingFlags.Static | BindingFlags.CreateInstance | BindingFlags.InvokeMethod | BindingFlags.Public);

        //                    if (m != null)
        //                    {
        //                        var k = m.MakeGenericMethod(((TView)e.OldItems[i]).EntityType);
        //                        k.Invoke(this, new object[] {SaveModelController, "Delete", new object[]{
        //                            typeof(TView).GetProperty("Entity").GetValue(e.OldItems[i])
        //                            , i == (e.OldItems.Count - 1) } });
        //                    }                            
        //                }
        //            }
        //            break;
        //    }
        //}

        //public static TCollection Query<TCollection, TEntity>(params object[] Parameers) where TCollection : BaseViewModelCollection<TView> where TEntity : class
        //{
        //    try
        //    {
        //        TCollection collection = Activator.CreateInstance<TCollection>();

        //        collection = Query<TCollection, TEntity>(
        //             collection.SaveModelController, "QueryAll", Parameers);

        //        return collection;
        //    }
        //    catch (Exception ex)
        //    {
        //        TCollection emptycollection =
        //            Activator.CreateInstance<TCollection>();
        //        setErrortoModel(emptycollection, ex);
        //        return emptycollection;
        //    }
        //}
    }
}
