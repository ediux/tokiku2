﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.MVVM;
using Tokiku.Entity;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 財務管理資料存取服務介面
    /// </summary>
    public interface IFinancialManagementDataService : ITicketPeriodDataService, IMaterialCategoryDataService, IPaymentTypesDataService, IPromissoryNoteManagementDataService
    {
    }
}