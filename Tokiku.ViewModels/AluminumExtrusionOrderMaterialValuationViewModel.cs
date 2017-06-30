using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AluminumExtrusionOrderMaterialValuationViewModelCollection :BaseViewModelCollection<AluminumExtrusionOrderMaterialValuationViewModel>
    {
        public AluminumExtrusionOrderMaterialValuationViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderMaterialValuationViewModelCollection(IEnumerable<AluminumExtrusionOrderMaterialValuationViewModel> source) : base(source)
        {
            
        }

        public override void Query()
        {
            AluminumExtrusionOrderMaterialValuationController ctrl = new AluminumExtrusionOrderMaterialValuationController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderMaterialValuationViewModel vm = new AluminumExtrusionOrderMaterialValuationViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }


    }

    public class AluminumExtrusionOrderMaterialValuationViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AluminumExtrusionOrderMaterialValuationEntity)
                {
                    AluminumExtrusionOrderMaterialValuationEntity data = (AluminumExtrusionOrderMaterialValuationEntity)entity;
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
