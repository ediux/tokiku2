using System.Data.Entity;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
	public partial interface IUnitOfWork : Tokiku.MVVM.Entities.IUnitOfWork
	{
		
        /// <summary>
        /// 提交資料庫變更要求的非同步方法。
        /// </summary>
        /// <returns>非同步執行結果。</returns>
        Task CommitAsync();
	}
}