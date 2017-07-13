using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredListViewModelCollection : BaseViewModelCollection<RequiredListViewModel>
    {
        public RequiredListViewModelCollection()
        {
            HasError = false;
        }

        public RequiredListViewModelCollection(IEnumerable<RequiredListViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    RequiredListController ctrl = new RequiredListController();
        //    ExecuteResultEntity<ICollection<RequiredListEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        RequiredListViewModel vm = new RequiredListViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            //vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class RequiredListViewModel : BaseViewModelWithPOCOClass<RequiredListEntity>
    {
        public RequiredListViewModel()
        {

        }

        public RequiredListViewModel(RequiredListEntity entity) : base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is RequiredListEntity)
        //        {
        //            RequiredListEntity data = (RequiredListEntity)entity;
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
