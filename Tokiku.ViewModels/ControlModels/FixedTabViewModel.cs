using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public class FixedTabViewModel : TabViewModelBase, IFixedTabViewModel
    {
        public FixedTabViewModel()
        {
            _Mode = DocumentLifeCircle.None;
        }

        private DocumentLifeCircle _Mode;
        public DocumentLifeCircle Mode { get => _Mode; set { _Mode = value; RaisePropertyChanged("Mode"); } }
    }
}