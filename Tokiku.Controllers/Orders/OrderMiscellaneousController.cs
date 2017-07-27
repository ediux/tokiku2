using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AluminumExtrusionOrderMiscellaneousController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<OrderMiscellaneous>> QuerAll(Guid ProjectId)
        {
            //sql = " select TokikuId, ManufacturersId, Description, UnitPrice, " +
            //             " Quantity, UnitPrice*Quantity as Total " +
            //        " from TABL3 a " +
            //   " left join TABL1 b on b.Id = a.TABL1ID ";

            ExecuteResultEntity<ICollection<OrderMiscellaneous>> rtn;

            try
            {
                var repo = this.GetReoisitory<OrderMiscellaneous>();
                var result = (from q in repo.All()
                              from x in q.Orders.OrderDetails
                              where x.RequiredDetails.Required.ProjectId == ProjectId
                              orderby x.RequiredDetails.Required.Projects.Code ascending
                              select q).Distinct();

                rtn = ExecuteResultEntity<ICollection<OrderMiscellaneous>>.CreateResultEntity(
                    new Collection<OrderMiscellaneous>(result.ToList()));

                return rtn;
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<OrderMiscellaneous>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
