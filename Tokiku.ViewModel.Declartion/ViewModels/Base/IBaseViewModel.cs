using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

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
        /// 初始化作業。
        /// </summary>
        /// <remarks>
        /// 此方法可以視為當新建立資料時需要呼叫的方法。
        /// </remarks>
        void Initialized();

        /// <summary>
        /// 儲存單一或多個資料列的檢視模型元素時候對應的處理方法。
        /// </summary>
        /// <param name="isLast">指出是否為最後一筆?</param>
        void SaveModel(bool isLast = true);

        /// <summary>
        /// 儲存檢視模型的處理方法。
        /// </summary>
        void SaveModel();

        /// <summary>
        /// 取得儲存檢視模型時要調用的控制器名稱。(不含Controller後綴詞)
        /// </summary>
        /// <remarks>
        /// 此屬性預設回傳值為檢視模型名稱去掉ViewModel字眼的名稱當作預設控制器名稱，可以由衍生的類別改寫此屬性。
        /// </remarks>
        string ControllerName { get; }

        
    }
}