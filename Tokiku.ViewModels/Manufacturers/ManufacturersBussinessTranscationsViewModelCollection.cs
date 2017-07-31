using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsViewModelCollection 
        : BaseViewModelCollection<ManufacturersBussinessTranscationsViewModel>
    {
        public ManufacturersBussinessTranscationsViewModelCollection()
        {
            _ControllerName = "ManufacturersManage";
        }

        public ManufacturersBussinessTranscationsViewModelCollection(IEnumerable<ManufacturersBussinessTranscationsViewModel> source):
            base(source)
        {
            _ControllerName = "ManufacturersManage";
        }

        public static ManufacturersBussinessTranscationsViewModelCollection Query(Guid ManufacturersId)
        {
            try
            {
                return Query<ManufacturersBussinessTranscationsViewModelCollection, ManufacturersBussinessItems>(
                    "ManufacturersManage", "QueryViewManufacturersBussinessTranscations", ManufacturersId);
            }
            catch (Exception ex)
            {
                ManufacturersBussinessTranscationsViewModelCollection emptycollection =
                    new ManufacturersBussinessTranscationsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
       
    }
}
