using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public partial class EFRepository<T> : IRepositoryBase<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        private IDbSet<T> _objectset;
        protected IDbSet<T> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = UnitOfWork.Context.Set<T>();
                }
                _objectset.Load();
                return _objectset;
            }
        }

        /// <summary>
        /// 傳回主索引鍵欄位的內容值。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object[] IdentifyPrimaryKey(T entity)
        {

            ObjectContext objectContext = ((IObjectContextAdapter)UnitOfWork.Context).ObjectContext;
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

        public virtual IQueryable<T> All()
        {

            return ObjectSet.Local.AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return ObjectSet.Local.AsQueryable().Where(expression);
        }

        public virtual T Add(T entity)
        {
            ObjectSet.Local.Add(entity);
            return Get(IdentifyPrimaryKey(entity));
        }

        public virtual void Delete(T entity)
        {
            ObjectSet.Local.Remove(entity);            
        }

        public Task<IQueryable<T>> AllAsync()
        {
            return Task.FromResult(All());
        }

        public IList<T> BatchAdd(IEnumerable<T> entities)
        {
            return ((DbSet<T>)ObjectSet).AddRange(entities).ToList();
        }

        public T Get(params object[] values)
        {
            return ObjectSet.Find(values);
        }

        public Task<T> GetAsync(params object[] values)
        {
            return Task.FromResult(Get(values));
        }

        public T Reload(T entity)
        {
            UnitOfWork.Context.Entry(entity).Reload();
            return entity;
        }

        public async Task<T> ReloadAsync(T entity)
        {
            await UnitOfWork.Context.Entry(entity).ReloadAsync();
            return entity;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //UnitOfWork.Commit();
                    UnitOfWork.Context.Dispose();
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~EFRepository() {
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
    }
}