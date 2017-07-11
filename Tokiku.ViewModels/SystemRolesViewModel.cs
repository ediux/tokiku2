using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class SystemRolesViewModelCollection : BaseViewModelCollection<SystemRolesViewModel>
    {
        public SystemRolesViewModelCollection()
        {
            HasError = false;
        }

        public SystemRolesViewModelCollection(IEnumerable<SystemRolesViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            SystemRolesController ctrl = new SystemRolesController();
            ExecuteResultEntity<ICollection<SystemRolesEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                SystemRolesViewModel vm = new SystemRolesViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class SystemRolesViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is SystemRolesEntity)
                {
                    SystemRolesEntity data = (SystemRolesEntity)entity;
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
