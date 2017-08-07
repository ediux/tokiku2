using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 存取記錄檢視模型
    /// </summary>
    public interface IAccessLogViewModel : IBaseViewModel
    {
        string AccessUser { get; }
        ActionCodes Action { get; }
        string Reason { get; }
        DateTime AccessTime { get; }
    }
}
