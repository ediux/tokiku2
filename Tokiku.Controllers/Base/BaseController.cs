﻿using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    /// <summary>
    /// 商業邏輯層控制器基底類別。
    /// </summary>
    public abstract class ControllerBase :  IViewController
    {

        public ControllerBase()
        {
        }


        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
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
        /// 登入系統。
        /// </summary>
        /// <param name="model">登入畫面的檢視模型物件。</param>
        /// <returns>傳回登入結果。</returns>
        public IExecuteResultEntity<IUsers> Login(ILoginViewModel model)
        {
            try
            {

                string loweredUserName = model.UserName.ToLowerInvariant();
                _CurrentLoginedUserStorage = (from q in this.GetRepository<IUsersRepository, Users>().All()
                                              where q.LoweredUserName == loweredUserName
                                              && q.Membership.Password == model.Password
                                              select q).SingleOrDefault();

                if (_CurrentLoginedUserStorage != null)
                {
                    return new ExecuteResultEntity<IUsers>() { Result = _CurrentLoginedUserStorage };
                }

                IExecuteResultEntity<IUsers> error = ExecuteResultEntity<IUsers>.CreateErrorResultEntity("登入失敗!");

                return error;

            }
            catch (Exception ex)
            {
                IExecuteResultEntity<IUsers> error = ExecuteResultEntity<IUsers>.CreateErrorResultEntity(ex);
                return error;
            }

        }

        protected static Users _CurrentLoginedUserStorage;

        /// <summary>
        /// 取得目前登入的使用者資訊物件。
        /// </summary>
        /// <returns>傳回目前已經登入的使用者資訊物件。</returns>
        public IExecuteResultEntity<IUsers> GetCurrentLoginUser()
        {
            try
            {
                if (_CurrentLoginedUserStorage != null)
                {
                    return new ExecuteResultEntity<IUsers>() { Result = _CurrentLoginedUserStorage };
                }

                return new ExecuteResultEntity<IUsers>() { Errors = new string[] { "登入失敗!" } };
            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<IUsers>.CreateErrorResultEntity(ex);
            }
        }

        public IExecuteResultEntity<IUsers> GetUser(string UserName)
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
                        return ExecuteResultEntity<IUsers>.CreateResultEntity(_CurrentLoginedUserStorage);
                    }


                    return ExecuteResultEntity<IUsers>.CreateErrorResultEntity(new Exception("登入失敗!"));
                }

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<IUsers>.CreateErrorResultEntity(ex);
            }
        }

        public IExecuteResultEntity<IUsers> Login(string UserName, string pwd)
        {
            try
            {
                var model= SimpleIoc.Default.GetInstance<ILoginViewModel>();
                model.UserName = UserName;
                model.Password = pwd;
                return Login(model);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<IUsers>.CreateErrorResultEntity(ex);
            }
        }

    }

    /// <summary>
    /// 針對指定實體類別<typeparamref name="T"/>的商業邏輯控制器。
    /// </summary>
    /// <typeparam name="T">對應的資料表實體物件。</typeparam>
    public abstract class BaseController<TMainRepository, T> : ControllerBase, IBaseController<T>
        where TMainRepository : IRepositoryBase<T>
        where T : class
    {
        public BaseController() : base()
        {

        }





        /// <summary>
        /// 建立預設的資料實體物件執行個體的方法。
        /// </summary>
        /// <returns>傳回初始化的資料實體物件。</returns>
        public virtual IExecuteResultEntity<T> CreateNew()
        {
            ExecuteResultEntity<T> model = null;

            try
            {
                model = ExecuteResultEntity<T>.CreateResultEntity(Activator.CreateInstance<T>());
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
        /// <param name="entity">要插入到資料庫的檢視資料實體模型。</param>
        /// <returns></returns>
        public virtual IExecuteResultEntity Add(T entity, bool isLastRecord = true)
        {
            try
            {
                var repo = GetRepository();

                if (repo == null)
                    return ExecuteResultEntity.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(T).Name));

                entity = repo.Add(entity);

                var log = this.GetRepository<IAccessLogRepository, AccessLog>();

                AccessLog addlog = new AccessLog()
                {
                    ActionCode = (byte)ActionCodes.Create,
                    DataId = typeof(T).GetProperty("Id")?.GetValue(entity).ToString(),
                    CreateTime = DateTime.Now,
                    DataTableName = typeof(T).Name,
                    Reason = "新增資料",
                    UserId = GetCurrentLoginUser().Result.UserId
                };
                log.Add(addlog);

                if (isLastRecord)
                {
                    repo.UnitOfWork.Commit();
                    repo = GetRepository();
                    entity = repo.Get(IdentifyPrimaryKey(entity));

                }

                return ExecuteResultEntity.CreateResultEntity();

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
        public virtual IExecuteResultEntity<ICollection<T>> Query(Expression<Func<T, bool>> filiter)
        {

            ExecuteResultEntity<ICollection<T>> model = null;

            try
            {

                var repo = GetRepository();

                //database = repo.UnitOfWork;

                if (repo == null)
                    return ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(T).Name));

                var result = repo.Where(filiter);

                if (result.Any())
                {
                    var detachs = result.ToList();
                    model = ExecuteResultEntity<ICollection<T>>.CreateResultEntity(new Collection<T>(detachs));
                    return model;
                }

                model = ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity("Not Found!");
                return model;

            }
            catch (Exception ex)
            {
                model = ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity(ex);
                return model;
            }

        }

        /// <summary>
        /// 更新資料庫。
        /// </summary>
        /// <param name="model">來自前端UI且綁定的資料實體物件執行個體。</param>
        /// <returns></returns>
        public virtual IExecuteResultEntity<T> Update(T fromModel, bool isLastRecord = true)
        {
            try
            {
                var repo = GetRepository();
                if (repo == null)
                    return ExecuteResultEntity<T>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(T).Name));

                //repo.UnitOfWork.Context.Entry(fromModel).State = EntityState.Added;
                repo.UnitOfWork.Context.Entry(fromModel).State = EntityState.Modified;

                var log = this.GetRepository<IAccessLogRepository, AccessLog>();
                AccessLog addlog = new AccessLog()
                {
                    ActionCode = (byte)ActionCodes.Create,
                    DataId = typeof(T).GetProperty("Id")?.GetValue(fromModel).ToString(),
                    CreateTime = DateTime.Now,
                    DataTableName = typeof(T).Name,
                    Reason = "更新資料",
                    UserId = GetCurrentLoginUser().Result.UserId
                };
                log.Add(addlog);

                if (isLastRecord)
                {


                    repo.UnitOfWork.Commit();

                    //database = null;
                    repo = GetRepository();
                    var findresult = repo.Get(IdentifyPrimaryKey(fromModel));
                    return ExecuteResultEntity<T>.CreateResultEntity(findresult);
                }

                return ExecuteResultEntity<T>.CreateResultEntity(fromModel);
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
        public virtual IExecuteResultEntity<T> Delete(T entity, bool isDeleteRightNow = false)
        {
            try
            {
                var repo = GetRepository();

                if (repo == null)
                    return ExecuteResultEntity<T>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(T).Name));

                repo.Delete(entity);
                //repo.UnitOfWork.Context.Entry(entity).State = EntityState.Deleted;
                var log = this.GetRepository<IAccessLogRepository, AccessLog>();
                AccessLog addlog = new AccessLog()
                {
                    ActionCode = (byte)ActionCodes.Create,
                    DataId = typeof(T).GetProperty("Id")?.GetValue(entity).ToString(),
                    CreateTime = DateTime.Now,
                    DataTableName = typeof(T).Name,
                    Reason = "刪除資料",
                    UserId = GetCurrentLoginUser().Result.UserId
                };
                log.Add(addlog);

                if (isDeleteRightNow)
                {
                    repo.UnitOfWork.Commit();
                }

                return ExecuteResultEntity<T>.CreateResultEntity(entity);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<T>.CreateErrorResultEntity(ex);
            }

        }

        /// <summary>
        /// 新增或更新資料至資料庫。
        /// </summary>
        /// <param name="model">已經變更的資料實體物件(來自UI)</param>
        public virtual IExecuteResultEntity<T> CreateOrUpdate(T entity, bool isLastRecord = true)
        {
            try
            {
                var repo = GetRepository();


                if (repo == null)
                    return ExecuteResultEntity<T>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(T).Name));



                //檢查資料庫資料是否存在?
                if (repo.Get(IdentifyPrimaryKey(entity)) != null)
                {
                    //repo.UnitOfWork.Context.Entry(entity).State = EntityState.Detached;

                    var update_result = Update(entity, isLastRecord);

                    if (update_result.HasError)
                    {
                        update_result.Result = entity;
                        return update_result;
                    }

                    return ExecuteResultEntity<T>.CreateResultEntity(update_result.Result);
                }
                else
                {
                    var add_result = Add(entity, isLastRecord);
                    if (add_result.HasError)
                    {
                        return new ExecuteResultEntity<T>()
                        {
                            Errors = add_result.Errors,
                            Result = entity
                        };
                    }

                    return ExecuteResultEntity<T>.CreateResultEntity(entity);
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<T>.CreateErrorResultEntity(ex);
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
                return GetRepository().Where(filiter).Any();
            }
            catch
            {
                throw;
            }
        }

        public IExecuteResultEntity<ICollection<T>> QueryAll(params object[] Parameters)
        {
            try
            {
                var repo = GetRepository();

                var mapping = Parameters.OfType<Dictionary<string, object>>().ToList();

                if (mapping.Any())
                {
                    var element = mapping.First();

                    ParameterExpression param = Expression.Parameter(typeof(T), "q");

                    Queue<Expression> expQ = new Queue<Expression>();

                    foreach (string key in element.Keys)
                    {
                        var prop = typeof(T).GetProperty(key);
                        if (prop == null)
                            continue;

                        Expression left = Expression.Property(param, prop);
                        Expression right = Expression.Constant(element[key]);
                        Expression filter = Expression.Equal(left, right);

                        if (expQ.Count == 0)
                            expQ.Enqueue(filter);
                        else
                        {
                            Expression lastexp = expQ.Dequeue();
                            Expression currexp = Expression.And(lastexp, filter);
                            expQ.Enqueue(currexp);
                        }
                    }

                    Expression pred = Expression.Lambda(expQ.Dequeue(), param);

                    Expression expr = Expression.Call(typeof(Queryable), "Where", new Type[] { typeof(T) }, Expression.Constant(repo), pred);

                    IQueryable<T> query = repo.All().Provider.CreateQuery<T>(expr);

                    return ExecuteResultEntity<ICollection<T>>.CreateResultEntity(
                        new Collection<T>(query.ToList()));
                }
                else
                {
                    return ExecuteResultEntity<ICollection<T>>.CreateResultEntity(
                    new Collection<T>(repo.All().ToList()));
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<T>>.CreateErrorResultEntity(ex);
            }
        }

        public IExecuteResultEntity<T> QuerySingle(params object[] Parameters)
        {
            try
            {
                var repo = this.GetRepository();
                var result = repo.Get(Parameters);

                return ExecuteResultEntity<T>.CreateResultEntity(result);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<T>.CreateErrorResultEntity(ex);
            }
        }

        public static IExecuteResultEntity AddLogRecord(string DataId, Guid UserId, byte ActionCode, string TableName = "", string ActionReason = "")
        {
            try
            {
                AccessLog newLogData = new AccessLog()
                {
                    ActionCode = ActionCode,
                    CreateTime = DateTime.Now,
                    DataId = DataId,
                    UserId = UserId,
                    DataTableName = TableName,
                    Reason = ActionReason
                };

                using (var db = RepositoryHelper.GetAccessLogRepository())
                {
                    db.Add(newLogData);
                    db.UnitOfWork.Commit();
                }

                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 檢查並更新來自資料庫的資料實體內容。
        /// </summary>
        /// <param name="source">來源資料實體物件(通常來自於前端UI的變更後資料內容)</param>
        /// <param name="target">目的資料實體物件(一定是來自資料庫的資料實體)</param>
        protected void CheckAndUpdateValue(dynamic source, dynamic target)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (target == null)
                throw new ArgumentNullException("target");

            Type sourcetype = ((object)source).GetType();
            Type targettype = ((object)target).GetType();

            foreach (var tarprop in targettype.GetProperties())
            {
                var sourceprop = sourcetype.GetProperty(tarprop.Name);

                if (sourceprop != null)
                {
                    if (sourceprop.PropertyType == tarprop.PropertyType)
                    {
                        if (sourceprop.PropertyType.IsGenericType && sourceprop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                        {
                            continue;
                        }

                        object sourcevalue = sourceprop.GetValue(source);
                        object targetvalue = tarprop.GetValue(target);

                        if (targetvalue != null)
                        {
                            if (sourcevalue != null && !targetvalue.Equals(sourcevalue))
                            {
                                tarprop.SetValue(target, sourcevalue);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (sourcevalue != null)
                            {
                                tarprop.SetValue(target, sourcevalue);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 傳回主索引鍵欄位的內容值。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object[] IdentifyPrimaryKey(T entity)
        {

            ObjectContext objectContext = ((IObjectContextAdapter)this.GetRepository<IUsersRepository, Users>().UnitOfWork.Context).ObjectContext;
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
    }
}
