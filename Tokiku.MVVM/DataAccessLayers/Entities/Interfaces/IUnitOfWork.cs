using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.MVVM.Entities
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }

        /// <summary>
        /// 提交資料庫變更耀球的非同步方法。
        /// </summary>
		void Commit();
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }

    }
}
