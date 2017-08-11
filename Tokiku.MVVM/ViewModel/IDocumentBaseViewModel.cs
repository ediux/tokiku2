using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IDocumentBaseViewModel<T> : IEntityBaseViewModel<T> where T : class
    {
        /// <summary>
        /// 資料識別碼
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// 文件狀態追蹤
        /// </summary>
        IDocumentStatusViewModel Status { get; set; }

        /// <summary>
        /// 文件操作模式
        /// </summary>
        DocumentLifeCircle Mode { get; set; }

        /// <summary>
        /// 文件的異動紀錄
        /// </summary>
        ObservableCollection<IAccessLogViewModel> AccessLogs { get; }

        /// <summary>
        /// 建立時間
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 建立人員識別碼
        /// </summary>
        Guid CreateUserId { get; set; }

        /// <summary>
        /// 建立人員
        /// </summary>
        IUserViewModel CreateUser { get; set; }

        /// <summary>
        /// 最後異動時間
        /// </summary>
        DateTime? LastUpdateDate { get; }

        /// <summary>
        /// 最後異動人員識別碼
        /// </summary>
        Guid? LastUpdateUserId { get; }

        /// <summary>
        /// 最後異動人員
        /// </summary>
        IUserViewModel LastUpadateUser { get; }

       

        ICommand ModeChangedCommand { get; set; }
    }

   
}
