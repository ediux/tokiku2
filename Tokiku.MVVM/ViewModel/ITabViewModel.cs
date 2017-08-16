using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public interface ITabViewModel : IBaseViewModel
    {
        string TabControlName { get; set; }

        string Header { get; set; }

        Type ViewType { get; set; }

        Type DataModelType { get; set; }

        object ContentView { get; set; }

        object SelectedObject { get; set; }

        bool CanClose { get; set; }

        bool IsNewModel { get; set; }
    }
}