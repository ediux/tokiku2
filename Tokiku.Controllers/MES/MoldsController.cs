using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class MoldsController : BaseController
    {
        public Task<ExecuteResultEntity<ICollection<Molds>>> Query()
        {
            try
            {
                var repo = RepositoryHelper.GetMoldsRepository();
                database = repo.UnitOfWork;
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<Molds>>.CreateResultEntity(
                        new Collection<Molds>(repo.All().ToList())));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<Molds>>.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 傳回主索引鍵欄位的內容值。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected object[] IdentifyPrimaryKey<T>(T entity) where T : class
        {

            ObjectContext objectContext = ((IObjectContextAdapter)database.Context).ObjectContext;
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

        public Task<ExecuteResultEntity<ICollection<Molds>>> QueryAsync(Expression<Func<Molds, bool>> filiter)
        {
            try
            {
                var repo = RepositoryHelper.GetMoldsRepository();
                database = repo.UnitOfWork;
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<Molds>>.CreateResultEntity(
                       new Collection<Molds>(repo.Where(filiter).ToList())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<Molds>>.CreateErrorResultEntity(ex));
            }
        }

        public Task<ExecuteResultEntity<ICollection<MoldUseStatus>>> QueryAsync(Expression<Func<MoldUseStatus, bool>> filiter)
        {
            try
            {
                var repo = RepositoryHelper.GetMoldUseStatusRepository();
                database = repo.UnitOfWork;
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<MoldUseStatus>>.CreateResultEntity(
                       new Collection<MoldUseStatus>(repo.Where(filiter).ToList())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    ExecuteResultEntity<ICollection<MoldUseStatus>>.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 用來作為匯入用的儲存方法
        /// </summary>
        /// <param name="entityCollection"></param>
        /// <returns></returns>
        public Task<ExecuteResultEntity> CreateOrUpdateAsync(ICollection<Molds> entityCollection)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return Task.FromResult(ExecuteResultEntity.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name)));

                    database = repo.UnitOfWork;

                    if (entityCollection.Any())
                    {
                        int c = 1;
                        foreach (var entity in entityCollection)
                        {
                            if (repo.Get(entity.Id) != null)
                            {
                                var update_result = Update(entity, c == entityCollection.Count);
                                if (update_result.HasError)
                                {
                                    c++;
                                    continue;
                                }

                            }
                            else
                            {
                                var add_result = Add(entity, c == entityCollection.Count);
                                if (add_result.HasError)
                                {
                                    c++;
                                    continue;
                                }
                            }
                            c++;
                        }
                    }

                    return Task.FromResult(ExecuteResultEntity.CreateResultEntity());

                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity.CreateErrorResultEntity(ex));
            }
        }

        /// <summary>
        /// 加入單一資料列到資料庫。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity Add(Molds entity, bool isLastRecord = true)
        {
            try
            {

                var repo = RepositoryHelper.GetMoldsRepository(database);
                database = repo.UnitOfWork;
                if (repo == null)
                    return ExecuteResultEntity.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                entity = repo.Add(entity);

                if (isLastRecord)
                {
                    repo.UnitOfWork.Commit();
                    database = repo.UnitOfWork;
                    repo.UnitOfWork.Context.Set<Molds>().Attach(entity);
                    entity = repo.Reload(entity);
                }

                return ExecuteResultEntity.CreateResultEntity();

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ExecuteResultEntity<Molds> Update(Molds fromModel, bool isLastRecord = true)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return ExecuteResultEntity<Molds>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                    database = repo.UnitOfWork;

                    Molds findresult = repo.Get(IdentifyPrimaryKey(fromModel));

                    if (findresult != null)
                    {
                        CheckAndUpdateValue(fromModel, findresult);

                        if (isLastRecord)
                        {
                            repo.UnitOfWork.Commit();
                            database = repo.UnitOfWork;
                            findresult = repo.Get(IdentifyPrimaryKey(findresult));
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(findresult);
                    }
                }
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity("Data not found.");
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity(ex);
            }

        }
        /// <summary>
        /// 儲存或更新資料庫
        /// </summary>
        /// <param name="model"></param>
        public virtual ExecuteResultEntity<Molds> CreateOrUpdate(Molds entity)
        {
            try
            {
                using (var repo = RepositoryHelper.GetMoldsRepository())
                {
                    if (repo == null)
                        return ExecuteResultEntity<Molds>.CreateErrorResultEntity(string.Format("Can't found data repository of {0}.", typeof(Molds).Name));

                    database = repo.UnitOfWork;

                    if (repo.Get(IdentifyPrimaryKey(entity)) != null)
                    {
                        var update_result = Update(entity);

                        if (update_result.HasError)
                        {
                            update_result.Result = entity;
                            return update_result;
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(update_result.Result);
                    }
                    else
                    {
                        var add_result = Add(entity);
                        if (add_result.HasError)
                        {
                            return new ExecuteResultEntity<Molds>()
                            {
                                Errors = add_result.Errors,
                                Result = entity
                            };
                        }

                        return ExecuteResultEntity<Molds>.CreateResultEntity(entity);
                    }

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Molds>.CreateErrorResultEntity(ex);
            }
        }

    }
}
