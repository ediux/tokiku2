using System.Data.Entity;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
	public partial class EFUnitOfWork : IUnitOfWork
	{
		private DbContext _context;
		public DbContext Context { get{ return _context;} set{ _context=value; } }

		public EFUnitOfWork()
		{
            _context = new TokikuEntities();
		}

		public void Commit()
		{
			Context.SaveChanges();

        }
		
		public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public bool ProxyCreationEnabled
		{
			get { return Context.Configuration.ProxyCreationEnabled; }
			set { Context.Configuration.ProxyCreationEnabled = value; }
		}
		
		public string ConnectionString
		{
			get { return Context.Database.Connection.ConnectionString; }
			set { Context.Database.Connection.ConnectionString = value; }
		}

        #region IDisposable Support
        private bool disposedValue = false; // �����h�l���I�s

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: �B�m Managed ���A (Managed ����)�C
                    _context.Dispose();
                }

                // TODO: ���� Unmanaged �귽 (Unmanaged ����) ���мg�U�誺�������C
                // TODO: �N�j�����]�� null�C

                disposedValue = true;
            }
        }

        // TODO: �ȷ�W�誺 Dispose(bool disposing) �㦳�|���� Unmanaged �귽���{���X�ɡA�~�мg�������C
        // ~EFUnitOfWork() {
        //   // �Ф��ܧ�o�ӵ{���X�C�бN�M���{���X��J�W�誺 Dispose(bool disposing) ���C
        //   Dispose(false);
        // }

        // �[�J�o�ӵ{���X���ت��b���T��@�i�B�m���Ҧ��C
        public void Dispose()
        {
            // �Ф��ܧ�o�ӵ{���X�C�бN�M���{���X��J�W�誺 Dispose(bool disposing) ���C
            Dispose(true);
            // TODO: �p�G�W�誺�������w�Q�мg�A�Y�����U�檺���Ѫ��A�C
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
