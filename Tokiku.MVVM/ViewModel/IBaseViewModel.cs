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

  

        
    }
}