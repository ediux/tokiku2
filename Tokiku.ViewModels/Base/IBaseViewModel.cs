using System.Collections.Generic;
using System.ComponentModel;

namespace Tokiku.ViewModels
{

    public interface IBaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        bool HasError { get; set; }

        /// <summary>
        /// 對模型發出查詢命令，將查詢回來的單一列結果抄寫到檢視模型中
        /// </summary>
        /// <remarks>
        /// 查詢條件就是本身的屬性內容，所以不需要額外參數。
        /// 如果有屬於特殊條件查詢但不存在於本身的屬性時，請自行宣告方法。
        /// </remarks>
        void Query();

        /// <summary>
        /// 初始化作業。
        /// </summary>
        void Initialized();

        /// <summary>
        /// 重新整理檢視模型
        /// </summary>
        void Refresh();

        /// <summary>
        /// 儲存或更新檢視模型
        /// </summary>
        void SaveModel();

        /// <summary>
        /// 依據來源實體設定檢視模型內容。
        /// </summary>
        /// <param name="entity">傳入的實體物件</param>
        void SetModel(dynamic entity);
    }


}