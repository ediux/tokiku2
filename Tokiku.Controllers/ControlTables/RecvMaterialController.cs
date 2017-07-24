using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RecvMaterialController : BaseController
    {
        private ExecuteResultEntity<ICollection<Receive>> rtn;

        public ExecuteResultEntity<ICollection<Receive>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetReceiveRepository();
                return ExecuteResultEntity<ICollection<Receive>>.CreateResultEntity(
                    new Collection<Receive>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<Receive>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
