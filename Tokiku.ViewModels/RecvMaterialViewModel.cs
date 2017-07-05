using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RecvMaterialViewModelCollection : BaseViewModelCollection<RecvMaterialViewModel>
    {
        public RecvMaterialViewModelCollection()
        {
            HasError = false;
        }

        public RecvMaterialViewModelCollection(IEnumerable<RecvMaterialViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            RecvMaterialController ctrl = new RecvMaterialController();
            ExecuteResultEntity<ICollection<RecvMaterialEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                RecvMaterialViewModel vm = new RecvMaterialViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class RecvMaterialViewModel : BaseViewModel
    {

    }
}
