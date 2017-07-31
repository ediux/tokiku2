using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ObtainMaterialController : BaseController
    {
        public ExecuteResultEntity<ICollection<PickListDetails>> QueryAll()
        {
            try {
                var repo = RepositoryHelper.GetPickListDetailsRepository();
                return ExecuteResultEntity<ICollection<PickListDetails>>.CreateResultEntity(
                    new Collection<PickListDetails>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<PickListDetails>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
