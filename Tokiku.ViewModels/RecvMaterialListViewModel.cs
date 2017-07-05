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
    public class RecvMaterialListViewModelCollection : BaseViewModelCollection<RecvMaterialListViewModel>
    {
        public RecvMaterialListViewModelCollection()
        {
            HasError = false;
        }

        public RecvMaterialListViewModelCollection(IEnumerable<RecvMaterialListViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            RecvMaterialListController ctrl = new RecvMaterialListController();
            ExecuteResultEntity<ICollection<RecvMaterialListEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                RecvMaterialListViewModel vm = new RecvMaterialListViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class RecvMaterialListViewModel : BaseViewModel
    {

    }
}
