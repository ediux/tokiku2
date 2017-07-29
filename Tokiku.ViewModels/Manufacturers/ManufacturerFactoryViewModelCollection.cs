using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class ManufacturerFactoryViewModelCollection : BaseViewModelCollection<ManufacturerFactoryViewModel, ManufacturersFactories>
    {
        public ManufacturerFactoryViewModelCollection()
        {

        }

        public ManufacturerFactoryViewModelCollection(IEnumerable<ManufacturerFactoryViewModel> source) : base(source)
        {

        }

        public static ManufacturerFactoryViewModelCollection Query(Guid ManufacturersId)
        {
            try
            {
                return Query<ManufacturerFactoryViewModelCollection>(
                    "ManufacturersManage", "QueryManufacturerFactoryByManufacturersId", ManufacturersId);
            }
            catch (Exception ex)
            {
                ManufacturerFactoryViewModelCollection emptycollection =
                    new ManufacturerFactoryViewModelCollection();
                emptycollection.setErrortoModel(ex);
                return emptycollection;
            }
        }
    }
}
