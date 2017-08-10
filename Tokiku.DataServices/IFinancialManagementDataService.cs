using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.MVVM;
using Tokiku.Entity;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 財務管理資料服務介面
    /// </summary>
    public interface IFinancialManagementDataService : IDataService<PaymentTypes>, IDataService<TicketPeriod>, IDataService<PromissoryNoteManagement>
    {
    }
}