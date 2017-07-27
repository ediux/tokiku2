using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderViewModelCollection : BaseViewModelCollection<OrderViewModel>
    {
        public OrderViewModelCollection()
        {

        }

        public OrderViewModelCollection(IEnumerable<OrderViewModel> source) : base(source)
        {

        }

        public static OrderViewModelCollection Query(Guid ProjectId)
        {
            return Query<OrderViewModelCollection, Orders>("", "");
        }
    }
}
