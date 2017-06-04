using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class ExecuteResultEntity : INotifyPropertyChanged, IDisposable
    {
        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get { return _Errors; } set { _Errors = value; if (_Errors != null) { _HasError = true; } else { _HasError = false; } RaisePropertyChanged("Errors"); RaisePropertyChanged("HasError"); } }
        private bool _HasError = false;
        public bool HasError { get { return _HasError; } set { _HasError = value; RaisePropertyChanged("HasError"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static ExecuteResultEntity CreateResultEntity()
        {
            return new ExecuteResultEntity() { Errors = null };
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。

                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~ExecuteResultEntity() {
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
        public static ExecuteResultEntity CreateErrorResultEntity(string ErrorMessage)
        {
            ExecuteResultEntity model = new ExecuteResultEntity();
            model.Errors = new string[] { ErrorMessage };
            return model;
        }

        public static ExecuteResultEntity CreateErrorResultEntity(Exception ex)
        {

            ExecuteResultEntity model = new ExecuteResultEntity();

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

            return model;
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

    public class ExecuteResultEntity<TEntity> : ExecuteResultEntity where TEntity : class
    {

        private TEntity _Result = default(TEntity);
        public TEntity Result { get { return _Result; } set { _Result = value; RaisePropertyChanged("Result"); } }

        public static ExecuteResultEntity<TEntity> CreateResultEntity(TEntity entity)
        {
            return new ExecuteResultEntity<TEntity>() { Errors = null, Result = entity };
        }

        public new static ExecuteResultEntity<TEntity> CreateErrorResultEntity(Exception ex)
        {
            var error = ExecuteResultEntity.CreateErrorResultEntity(ex);
            return new ExecuteResultEntity<TEntity>() { Errors = error.Errors, Result = null };
        }

        public new static ExecuteResultEntity<TEntity> CreateErrorResultEntity(string ErrorMessage)
        {
            ExecuteResultEntity<TEntity> model = new ExecuteResultEntity<TEntity>();
            model.Errors = new string[] { ErrorMessage };
            return model;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Result = null;
            }
        }

    }
}
