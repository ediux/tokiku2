using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class OrderControlTableController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<OrderControlTableEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<OrderControlTableEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<OrderControlTableEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<OrderControlTableEntity>>.CreateResultEntity(
                        new Collection<OrderControlTableEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<OrderControlTableEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
