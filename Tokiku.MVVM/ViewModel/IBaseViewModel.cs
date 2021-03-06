﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Tokiku.MVVM;

namespace Tokiku.ViewModels
{
    public interface IBaseViewModel
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