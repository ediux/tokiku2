using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM.Entities;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    public abstract class DataServiceBase : IDataService
    {
        public DataServiceBase()
        {
            _Errors = new string[] { };
            _HasError = false;
        }

        private IEnumerable<string> _Errors;
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }

        private bool _HasError;
        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        public bool HasError { get => _HasError; set => _HasError = value; }

        /// <summary>
        /// 取得資料庫儲存庫物件。
        /// </summary>        
        /// <typeparam name="TRepository"></typeparam>
        /// <returns>回傳指定資料表的儲存庫物件。</returns>
        protected TRepository GetRepository<TRepository>()
        {
            return SimpleIoc.Default.GetInstance<TRepository>();
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected  void setErrortoModel( Exception ex)
        {
          

            List<string> _Messages = new List<string>();
            ScanErrorMessage(ex, _Messages);

            if (_Errors == null)
                _Errors = new string[] { }.AsEnumerable();

            _Errors = _Messages.AsEnumerable();

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected void setErrortoModel(string Message)
        {
          

            if (_Errors == null)
                _Errors = new string[] { }.AsEnumerable();

            _Errors = new string[] { Message };
        }

        /// <summary>
        /// 掃描深度錯誤訊息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="messageQueue"></param>
        private void ScanErrorMessage(Exception ex, List<string> messageQueue)
        {
            if (ex.InnerException != null)
            {
                ScanErrorMessage(ex.InnerException, messageQueue);
            }

            messageQueue.Add(ex.Message);

        }
    }
    /// <summary>
    /// 資料存取服務基底類別!
    /// 使用MVVM Light Toolkit
    /// </summary>
    public abstract class DataServiceBase<TModel> : DataServiceBase, IDataService<TModel>
    {
        public DataServiceBase()
        {

        }

        public DataServiceBase(TModel model) : base()
        {

        }

        private TModel _ViewModel = default(TModel);

        protected TModel ViewModel { get => _ViewModel; set => _ViewModel = value; }

        protected Type GetEntityType(TModel model)
        {
            var prop_entity = typeof(TModel).GetProperty("EntityType");
            if (prop_entity != null)
            {
                return (Type)prop_entity.GetValue(model);
            }
            return null;
        }

        protected object GetEntity(TModel model)
        {
            var prop_entity = typeof(TModel).GetProperty("Entity");

            if (prop_entity != null)
            {
                return prop_entity.GetValue(model);
            }
            return null;
        }

        public virtual IEnumerable<TModel> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            return SimpleIoc.Default.GetInstance<IUnitOfWork>().Context.Database.SqlQuery<TModel>(tsql, parameters).AsEnumerable();
        }

        public abstract TModel Add(TModel model);
        public abstract IEnumerable<TModel> AddRange(IEnumerable<TModel> models);
        public abstract TModel GetSingle(Expression<Func<TModel, bool>> filiter);
        public abstract IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filiter = null);
        public abstract TModel Update(TModel Source, Expression<Func<TModel, bool>> filiter = null);
        public abstract IEnumerable<TModel> UpdateRange(IEnumerable<TModel> MultiSource, Expression<Func<TModel, bool>> filiter = null);
        public abstract void Remove(TModel model);
        public abstract void RemoveAll();
        public abstract void RemoveWhere(Expression<Func<TModel, bool>> filiter = null);
        public abstract ICollection<TModel> SearchByText(string filiter);
        public abstract void CreateOrUpdate(TModel Model);
        public abstract void CreateOrUpdate(IEnumerable<TModel> Model);
        
    }
}