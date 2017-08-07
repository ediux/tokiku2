using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface ICloseableTabViewModel : ITabViewModel
    {
        DocumentLifeCircle Mode { get; set; }
        ICommand CloseTabCommand { get; set; }
    }
}