
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class StockViewModelCollection : BaseViewModelCollection<StockViewModel>
    {
        public StockViewModelCollection()
        {

        }

        public StockViewModelCollection(IEnumerable<StockViewModel> source) : base(source)
        {

        }

        public static StockViewModelCollection Query()
        {
            try
            {
                return Query<StockViewModelCollection, Stocks>(
                    "Stock", "QueryAll");
            }
            catch (Exception ex)
            {
                StockViewModelCollection emptycollection = new StockViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
