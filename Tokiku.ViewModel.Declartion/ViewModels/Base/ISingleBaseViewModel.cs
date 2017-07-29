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
        /// 取得或設定對應的資料實體
        /// </summary>
        Type EntityType { get; set; }

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
        IMultiBaseViewModel<ISingleBaseViewModel<TPOCO>, TPOCO> Details { get; }

        #region 共用資料屬性

        /// <summary>
        /// 資料識別碼
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 建立人員ID
        /// </summary>
        Guid CreateUserId { get; set; }

        /// <summary>
        /// 建立人員
        /// </summary>
        IUserViewModel CreateUser { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        DateTime? LastUpdateDate { get; set; }

        /// <summary>
        /// 最後更新人員ID
        /// </summary>
        Guid? LastUpdateUserId { get; set; }

        /// <summary>
        /// 最後更新人員
        /// </summary>
        IUserViewModel LastUpdateUser { get; set; }
        #endregion

        /// <summary>
        /// 查詢
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TView Query<TView>(params object[] parameters) where TView : ISingleBaseViewModel<TPOCO>;
    }
}
