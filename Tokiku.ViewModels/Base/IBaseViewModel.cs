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
        void Initialized();

        void SaveModel(string ControllerName);

        void SaveModel();

        string SaveModelController { get; }

        ICommand SaveCommand { get; set; }
        ICommand CreateNewCommand { get; set; }
        ICommand ReplyCommand { get; set; }
    }

    public interface ISingleBaseViewModel : IBaseViewModel
    {
        void SaveModel(string ControllerName, bool isLast = true);

        Type EntityType { get; set; }

        DocumentStatusViewModel Status { get; set; }
    }
}