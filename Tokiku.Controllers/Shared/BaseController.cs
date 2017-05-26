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
    public abstract class BaseController<TView, T> where TView : IBaseViewModel where T : class
    {
        protected TokikuEntities database;

        public BaseController()
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
                    var ctProp = ct.GetProperty(prop.Name);

                    if (ctProp != null)
                    {
                        ctProp.SetValue(ViewModel, prop.GetValue(entity));
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
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected TViewB BindingFromNotModel<TViewB, TB>(TB entity) where TViewB : IBaseViewModel where TB : class
        {
            TViewB ViewModel = Activator.CreateInstance<TViewB>();

            try
            {
                Type t = typeof(TB);
                Type ct = typeof(TViewB);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    var ctProp = ct.GetProperty(prop.Name);

                    if (ctProp != null)
                    {
                        ctProp.SetValue(ViewModel, prop.GetValue(entity));
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
                Type t = typeof(TView);
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
            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                    ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }

        /// <summary>
        /// 將檢視模型的內容抄寫到非資料實體模型物件。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToNotModel<TViewB>(T entity, TViewB ViewModel) where TViewB : IBaseViewModel
        {

            try
            {
                Type t = typeof(TView);
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

            model.Errors = new string[] { ex.Message };
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
