using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProcessingController : BaseController
    {
        public ExecuteResultEntity<ICollection<ProcessingAtlas>> QueryAll()
        {
            try {
                var repo = RepositoryHelper.GetProcessingAtlasRepository();
                return ExecuteResultEntity<ICollection<ProcessingAtlas>>.CreateResultEntity(
                    new Collection<ProcessingAtlas>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<ProcessingAtlas>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
