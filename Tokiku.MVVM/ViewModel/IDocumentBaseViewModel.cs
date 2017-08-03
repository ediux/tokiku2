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
    public interface IDocumentBaseViewModel<T> : IBaseViewModel where T : class
    {
        void CreateNew();

        void Delete();

        void Load();

        void Save();

        Expression<Func<T,bool>> Filiter { get; set; }

        /// <summary>
        /// 實體
        /// </summary>
        T Entity { get; }

        /// <summary>
        /// 實體類型
        /// </summary>
        Type EntityType { get; set; }

        /// <summary>
        /// 文件狀態追蹤
        /// </summary>
        IDocumentStatusViewModel Status { get; set; }

        /// <summary>
        /// 文件操作模式
        /// </summary>
        DocumentLifeCircle Mode { get; set; }

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
    }

    public interface IDocumentBaseViewModel<TMaster, TDetail> : IDocumentBaseViewModel<TMaster>
        where TMaster : class
        where TDetail : class
    {
        TDetail DetailsEntity { get; }

        Type DetailsEntityType { get; set; }
    }

    public interface IDocumentBaseViewModel<TMaster, TDetail, TDetail2> : IDocumentBaseViewModel<TMaster, TDetail>
        where TMaster : class
        where TDetail : class
        where TDetail2 : class
    {
        TDetail2 SecondDetailsEntity { get; }

        Type SecondDetailsEntityType { get; set; }
    }

    public interface IDocumentBaseViewModel<TMaster, TDetail, TDetail2,TDetail3> : IDocumentBaseViewModel<TMaster, TDetail, TDetail2>
        where TMaster : class
        where TDetail : class
        where TDetail2 : class
        where TDetail3 : class
    {
        TDetail3 ThirdDetailsEntity { get; }

        Type ThirdDetailsEntityType { get; set; }
    }
}
