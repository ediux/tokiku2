using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    /// <summary>
    /// 聯絡人資料存取服務
    /// </summary>
    /// <remarks>此服務屬於使用者帳號資料存取服務之一</remarks>
    public interface IContactsDataService : IDataService<Contacts>
    {
        #region 聯絡人
        /// <summary>
        /// 搜尋聯絡人用
        /// </summary>
        /// <param name="filiter"></param>
        /// <param name="ManufactoryId"></param>
        /// <param name="isClient"></param>
        /// <returns></returns>
        ICollection<Contacts> SearchByText(string filiter, Guid ManufactoryId, bool isClient);
        #endregion
    }
}