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
    public class RecvMaterialListViewModelCollection : BaseViewModelCollection<RecvMaterialListViewModel, RecvMaterialListEntity>
    {
        public RecvMaterialListViewModelCollection()
        {
            HasError = false;
        }

        public RecvMaterialListViewModelCollection(IEnumerable<RecvMaterialListViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    RecvMaterialListController ctrl = new RecvMaterialListController();
        //    ExecuteResultEntity<ICollection<RecvMaterialListEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        RecvMaterialListViewModel vm = new RecvMaterialListViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class RecvMaterialListViewModel : BaseViewModelWithPOCOClass<RecvMaterialListEntity>
    {
        public RecvMaterialListViewModel()
        {

        }

        public RecvMaterialListViewModel(RecvMaterialListEntity entity) : base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is RecvMaterialListEntity)
        //        {
        //            RecvMaterialListEntity data = (RecvMaterialListEntity)entity;
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
