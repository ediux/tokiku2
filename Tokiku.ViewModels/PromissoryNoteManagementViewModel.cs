using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class PromissoryNoteManagementViewModelCollection : ObservableCollection<PromissoryNoteManagementViewModel>, IBaseViewModel
    {
        public PromissoryNoteManagementViewModelCollection()
        {
            HasError = false;
        }

        public PromissoryNoteManagementViewModelCollection(IEnumerable<PromissoryNoteManagementViewModel> source):base(source){

        }

        public IEnumerable<string> Errors { get; set; }
        public bool HasError { get; set; }
    }

    public class PromissoryNoteManagementViewModel : BaseViewModel
    {
    }
}
