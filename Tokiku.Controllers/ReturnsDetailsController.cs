using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ReturnsDetailsController:BaseController<ReturnDetails>
    {
        public ExecuteResultEntity<ICollection<ReturnDetails>> QueryAllByProject(Guid ProjectId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<ReturnDetails>>.CreateResultEntity(new Collection<ReturnDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ReturnDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ReturnDetails>> QueryAll(Guid MasterId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.ReturnId == MasterId
                             select q;

                return ExecuteResultEntity<ICollection<ReturnDetails>>.CreateResultEntity(new Collection<ReturnDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ReturnDetails>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
