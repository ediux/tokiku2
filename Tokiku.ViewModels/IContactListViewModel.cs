using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 聯絡人清單檢視模型
    /// </summary>
    public interface IContactListViewModel : IBaseViewModel
    {
        DocumentLifeCircle Mode { get; set; }
        ObservableCollection<IContactsViewModel> ContractsList { get; set; }
    }
}