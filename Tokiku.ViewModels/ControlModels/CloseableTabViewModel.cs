using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public class CloseableTabViewModel : TabViewModelBase, ICloseableTabViewModel
    {
        public CloseableTabViewModel()
        {
            _Mode = DocumentLifeCircle.None;
            _CloseTabCommand = new RelayCommand(ProcessCloseHandler);
            _CanClose = true;
        }


        private ICommand _CloseTabCommand;
        public ICommand CloseTabCommand { get => _CloseTabCommand; set { _CloseTabCommand = value; RaisePropertyChanged("CloseTabCommand"); } }
        private DocumentLifeCircle _Mode;
        public DocumentLifeCircle Mode { get =>_Mode; set { _Mode = value; RaisePropertyChanged<DocumentLifeCircle>("Mode", broadcast: true); } }

        public override bool CanClose { get => true; set { RaisePropertyChanged("CanClose"); } }

        private void ProcessCloseHandler()
        {

        }
    }
}