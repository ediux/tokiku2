using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InventoryListViewModelCollection : BaseViewModelCollection<InventoryListViewModel>
    {
        public InventoryListViewModelCollection()
        {
            HasError = false;
        }

        public InventoryListViewModelCollection(IEnumerable<InventoryListViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    InventoryListController ctrl = new InventoryListController();
        //    ExecuteResultEntity<ICollection<InventoryListEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        InventoryListViewModel vm = new InventoryListViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class InventoryListViewModel : BaseViewModelWithPOCOClass<InventoryListEntity>
    {
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is InventoryListEntity)
        //        {
        //            InventoryListEntity data = (InventoryListEntity)entity;
        //            BindingFromModel(data, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //        throw;
        //    }
        //}

    }
}
