

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
		/// 取得統一資料庫連線物件
		/// </summary>		
		IUnitOfWork UnitOfWork { get; set; }
		
		/// <summary>
		/// 取得Entity全部筆數的IQueryable。
		/// </summary>
		/// <returns>Entity全部筆數的IQueryable。</returns>
		IQueryable<T> All();

        /// <summary>
        /// 取得Entity全部筆數的IQueryable<<typeparamref name="T>"></typeparamref>>的非同步版本。
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> AllAsync();

		/// <summary>
		/// 篩選查詢結果。
		/// </summary>
		/// <returns>傳回符合查詢條件的結果</returns>
		IQueryable<T> Where(Expression<Func<T, bool>> expression);

		/// <summary>
		/// 加入指定的資料列
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
		/// 刪除指定資料列
		/// </summary>		
		void Delete(T entity);

        /// <summary>
        /// 依據傳入的主索引鍵值尋找符合的資料列並回傳。
        /// </summary>
        /// <param name="predicate">主索引鍵值(組)</param>
        /// <returns>傳回符合鍵值的資料列。</returns>
		T Get(params object[] values);

        /// <summary>
        /// 以非同步方法依據傳入的主索引鍵值尋找符合的資料列並回傳。
        /// </summary>
        /// <param name="values">主索引鍵值(組)</param>
        /// <returns>傳回符合鍵值的資料列。</returns>
        Task<T> GetAsync(params object[] values);

		/// <summary>
		/// 重新載入資料實體的同步方法。
		/// </summary>
		/// <param name="entity">Entity.</param>
		T Reload(T entity);

		/// <summary>
		/// 重新載入資料實體的非同步方法。
		/// </summary>
		/// <returns></returns>
		Task<T> ReloadAsync(T entity);
	}
}

