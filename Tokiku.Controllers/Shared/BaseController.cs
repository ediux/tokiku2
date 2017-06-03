using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public abstract class BaseController : IDisposable
    {
      
        protected TokikuEntities database;

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

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    database.Dispose();
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~BaseController() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion

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

            if (ex is DbEntityValidationException)
            {
                DbEntityValidationException dbex = (DbEntityValidationException)ex;

                List<string> msg = new List<string>(model.Errors);

                foreach (var err in dbex.EntityValidationErrors)
                {
                    foreach (var errb in err.ValidationErrors)
                    {
#if DEBUG
                        Debug.WriteLine(errb.ErrorMessage);
#endif
                        msg.Add(errb.ErrorMessage);
                    }
                }

                model.Errors = msg.AsEnumerable();

            }
            else
            {
                if (ex is DbUpdateException)
                {
                    DbUpdateException efex = (DbUpdateException)ex;

                    List<string> msg = new List<string>();

                    ScanErrorMessage(efex, msg);

                    model.Errors = msg.AsEnumerable();
                }
                else
                {
                    model.Errors = new string[] { ex.Message, ex.StackTrace };
                }

            }

        }

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

        public UserViewModel Login(LoginViewModel model)
        {
            try
            {
                using (database)
                {
                    string loweredUserName = model.UserName.ToLowerInvariant();
                    _CurrentLoginedUserStorage = (from q in database.Users
                                                  from m in database.Membership
                                                  where m.UserId == q.UserId && q.LoweredUserName == loweredUserName
                                                  && m.Password == model.Password
                                                  select new UserViewModel()
                                                  {
                                                      IsAnonymous = q.IsAnonymous,
                                                      LastActivityDate = q.LastActivityDate,
                                                      LoweredUserName = q.LoweredUserName,
                                                      MobileAlias = q.MobileAlias,
                                                      Password = m.Password,
                                                      UserId = q.UserId,
                                                      UserName = q.UserName
                                                  }).SingleOrDefault();
                    if (_CurrentLoginedUserStorage != null)
                    {
                        return _CurrentLoginedUserStorage;
                    }

                    _CurrentLoginedUserStorage = new UserViewModel();
                    setErrortoModel(_CurrentLoginedUserStorage, "登入失敗!");
                    return _CurrentLoginedUserStorage;
                }
            }
            catch (Exception ex)
            {

                setErrortoModel(model, ex);

                return new UserViewModel() { Errors = model.Errors };
            }
            finally
            {
                database = new TokikuEntities();
            }

        }
        protected static UserViewModel _CurrentLoginedUserStorage;

        public UserViewModel GetCurrentLoginUser()
        {
            try
            {
                if (_CurrentLoginedUserStorage != null)
                {
                    return _CurrentLoginedUserStorage;
                }

                return default(UserViewModel);
            }
            catch (Exception ex)
            {
                UserViewModel error = new UserViewModel();
                error.Errors = new string[] { ex.Message };
                return error;
            }
        }

        public UserViewModel GetUser(string UserName)
        {
            UserViewModel vm = new UserViewModel();

            try
            {
                using (database)
                {
                    string loweredUserName = UserName.ToLowerInvariant();
                    _CurrentLoginedUserStorage = (from q in database.Users
                                                  from m in database.Membership
                                                  where m.UserId == q.UserId && q.LoweredUserName == loweredUserName
                                                  select new UserViewModel()
                                                  {
                                                      IsAnonymous = q.IsAnonymous,
                                                      LastActivityDate = q.LastActivityDate,
                                                      LoweredUserName = q.LoweredUserName,
                                                      MobileAlias = q.MobileAlias,
                                                      Password = m.Password,
                                                      UserId = q.UserId,
                                                      UserName = q.UserName
                                                  }).SingleOrDefault();

                    if (_CurrentLoginedUserStorage != null)
                    {
                        return _CurrentLoginedUserStorage;
                    }

                    _CurrentLoginedUserStorage = new UserViewModel();
                    setErrortoModel(_CurrentLoginedUserStorage, "登入失敗!");
                    return _CurrentLoginedUserStorage;
                }
            }
            catch (Exception ex)
            {
                vm.Errors = new string[] { ex.Message };
                return vm;
            }
        }

        public UserViewModel Login(string UserName, string pwd)
        {
            try
            {
                return Login(new LoginViewModel() { Password = pwd, UserName = UserName });
            }
            catch (Exception ex)
            {
                UserViewModel model = new UserViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

    }

    public abstract class BaseController<TView, T> : BaseController where TView : IBaseViewModel where T : class
    {
        public BaseController() : base()
        {
            try
            {
                database = new TokikuEntities();
            }
            catch
            {
#if DEBUG
                database = new TokikuEntities("data source=220.130.128.36,1443;initial catalog=Tokiku2;persist security info=True;user id=sa;password=1qaz@WSX;MultipleActiveResultSets=True;App=EntityFramework");
#endif
            }
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected TView BindingFromModel(T entity)
        {
            return BindingFromModel<TView, T>(entity);

        }

        /// <summary>
        /// 將檢視模型的內容抄寫到資料實體模型。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel(T entity, TView ViewModel)
        {
            base.CopyToModel(entity, ViewModel);
        }

        /// <summary>
        /// 傳回主索引鍵欄位的內容值。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object[] IdentifyPrimaryKey(T entity)
        {

            ObjectContext objectContext = ((IObjectContextAdapter)database).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            Type entityreflection = typeof(T);

            var pkeys = entityreflection.GetProperties()
                .Join(keyNames, (x) => x.Name, (y) => y, (k, t) => k)
                .Select(s => s.GetValue(entity));

            return pkeys.ToArray();
        }

        /// <summary>
        /// 預設的建立檢視模型執行個體的方法。
        /// </summary>
        /// <returns>傳回初始化的檢視模型。</returns>
        public virtual TView CreateNew()
        {
            TView model = default(TView);

            try
            {
                model = Activator.CreateInstance<TView>();
                return model;
            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
                return model;
            }
        }

        public virtual void Add(TView model)
        {
            try
            {
                using (database)
                {
                    T entity = Activator.CreateInstance<T>();
                    CopyToModel(entity, model);
                    database.Set<T>().Add(entity);
                    database.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public virtual TView Query(Expression<Func<T, bool>> filiter)
        {
            TView model = default(TView);

            try
            {
                using (database)
                {
                    var result = database.Set<T>().Where(filiter);

                    if (result.Any())
                    {
                        T entity = result.Single();
                        model = BindingFromModel(entity);
                        return model;
                    }

                    model = Activator.CreateInstance<TView>();
                    setErrortoModel(model, "Not Found!");
                    return model;
                }
            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
                return model;
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public virtual TView Update(TView model)
        {
            try
            {
                using (database)
                {
                    T entity = Activator.CreateInstance<T>();
                    CopyToModel(entity, model);

                    var findresult = database.Set<T>().Find(IdentifyPrimaryKey(entity));

                    if (findresult != null)
                    {
                        findresult = entity;
                        database.SaveChanges();
                        findresult = database.Set<T>().Find(IdentifyPrimaryKey(findresult));
                        return BindingFromModel(findresult);
                    }

                    return default(TView);
                }

            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
                return model;
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public virtual void Delete(TView model)
        {
            try
            {
                using (database)
                {
                    T entity = Activator.CreateInstance<T>();
                    CopyToModel(entity, model);

                    var findresult = database.Set<T>().Find(IdentifyPrimaryKey(entity));

                    if (findresult != null)
                    {
                        database.Set<T>().Remove(findresult);
                        database.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public virtual void SaveModel(TView model)
        {
            try
            {
                T entity = Activator.CreateInstance<T>();
                CopyToModel(entity, model);

                var findresult = database.Set<T>().Find(IdentifyPrimaryKey(entity));

                if (findresult != null)
                {
                    Update(model);
                }
                else
                {
                    Add(model);
                }

            }
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
            }
        }

        public virtual bool IsExists(Expression<Func<T, bool>> filiter)
        {
            try
            {
                return database.Set<T>().Where(filiter).Any();
            }
            catch
            {
                throw;
            }
        }



    }
}
