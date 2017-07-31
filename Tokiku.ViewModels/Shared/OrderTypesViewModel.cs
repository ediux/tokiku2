using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderTypesViewModel : BaseViewModelWithPOCOClass<OrderTypes>
    {
        public OrderTypesViewModel()
        {
            _SaveModelController = "OrderTypes";
        }

        public OrderTypesViewModel(OrderTypes entity) : base(entity)
        {
            _SaveModelController = "OrderTypes";
        }

        public string Name { get => CopyofPOCOInstance.Name; set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); } }
       
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
