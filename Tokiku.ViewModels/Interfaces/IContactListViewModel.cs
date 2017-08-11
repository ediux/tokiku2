using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    /// <summary>
    /// 聯絡人清單檢視模型
    /// </summary>
    public interface IContactListViewModel : IDocumentBaseViewModel<Contacts>
    {      
        ObservableCollection<IContactsViewModel> ContractsList { get; set; }
    }
}