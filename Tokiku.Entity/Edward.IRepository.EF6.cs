

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
		/// <summary>
		/// ���o�Τ@��Ʈw�s�u����
		/// </summary>		
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

		/// <summary>
		/// �z��d�ߵ��G�C
		/// </summary>
		/// <returns>�Ǧ^�ŦX�d�߱��󪺵��G</returns>
		IQueryable<T> Where(Expression<Func<T, bool>> expression);

		/// <summary>
		/// �[�J���w����ƦC
		/// </summary>
		/// <returns></returns>
		T Add(T entity);

		/// <summary>
		/// Batchs the create.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="entities">Entities.</param>
		IList<T> BatchAdd(IEnumerable<T> entities);

		/// <summary>
		/// �R�����w��ƦC
		/// </summary>		
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
		/// ���s���J��ƹ��骺�P�B��k�C
		/// </summary>
		/// <param name="entity">Entity.</param>
		T Reload(T entity);

		/// <summary>
		/// ���s���J��ƹ��骺�D�P�B��k�C
		/// </summary>
		/// <returns></returns>
		Task<T> ReloadAsync(T entity);
	}
}

