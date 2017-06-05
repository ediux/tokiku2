using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public abstract class BaseController : IDisposable
    {

        protected IUnitOfWork database;



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



        public ExecuteResultEntity<Users> Login(LoginParameter model)
        {
            try
            {
          
                    string loweredUserName = model.UserName.ToLowerInvariant();
                    _CurrentLoginedUserStorage = (from q in RepositoryHelper.GetUsersRepository(database).All()
                                                  where q.LoweredUserName == loweredUserName
                                                  && q.Membership.Password == model.Password
                                                  select q).SingleOrDefault();

                    if (_CurrentLoginedUserStorage != null)
                    {
                        return new ExecuteResultEntity<Users>() { Result = _CurrentLoginedUserStorage };
                    }

                    ExecuteResultEntity<Users> error = ExecuteResultEntity<Users>.CreateErrorResultEntity("登入失敗!");

                    return error;
               
            }
            catch (Exception ex)
            {
                ExecuteResultEntity<Users> error = ExecuteResultEntity<Users>.CreateErrorResultEntity(ex);
                return error;
            }

        }

        protected static Users _CurrentLoginedUserStorage;

        public ExecuteResultEntity<Users> GetCurrentLoginUser()
        {
            try
            {
                if (_CurrentLoginedUserStorage != null)
                {
                    return new ExecuteResultEntity<Users>() { Result = _CurrentLoginedUserStorage };
                }

                return new ExecuteResultEntity<Users>() { Errors = new string[] { "登入失敗!" } };
            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<Users>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<Users> GetUser(string UserName)
        {
            try
            {
                using (IUsersRepository UserRepo = RepositoryHelper.GetUsersRepository())
                {

                    string loweredUserName = UserName.ToLowerInvariant();
                    _CurrentLoginedUserStorage = (from q in UserRepo.All()
                                                  where q.LoweredUserName == loweredUserName
                                                  select q).SingleOrDefault();

                    if (_CurrentLoginedUserStorage != null)
                    {
                        return ExecuteResultEntity<Users>.CreateResultEntity(_CurrentLoginedUserStorage);
                    }


                    return ExecuteResultEntity<Users>.CreateErrorResultEntity(new Exception("登入失敗!"));
                }

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Users>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<Users> Login(string UserName, string pwd)
        {
            try
            {
                return Login(new LoginParameter() { Password = pwd, UserName = UserName });
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Users>.CreateErrorResultEntity(ex);
            }
        }

    }

    public abstract class BaseController<T> : BaseController where T : class
    {
        public BaseController() : base()
        {
            try
            {
                database = RepositoryHelper.GetUnitOfWork();
            }
            catch
            {
#if DEBUG
                //database = new TokikuEntities("data source=220.130.128.36,1443;initial catalog=Tokiku2;persist security info=True;user id=sa;password=1qaz@WSX;MultipleActiveResultSets=True;App=EntityFramework");
                database = RepositoryHelper.GetUnitOfWork();
                database.ConnectionString = "data source = 220.130.128.36,1443; initial catalog = Tokiku2; persist security info = True; user id = sa; password = 1qaz @WSX; MultipleActiveResultSets = True; App = EntityFramework";
#endif
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

        private IRepositoryBase<T> GetRepository()
        {
            Type type = typeof(T);

            Type RepositoryType = typeof(RepositoryHelper);


            if (RepositoryType != null)
            {
                MethodInfo GetRepositoryMethod = RepositoryType.GetMethod(string.Format("{0}Repository"), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance);

                return (IRepositoryBase<T>)GetRepositoryMethod.Invoke(null, new object[] { database });
            }

            return default(IRepositoryBase<T>);

        }

        /// <summary>
        /// 預設的建立檢視模型執行個體的方法。
        /// </summary>
        /// <returns>傳回初始化的檢視模型。</returns>
        public virtual ExecuteResultEntity<T> CreateNew()
        {
            ExecuteResultEntity<T> model = null;

            try
            {
                model = new ExecuteResultEntity<T>();
                model.Result = Activator.CreateInstance<T>();
                return model;
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<T>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 加入單一資料列到資料庫。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity Add(T entity, bool isLastRecord = true)
        {
            try
            {
                using (IRepositoryBase<T> repo = GetRepository())
                {
                    repo.Add(entity);

                    if (isLastRecord)
                    {
                        repo.UnitOfWork.Commit();
                        entity = repo.Reload(entity);
                    }

                    return ExecuteResultEntity<T>.CreateResultEntity(entity);
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 取得查詢結果。        
        /// </summary>
        /// <param name="filiter">LINQ查詢表示式</param>
        /// <returns>傳回帶有訊息的查詢集合。</returns>
        public virtual ExecuteResultEntity<ICollection<T>> Query(Expression<Func<T, bool>> filiter)
        {

            ExecuteResultEntity<ICollection<T>> model = null;

            try
            {
                using (var repo = GetRepository())
                {
                    var result = repo.Where(filiter);

                    if (result.Any())
                    {
                        model = ExecuteResultEntity<ICollection<T>>.CreateResultEntity(new Collection<T>(result.ToList()));
                        return model;
                    }

                    model = ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity("Not Found!");
                    return model;
                }
            }
            catch (Exception ex)
            {
                model = ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity(ex);
                return model;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity<T> Update(T fromModel, bool isLastRecord = true)
        {
            try
            {
                using (var repo = GetRepository())
                {
                    T findresult = repo.Get(IdentifyPrimaryKey(fromModel));

                    if (findresult != null)
                    {
                        Type fromSource = fromModel.GetType();

                        foreach (var prop in findresult.GetType().GetProperties())
                        {
                            var OldValue = prop.GetValue(findresult);
                            var NewValue = fromSource.GetProperty(prop.Name).GetValue(fromModel);

                            if (OldValue != null)
                            {
                                if (NewValue != null && !OldValue.Equals(NewValue))
                                {
                                    prop.SetValue(findresult, fromSource.GetProperty(prop.Name).GetValue(fromModel));
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (NewValue != null)
                                {
                                    prop.SetValue(findresult, fromSource.GetProperty(prop.Name).GetValue(fromModel));
                                }
                            }
                        }

                        if (isLastRecord)
                        {
                            database.Commit();
                        }

                        fromModel = repo.Reload(fromModel);
                        return ExecuteResultEntity<T>.CreateResultEntity(fromModel);
                    }

                    return ExecuteResultEntity<T>.CreateErrorResultEntity("Data not found.");
                }

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<T>.CreateErrorResultEntity(ex);
            }

        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity Delete(Expression<Func<T, bool>> condtion)
        {
            try
            {
                using (var repo = GetRepository())
                {
                    var findresult = repo.Where(condtion);

                    if (findresult.Any())
                    {
                        foreach (var result in findresult)
                        {
                            repo.Delete(result);
                        }

                        repo.UnitOfWork.Commit();

                        return ExecuteResultEntity.CreateResultEntity();
                    }

                    return ExecuteResultEntity.CreateErrorResultEntity("Data no found.");
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }

        }

        /// <summary>
        /// 儲存或更新資料庫
        /// </summary>
        /// <param name="model"></param>
        public virtual ExecuteResultEntity<ICollection<T>> CreateOrUpdate(ICollection<T> ObjectDataSet)
        {
            try
            {
                using (var repo = GetRepository())
                {
                    if (ObjectDataSet.Any())
                    {
                        int c = 0;
                        foreach (var result in ObjectDataSet)
                        {
                            if (repo.Get(result) != null)
                            {
                                Update(result, c == ObjectDataSet.Count);
                            }
                            else
                            {
                                Add(result);
                            }
                        }

                        return ExecuteResultEntity<ICollection<T>>.CreateResultEntity(ObjectDataSet);
                    }

                    return ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity("No data update.");

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 檢查是否有符合查詢條件式的資料列
        /// </summary>
        /// <param name="filiter"></param>
        /// <returns></returns>
        public virtual bool IsExists(Expression<Func<T, bool>> filiter)
        {
            try
            {
                return database.Context.Set<T>().Where(filiter).Any();
            }
            catch
            {
                throw;
            }
        }



    }
}
