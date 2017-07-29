using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsViewModelCollection
        : BaseViewModelCollection<ManufacturersBussinessTranscationsViewModel, ManufacturersBussinessItems>
    {
        public ManufacturersBussinessTranscationsViewModelCollection()
        {

        }

        public ManufacturersBussinessTranscationsViewModelCollection(IEnumerable<ManufacturersBussinessTranscationsViewModel> source) :
            base(source)
        {

        }

        public static ManufacturersBussinessTranscationsViewModelCollection Query(Guid ManufacturersId)
        {
            try
            {
                return Query<ManufacturersBussinessTranscationsViewModelCollection>(
                    "ManufacturersManage", "QueryViewManufacturersBussinessTranscations", ManufacturersId);
            }
            catch (Exception ex)
            {
                ManufacturersBussinessTranscationsViewModelCollection emptycollection =
                    new ManufacturersBussinessTranscationsViewModelCollection();
                emptycollection.setErrortoModel(ex);
                return emptycollection;
            }
        }

    }
}
