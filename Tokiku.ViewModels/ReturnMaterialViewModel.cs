using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ReturnMaterialViewModelCollection : BaseViewModelCollection<ReturnMaterialViewModel>
    {
        public ReturnMaterialViewModelCollection()
        {
            HasError = false;
        }

        public ReturnMaterialViewModelCollection(IEnumerable<ReturnMaterialViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    ReturnMaterialController ctrl = new ReturnMaterialController();
        //    ExecuteResultEntity<ICollection<ReturnMaterialEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        ReturnMaterialViewModel vm = new ReturnMaterialViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class ReturnMaterialViewModel : BaseViewModelWithPOCOClass<ReturnMaterialEntity>
    {
        public ReturnMaterialViewModel()
        {

        }

        public ReturnMaterialViewModel(ReturnMaterialEntity entity) : base(entity)
        {

        }
    }
}
