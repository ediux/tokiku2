using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public static class RepositoriesStorageHelper
    {
        /// <summary>
        /// 統一資料庫連線物件。
        /// </summary>
        private static IUnitOfWork database;

        private static HashSet<object> RepositoriesTable = new HashSet<object>();

        public static IRepositoryBase<T> GetReoisitory<T>(this IBaseController controller) where T : class
        {
            try
            {
                if (database == null)
                    database = RepositoryHelper.GetUnitOfWork();

                var searchResult = RepositoriesTable.OfType<IRepositoryBase<T>>();

                if (searchResult.Any())
                {
                    return searchResult.Single();
                }

                Type type = typeof(T);

                Type RepositoryType = typeof(RepositoryHelper);

                if (RepositoryType != null)
                {
                    MethodInfo GetRepositoryMethod = RepositoryType.GetMethod(string.Format("Get{0}Repository", type.Name), new Type[] { typeof(IUnitOfWork) });



                    if (GetRepositoryMethod != null)
                    {
                        IRepositoryBase<T> repositoryobject = (IRepositoryBase<T>)GetRepositoryMethod.Invoke(null, new object[] { database });
                        RepositoriesTable.Add(repositoryobject);
                        return repositoryobject;
                    }
                    else
                        throw new NotImplementedException(string.Format("Function of Get{0}Repository not found or not implemented.", type.Name));
                }

                throw new NotImplementedException(string.Format("Repository of {0} can't found.", typeof(IRepositoryBase<T>).Name));
            }
            catch
            {
                throw;
            }
        }

        public static IRepositoryBase<T> GetReoisitory<T>(this IBaseController<T> controller) where T : class
        {
            try
            {
                return GetReoisitory<T>((IBaseController)controller);
            }
            catch
            {
                throw;
            }
        }
    }
}
