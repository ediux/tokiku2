using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ReturnsController : BaseController<IReturnsRepository, Returns>
    {
        public ExecuteResultEntity<ICollection<Returns>> QueryAll()
        {
            try {
                var repo = this.GetRepository();
                return ExecuteResultEntity<ICollection<Returns>>.CreateResultEntity(
                    new Collection<Returns>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Returns>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
