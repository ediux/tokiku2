using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 資料存取歷史紀錄存取服務
    /// </summary>
    public interface IAccessLogDataService : MVVM.IDataService
    {
        void AddAccessLog(string DataTableName, string DataId, object UserId, string Reason, ActionCodes Action, bool isLastRecord = true);

        IUserViewModel GetLastUpdateUser(string DataTable, string DataId);

        DateTime? GetLastUpdateTime(string DataTable, string DataId);
    }
}