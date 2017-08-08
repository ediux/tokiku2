using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public interface IFixedTabViewModel : ITabViewModel
    {
         DocumentLifeCircle Mode { get; set; }
    }
}