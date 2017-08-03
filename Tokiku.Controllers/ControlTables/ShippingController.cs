using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingController : BaseController<IPickListRepository, PickList>
    {
        public ExecuteResultEntity<ICollection<PickList>> QueryAll(Guid ProjectId)
        {
            try {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             from m in q.PickListDetails
                             where m.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<PickList>>.CreateResultEntity(
                    new Collection<PickList>(result.ToList()));

            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<PickList>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<PickList> QuerySingle(Guid Id,Guid ProjectId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             from m in q.PickListDetails
                             where m.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             && q.Id==Id
                             select q;

                return ExecuteResultEntity<PickList>.CreateResultEntity(
                    result.SingleOrDefault());

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<PickList>.CreateErrorResultEntity(ex);
            }
        }
    }
}
