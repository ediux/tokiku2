using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class StockController : BaseController<Stocks>
    {
        public ExecuteResultEntity<ICollection<Stocks>> QueryAll()
        {
            try
            {
                var repo = this.GetRepository();

                var result = from q in repo.All()
                             select q;

                return ExecuteResultEntity<ICollection<Stocks>>.CreateResultEntity(
                    new Collection<Stocks>(result.ToList()));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<ICollection<Stocks>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<Stocks> QuerySingle(Guid Id)
        {
            try
            {
                var repo = this.GetRepository();

                var result = from q in repo.All()
                             where q.Id == Id
                             select q;

                return ExecuteResultEntity<Stocks>.CreateResultEntity(
                   result.SingleOrDefault());
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<Stocks>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
