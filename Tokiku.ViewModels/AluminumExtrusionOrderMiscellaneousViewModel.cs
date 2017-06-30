using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AluminumExtrusionOrderMiscellaneousViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderMiscellaneousViewModel>
    {
        public AluminumExtrusionOrderMiscellaneousViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderMiscellaneousViewModelCollection(IEnumerable<AluminumExtrusionOrderMiscellaneousViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            AluminumExtrusionOrderMiscellaneousController ctrl = new AluminumExtrusionOrderMiscellaneousController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderMiscellaneousViewModel vm = new AluminumExtrusionOrderMiscellaneousViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }
    public class AluminumExtrusionOrderMiscellaneousViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AluminumExtrusionOrderMiscellaneousEntity)
                {
                    AluminumExtrusionOrderMiscellaneousEntity data = (AluminumExtrusionOrderMiscellaneousEntity)entity;
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
