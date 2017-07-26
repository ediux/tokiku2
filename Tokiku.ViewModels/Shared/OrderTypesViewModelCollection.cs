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

        }

        public OrderTypesViewModelCollection(IEnumerable<OrderTypesViewModel> source):base(source)
        {

        }

        public static OrderTypesViewModelCollection Query()
        {
            try
            {
                var coll = Query<OrderTypesViewModelCollection, OrderTypes>("Orders", "Query");           
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
