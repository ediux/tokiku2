using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AluminumExtrusionOrderViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderViewModel>
    {
        public AluminumExtrusionOrderViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderViewModelCollection(IEnumerable<AluminumExtrusionOrderViewModel> source) : base(source)
        {


        }

        public override void Query()
        {
            AluminumExtrusionOrderController ctrl = new AluminumExtrusionOrderController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderViewModel vm = new AluminumExtrusionOrderViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }
    public class AluminumExtrusionOrderViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AluminumExtrusionOrderEntity)
                {
                    AluminumExtrusionOrderEntity data = (AluminumExtrusionOrderEntity)entity;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }

    }
}
