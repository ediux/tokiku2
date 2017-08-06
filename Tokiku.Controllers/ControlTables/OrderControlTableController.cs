using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class OrderControlTableController : ControllerBase
    {
        public ExecuteResultEntity<ICollection<View_OrderControlTable>> QueryAll()
        {
            try
            {
                var repo = this.GetRepository<IView_OrderControlTableRepository, View_OrderControlTable>();
                return ExecuteResultEntity<ICollection<View_OrderControlTable>>.CreateResultEntity(
                    new Collection<View_OrderControlTable>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_OrderControlTable>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
