using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class OrderTypesViewModelCollection : BaseViewModelCollection<OrderTypesViewModel>
    {
        public OrderTypesViewModelCollection()
        {

        }

        public OrderTypesViewModelCollection(IEnumerable<OrderTypesViewModel> source):base(source)
        {

        }
    }
}
