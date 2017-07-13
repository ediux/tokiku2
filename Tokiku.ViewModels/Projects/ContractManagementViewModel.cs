using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ContractManagementViewModelCollection : BaseViewModelCollection<ContractManagementViewModel>
    {
        public ContractManagementViewModelCollection()
        {
            HasError = false;
        }

        public ContractManagementViewModelCollection(IEnumerable<ContractManagementViewModel> source) : base(source)
        {


        }

        //public override void Query()
        //{
        //    ContractManagementController ctrl = new ContractManagementController();
        //    ExecuteResultEntity<ICollection<ContractManagementEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        ContractManagementViewModel vm = new ContractManagementViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }

    public class ContractManagementViewModel : BaseViewModelWithPOCOClass<ProjectContract>
    {
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is ContractManagementEntity)
        //        {
        //            ContractManagementEntity data = (ContractManagementEntity)entity;
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
