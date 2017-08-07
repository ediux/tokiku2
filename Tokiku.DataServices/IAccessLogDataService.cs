using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.DataServices
{
    public interface IAccessLogDataService : MVVM.IDataService
    {
        void AddAccessLog(string DataTableName, string DataId, object UserId, string Reason, ActionCodes Action);

        IUserViewModel GetLastUpdateUser(string DataTable, string DataId);

        DateTime? GetLastUpdateTime(string DataTable, string DataId);
    }
}