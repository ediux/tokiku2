using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class SystemController : BaseController
    {
        public static ExecuteResultEntity<ICollection<AccessLog>> QueryAccessLog(string DataId)
        {
            try
            {
                var Repo = RepositoryHelper.GetAccessLogRepository();
                var queryresult = Repo.Where(w => w.DataId == DataId).OrderByDescending(o => o.CreateTime);
                return ExecuteResultEntity<ICollection<AccessLog>>.CreateResultEntity(queryresult.ToList());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AccessLog>>.CreateErrorResultEntity(ex);
            }
        }
        public static ExecuteResultEntity StartUp()
        {
            try
            {
                TokikuEntities.StartUp();
                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }

        }
    }
}
