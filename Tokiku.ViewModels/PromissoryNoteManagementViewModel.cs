using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class PromissoryNoteManagementViewModelCollection : BaseViewModelCollection<PromissoryNoteManagementViewModel>
    {
        public PromissoryNoteManagementViewModelCollection()
        {
            HasError = false;
        }

        public PromissoryNoteManagementViewModelCollection(IEnumerable<PromissoryNoteManagementViewModel> source):base(source){

        }

    }

    public class PromissoryNoteManagementViewModel : BaseViewModel
    {
    }
}
