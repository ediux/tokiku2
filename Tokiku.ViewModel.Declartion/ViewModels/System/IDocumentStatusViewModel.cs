using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public interface IDocumentStatusViewModel : IBaseViewModel
    {
        /// <summary>
        /// 指出目前是否處於初始化狀態
        /// </summary>
        bool IsNewInstance { get; set; }

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        bool IsModify { get; set; }

        /// <summary>
        /// 是否已存檔?
        /// </summary>
        bool IsSaved { get; set; }
       
    }
}
