using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.DataServices
{
    public interface IEncodingSubSystemDataService : IDataService<EncodingRecords>
    {
        /// <summary>
        /// 取得下一組流水號編碼
        /// </summary>
        /// <param name="Name">編碼名稱</param>
        /// <param name="CodeFormat">編碼格式化字串</param>
        /// <param name="Parameters">傳入的額外引數內容值。</param>
        /// <returns>傳回新的流水號編碼字串。</returns>
        string GetNextCode(string Name, string CodeFormat, params object[] Parameters);
    }
}