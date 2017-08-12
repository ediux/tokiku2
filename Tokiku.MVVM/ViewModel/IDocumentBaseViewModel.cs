using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IDocumentBaseViewModel : IBaseViewModelWithLoginedUser
    {
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
        /// 取得或設定文件生命週期變更命令物件。
        /// </summary>
        ICommand ModeChangedCommand { get; set; }

        /// <summary>
        /// 查詢命令
        /// </summary>
        ICommand QueryCommand { get; set; }
        /// <summary>
        /// 儲存命令
        /// </summary>
        ICommand SaveCommand { get; set; }
        /// <summary>
        /// 新建命令
        /// </summary>
        ICommand CreateNewCommand { get; set; }
        /// <summary>
        /// 刪除命令
        /// </summary>
        ICommand DeleteCommand { get; set; }
        /// <summary>
        /// 處理轉送路由資料的命令
        /// </summary>
        ICommand RelayCommand { get; set; }
    }

    /// <summary>
    /// 以文件操作模式為基礎的UX檢視模型基底介面
    /// </summary>
    /// <typeparam name="T">文件對應的資料實體物件型別。</typeparam>
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

       
        /// <summary>
        /// 取得或設定文件生命週期變更命令物件。
        /// </summary>
        ICommand ModeChangedCommand { get; set; }
    }

   
}
