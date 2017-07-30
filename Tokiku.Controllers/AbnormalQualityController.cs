using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AbnormalQualityController : BaseController<AbnormalQuality>
    {
        public ExecuteResultEntity<ICollection<AbnormalQuality>> QueryAll(Guid ProjectId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             from s in q.AbnormalQualityDetails
                             where s.ReceiptDetails.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<AbnormalQuality>>.CreateResultEntity(new Collection<AbnormalQuality>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AbnormalQuality>>.CreateErrorResultEntity(ex);
            }
        }

        //public ExecuteResultEntity<AbnormalQuality> QuerySingle(Guid Id)
        //{
        //    try
        //    {
        //        var repo = this.GetRepository();
        //        var result = repo.Get(Id);

        //        return ExecuteResultEntity<AbnormalQuality>.CreateResultEntity(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExecuteResultEntity<AbnormalQuality>.CreateErrorResultEntity(ex);
        //    }
        //}
    }
}
