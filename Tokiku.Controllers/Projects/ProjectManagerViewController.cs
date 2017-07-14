using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProjectManagerViewController : BaseController<Projects>
    {
        public ExecuteResultEntity<Projects> QueryById(Guid id)
        {
            try
            {
                var executeresult = Query(p => p.Id == id);
                if (!executeresult.HasError)
                {
                    var entity = executeresult.Result.SingleOrDefault();
                    //database.Context.Entry<Projects>(entity).State = System.Data.Entity.EntityState.Detached;
                    return ExecuteResultEntity<Projects>.CreateResultEntity(entity);
                }
                return ExecuteResultEntity<Projects>.CreateResultEntity(new Projects());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Projects>.CreateErrorResultEntity(ex);
            }



        }
    }
}
