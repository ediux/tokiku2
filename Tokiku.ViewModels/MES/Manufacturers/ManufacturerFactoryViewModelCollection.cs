using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturerFactoryViewModelCollection : BaseViewModelCollection<ManufacturerFactoryViewModel>
    {
        public ManufacturerFactoryViewModelCollection()
        {

        }

        public ManufacturerFactoryViewModelCollection(IEnumerable<ManufacturerFactoryViewModel> source):base(source)
        {

        }

        public static ManufacturerFactoryViewModelCollection Query(Guid ManufacturersId)
        {
            try
            {
                return Query<ManufacturerFactoryViewModelCollection, ManufacturersFactories>(
                    "ManufacturersManage", "QueryManufacturerFactoryByManufacturersId", ManufacturersId);
            }
            catch (Exception ex)
            {
                ManufacturerFactoryViewModelCollection emptycollection =
                    new ManufacturerFactoryViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
