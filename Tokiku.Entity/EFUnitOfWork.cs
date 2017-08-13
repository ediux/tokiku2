using System.Data.Entity;
using System.Threading.Tasks;
using Tokiku.MVVM.Entities;

namespace Tokiku.Entity
{
	public partial class EFUnitOfWork : EFUnitOfWorkBase, IUnitOfWork
	{
		public EFUnitOfWork()
		{
			Context = new TokikuEntities();
		}
	
		public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }
	}
}
