using System.ComponentModel;

namespace Tokiku.ViewModels
{
    public interface IToolbarButtonsViewModel:  INotifyPropertyChanged
    {
        bool CanAddColumn { get; set; }
        bool CanAddRow { get; set; }
        bool CanCancel { get; set; }
        bool CanClose { get; set; }
        bool CanCommit { get; set; }
        bool CanDelete { get; set; }
        bool CanEdit { get; set; }
        bool CanNew { get; set; }
        bool CanPrint { get; set; }
        bool CanQuery { get; set; }
        bool CanRunExcel { get; set; }
        bool CanSave { get; set; }
        bool CanUseFeatures { get; set; }

        void DisabledEditor();
        void EnableEditor();
    }
}