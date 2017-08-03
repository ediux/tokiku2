using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingMaterialDetailsController : BaseController<IPickListDetailsRepository, PickListDetails>
    {
        public ExecuteResultEntity<PickListDetails> QuerySingle(Guid Id)
        {
            try
            {
                var repo = this.GetRepository();
                return ExecuteResultEntity<PickListDetails>.CreateResultEntity(
                    repo.Get(Id));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<PickListDetails>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<PickListDetails>> QueryAll(Guid ShippingMasterId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.PickListId == ShippingMasterId
                             select q;

                return ExecuteResultEntity<ICollection<PickListDetails>>.CreateResultEntity(
                    new Collection<PickListDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<PickListDetails>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
