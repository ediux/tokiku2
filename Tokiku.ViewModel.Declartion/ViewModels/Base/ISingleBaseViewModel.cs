using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 單一資料元素檢視模型介面
    /// </summary>
    public interface ISingleBaseViewModel<TPOCO> : IBaseViewModelWithLoginedUser where TPOCO : class
    {
        /// <summary>
        /// 取得資料實體物件參考。
        /// </summary>
        TPOCO Entity { get; }

        /// <summary>
        /// 文件狀態追蹤模型
        /// </summary>
        IDocumentStatusViewModel Status { get; set; }

        /// <summary>
        /// 取得主表的檢視模型參考。
        /// </summary>
        /// <remarks>
        /// 如果是Master-Detail的檢視關聯的話請設定這個屬性內容，如果不是請永遠讓此屬性傳回NULL。
        /// </remarks>
        object Master { get; }
    }
}
