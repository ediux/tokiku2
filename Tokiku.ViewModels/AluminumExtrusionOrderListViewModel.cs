using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    public class AluminumExtrusionOrderListViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderListViewModel>
    {
        public AluminumExtrusionOrderListViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderListViewModelCollection(IEnumerable<AluminumExtrusionOrderListViewModel> source) : base(source)
        {


        }

        public override void Query()
        {
            AluminumExtrusionOrderListController ctrl = new AluminumExtrusionOrderListController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderListEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderListViewModel vm = new AluminumExtrusionOrderListViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class AluminumExtrusionOrderListViewModel : BaseViewModel
    {

    }
}
