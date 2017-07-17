using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ControlTableController : BaseController<ControlTableDetails>
    {
        private ExecuteResultEntity<ICollection<ControlTableDetails>> rtn;

        public ExecuteResultEntity<ICollection<ControlTableDetails>> Query(Guid ProjectId)
        {
            try
            {
                var repo = this.GetReoisitory().All();
                var result = from q in repo
                             where q.RequiredDetails.Required.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }
        public ExecuteResultEntity<ICollection<ControlTableDetails>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetControlTableDetailsRepository();
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

    }
}
