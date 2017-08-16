using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 客戶管理資料存取服務
    /// </summary>
    public interface IClientDataService : IDataService<Manufacturers>
    {
        Manufacturers CreateNew();
    }
}