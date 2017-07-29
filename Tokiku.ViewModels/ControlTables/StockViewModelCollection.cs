
using System;
using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class StockViewModelCollection : BaseViewModelCollection<StockViewModel,Stocks>
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
                return Query<StockViewModelCollection>(
                    "Stock", "QueryAll");
            }
            catch (Exception ex)
            {
                StockViewModelCollection emptycollection = new StockViewModelCollection();
                emptycollection.setErrortoModel(ex);
                return emptycollection;
            }
        }
    }
}
