
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    int lastindex = (e.NewStartingIndex + e.NewItems.Count)-1;
                    int seekpostion = e.NewStartingIndex;
                    foreach (var additem in e.NewItems)
                    {
                        ExecuteAction<Stocks>("Stock", "Add", ((StockViewModel)additem).Entity, lastindex == seekpostion);
                        seekpostion++;
                    }
                    break;
            }
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
