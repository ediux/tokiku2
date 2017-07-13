using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProjectManagerViewController : BaseController<Projects>
    {
        public ExecuteResultEntity<ICollection<Projects>> QueryById(Guid id)
        {
            return Query(p => p.Id == id);
        }
    }
}
