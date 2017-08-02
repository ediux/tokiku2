using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AccessLogController : BaseController<AccessLog>
    {
        public ExecuteResultEntity<AccessLog> QueryLastUpdateLog(string DataId)
        {
            try
            {
                var repo = this.GetRepository();
                var result = from q in repo.All()
                             where q.DataId == DataId
                             orderby q.CreateTime descending
                             select q;

                return ExecuteResultEntity<AccessLog>.CreateResultEntity(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<AccessLog>.CreateErrorResultEntity(ex);
            }
        }
    }
}
