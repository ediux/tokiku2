using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 以資料實體為基底的檢視模型介面
    /// </summary>
    public interface IEntityBaseViewModel<T> : IBaseViewModel where T : class
    {
        void CreateNew();

        void Delete();

        void Load();

        void Save();

        void SetEntity(T entity);

        Expression<Func<T, bool>> Filiter { get; set; }

        /// <summary>
        /// 實體
        /// </summary>
        T Entity { get; }

        /// <summary>
        /// 實體類型
        /// </summary>
        Type EntityType { get; set; }

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
}