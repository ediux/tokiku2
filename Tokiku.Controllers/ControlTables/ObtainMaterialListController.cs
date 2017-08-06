using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ObtainMaterialListController : ControllerBase
    {
        public ExecuteResultEntity<ICollection<PickList>> QueryAll()
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
