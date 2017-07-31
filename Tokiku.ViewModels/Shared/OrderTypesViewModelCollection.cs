using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderTypesViewModelCollection : BaseViewModelCollection<OrderTypesViewModel>
    {
        public OrderTypesViewModelCollection()
        {
            _ControllerName = "OrderTypes";
        }

        public OrderTypesViewModelCollection(IEnumerable<OrderTypesViewModel> source):base(source)
        {
            _ControllerName = "OrderTypes";
        }

        public static OrderTypesViewModelCollection Query()
        {
            try
            {
                var coll = Query<OrderTypesViewModelCollection, OrderTypes>("OrderTypes", "Query");           
                return coll;
            }
            catch (Exception ex)
            {
                OrderTypesViewModelCollection collection = new OrderTypesViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }
    }
}
