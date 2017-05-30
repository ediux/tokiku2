using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
                                ctProp.SetValue(ViewModel, prop.GetValue(entity));
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }

                }

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
                Type CurrentViewModelType = typeof(TViewB);
                Type TargetEntity = typeof(TB);

                var CurrentViewModel_Property = CurrentViewModelType.GetProperties();

                foreach (var ViewModelProperty in CurrentViewModel_Property)
                {
                    try
                    {
                        var EntityProperty = TargetEntity.GetProperty(ViewModelProperty.Name);
                        if (EntityProperty != null)
                        {
                            var value = ViewModelProperty.GetValue(ViewModel);

                            if (value != null && !value.Equals(EntityProperty.GetValue(entity)))
                            {
                                EntityProperty.SetValue(entity, ViewModelProperty.GetValue(ViewModel));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        setErrortoModel(ViewModel, ex);
                        continue;
                    }

                }
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

            if (ex is DbEntityValidationException)
            {
                DbEntityValidationException dbex = (DbEntityValidationException)ex;

                List<string> msg = new List<string>();

                foreach (var err in dbex.EntityValidationErrors)
                {
                    foreach (var errb in err.ValidationErrors)
                    {
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

        private static void ScanErrorMessage(Exception ex, List<string> messageQueue)
        {
            if (ex.InnerException != null)
            {
                ScanErrorMessage(ex.InnerException, messageQueue);
            }

            messageQueue.Add(ex.Message);

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
            TView ViewModel = Activator.CreateInstance<TView>();

            try
            {
                Type t = typeof(T);
                Type ct = typeof(TView);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {

                            if (ctProp.PropertyType == prop.PropertyType)
                            {

                                ctProp.SetValue(ViewModel, prop.GetValue(entity));
                            }

                        }
                    }
                    catch
                    {
                        continue;
                    }

                }

                return ViewModel;
            }
            catch (Exception ex)
            {
                ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
                return ViewModel;
            }

        }

        /// <summary>
        /// 將檢視模型的內容抄寫到資料實體模型。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel(T entity, TView ViewModel)
        {

            try
            {
                Type CurrentViewModelType = typeof(TView);
                Type TargetEntity = typeof(T);

                var CurrentViewModel_Property = CurrentViewModelType.GetProperties();

                foreach (var ViewModelProperty in CurrentViewModel_Property)
                {
                    try
                    {
                        var EntityProperty = TargetEntity.GetProperty(ViewModelProperty.Name);
                        if (EntityProperty != null)
                        {
                            var value = ViewModelProperty.GetValue(ViewModel);

                            if (value != null && !value.Equals(EntityProperty.GetValue(entity)))
                            {
                                EntityProperty.SetValue(entity, ViewModelProperty.GetValue(ViewModel));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //setErrortoModel(ViewModel, ex);
                        continue;
                    }

                }
            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                    ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
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
                T entity = Activator.CreateInstance<T>();
                CopyToModel(entity, model);
                database.Set<T>().Add(entity);
                database.SaveChanges();
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

        public virtual TView Query(Expression<Func<T, bool>> filiter)
        {
            TView model = default(TView);

            try
            {
                var result = database.Set<T>().Where(filiter);

                if (result.Any())
                {
                    T entity = result.Single();
                    model = BindingFromModel(entity);
                    return model;
                }

                return default(TView);
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

        public virtual TView Update(TView model)
        {


            try
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

        public virtual void Delete(TView model)
        {
            try
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
            catch (Exception ex)
            {
                if (model == null)
                {
                    model = Activator.CreateInstance<TView>();
                }
                setErrortoModel(model, ex);
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
