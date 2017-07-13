using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InventoryViewModelCollection : BaseViewModelCollection<InventoryViewModel>
    {
        public InventoryViewModelCollection()
        {
            HasError = false;
        }

        public InventoryViewModelCollection(IEnumerable<InventoryViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    InventoryController ctrl = new InventoryController();
        //    ExecuteResultEntity<ICollection<InventoryEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        InventoryViewModel vm = new InventoryViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class InventoryViewModel : BaseViewModelWithPOCOClass<InventoryEntity>
    {
        public InventoryViewModel()
        {

        }
        public InventoryViewModel(InventoryEntity entity) : base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is InventoryEntity)
        //        {
        //            InventoryEntity data = (InventoryEntity)entity;
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
