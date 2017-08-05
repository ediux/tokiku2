using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tokiku.MVVM
{
    /// <summary>
    /// 定義可以同時存取多個Repository的資料服務介面。以利提供複雜類型的資料存取動作!(ORM)
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        IEnumerable<string> Errors { get; set; }
        /// <summary>
        /// 指出是否發生錯誤?
        /// </summary>
        bool HasError { get; set; }

        /// <summary>
        /// 將單一檢視模型中資料新增到資料庫的方法。
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        TModel Add<TModel>(TModel model) where TModel : Tokiku.ViewModels.IBaseViewModel;
        /// <summary>
        /// 將多個檢視模型中的資料新增到資料庫的方法。
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="models"></param>
        /// <returns></returns>
        IEnumerable<TModel> AddRange<TModel>(IEnumerable<TModel> models) where TModel : Tokiku.ViewModels.IBaseViewModel;
        /// <summary>
        /// 依據條件表示式傳回資料庫單一查詢結果。
        /// </summary>
        /// <typeparam name="TModel">要查詢的檢視模型。</typeparam>
        /// <param name="filiter">條件表示式。</param>
        /// <returns></returns>
        TModel GetSingle<TModel>(Expression<Func<TModel,bool>> filiter) where TModel : Tokiku.ViewModels.IBaseViewModel;
        /// <summary>
        /// 依據條件表示式傳回資料庫查詢結果。
        /// </summary>
        /// <typeparam name="TModel">要查詢的檢視模型。</typeparam>
        /// <param name="filiter">條件表示式。</param>
        /// <returns></returns>
        IEnumerable<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filiter=null) where TModel : Tokiku.ViewModels.IBaseViewModel;
        /// <summary>
        /// 將單一檢視模型中資料更新到資料庫的方法。
        /// </summary>
        /// <typeparam name="TModel">要查詢的檢視模型。</typeparam>
        /// <param name="Source"></param>
        /// <param name="filiter">條件表示式。</param>
        /// <returns></returns>
        TModel Update<TModel>(TModel Source, Expression<Func<TModel, bool>> filiter = null) where TModel : Tokiku.ViewModels.IBaseViewModel;
        /// <summary>
        /// 更新多筆檢視模型中的資料到資料庫中。
        /// </summary>
        /// <typeparam name="TModel">要查詢的檢視模型。</typeparam>
        /// <param name="MultiSource">多個檢視模型來源</param>
        /// <param name="filiter">條件表示式。</param>
        /// <returns></returns>
        IEnumerable<TModel> UpdateRange<TModel>(IEnumerable<TModel> MultiSource, Expression<Func<TModel, bool>> filiter = null);
        /// <summary>
        /// 移除指定檢視模型中的資料庫資料。
        /// </summary>
        /// <typeparam name="TModel">要操作的檢視模型</typeparam>
        /// <param name="model"></param>
        void Remove<TModel>(TModel model);
        /// <summary>
        /// 清除相關資料表內的所有資料。
        /// </summary>
        void RemoveAll();
        /// <summary>
        /// 針對過濾條件進行刪除作業的方法。
        /// </summary>
        /// <typeparam name="TModel">操作的檢視模型</typeparam>
        /// <param name="filiter">過濾條件表示式</param>
        void RemoveWhere<TModel>(Expression<Func<TModel, bool>> filiter = null);
        /// <summary>
        /// 直接對資料庫下查詢句柄。
        /// </summary>
        /// <typeparam name="TModel">接收查詢結果的資料模型。</typeparam>
        /// <param name="tsql">參數化TSQL字串</param>
        /// <param name="parameters">要傳遞的參數集合。</param>
        /// <returns>傳回查詢結果集合。</returns>
        IEnumerable<TModel> DirectExecuteSQL<TModel>(string tsql,params object[] parameters);
    }
}