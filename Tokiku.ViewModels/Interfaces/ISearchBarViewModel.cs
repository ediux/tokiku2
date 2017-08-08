using System.ComponentModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface ISearchBarViewModel : IBaseViewModel
    {
        ICommand QueryCommand { get; set; }
        ICommand RefreshCommand { get; set; }
        ICommand ResetCommand { get; set; }
        string SearchText { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}