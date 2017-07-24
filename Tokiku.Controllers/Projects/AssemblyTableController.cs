using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AssemblyTableController : BaseController
    {
        public ExecuteResultEntity<ICollection<Orders>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetOrdersRepository();
                return ExecuteResultEntity<ICollection<Orders>>.CreateResultEntity(
                    new Collection<Orders>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<Orders>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
