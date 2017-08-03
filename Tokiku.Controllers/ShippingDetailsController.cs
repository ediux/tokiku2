using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingDetailsController : BaseController
    {
        public ExecuteResultEntity<ICollection<View_Shipping>> QueryAll()
        {
            try
            {
                var repo = this.GetRepository<IView_ShippingRepository, View_Shipping>();
                return ExecuteResultEntity<ICollection<View_Shipping>>.CreateResultEntity(
                    new Collection<View_Shipping>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_Shipping>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
