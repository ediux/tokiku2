using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class WorkItemListController : BaseController
    {
        public ExecuteResultEntity<ICollection<Engineering>> QueryAll()
        {
            try {
                var repo = RepositoryHelper.GetEngineeringRepository();
                return ExecuteResultEntity<ICollection<Engineering>>.CreateResultEntity(
                    new Collection<Engineering>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Engineering>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
