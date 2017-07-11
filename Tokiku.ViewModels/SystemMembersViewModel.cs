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
    public class SystemMembersViewModelCollection : BaseViewModelCollection<SystemMembersViewModel>
    {
        public SystemMembersViewModelCollection()
        {
            HasError = false;
        }

        public SystemMembersViewModelCollection(IEnumerable<SystemMembersViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            SystemMembersController ctrl = new SystemMembersController();
            ExecuteResultEntity<ICollection<SystemMembersEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                SystemMembersViewModel vm = new SystemMembersViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class SystemMembersViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is SystemMembersEntity)
                {
                    SystemMembersEntity data = (SystemMembersEntity)entity;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }

    }
}
