using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 聯絡人清單檢視模型
    /// </summary>
    public interface IContactListViewModel : IBaseViewModel
    {
        ICommand QueryCommand { get; set; }
        ICommand SaveCommand { get; set; }
        ICommand ModeChangedCommand { get; set; }
        DocumentLifeCircle Mode { get; set; }
        ObservableCollection<IContactsViewModel> ContractsList { get; set; }
    }
}