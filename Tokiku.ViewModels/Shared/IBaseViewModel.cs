using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Tokiku.ViewModels
{

    public interface IBaseViewModel
    {
        /// <summary>
        /// 指出是否可以建立新資料
        /// </summary>
        bool CanNew { get; set; }
        /// <summary>
        /// 指出是否可以存檔?
        /// </summary>
        bool CanSave { get; set; }
        /// <summary>
        /// 指出是否可以被刪除(停用)
        /// </summary>
        bool CanDelete { get; set; }
        /// <summary>
        /// 指出是否可以被編輯
        /// </summary>
        bool CanEdit { get; set; }

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// 指出是否發生錯誤
        /// </summary>
        bool HasError { get; set; }

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        bool IsModify { get; set; }
        /// <summary>
        /// 指出目前是否處於初始化狀態
        /// </summary>
        bool IsNewInstance { get; set; }
        /// <summary>
        /// 是否已存檔?
        /// </summary>
        bool IsSaved { get; set; }

        bool CanQuery { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void DisabledEditor();
        void EnableEditor();
    }

    public interface IBaseViewModelWithLoginedUser : IBaseViewModel
    {
        UserViewModel LoginedUser { get; set; }
    }
}