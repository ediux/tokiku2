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
        private ExecuteResultEntity<ICollection<ProcessingAtlas>> rtn;

        public ExecuteResultEntity<ICollection<ProcessingAtlas>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetProcessingAtlasRepository();
                return ExecuteResultEntity<ICollection<ProcessingAtlas>>.CreateResultEntity(
                    new Collection<ProcessingAtlas>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<ProcessingAtlas>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

    }
}
