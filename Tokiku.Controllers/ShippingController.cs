using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingMaterialController : BaseController
    {
        public ExecuteResultEntity<ICollection<PickList>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetPickListRepository();
                return ExecuteResultEntity<ICollection<PickList>>.CreateResultEntity(
                    new Collection<PickList>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<PickList>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
