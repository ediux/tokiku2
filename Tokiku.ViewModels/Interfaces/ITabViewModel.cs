using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public interface ITabViewModel : IBaseViewModel
    {
        string Header { get; set; }

        System.Type ViewType { get; set; }

        object ContentView { get; set; }

        bool CanClose { get; set; }
    }
}