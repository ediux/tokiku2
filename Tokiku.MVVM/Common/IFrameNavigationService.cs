using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public interface IFrameNavigationService :INavigationService
    {
        /// <summary>
        /// 取得或設定傳遞的參數物件。
        /// </summary>
        object Parameter { get;  }

        /// <summary>
        /// 跳轉到另一個畫面或視窗。
        /// </summary>
        /// <param name="pageKey">要跳轉的鍵值名稱。</param>
        /// <param name="parameter">要傳遞的參數。</param>
        /// <param name="isModal">指出是否使用對話框顯示模式?</param>
        void NavigateTo(string pageKey, object parameter,bool isModal);

        void Configure(string key, Uri pageType, Type elementtype = null);

        void AutoConfigure();
    }
}