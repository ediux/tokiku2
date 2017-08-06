using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.MVVM
{
    /// <summary>
    /// 資料存取服務基底類別!
    /// 使用MVVM Light Toolkit
    /// </summary>
    public class DataServiceBase<TModel> : IDataService<TModel> where TModel : ViewModelBase
    {

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

        public TModel Add(TModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> AddRange(IEnumerable<TModel> models)
        {
            throw new NotImplementedException();
        }

        public TModel GetSingle(Expression<Func<TModel, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public TModel Update(TModel Source, Expression<Func<TModel, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> UpdateRange(IEnumerable<TModel> MultiSource, Expression<Func<TModel, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(TModel model)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveWhere(Expression<Func<TModel, bool>> filiter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> DirectExecuteSQL(string tsql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}