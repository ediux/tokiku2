using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 生產製造管理相關資料存取服務
    /// </summary>
    public interface IManufacturingExecutionDataService : IManufacturersDataService, IBusinessItemsDataService, ISupplierTranscationDataService
    {
    }
}