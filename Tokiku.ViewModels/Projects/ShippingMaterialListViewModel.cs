using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialListViewModelCollection : BaseViewModelCollection<ShippingMaterialListViewModel>
    {
        public ShippingMaterialListViewModelCollection()
        {
            HasError = false;
        }

        public ShippingMaterialListViewModelCollection(IEnumerable<ShippingMaterialListViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    ShippingMaterialListController ctrl = new ShippingMaterialListController();
        //    ExecuteResultEntity<ICollection<ShippingMaterialListEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        ShippingMaterialListViewModel vm = new ShippingMaterialListViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class ShippingMaterialListViewModel : BaseViewModelWithPOCOClass<ShippingMaterialListEntity>
    {
        public ShippingMaterialListViewModel()
        {

        }

        public ShippingMaterialListViewModel(ShippingMaterialListEntity entity) : base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ShippingMaterialListEntity)
        //        {
        //            ShippingMaterialListEntity data = (ShippingMaterialListEntity)entity;
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
