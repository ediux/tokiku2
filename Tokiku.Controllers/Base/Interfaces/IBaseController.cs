using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IBaseController : IDisposable
    {
        IExecuteResultEntity<Users> GetCurrentLoginUser();
        IExecuteResultEntity<Users> GetUser(string UserName);
        IExecuteResultEntity<Users> Login(LoginViewModel model);
        IExecuteResultEntity<Users> Login(string UserName, string pwd);
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