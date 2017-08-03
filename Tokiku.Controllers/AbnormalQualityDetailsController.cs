using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AbnormalQualityDetailsController : BaseController<IAbnormalQualityDetailsRepository, AbnormalQualityDetails>
    {
        public ExecuteResultEntity<ICollection<AbnormalQualityDetails>> QueryAllByProject(Guid ProjectId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.ReceiptDetails.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId                             
                             select q;

                return ExecuteResultEntity<ICollection<AbnormalQualityDetails>>.CreateResultEntity(new Collection<AbnormalQualityDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AbnormalQualityDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<AbnormalQualityDetails>> QueryAll(Guid MasterId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.AbnormalQualityId == MasterId
                             select q;

                return ExecuteResultEntity<ICollection<AbnormalQualityDetails>>.CreateResultEntity(new Collection<AbnormalQualityDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AbnormalQualityDetails>>.CreateErrorResultEntity(ex);
            }
        }       
    }
}
