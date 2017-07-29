using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProcessingViewModelCollection : BaseViewModelCollection<ProcessingViewModel,ProcessingAtlas>
    {
        public ProcessingViewModelCollection()
        {
            
        }

        public ProcessingViewModelCollection(IEnumerable<ProcessingViewModel> source) : base(source)
        {

        }

        //public static ProcessingViewModelCollection Query()
        //{
        //    ProcessingController ctrl = new ProcessingController();
        //    ExecuteResultEntity<ICollection<ProcessingAtlas>> ere = ctrl.QuerAll();

        //    if (!ere.HasError)
        //    {
        //        return new ProcessingViewModelCollection(ere.Result.Select(s => new ProcessingViewModel(s)).ToList());
        //    }

        //    return new ProcessingViewModelCollection();
        //}

    }

    public class ProcessingViewModel : BaseViewModelWithPOCOClass<ProcessingAtlas>
    {
        public ProcessingViewModel(ProcessingAtlas entity) : base(entity)
        {

        }

        // 圖集
        public int Atlas
        {
            get { return CopyofPOCOInstance.Atlas; }
            set { CopyofPOCOInstance.Atlas = value; RaisePropertyChanged("Atlas"); }
        }

    }
}
