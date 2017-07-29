using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IMultiBaseViewModel<TView, TEntity> : IBaseViewModel, System.Collections.Generic.ICollection<TView> 
        where TView : ISingleBaseViewModel<TEntity> 
        where TEntity : class
    {
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
        /// 取得關聯的子表資料檢視模型
        /// </summary>
        TView Master { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TCollection QueryAll<TCollection>(params object[] parameters) where TCollection : IMultiBaseViewModel<TView, TEntity>;
    }
}
