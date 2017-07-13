using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RequiredController : BaseController
    {
        private ExecuteResultEntity<ICollection<Required>> rtn;

        public ExecuteResultEntity<ICollection<Required>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetRequiredRepository();
                return ExecuteResultEntity<ICollection<Required>>.CreateResultEntity(
                    new Collection<Required>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<Required>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
