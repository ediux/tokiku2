using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ReturnsDetailsViewModelCollection : BaseViewModelCollection<ReturnsDetailsViewModel>
    {
        public ReturnsDetailsViewModelCollection()
        {
            _ControllerName = "ReturnsDetails";
        }
        public ReturnsDetailsViewModelCollection(IEnumerable<ReturnsDetailsViewModel> source) : base(source)
        {
            _ControllerName = "ReturnsDetails";
        }

        public static ReturnsDetailsViewModelCollection Query(Guid MasterId)
        {
            try
            {
                ReturnsDetailsViewModelCollection collection = new ReturnsDetailsViewModelCollection();

                collection = Query<ReturnsDetailsViewModelCollection, ReturnDetails>(
                     collection.SaveModelController, "QueryAll", MasterId);

                return collection;
            }
            catch (Exception ex)
            {
                ReturnsDetailsViewModelCollection emptycollection =
                    new ReturnsDetailsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
