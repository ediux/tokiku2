using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class RequiredDetailViewModelCollection : BaseViewModelCollection<RequiredDetailViewModel, RequiredDetails>
    {
        public RequiredDetailViewModelCollection()
        {

        }

        public RequiredDetailViewModelCollection(IEnumerable<RequiredDetailViewModel> source) : base(source)
        {

        }

        public static RequiredDetailViewModelCollection Query(Guid RequireId)
        {
            try
            {
                return Query<RequiredDetailViewModelCollection>(
                    "Required", "QueryAllDetail", RequireId);
            }
            catch (Exception ex)
            {
                RequiredDetailViewModelCollection collection = new RequiredDetailViewModelCollection();
                collection.setErrortoModel(ex);
                return collection;
            }
        }
    }
}
