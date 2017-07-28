using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IMVVMCommand : ICommand
    {
        /// <summary>
        /// 命令文字
        /// </summary>
        string Text { get; set; }
    }
}
