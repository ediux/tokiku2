using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsViewModelCollection : BaseViewModelCollection<ManufacturersBussinessTranscationsViewModel>
    {
   

        public void Query(Guid ManufacturersId)
        {
            try
            {
                ManufacturersManageController controller = new ManufacturersManageController();
                var executeresult = controller.QueryViewManufacturersBussinessTranscations(ManufacturersId);
                if (!executeresult.HasError)
                {
                    var objectdataset = executeresult.Result;
                    if (objectdataset.Any())
                    {
                        ClearItems();
                        foreach (var row in objectdataset)
                        {
                            ManufacturersBussinessTranscationsViewModel model = new ManufacturersBussinessTranscationsViewModel();
                           
                            Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

      
    }
}
