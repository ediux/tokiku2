using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredViewModelCollection : BaseViewModelCollection<RequiredViewModel>
    {
        public RequiredViewModelCollection()
        {
            HasError = false;
        }

        public RequiredViewModelCollection(IEnumerable<RequiredViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            RequiredController ctrl = new RequiredController();
            ExecuteResultEntity<ICollection<RequiredEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                RequiredViewModel vm = new RequiredViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class RequiredViewModel : BaseViewModelWithPOCOClass<Required>
    {
       

    }
}
