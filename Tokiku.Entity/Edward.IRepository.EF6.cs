

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tokiku.Entity
{ 
	public partial interface IRepositoryBase<T> :IDisposable
		where T : class
	{
		IUnitOfWork UnitOfWork { get; set; }
		
		/// <summary>
		/// ���oEntity�������ƪ�IQueryable�C
		/// </summary>
		/// <returns>Entity�������ƪ�IQueryable�C</returns>
		IQueryable<T> All();
        /// <summary>
        /// ���oEntity�������ƪ�IQueryable<<typeparamref name="T>"></typeparamref>>���D�P�B�����C
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> AllAsync();

		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		T Add(T entity);

		/// <summary>
		/// Batchs the create.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="entities">Entities.</param>
		IList<T> BatchAdd(IEnumerable<T> entities);
		
		void Delete(T entity);

        /// <summary>
        /// �̾ڶǤJ���D������ȴM��ŦX����ƦC�æ^�ǡC
        /// </summary>
        /// <param name="predicate">�D�������(��)</param>
        /// <returns>�Ǧ^�ŦX��Ȫ���ƦC�C</returns>
		T Get(params object[] values);

        /// <summary>
        /// �H�D�P�B��k�̾ڶǤJ���D������ȴM��ŦX����ƦC�æ^�ǡC
        /// </summary>
        /// <param name="values">�D�������(��)</param>
        /// <returns>�Ǧ^�ŦX��Ȫ���ƦC�C</returns>
        Task<T> GetAsync(params object[] values);

		/// <summary>
		/// Reload the specified entity.
		/// </summary>
		/// <param name="entity">Entity.</param>
		T Reload(T entity);

		Task<T> ReloadAsync(T entity);
	}
}

