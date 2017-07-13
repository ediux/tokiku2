using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class ReturnMaterialListViewModelCollection : BaseViewModelCollection<ReturnMaterialListViewModel>
    {
        public ReturnMaterialListViewModelCollection()
        {
            HasError = false;
        }

        public ReturnMaterialListViewModelCollection(IEnumerable<ReturnMaterialListViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    ReturnMaterialListController ctrl = new ReturnMaterialListController();
        //    ExecuteResultEntity<ICollection<ReturnMaterialListEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        ReturnMaterialListViewModel vm = new ReturnMaterialListViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class ReturnMaterialListViewModel : BaseViewModelWithPOCOClass<ReturnMaterialListEntity>
    {
        public ReturnMaterialListViewModel()
        {

        }

        public ReturnMaterialListViewModel(ReturnMaterialListEntity entity) : base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ReturnMaterialListEntity)
        //        {
        //            ReturnMaterialListEntity data = (ReturnMaterialListEntity)entity;
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
