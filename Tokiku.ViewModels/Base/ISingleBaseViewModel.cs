using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public interface ISingleBaseViewModel : IBaseViewModel
    {
        void SaveModel(string ControllerName, bool isLast = true);

        Type EntityType { get; set; }

        DocumentStatusViewModel Status { get; set; }
    }
}
