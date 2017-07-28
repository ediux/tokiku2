using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShippingMaterialViewModelCollection : BaseViewModelCollection<ShippingMaterialViewModel>
    {
        public ShippingMaterialViewModelCollection()
        {
            HasError = false;
        }

        public ShippingMaterialViewModelCollection(IEnumerable<ShippingMaterialViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    ShippingMaterialController ctrl = new ShippingMaterialController();
        //    ExecuteResultEntity<ICollection<ShippingMaterialEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        ShippingMaterialViewModel vm = new ShippingMaterialViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class ShippingMaterialViewModel : BaseViewModelWithPOCOClass<ShippingMaterialEntity>
    {
        public ShippingMaterialViewModel()
        {

        }
        public ShippingMaterialViewModel(ShippingMaterialEntity entity):base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ShippingMaterialEntity)
        //        {
        //            ShippingMaterialEntity data = (ShippingMaterialEntity)entity;
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
