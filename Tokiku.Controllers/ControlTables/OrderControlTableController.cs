using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class OrderControlTableController : BaseController
    {
        private ExecuteResultEntity<ICollection<Orders>> rtn;

        public ExecuteResultEntity<ICollection<Orders>> QuerAll()
        {
            try {
                var repo = this.GetReoisitory<Orders>();

                return ExecuteResultEntity<ICollection<Orders>>.CreateResultEntity(
                    new Collection<Orders>(repo.All().ToList()));
            }
            catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<Orders>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
