using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 系統核心資料存取服務介面
    /// </summary>
    public interface ICoreDataService : IUserDataService, IContactsDataService, IRoleDataService, IAccessLogDataService
    {
    }
}