using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public interface IBaseController : IDisposable
    {
        IExecuteResultEntity<IUsers> GetCurrentLoginUser();
        IExecuteResultEntity<IUsers> GetUser(string UserName);
        IExecuteResultEntity<IUsers> Login(ILoginViewModel model);
        IExecuteResultEntity<IUsers> Login(string UserName, string Password);
    }

    public interface IBaseController<T> : IBaseController where T : class
    {
        bool IsExists(Expression<Func<T, bool>> filiter);
        IExecuteResultEntity<T> CreateNew();
        IExecuteResultEntity Add(T entity, bool isLastRecord = true);
        IExecuteResultEntity<ICollection<T>> Query(Expression<Func<T, bool>> filiter);
        IExecuteResultEntity<T> Update(T fromModel, bool isLastRecord = true);
        IExecuteResultEntity<T> Delete(T entity, bool isDeleteRightNow = false);
        IExecuteResultEntity<T> CreateOrUpdate(T entity,bool isLastRecord = true);
        IExecuteResultEntity<ICollection<T>> QueryAll(params object[] Parameters);
        IExecuteResultEntity<T> QuerySingle(params object[] Parameters);
    }
}