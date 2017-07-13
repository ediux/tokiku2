using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ReturnsController : BaseController
    {
        private ExecuteResultEntity<ICollection<Returns>> rtn;

        public ExecuteResultEntity<ICollection<Returns>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetReturnsRepository();
                return ExecuteResultEntity<ICollection<Returns>>.CreateResultEntity(
                    new Collection<Returns>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<Returns>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
