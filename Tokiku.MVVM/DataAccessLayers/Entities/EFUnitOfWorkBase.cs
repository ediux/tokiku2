using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.MVVM.Entities
{
    public class EFUnitOfWorkBase : IUnitOfWork
    {
        //log4net
        static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DbContext _context;
        public DbContext Context { get { return _context; } set { _context = value; } }

        public EFUnitOfWorkBase()
        {

        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        public bool LazyLoadingEnabled
        {
            get
            {
                try
                {
                    return Context.Configuration.LazyLoadingEnabled;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                    throw ex;
                }
            }
            set
            {
                try
                {
                    Context.Configuration.LazyLoadingEnabled = value;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                }
            }
        }

        public bool ProxyCreationEnabled
        {
            get
            {
                try
                {
                    return Context.Configuration.ProxyCreationEnabled;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                    throw ex;
                }
            }
            set
            {
                try
                {
                    Context.Configuration.ProxyCreationEnabled = value;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return Context.Database.Connection.ConnectionString;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                    throw ex;
                }
            }
            set
            {
                try
                {
                    Context.Database.Connection.ConnectionString = value;
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 處置 Managed 狀態 (Managed 物件)。
                        _context.Dispose();
                    }

                    // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                    // TODO: 將大型欄位設為 null。

                    disposedValue = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("執行 '{0}' 方法時發生錯誤!", MethodBase.GetCurrentMethod().Name), ex);
            }

        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~EFUnitOfWork() {
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
