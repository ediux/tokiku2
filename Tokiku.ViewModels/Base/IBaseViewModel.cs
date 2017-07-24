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
        void Initialized(object Parameter);

        void SaveModel(string ControllerName);

        void SaveModel();

        string SaveModelController { get; }

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