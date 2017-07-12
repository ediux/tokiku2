using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderControlTableViewModelCollection : BaseViewModelCollection<OrderControlTableViewModel>
    {
        public OrderControlTableViewModelCollection()
        {
            HasError = false;
        }

        public OrderControlTableViewModelCollection(IEnumerable<OrderControlTableViewModel> source) : base(source)
        {

        }

        public override void Query()
        {
            OrderControlTableController ctrl = new OrderControlTableController();
            ExecuteResultEntity<ICollection<OrderControlTableEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                OrderControlTableViewModel vm = new OrderControlTableViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }

    public class OrderControlTableViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is OrderControlTableEntity)
                {
                    OrderControlTableEntity data = (OrderControlTableEntity)entity;
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
