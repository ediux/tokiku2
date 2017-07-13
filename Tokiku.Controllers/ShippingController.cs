using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingController : BaseController
    {
        private ExecuteResultEntity<ICollection<PickList>> rtn;

        public ExecuteResultEntity<ICollection<PickList>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetPickListRepository();
                return ExecuteResultEntity<ICollection<PickList>>.CreateResultEntity(
                    new Collection<PickList>(repo.All().ToList()));
            }
            catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<PickList>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
